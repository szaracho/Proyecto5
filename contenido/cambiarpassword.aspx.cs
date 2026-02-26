using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5.contenido
{
    public partial class cambiarpassword : System.Web.UI.Page
    {
        public string rol;
        public string userName;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.User.Identity.IsAuthenticated)
            {
                userName = Context.User.Identity.Name;
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                rol = ticket.UserData;

            }
            txtCodigoR.Value = userName;
        }
        private bool ValidateIguales(string passWord, string confirmado)
        {

            return (0 == string.Compare(passWord, confirmado, false));
        }

        protected void btnModificacionReset_Click(object sender, EventArgs e)
        {
            if (ValidateIguales(txtPasswordReset.Value, txtConfirmarPasswordR.Value))
            {
                try
                {
                    
                    SqlResetPass.UpdateParameters["codigo"].DefaultValue = userName;
                    SqlResetPass.UpdateParameters["Pwd"].DefaultValue = txtPasswordReset.Value;
                    
                    SqlResetPass.Update();

                    FormsAuthentication.SignOut();
                    Response.Redirect(ResolveClientUrl("~/login.aspx"), true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                lblmensajeR.Text = "Ingrese valores validos";
                pnlAlertReset.Visible = true;
            }
        }
    }
}