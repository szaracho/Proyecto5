using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5.contenido
{
    public partial class registroempresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid) { 
            try
            {

                SqlEmpresas.InsertParameters["empresa"].DefaultValue = txtEmpresa.Value.ToUpper();
                SqlEmpresas.InsertParameters["basedatos"].DefaultValue = txtBaseDatos.Value.ToUpper();
                SqlEmpresas.InsertParameters["activo"].DefaultValue = chkactivo.Checked.ToString();
                SqlEmpresas.InsertParameters["orden"].DefaultValue = txtOrden.Value;
                SqlEmpresas.Insert();
                SqlEmpresas.DataBind();
                pnlListaEmpresas.Visible = true;
                pnlRegistroEm.Visible = false;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblmensaje.Text = "El codigo ya existe";
                pnlalert.Visible = true;
            }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlRegistroEm.Visible = true;
            pnlListaEmpresas.Visible = false;
        }
    }
}