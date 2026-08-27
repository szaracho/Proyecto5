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
    public partial class listado_de_precios_tipologia : System.Web.UI.Page
    {
        public String basedatos;
        public string rol = "4";

        protected void Page_Init(object sender, EventArgs e)
        {
            basedatos = Request.QueryString["bd"];

            ReportDocument CRRpt = new ReportDocument();

            string SAP_Server = "192.168.0.5:30015";

            string SAP_DBUID = "SYSTEM";
            string SAP_DBPass = "V1nsoc4!";
            string SAP_DBName = basedatos;

            CRRpt.Load("C:\\Reportes_Sap\\listado_de_precios_tipologia.rpt");

            string strConnection = string.Format("DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};", "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName);

            for (int i = 0; i < CRRpt.DataSourceConnections.Count; i++)
            {
                NameValuePairs2 lp = CRRpt.DataSourceConnections[i].LogonProperties;
                lp.Set("Provider", "B1CRHPROXY");
                lp.Set("Server Type", "B1CRHPROXY");
                lp.Set("Connection String", strConnection);
                CRRpt.DataSourceConnections[i].SetLogonProperties(lp);
                CRRpt.DataSourceConnections[i].SetConnection(SAP_Server, SAP_DBName, false);
            }

            foreach (ReportDocument sub in CRRpt.Subreports)
            {
                for (int i = 0; i < sub.DataSourceConnections.Count; i++)
                {
                    NameValuePairs2 lp = sub.DataSourceConnections[i].LogonProperties;
                    lp.Set("Provider", "B1CRHPROXY");
                    lp.Set("Server Type", "B1CRHPROXY");
                    lp.Set("Connection String", strConnection);
                    sub.DataSourceConnections[i].SetLogonProperties(lp);
                    sub.DataSourceConnections[i].SetConnection(SAP_Server, SAP_DBName, false);
                }
            }

            CrystalReportViewer1.ReportSource = CRRpt;
        }
    }
}
