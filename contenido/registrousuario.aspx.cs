using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5.contenido
{
    public partial class registrousuario : System.Web.UI.Page
    {
        public string rol;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                string userName = Context.User.Identity.Name;
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                rol = ticket.UserData;

            }
        }
        private bool ValidateUser(string codigo, string passWord, string confirmado, string nombre)
        {
           
            if ((null == codigo) || (0 == codigo.Length) || (codigo.Length > 15))
            {

                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            if ((null == nombre) || (0 == nombre.Length) )
            {

                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;

            }
            if ((null == confirmado) || (0 == confirmado.Length) || (confirmado.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;

            }else
            { return true; }

        }
        private bool ValidateIguales( string passWord, string confirmado)
        {
            
            return (0 == string.Compare(passWord, confirmado, false));
        }

       

        protected void btnregistrar_Click1(object sender, EventArgs e)
        {
            if (ValidateUser(txtUserName.Value, txtUserPass.Value, txtConfirmarPass.Value, txtNombre.Value))
            {
                if (ValidateIguales(txtUserPass.Value, txtConfirmarPass.Value))
                {
                   /* try
                    {*/
                        pnlalert.Visible = false;
                        SqlGuardarUsuarios.InsertParameters["codigo"].DefaultValue = txtUserName.Value;
                        SqlGuardarUsuarios.InsertParameters["Nombre"].DefaultValue = txtNombre.Value;
                        SqlGuardarUsuarios.InsertParameters["Pwd"].DefaultValue = txtUserPass.Value;
                        SqlGuardarUsuarios.InsertParameters["rol_id"].DefaultValue = drpRol.SelectedValue;
                        SqlGuardarUsuarios.InsertParameters["modificarpass"].DefaultValue = chkModificarpass.Checked.ToString();
                        SqlGuardarUsuarios.Insert();
                        SqlGuardarUsuarios.DataBind();
                        pnlListaUsuario.Visible = true;
                        pnlRegistro.Visible = false;
                       
                        

                    //}
                    /*catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        lblmensaje.Text = "El codigo ya existe";
                        pnlalert.Visible = true;
                    }*/
                }
                else
                {
                    lblmensaje.Text = "Las contraseñas no coinciden";
                    pnlalert.Visible = true;
                }
            }
            else
            {
                lblmensaje.Text = "Ingrese un Nombre de Usuario y Clave Validos";
                pnlalert.Visible = true;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = true;
            pnlListaUsuario.Visible = false;
        }

        protected void grdListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoM.Value = grdListaUsuarios.SelectedRow.Cells[1].Text;
            txtNombreM.Value = grdListaUsuarios.SelectedRow.Cells[2].Text;
            chkModificarpass.Text = grdListaUsuarios.SelectedRow.Cells[4].Text;
            int rol_id = Convert.ToInt32(grdListaUsuarios.SelectedDataKey.Values["rol_id"]);
            drpListarRolM.SelectedValue = rol_id.ToString();
            pnlListaUsuario.Visible = false;
            pnlModificar.Visible = true;

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            txtCodigoR.Value = grdListaUsuarios.SelectedRow.Cells[1].Text;
            pnlResetPass.Visible = true;
            pnlModificar.Visible = false;
        }

        protected void btnModficar_Click(object sender, EventArgs e)
        {
            if ((null == txtNombreM.Value) || (0 == txtNombreM.Value.Length))
            {
                lblmensajeM.Text = "Ingrese valores validos";
                pnlalertM.Visible = true;
            }
            else
            {
                try
                {
                    pnlalert.Visible = false;
                    SqlUpdate.UpdateParameters["codigo"].DefaultValue = txtCodigoM.Value;
                    SqlUpdate.UpdateParameters["Nombre"].DefaultValue = txtNombreM.Value;
                    SqlUpdate.UpdateParameters["rol_id"].DefaultValue = drpListarRolM.SelectedValue;
                    SqlUpdate.UpdateParameters["modificarpass"].DefaultValue = chkmodificarpassM.Checked.ToString();
                    SqlUpdate.Update();
                    SqlGuardarUsuarios.DataBind();
                    grdListaUsuarios.DataBind();
                    pnlListaUsuario.Visible = true;
                    pnlRegistro.Visible = false;
                    pnlModificar.Visible = false;



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }

        }

        protected void btnModificacionReset_Click(object sender, EventArgs e)
        {
            if (ValidateIguales(txtPasswordReset.Value, txtConfirmarPasswordR.Value))
            {
                try
                {
                    pnlalert.Visible = false;
                    SqlResetPass.UpdateParameters["codigo"].DefaultValue = txtCodigoR.Value;
                    SqlResetPass.UpdateParameters["Pwd"].DefaultValue = txtPasswordReset.Value;
                    SqlResetPass.Update();
                    SqlGuardarUsuarios.DataBind();
                    grdListaUsuarios.DataBind();
                    pnlListaUsuario.Visible = true;
                    pnlRegistro.Visible = false;
                    pnlModificar.Visible = false;
                    pnlResetPass.Visible = false;


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