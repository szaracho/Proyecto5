using System;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace proyecto5
{
    public static class ReportCache
    {
        private const string SAP_Server = "192.168.0.5:30015";
        private const string SAP_DBUID = "SYSTEM";
        private const string SAP_DBPass = "V1nsoc4!";

        private static readonly System.Threading.SemaphoreSlim CrystalGate =
            new System.Threading.SemaphoreSlim(6);

        public static readonly string[] RptPaths = new[]
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
            @"C:\Reportes_Sap\Dashboard\Entregas Pendientes.rpt"
        };

        public static void PreloadAll(string baseDatos = "INVERSIONESGGSA")
        {
            string strConnection = string.Format(
            "DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};",
            "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, baseDatos);

            for (int i = 1; i < RptPaths.Length; i++)
            {
                if (string.IsNullOrEmpty(RptPaths[i])) continue;
                if (!System.IO.File.Exists(RptPaths[i])) continue;

                string key = $"CR_DOC_{i}";

                // Limpiar UNO y recargar UNO antes de pasar al siguiente
                // Así antes de borrar del caché, cierra y libera el reporte viejo de Crystal Reports correctamente. Crystal no acumula reportes y no explota. 
                if (HttpRuntime.Cache[key] != null)
                {
                    var oldDoc = HttpRuntime.Cache[key] as ReportDocument; 
                    if (oldDoc != null)
                    {
                        try { oldDoc.Close();} catch { }
                        try { oldDoc.Dispose();} catch { }
                    }
                    HttpRuntime.Cache.Remove(key);
                }

                CrystalGate.Wait();
                try
                {
                    var doc = new ReportDocument();
                    doc.Load(RptPaths[i]);
                    ApplyConnection(doc, strConnection, SAP_Server, baseDatos);

                    HttpRuntime.Cache.Insert(key, doc, null,
                        DateTime.Now.AddHours(8),
                        System.Web.Caching.Cache.NoSlidingExpiration);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error precargando {i}: {ex.Message}");
                }
                finally
                {
                    CrystalGate.Release();
                }
            }
           
        }


        public static ReportDocument GetOrLoad(int i, string baseDatos = "INVERSIONESGGSA")
        {
            string key = $"CR_DOC_{i}";
            var doc = HttpRuntime.Cache[key] as ReportDocument;

            if (doc == null)
            {
                string strConnection = string.Format(
                    "DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};",
                    "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, baseDatos);

                CrystalGate.Wait();
                try
                {
                    doc = new ReportDocument();
                    doc.Load(RptPaths[i]);
                    ApplyConnection(doc, strConnection, SAP_Server, baseDatos);

                    HttpRuntime.Cache.Insert(key, doc, null,
                        DateTime.Now.AddHours(8),
                        System.Web.Caching.Cache.NoSlidingExpiration);
                }
                finally
                {
                    CrystalGate.Release();
                }
            }

            return doc;
        }

        private static void ApplyConnection(ReportDocument doc, string strConnection,
            string server, string db)
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
    }
}