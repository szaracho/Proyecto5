using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5
{
    public partial class SiteMaster : MasterPage
    {
        public String bd;
        public string userName;
        public string rol;
        public string nombreusu;
        public string fondocss;

        // Clave para cachear la lista en Session
        private const string SESSION_EMPRESAS = "EmpresasLista";

        // Acceso cómodo a la lista cacheada
        private List<Empresas> EmpresasLista
        {
            get
            {
                var list = Session[SESSION_EMPRESAS] as List<Empresas>;
                if (list == null)
                {
                    list = GetEmpresasFromDb();
                    Session[SESSION_EMPRESAS] = list;
                }
                return list;
            }
            set { Session[SESSION_EMPRESAS] = value; }
        }

        public List<Empresas> EmpresasListaPublic
        {
            get { return EmpresasLista; } // EmpresasLista es la privada que se guarda en Session
        }


        protected void Page_Load(object sender, EventArgs e) //busca empresas, si no están en Session va a SQL
        {
            // Fondo según URL 
            var onReportes = Request.Url.AbsoluteUri.IndexOf("Reportes", StringComparison.OrdinalIgnoreCase) >= 0;
            fondocss = onReportes ? "sinfondo" : "fondo";

            // Autenticación y lectura de roles/nombre
            if (Context?.User?.Identity?.IsAuthenticated == true)
            {
                userName = Context.User.Identity.Name;

                var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                    {
                        var data = ticket.UserData.Split(',');
                        if (data.Length >= 2)
                        {
                            rol = data[0];
                            nombreusu = data[1];
                        }
                    }
                }

                // Solo si es la primera vez que entra a la app (no cada postback),
                // inicializa el cache si no existe.
                if (!IsPostBack && Session[SESSION_EMPRESAS] == null)
                {
                    EmpresasLista = GetEmpresasFromDb(); //Entra aca porque le sesion esta vacia
                }
            }
            else
            {
                // Usuario no autenticado: evita nulls
                rol = "";
                nombreusu = "";
            }
        }

        // MUY IMPORTANTE: siempre re-vincular en PreRender para que el menú superior no “desaparezca” en postbacks de páginas hijas.

        protected void Page_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (rptEmpresasSuperior != null)
                {
                    rptEmpresasSuperior.DataSource = EmpresasLista;
                    rptEmpresasSuperior.DataBind();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    string logPath = @"C:\Reportes_Sap\error_log.txt";
                    string msg = string.Format(
                        "[{0}] ERROR en Page_PreRender Site_Master\r\n" +
                        "Mensaje : {1}\r\n" +
                        "Tipo    : {2}\r\n" +
                        "Stack   :\r\n{3}\r\n" +
                        "Inner   : {4}\r\n" +
                        "{5}\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        ex.Message,
                        ex.GetType().FullName,
                        ex.StackTrace,
                        ex.InnerException?.Message ?? "ninguna",
                        new string('-', 80)
                    );
                    System.IO.File.AppendAllText(logPath, msg);
                }
                catch { }

                if (rptEmpresasSuperior != null)
                {
                    rptEmpresasSuperior.DataSource = new List<Empresas>();
                    rptEmpresasSuperior.DataBind();
                }
            }
        }

        private List<Empresas> GetEmpresasFromDb()
        {
            // Primero buscar en caché de aplicación
            var cached = HttpRuntime.Cache["EmpresasLista"] as List<Empresas>;
            if (cached != null) return cached;

            var result = new List<Empresas>();
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                using (var command = new SqlCommand("SELECT empresa, basedatos FROM empresas WHERE activo=1 ORDER BY orden", connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Empresas
                            {
                                empresa = reader["empresa"]?.ToString(),
                                bd = reader["basedatos"]?.ToString()
                            });
                        }
                    }
                }

                // Guardar en caché por 8 horas
                HttpRuntime.Cache.Insert("EmpresasLista", result, null,
                    DateTime.Now.AddHours(8),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            catch { }

            return result;
        }

        // === Opciones por BD  ===
        public List<Opcion> ObtenerOpcionesPorBD(string bd)
        {
            var opciones = new List<Opcion>();

            
            switch ((bd ?? "").ToUpperInvariant())
            {
                case "EDIFICACIONESGGSA":
                    opciones.Add(new Opcion { Nombre = "Altavida Luque", Url = ResolveClientUrl("~/opcion1.aspx") });
                    opciones.Add(new Opcion { Nombre = "Loma Pyta", Url = ResolveClientUrl("~/opcion2.aspx") });
                    break;

                case "CORPORACIONGGSA":
                    opciones.Add(new Opcion { Nombre = "Ycua Sati", Url = ResolveClientUrl("~/opcionA.aspx") });
                    opciones.Add(new Opcion { Nombre = "Altavida Luque", Url = ResolveClientUrl("~/opcionB.aspx") });
                    break;

                

                default:
                    // Si no hay opciones específicas, puedes dejar vacío o agregar “genéricas”
                    break;
            }

            return opciones;
        }

        // ==== Clicks de menú de usuario  ====
        protected void licerrar_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(ResolveClientUrl("~/login.aspx"), true);
        }

        protected void lklregistrarusuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveClientUrl("~/contenido/registrousuario.aspx"), true);
        }

        protected void lklCambiarPass_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveClientUrl("~/contenido/cambiarpassword.aspx"), true);
        }

        protected void lklRoles_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveClientUrl("~/contenido/roles.aspx"), true);
        }

        protected void lklEmpresas_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveClientUrl("~/contenido/registroempresa.aspx"), true);
        }

        // ====== Modelos simples para Session (serializables por si habilitas StateServer/SQL) ======
        [Serializable]
        public class Empresas
        {
            public string empresa { get; set; }
            public string bd { get; set; }
        }

        [Serializable]
        public class Opcion
        {
            public string Nombre { get; set; }
            public string Url { get; set; }
        }
    }
}
