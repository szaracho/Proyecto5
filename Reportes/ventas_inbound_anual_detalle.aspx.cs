using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace proyecto5.Reportes
{
    public partial class ventas_inbound_anual_detalle : System.Web.UI.Page
    {
        public String basedatos;
        public string rol = "4";
        private List<ReportDocument> reportDocuments = new List<ReportDocument>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            basedatos = Request.QueryString["bd"];
            basedatos = "INVERSIONESGGSA";
            ReportDocument CRRpt2 = new ReportDocument();
            reportDocuments.Add(CRRpt2);

            string SAP_Server = "192.168.0.5:30015";

            string SAP_DBUID = "SYSTEM";
            string SAP_DBPass = "V1nsoc4!";
            //string SAP_DBName = "DESARROLLADORAGGSA";
            string SAP_DBName = basedatos;

            CRRpt2.Load("C:\\Reportes_Sap\\Dashboard\\Detalles\\Ventas Inbound del año Detallado.rpt");

            string strConnection = string.Format("DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};", "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName);

            NameValuePairs2 logonProps2 = CRRpt2.DataSourceConnections[0].LogonProperties;
            logonProps2.Set("Provider", "B1CRHPROXY");
            logonProps2.Set("Server Type", "B1CRHPROXY");
            logonProps2.Set("Connection String", strConnection);

            CRRpt2.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt2.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer2.ReportSource = CRRpt2;

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //Cierra los reportes y libera los recursos
            foreach (var report in reportDocuments)
            {
                if (report != null)
                {
                    report.Close();
                    report.Dispose();
                }
            }
        }
    }
}