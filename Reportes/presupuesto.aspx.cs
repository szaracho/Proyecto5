using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto5.Reportes
{
    public partial class presupuesto : System.Web.UI.Page
    {
        public String basedatos;
        public string rol = "4";
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                basedatos = Request.QueryString["bd"];
                string SAP_Server = "192.168.0.5:30015";
                string SAP_DBUID = "SYSTEM";
                string SAP_DBPass = "V1nsoc4!";
                string SAP_DBName = basedatos;

                ReportDocument CRRpt = new ReportDocument();
                CRRpt.Load(@"C:\Reportes_Sap\Presupuesto.rpt");

                // DEBUG temporal
                Response.Write("<b>--- TABLAS PRINCIPALES ---</b><br>");
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in CRRpt.Database.Tables)
                    Response.Write("Tabla: " + table.Name + " | BD: " + table.LogOnInfo.ConnectionInfo.DatabaseName + "<br>");

                Response.Write("<b>--- SUBREPORTES ---</b><br>");
                foreach (ReportDocument sub in CRRpt.Subreports)
                {
                    Response.Write("Subreporte: " + sub.Name + "<br>");
                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in sub.Database.Tables)
                        Response.Write("&nbsp;&nbsp;Tabla: " + table.Name + " | BD: " + table.LogOnInfo.ConnectionInfo.DatabaseName + "<br>");
                }
                // FIN DEBUG

                TableLogOnInfo logonInfo = new TableLogOnInfo();
                logonInfo.ConnectionInfo.ServerName = SAP_Server;
                logonInfo.ConnectionInfo.DatabaseName = SAP_DBName;
                logonInfo.ConnectionInfo.UserID = SAP_DBUID;
                logonInfo.ConnectionInfo.Password = SAP_DBPass;
                logonInfo.ConnectionInfo.IntegratedSecurity = false;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in CRRpt.Database.Tables)
                    table.ApplyLogOnInfo(logonInfo);

                foreach (ReportDocument subreport in CRRpt.Subreports)
                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreport.Database.Tables)
                        table.ApplyLogOnInfo(logonInfo);

                CrystalReportViewer1.ReportSource = CRRpt;
            }
            catch (Exception ex)
            {
                Response.Write("<br><b>Error:</b> " + ex.Message);
                Response.Write("<br><pre>" + ex.ToString() + "</pre>");
            }
        }
    }
}