using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Web.UI.WebControls;
using proyecto5.Models;

namespace proyecto5
{
    public partial class _Default : Page
    {
        public string userName;
        public String basedatos;
        public string rol;
        public string nombreusu;
        public List<Empresas> registros = new List<Empresas>();
        public String fondocss;

        private bool DIAG = true; // activar diagnóstico en lblStatus
        private void AppendDiag(string msg)
        {
            var lbl = FindControlRecursive(GetReportsRoot(), "lblStatus") as Label;
            if (lbl != null)
            {
                lbl.Text += (lbl.Text?.Length > 0 ? " | " : "") + msg;
            }
        }

        private static void ReleaseViewer(CrystalDecisions.Web.CrystalReportViewer v)
        {
            if (v == null) return;

            try
            {
                if (v.ReportSource is ReportDocument oldDoc)
                {
                    try { oldDoc.Close(); } catch { }
                    try { oldDoc.Dispose(); } catch { }
                }
            }
            catch { }
            finally
            {
                v.ReportSource = null; // SIEMPRE quitar referencia
            }
        }

        // Concurrencia (máx 20 reportes procesándose a la vez) (evita saturar Crystal)
        private static readonly System.Threading.SemaphoreSlim CrystalGate = new System.Threading.SemaphoreSlim(6);

        // Lista de reportes que realmente abrimos (para Dispose)
        private readonly List<ReportDocument> _openedReports = new List<ReportDocument>();

        // Tamaño del lote
        private const int BatchSize = 9;

        // Config de HANA/Proxy 
        private const string SAP_Server = "192.168.0.5:30015";
        //private const string SAP_Server = "localhost:8084";
        private const string SAP_DBUID = "SYSTEM";
        private const string SAP_DBPass = "V1nsoc4!";

        // DB desde querystring, con fallback 
        public String basedatoss;
        public string roll = "4";
        private string SAP_DBName => string.IsNullOrEmpty(basedatoss) ? "INVERSIONESGGSA" : basedatoss;

       // private List<CrystalReportViewer> _viewers;

        // Devuelve el contenedor real donde están los rowN y los viewers (dentro del UpdatePanel)
        private Control GetReportsRoot()
        {
            // 1) Busca el UpdatePanel (upReportes) y usa su ContentTemplateContainer
            var up = FindControlRecursive(this, "upReportes") as UpdatePanel;
            if (up != null && up.ContentTemplateContainer != null)
                return up.ContentTemplateContainer;

            // 2) Fallback: usa el ContentPlaceHolder "Reportes" de la master
            var cph = Master?.FindControl("Reportes");
            if (cph != null) return cph;

            // 3) Último recurso: la página misma
            return this;
        }

        private static Control FindControlRecursive(Control root, string id)
        {
            if (root == null) return null;
            var c = root.FindControl(id);
            if (c != null) return c;
            foreach (Control child in root.Controls)
            {
                var r = FindControlRecursive(child, id);
                if (r != null) return r;
            }
            return null;
        }

        private CrystalDecisions.Web.CrystalReportViewer FindViewerByIndex(int i)
        {
            var root = GetReportsRoot();
            return FindControlRecursive(root, "CrystalReportViewer" + i) as CrystalDecisions.Web.CrystalReportViewer;
        }

        private void EnsureRowVisibleForViewer(int viewerIndex)
        {
            int rowIndex = ((viewerIndex - 1) / 3) + 1;
            var root = GetReportsRoot();
            var rowPanel = FindControlRecursive(root, "row" + rowIndex);
            if (rowPanel != null) rowPanel.Visible = true;
        }


