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
    public partial class avance_urbanismo : System.Web.UI.Page
    {
        public String basedatos;
        public string rol = "5";
        protected void Page_Init(object sender, EventArgs e)
        {
            basedatos = Request.QueryString["bd"];

            ReportDocument CRRpt = new ReportDocument();

            string SAP_Server = "192.168.0.5:30015";

            string SAP_DBUID = "SYSTEM";
            string SAP_DBPass = "V1nsoc4!";
            //string SAP_DBName = "DESARROLLADORAGGSA";
            string SAP_DBName = basedatos;

            CRRpt.Load("C:\\Reportes_Sap\\Avance Fisico Urbanismo.rpt");

            string strConnection = string.Format("DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};", "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName);

            NameValuePairs2 logonProps2 = CRRpt.DataSourceConnections[0].LogonProperties;
            logonProps2.Set("Provider", "B1CRHPROXY");
            logonProps2.Set("Server Type", "B1CRHPROXY");
            logonProps2.Set("Connection String", strConnection);

            CRRpt.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);

            CrystalReportViewer1.ReportSource = CRRpt;

        }
    }
}