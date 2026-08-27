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
    public partial class avance_edificaiones : System.Web.UI.Page
    {
        public String basedatos;
        public string rol = "5";
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
                CRRpt.Load(@"C:\Reportes_Sap\Avance Edificacion.rpt");

                string strConnection = string.Format(
                    "DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};",
                    "{B1CRHPROXY32}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName
                );

                // ✅ Todas las conexiones del reporte principal
                foreach (IConnectionInfo conn in CRRpt.DataSourceConnections)
                {
                    NameValuePairs2 props = conn.LogonProperties;
                    props.Set("Provider", "B1CRHPROXY32");
                    props.Set("Server Type", "B1CRHPROXY32");
                    props.Set("Connection String", strConnection);
                    conn.SetLogonProperties(props);
                    conn.SetConnection(SAP_Server, SAP_DBName, false);
                }

                // ✅ TableLogOnInfo también
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                logonInfo.ConnectionInfo.ServerName = SAP_Server;
                logonInfo.ConnectionInfo.DatabaseName = SAP_DBName;
                logonInfo.ConnectionInfo.UserID = SAP_DBUID;
                logonInfo.ConnectionInfo.Password = SAP_DBPass;
                logonInfo.ConnectionInfo.IntegratedSecurity = false;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in CRRpt.Database.Tables)
                    table.ApplyLogOnInfo(logonInfo);

                // ✅ Subreportes
                foreach (ReportDocument subreport in CRRpt.Subreports)
                {
                    foreach (IConnectionInfo conn in subreport.DataSourceConnections)
                    {
                        NameValuePairs2 props = conn.LogonProperties;
                        props.Set("Provider", "B1CRHPROXY32");
                        props.Set("Server Type", "B1CRHPROXY32");
                        props.Set("Connection String", strConnection);
                        conn.SetLogonProperties(props);
                        conn.SetConnection(SAP_Server, SAP_DBName, false);
                    }

                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreport.Database.Tables)
                        table.ApplyLogOnInfo(logonInfo);
                }

                CrystalReportViewer1.ReportSource = CRRpt;
            }
            catch (Exception ex)
            {
                Response.Write("<br><b>Error:</b> " + ex.Message);
                Response.Write("<br><pre>" + ex.ToString() + "</pre>");
            }
        }

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    basedatos = Request.QueryString["bd"];

        //    ReportDocument CRRpt = new ReportDocument();

        //    string SAP_Server = "192.168.0.5:30015";

        //    string SAP_DBUID = "SYSTEM";
        //    string SAP_DBPass = "V1nsoc4!";
        //    //string SAP_DBName = "DESARROLLADORAGGSA";
        //    string SAP_DBName = basedatos;

        //    CRRpt.Load("C:\\Reportes_Sap\\Avance Edificacion.rpt");

        //    string strConnection = string.Format("DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};", "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName);

        //    NameValuePairs2 logonProps2 = CRRpt.DataSourceConnections[0].LogonProperties;
        //    logonProps2.Set("Provider", "B1CRHPROXY");
        //    logonProps2.Set("Server Type", "B1CRHPROXY");
        //    logonProps2.Set("Connection String", strConnection);

        //    CRRpt.DataSourceConnections[0].SetLogonProperties(logonProps2);
        //    CRRpt.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);

        //    CrystalReportViewer1.ReportSource = CRRpt;

        //}
    }
}