        // Rutas de .rpt por índice (1..70).
        private static readonly string[] RptPaths = new[]
        {
            null,
            @"C:\Reportes_Sap\Dashboard\1-Facturación Anual Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\2-Facturación Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Facturacion Anual.rpt",
            @"C:\Reportes_Sap\Dashboard\3-Unidades Vendidas Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\4-Unidades Vendidas Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Unidades.rpt",
            @"C:\Reportes_Sap\Dashboard\M2 facturados año.rpt",
            @"C:\Reportes_Sap\Dashboard\M2 facturados mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual M2.rpt",
            @"C:\Reportes_Sap\Dashboard\19-% Crecimiento Año pasado vs Actual.rpt",
            @"C:\Reportes_Sap\Dashboard\20-% Crecimiento Mes Actual vs Mes año pasado.rpt",
            @"C:\Reportes_Sap\Dashboard\13- Disponible Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\5-Cobranza Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\6-Cobranza Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\21-% Crecimiento Año Actual vs Año pasado Cobranza.rpt",
            @"C:\Reportes_Sap\Dashboard\22-% Crecimiento Mes Actual vs  Mes Año pasado.rpt",
            @"C:\Reportes_Sap\Dashboard\14-Por Cobrar Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\Por Cobrar Grupo mes.rpt",
            @"C:\Reportes_Sap\Dashboard\15-Cartera Total.rpt",
            @"C:\Reportes_Sap\Dashboard\16-Morosidad.rpt",
            @"C:\Reportes_Sap\Dashboard\11-Inmuebles.rpt",
            @"C:\Reportes_Sap\Dashboard\11- Construidos.rpt",
            @"C:\Reportes_Sap\Dashboard\11- En construccion.rpt",
            @"C:\Reportes_Sap\Dashboard\11- Por construir.rpt",
            @"C:\Reportes_Sap\Dashboard\12-Pasivos del Grupo.rpt",
            @"C:\Reportes_Sap\Dashboard\18- Pasivos Bancos.rpt",
            @"C:\Reportes_Sap\Dashboard\Pasivos Accionistas.rpt",
            @"C:\Reportes_Sap\Dashboard\17- Tasa Promedio Pasivos Financieros.rpt",
            @"C:\Reportes_Sap\Dashboard\Cobertura.rpt",
            @"C:\Reportes_Sap\Dashboard\Unidades en alquiler al dia.rpt",
            @"C:\Reportes_Sap\Dashboard\unidades alquiladas año.rpt",
            @"C:\Reportes_Sap\Dashboard\unidades alquiladas mes.rpt",
            @"C:\Reportes_Sap\Dashboard\9-Facturacion Alquileres Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\10-Facturacion Alquileres Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Alquiler simple vs coc.rpt",
            @"C:\Reportes_Sap\Dashboard\Operaciones No Conciliadas.rpt",
            @"C:\Reportes_Sap\Dashboard\Monto No Conciliado.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores Administracion.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores Obreros.rpt",
            @"C:\Reportes_Sap\Dashboard\Informe Principal Colaboradores.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Leads.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho - Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual - inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\25-Leads_del_anho - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\26-Leads_mes_actual - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\33-visitas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\34-visitas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas.rpt",
            @"C:\Reportes_Sap\Dashboard\31-efectivas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\32-efectivas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\31-efectivas_del_anho - organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\32-efectivas_del_mes - organicos.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Visitas Efectivas Organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Inbound del Año.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Inbound del Mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Ventas Inbound.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Organicas del Año.rpt",
            @"C:\Reportes_Sap\Dashboard\Ventas Organicas del Mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Efectividad Anual Ventas Organicas.rpt",
            @"C:\Reportes_Sap\Dashboard\35-oportunidades_activas_del_anho.rpt",
            @"C:\Reportes_Sap\Dashboard\36-oportunidades_activas_del_mes.rpt",
            @"C:\Reportes_Sap\Dashboard\Oportunidades Facturacion.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Año en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Mes en Curso.rpt",
            @"C:\Reportes_Sap\Dashboard\Entregas Pendientes.rpt",
            @"C:\Reportes_Sap\Dashboard\Ingresos_Maquinarias.rpt",//total ingresos maquinarias
            @"C:\Reportes_Sap\Dashboard\Total Activos.rpt",//para saber los art construidos post venta 
            @"C:\Reportes_Sap\Dashboard\Marketing_Meta_kpi.rpt",//Metas marketing
            @"C:\Reportes_Sap\Dashboard\Proyectos_kpi.rpt",//Total de Ingresos y Egresos dpto de proyectos
            @"C:\Reportes_Sap\Dashboard\Maquinarias-Indice de cumplimiento.rpt",//Para saber los costos de las maquinarios y equipos
            @"C:\Reportes_Sap\Dashboard\INFORME EFECTIVIDAD COBRANZAS.rpt",//EFECTIVIDAD COBRANZAS 2025
            @"C:\Reportes_Sap\Dashboard\OBRAS KPI RENTABILDIAD_V3.rpt"//Total informe de efectividad de obras 
        };

        // Cuántos viewers ya mostramos (persistido entre postbacks)
        private int LoadedCount
        {
            get => (int?)ViewState["LoadedCount"] ?? 0;
            set => ViewState["LoadedCount"] = value;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack && pnlReportes.Visible)
            {
                int precargarHasta = 75;
                int maxIndex = ReportCache.RptPaths.Length - 1;  // ← cambio aquí
                int endIndex = Math.Min(maxIndex, precargarHasta);

                if (endIndex >= 1)
                {
                    BindRange(1, endIndex); //asigna los reportes a los users 
                    LoadedCount = endIndex;
                }
                else
                {
                    LoadedCount = 0;
                }

                lblGenerado.Text = "Generado: " + DateTime.Now.ToString("HH:mm:ss");
                btnLoadMore.Visible = false;
                lblStatus.Text = (LoadedCount >= maxIndex)
                    ? $"Se cargaron todos ({LoadedCount})."
                    : $"Mostrando {LoadedCount} reportes...";
            }
        }

