using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5
{
    public partial class roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoRol.Visible = true;
            pnlListaRoles.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                SqlRoles.InsertParameters["rol"].DefaultValue =txtRol.Value.ToUpper() ;

                SqlRoles.Insert();
                SqlRoles.DataBind();
                pnlListaRoles.Visible = true;
                pnlNuevoRol.Visible = false;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblmensaje.Text = "El codigo ya existe";
                pnlalert.Visible = true;
            }
        }
    }
}