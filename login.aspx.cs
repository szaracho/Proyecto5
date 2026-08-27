using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Configuration;
//using CrystalDecisions.CrystalReports.Engine;


namespace proyecto5
{
    public partial class login : System.Web.UI.Page
    {
        public List<Usuarios> usuarios = new List<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private List<Usuarios> ValidateUser(string codigo, string passWord)
        {
            SqlConnection conn;
            SqlCommand cmd;
            //usuarios = null;
            string lookupPassword = null;
            int elrol = 0;
           

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == codigo) || (0 == codigo.Length) || (codigo.Length > 15))
            {
                
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return usuarios;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return usuarios;
              
            }

            try
            {
                // Consult with your SQL Server administrator for an appropriate connection
                // string to use to connect to your local SQL Server.

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    string query = "SELECT codigo,nombre,rol_id, modificarpass FROM Users where codigo=@codigo and Pwd= HASHBYTES('MD5',@pass)";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.Parameters.AddWithValue("@pass", passWord);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios registro = new Usuarios();
                        registro.codigo = reader["codigo"].ToString();
                        registro.nombre = reader["nombre"].ToString();
                        registro.rol_id = Convert.ToInt32(reader["rol_id"]);
                        registro.modificarpass = Convert.ToBoolean(reader["modificarpass"]);
                        usuarios.Add(registro);
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                try
                {
                    string logPath = @"C:\Reportes_Sap\error_log.txt";
                    string msg = string.Format(
                        "[{0}] ERROR en ValidateUser Login\r\n" +
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
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
                return new List<Usuarios>();
            }       
            return usuarios;
        }

        public class Usuarios
        {
            public string codigo { get; set; }
            public string nombre { get; set; }
            public int rol_id { get; set; }
            public bool modificarpass { get; set; }
            // Agrega las propiedades adicionales que necesites
        }


        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //int roltraido = ValidateUser(txtUserName.Value, txtUserPass.Value);
            if (ValidateUser(txtUserName.Value, txtUserPass.Value).Count != 0)
            { 
                string datos = usuarios[0].rol_id.ToString()+','+usuarios[0].nombre.ToString();
                bool modificarpass = usuarios[0].modificarpass;
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
                DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, datos);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    if (modificarpass ==true)
                        strRedirect = "contenido/cambiarpassword.aspx";
                    else
                        strRedirect = "default.aspx";

                Response.Redirect(strRedirect, true);
            }
            else
                //Response.Redirect("login.aspx", true);

                pnlalert.Visible = true;
        }
    }
}