        private void LoadEmpresas()
        {
            var list = HttpRuntime.Cache["EmpresasLista"] as List<SiteMaster.Empresas>;
            if (list != null)
            {
                registros = list.Select(emp => new Empresas { empresa = emp.empresa, bd = emp.bd }).ToList();
                return;
            }

            // Si no está en caché va a SQL
            var result = new List<Empresas>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT empresa, basedatos FROM empresas WHERE activo=1 ORDER BY orden", connection);
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Empresas
                        {
                            empresa = reader["empresa"].ToString(),
                            bd = reader["basedatos"].ToString()
                        });
                    }
                }
            }
            Session["Empresas"] = result;
            registros = result;

            //var list = Session["Empresas"] as List<Empresas>;
            //if (list == null)
            //{
            //    list = new List<Empresas>();
            //    using (var connection = new SqlConnection(
            //           ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //    {
            //        var cmd = new SqlCommand(
            //            "SELECT empresa, basedatos FROM empresas WHERE activo=1 ORDER BY orden", connection);
            //        connection.Open();
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                list.Add(new Empresas
            //                {
            //                    empresa = reader["empresa"].ToString(),
            //                    bd = reader["basedatos"].ToString()
            //                });
            //            }
            //        }
            //    }
            //    Session["Empresas"] = list; // guarda para siguientes postbacks
            //}

            //registros = list; // asigna SIEMPRE la referencia que usa el .aspx
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!User.Identity.IsAuthenticated) return;

                userName = Context.User.Identity.Name;
                var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var data = ticket.UserData.Split(',');
                rol = data[0];
                nombreusu = data[1];

                pnlReportes.Visible = (rol == "6" || rol == "1");
                pnlEmpresasLateral.Visible = (rol == "4" || rol == "6" || rol == "1");

                LoadEmpresas();

                if (pnlEmpresasLateral.Visible)
                {
                    var master = (SiteMaster)Master;
                    var empresas = master?.EmpresasListaPublic ?? new List<SiteMaster.Empresas>();
                    rptEmpresasLateral.DataSource = empresas;
                    rptEmpresasLateral.DataBind();
                }

                if (!IsPostBack)
                {
                    var cacheEmp = HttpRuntime.Cache["EmpresasLista"] as List<SiteMaster.Empresas>;
                    if (cacheEmp != null)
                        registros = cacheEmp
                            .Select(emp => new Empresas { empresa = emp.empresa, bd = emp.bd })
                            .ToList();

                    basedatoss = Request.QueryString["bd"];
                    if (string.IsNullOrEmpty(basedatoss)) basedatoss = "INVERSIONESGGSA";
                }
                else
                {
                    if (LoadedCount > 0)
                        BindRange(1, LoadedCount);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    string logPath = @"C:\Reportes_Sap\error_log.txt";
                    string msg = string.Format(
                        "[{0}] ERROR en Page_Load\r\n" +
                        "Usuario : {1}\r\n" +
                        "Mensaje : {2}\r\n" +
                        "Tipo    : {3}\r\n" +
                        "Stack   :\r\n{4}\r\n" +
                        "Inner   : {5}\r\n" +
                        "{6}\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        userName ?? "desconocido",
                        ex.Message,
                        ex.GetType().FullName,
                        ex.StackTrace,
                        ex.InnerException?.Message ?? "ninguna",
                        new string('-', 80)
                    );
                    System.IO.File.AppendAllText(logPath, msg);
                }
                catch { }

                lblStatus.Text = "Error al cargar. Revisa el log en el servidor.";
            }
        }


        private void BindRange(int startIndexInclusive, int endIndexInclusive)
        {
            for (int i = startIndexInclusive; i <= endIndexInclusive; i++)
            {
                if (i >= ReportCache.RptPaths.Length ||
                    string.IsNullOrEmpty(ReportCache.RptPaths[i])) continue;

                var viewer = FindViewerByIndex(i);
                if (viewer == null)
                {
                    if (DIAG) AppendDiag($"NoHallado:V{i}");
                    continue;
                }

                EnsureRowVisibleForViewer(i);

                if (!System.IO.File.Exists(ReportCache.RptPaths[i]))
                {
                    if (DIAG) AppendDiag($"NoExiste:R{i}");
                    viewer.Visible = false;
                    continue;
                }

                try
                {
                    var doc = ReportCache.GetOrLoad(i, SAP_DBName); //trae del cache del reporte instantaneamente 

                    viewer.EnableViewState = true;
                    viewer.ReuseParameterValuesOnRefresh = true;
                    viewer.ToolPanelView = ToolPanelViewType.None;
                    viewer.EnableDatabaseLogonPrompt = false;
                    viewer.EnableParameterPrompt = false;
                    viewer.ReportSource = doc; //Es donde crystal reports renderiza el reporte en pantalla y eso se repite 65 veces 
                    viewer.Visible = true;

                    if (DIAG) AppendDiag($"OK{i}");
                }
                catch (Exception ex)
                {
                    viewer.Visible = false;
                    if (DIAG) AppendDiag($"ERR{i}:{ex.GetType().Name}");
                    System.Diagnostics.Debug.WriteLine($"Error cargando viewer {i}: {ex}");
                }
            }
        }



        private void LoadBatch(int startIndex, int count)
        {
            BindRange(startIndex, startIndex + count - 1);
        }


        protected void btnLoadMore_Click(object sender, EventArgs e)
        {
            int loaded = LoadedCount;
            int newEnd = Math.Min(RptPaths.Length - 1, loaded + BatchSize);

            if (loaded > 0) BindRange(1, loaded);        // re-asigna ReportSource desde Session
            if (newEnd > loaded) BindRange(loaded + 1, newEnd);

            LoadedCount = newEnd;
            lblStatus.Text = (newEnd >= RptPaths.Length - 1)
                ? $"Se cargaron todos ({LoadedCount})."
                : $"Mostrando {LoadedCount} reportes...";

            if (newEnd >= RptPaths.Length - 1) btnLoadMore.Enabled = false;
        }


        private static void ApplyB1CrhProxyConnection(ReportDocument doc, string strConnection, string server, string db)
        {
            var dsc = doc.DataSourceConnections[0];
            var logon = dsc.LogonProperties;
            logon.Set("Provider", "B1CRHPROXY");
            logon.Set("Server Type", "B1CRHPROXY");
            logon.Set("Connection String", strConnection);
            dsc.SetLogonProperties(logon);
            dsc.SetConnection(server, db, false);

            foreach (ReportDocument sub in doc.Subreports)
            {
                var s = sub.DataSourceConnections[0];
                var slogon = s.LogonProperties;
                slogon.Set("Provider", "B1CRHPROXY");
                slogon.Set("Server Type", "B1CRHPROXY");
                slogon.Set("Connection String", strConnection);
                s.SetLogonProperties(slogon);
                s.SetConnection(server, db, false);
            }
        }







        private const string SES_EMPRESAS = "EmpresasLista";

        protected void Page_Init(object sender, EventArgs e)
        {
           
        }




        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                foreach (var viewer in GetAllViewers(this))
                {
                    try { viewer.ReportSource = null; } catch { }
                }
            }
            catch { }
        }

        private IEnumerable<CrystalReportViewer> GetAllViewers(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is CrystalReportViewer crv)
                    yield return crv;
                foreach (var child in GetAllViewers(c))
                    yield return child;
            }
        }
        //{
        //// 1) Desacopla viewers que hayan quedado con un doc
        //try
        //{
        //    for (int i = 1; i <= LoadedCount; i++)
        //    {
        //        var v = FindViewerByIndex(i);
        //        ReleaseViewer(v);
        //    }
        //}
        //catch { }

        //// 2) Cierra/dispone todos los docs abiertos en este request
        //foreach (var report in _openedReports)
        //{
        //    try { report.Close(); } catch { }
        //    try { report.Dispose(); } catch { }
        //}
        //_openedReports.Clear();

        //// 3) Fuerza recolección para soltar handles nativos (Crystal)
        //try
        //{
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //}
        //catch { }
        //}

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClearCrystalDocsFromSession(); // versión sin ReportDocument
            }
            catch { }

            FormsAuthentication.SignOut();
            try { Session.Clear(); Session.Abandon(); } catch { }

            Response.Redirect("login.aspx", true);
            //FormsAuthentication.SignOut();
            //Response.Redirect("login.aspx", true);
            //GC.Collect();
            //foreach (var report in _openedReports)
            //{
            //    try { report.Close(); } catch { }
            //    try { report.Dispose(); } catch { }
            //}


        }

        private void ClearCrystalDocsFromSession()
        {
            var keysToRemove = new List<string>();

            foreach (string key in Session.Keys)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("CR_DOC_"))
                    keysToRemove.Add(key);
            }

            foreach (var key in keysToRemove)
            {
                Session.Remove(key);
            }
        }

        public class Empresas
        {
            public string empresa { get; set; }
            public string bd { get; set; }
            // Agrega las propiedades adicionales que necesites
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= LoadedCount; i++)
                    ReleaseViewer(FindViewerByIndex(i));

                foreach (var report in _openedReports)
                {
                    try { report.Close(); } catch { }
                    try { report.Dispose(); } catch { }
                }
                _openedReports.Clear();
            }
            catch { }
        }



    }
    [Serializable]
    public class Empresas
    {
        public string empresa { get; set; }
        public string bd { get; set; }
    }

}