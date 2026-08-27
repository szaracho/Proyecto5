using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace proyecto5
{
    public partial class inversiones : System.Web.UI.Page
    {
        public String bd;
        public String tituloempresa;
        public String clasecss;
        public string rol;
        public string nombreusu;


        protected void Page_Load(object sender, EventArgs e)
        {


            if (Context.User.Identity.IsAuthenticated)
            {
                string userName = Context.User.Identity.Name;
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string datos = ticket.UserData;
                string[] data = datos.Split(",".ToCharArray());
                //get the data stored in UserData property of forms authentication ticket
                rol = data[0];
                nombreusu = data[1];

            }
            //VARIABLES DEBASE DE DATOS
            bd = Request.QueryString["bd"];
            tituloempresa = Request.QueryString["empresa"];

        }
        public String basedatoss;
        public string roll = "4";
        private List<ReportDocument> reportDocuments = new List<ReportDocument>();
        protected void Page_Init(object sender, EventArgs e)
        {
            basedatoss = Request.QueryString["bd"];

            //------------------------------------------------------------------//
            ReportDocument CRRpt1 = new ReportDocument();
            ReportDocument CRRpt2 = new ReportDocument();
            ReportDocument CRRpt3 = new ReportDocument();
            ReportDocument CRRpt4 = new ReportDocument();
            ReportDocument CRRpt5 = new ReportDocument();
            ReportDocument CRRpt6 = new ReportDocument();
            ReportDocument CRRpt7 = new ReportDocument();
            ReportDocument CRRpt8 = new ReportDocument();
            ReportDocument CRRpt9 = new ReportDocument();
            ReportDocument CRRpt10 = new ReportDocument();
            ReportDocument CRRpt11 = new ReportDocument();
            ReportDocument CRRpt12 = new ReportDocument();
            ReportDocument CRRpt13 = new ReportDocument();
            ReportDocument CRRpt14 = new ReportDocument();
            ReportDocument CRRpt15 = new ReportDocument();
            ReportDocument CRRpt16 = new ReportDocument();
            ReportDocument CRRpt17 = new ReportDocument();
            ReportDocument CRRpt18 = new ReportDocument();
            ReportDocument CRRpt19 = new ReportDocument();
            ReportDocument CRRpt20 = new ReportDocument();
            ReportDocument CRRpt21 = new ReportDocument();
            ReportDocument CRRpt22 = new ReportDocument();
            ReportDocument CRRpt23 = new ReportDocument();
            ReportDocument CRRpt24 = new ReportDocument();
            ReportDocument CRRpt25 = new ReportDocument();
            ReportDocument CRRpt26 = new ReportDocument();
            ReportDocument CRRpt27 = new ReportDocument();
            ReportDocument CRRpt28 = new ReportDocument();
            ReportDocument CRRpt29 = new ReportDocument();
            ReportDocument CRRpt30 = new ReportDocument();
            ReportDocument CRRpt31 = new ReportDocument();
            ReportDocument CRRpt32 = new ReportDocument();
            ReportDocument CRRpt33 = new ReportDocument();
            ReportDocument CRRpt34 = new ReportDocument();
            ReportDocument CRRpt35 = new ReportDocument();
            ReportDocument CRRpt36 = new ReportDocument();
            ReportDocument CRRpt37 = new ReportDocument();
            ReportDocument CRRpt38 = new ReportDocument();
            ReportDocument CRRpt39 = new ReportDocument();
            ReportDocument CRRpt40 = new ReportDocument();
            ReportDocument CRRpt41 = new ReportDocument();
            ReportDocument CRRpt42 = new ReportDocument();
            ReportDocument CRRpt43 = new ReportDocument();
            ReportDocument CRRpt44 = new ReportDocument();
            ReportDocument CRRpt45 = new ReportDocument();
            ReportDocument CRRpt46 = new ReportDocument();
            ReportDocument CRRpt47 = new ReportDocument();
            ReportDocument CRRpt48 = new ReportDocument();
            ReportDocument CRRpt49 = new ReportDocument();
            ReportDocument CRRpt50 = new ReportDocument();
            ReportDocument CRRpt51 = new ReportDocument();


            //------------------------------------------------------------------//
            reportDocuments.Add(CRRpt1);
            reportDocuments.Add(CRRpt2);
            reportDocuments.Add(CRRpt3);
            reportDocuments.Add(CRRpt4);
            reportDocuments.Add(CRRpt5);
            reportDocuments.Add(CRRpt6);
            reportDocuments.Add(CRRpt7);
            reportDocuments.Add(CRRpt8);
            reportDocuments.Add(CRRpt9);
            reportDocuments.Add(CRRpt10);
            reportDocuments.Add(CRRpt11);
            reportDocuments.Add(CRRpt12);
            reportDocuments.Add(CRRpt13);
            reportDocuments.Add(CRRpt14);
            reportDocuments.Add(CRRpt15);
            reportDocuments.Add(CRRpt16);
            reportDocuments.Add(CRRpt17);
            reportDocuments.Add(CRRpt18);
            reportDocuments.Add(CRRpt19);
            reportDocuments.Add(CRRpt20);
            reportDocuments.Add(CRRpt21);
            reportDocuments.Add(CRRpt22);
            reportDocuments.Add(CRRpt23);
            reportDocuments.Add(CRRpt24);
            reportDocuments.Add(CRRpt25);
            reportDocuments.Add(CRRpt26);
            reportDocuments.Add(CRRpt27);
            reportDocuments.Add(CRRpt28);
            reportDocuments.Add(CRRpt29);
            reportDocuments.Add(CRRpt30);
            reportDocuments.Add(CRRpt31);
            reportDocuments.Add(CRRpt32);
            reportDocuments.Add(CRRpt33);
            reportDocuments.Add(CRRpt34);
            reportDocuments.Add(CRRpt35);
            reportDocuments.Add(CRRpt36);
            reportDocuments.Add(CRRpt37);
            reportDocuments.Add(CRRpt38);
            reportDocuments.Add(CRRpt39);
            reportDocuments.Add(CRRpt40);
            reportDocuments.Add(CRRpt41);
            reportDocuments.Add(CRRpt42);
            reportDocuments.Add(CRRpt43);
            reportDocuments.Add(CRRpt44);
            reportDocuments.Add(CRRpt45);
            reportDocuments.Add(CRRpt46);
            reportDocuments.Add(CRRpt47);
            reportDocuments.Add(CRRpt48);
            reportDocuments.Add(CRRpt49);
            reportDocuments.Add(CRRpt50);
            reportDocuments.Add(CRRpt51);

            //------------------------------------------------------------------//
            string SAP_Server = "192.168.0.5:30015";
            string SAP_DBUID = "SYSTEM";
            string SAP_DBPass = "V1nsoc4!";
            string SAP_DBName = basedatoss;

            //--------------------------------------------------------------------------------------------------------------------------------//
            CRRpt1.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\1-Facturación Anual Año en Curso.rpt");
            CRRpt2.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\2-Facturación Mes en Curso.rpt");
            CRRpt3.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\3-Unidades Vendidas Año en Curso.rpt");
            CRRpt4.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\4-Unidades Vendidas Mes en Curso.rpt");
            CRRpt5.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\M2 facturados año.rpt");
            CRRpt6.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\M2 facturados mes.rpt");
            CRRpt7.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\19-% Crecimiento Año pasado vs Actual.rpt");
            CRRpt8.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\20-% Crecimiento Mes Actual vs Mes año pasado.rpt");
            CRRpt9.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\13- Disponible Grupo.rpt");
            CRRpt10.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\5-Cobranza Año en Curso.rpt");
            CRRpt11.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\6-Cobranza Mes en Curso.rpt");
            CRRpt12.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\21-% Crecimiento Año Actual vs Año pasado Cobranza.rpt");
            CRRpt13.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\22-% Crecimiento Mes Actual vs  Mes Año pasado.rpt");
            CRRpt14.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\14-Por Cobrar Grupo.rpt"); //por cobrar año
            CRRpt15.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Por Cobrar Grupo mes.rpt");//Por cobrar mes
            CRRpt16.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\15-Cartera Total.rpt");
            CRRpt17.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\16-Morosidad.rpt");
            CRRpt18.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\11-Inmuebles.rpt");
            CRRpt19.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\11- Construidos.rpt");
            CRRpt20.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\11- En construccion.rpt");
            CRRpt21.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\11- Por construir.rpt");
            CRRpt22.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\12-Pasivos del Grupo.rpt");
            CRRpt23.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\18- Pasivos Bancos.rpt");
            CRRpt24.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Pasivos Accionistas.rpt");//pasivos Accionistas
            //Amortizacion Año en curso
            //Amortizacion Mes en curso

            //CRRpt23.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\17- Tasa Promedio Pasivos Financieros.rpt");

            CRRpt25.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Unidades en alquiler al dia.rpt");//unidades en alquiler al día
            CRRpt26.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\unidades alquiladas año.rpt");
            CRRpt27.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\unidades alquiladas mes.rpt");
            CRRpt28.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\9-Facturacion Alquileres Año en Curso.rpt");
            CRRpt29.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\10-Facturacion Alquileres Mes en Curso.rpt");
            CRRpt30.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Alquiler simple vs coc.rpt");//Alquiler simple / Con opcion a compra


            CRRpt31.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\25-Leads_del_anho.rpt");
            CRRpt32.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\26-Leads_mes_actual.rpt");
            CRRpt33.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\25-Leads_del_anho - Inbound.rpt");//Leads inbound año
            CRRpt34.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\26-Leads_mes_actual - inbound.rpt");//Leads inbound mes
            CRRpt35.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\25-Leads_del_anho - organicos.rpt");//Leads organicos año
            CRRpt36.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\26-Leads_mes_actual - organicos.rpt");//Leads Organicos mes
            CRRpt37.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\29-visitas_ganadas_del_anho.rpt");//Agendamientos inbound año
            CRRpt38.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\30-visitas_ganadas_del_mes.rpt");//Agendamientos inbound mes
            CRRpt39.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\31-efectivas_del_anho.rpt");//Visitas inbound año
            CRRpt40.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\32-efectivas_del_mes.rpt");//visitas inbound mes
            CRRpt41.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\31-efectivas_del_anho - organicas.rpt");//Visitas organicas año
            CRRpt42.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\32-efectivas_del_mes - organicos.rpt");//Visitas organicas mes
            CRRpt43.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\33-visitas_del_anho.rpt");// Visitas totales año
            CRRpt44.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\34-visitas_del_mes.rpt");//Visitas Totales mes
            CRRpt45.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Ventas Inbound del Año.rpt");//Ventas Inbound año
            CRRpt46.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Ventas Inbound del Mes.rpt");//Ventas Inbound mes
            CRRpt47.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Ventas Organicas del Año.rpt");//Ventas organicas año
            CRRpt48.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Ventas Organicas del Mes.rpt");//Ventas organicas mes
            CRRpt49.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\35-oportunidades_activas_del_anho.rpt");
            CRRpt50.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\36-oportunidades_activas_del_mes.rpt");
            CRRpt51.Load("C:\\Reportes_Sap\\Dashboard\\empresas\\Oportunidades Facturacion.rpt"); //Oportunidad de facturacion

            //Cant. Trabajadores oficina
            //Cant. Trabajadodes obreros
            //Presupuesto Nomina
            //Gastado vs Por gastar
            //Pasivo Laboral

            //Pedidos año en curso
            // % Pedidos Reales
            //Pedidos abiertos reales (Monto $)
            //Pedidos abiertos genéricos (Monto $)
            //Cambios presupuesto original
            //Variacion Presupuesto originales

            //Operaciones sin Conciliar
            //Operaciones Cheques en tránsito


            //--------------------------------------------------------------------------------------------------------------------------------//
            string strConnection = string.Format("DRIVER={0};UID={1};PWD={2};SERVERNODE={3};DATABASE={4};", "{B1CRHPROXY}", SAP_DBUID, SAP_DBPass, SAP_Server, SAP_DBName);

            NameValuePairs2 logonProps2 = CRRpt1.DataSourceConnections[0].LogonProperties;
            logonProps2.Set("Provider", "B1CRHPROXY");
            logonProps2.Set("Server Type", "B1CRHPROXY");
            logonProps2.Set("Connection String", strConnection);

            CRRpt1.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt1.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer1.ReportSource = CRRpt1;

            CRRpt2.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt2.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer2.ReportSource = CRRpt2;

            CRRpt3.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt3.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer3.ReportSource = CRRpt3;

            CRRpt4.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt4.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer4.ReportSource = CRRpt4;

            CRRpt5.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt5.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer5.ReportSource = CRRpt5;

            CRRpt6.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt6.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer6.ReportSource = CRRpt6;

            CRRpt7.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt7.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer7.ReportSource = CRRpt7;

            CRRpt8.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt8.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer8.ReportSource = CRRpt8;

            CRRpt9.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt9.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer9.ReportSource = CRRpt9;

            CRRpt10.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt10.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer10.ReportSource = CRRpt10;

            CRRpt11.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt11.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer11.ReportSource = CRRpt11;

            CRRpt12.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt12.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer12.ReportSource = CRRpt12;

            CRRpt13.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt13.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer13.ReportSource = CRRpt13;

            CRRpt14.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt14.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer14.ReportSource = CRRpt14;

            CRRpt15.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt15.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer15.ReportSource = CRRpt15;

            CRRpt16.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt16.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer16.ReportSource = CRRpt16;

            CRRpt17.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt17.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer17.ReportSource = CRRpt17;

            CRRpt18.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt18.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer18.ReportSource = CRRpt18;

            CRRpt19.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt19.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer19.ReportSource = CRRpt19;

            CRRpt20.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt20.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer20.ReportSource = CRRpt20;

            CRRpt21.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt21.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer21.ReportSource = CRRpt21;

            CRRpt22.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt22.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer22.ReportSource = CRRpt22;

            CRRpt23.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt23.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer23.ReportSource = CRRpt23;

            CRRpt24.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt24.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer24.ReportSource = CRRpt24;

            CRRpt25.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt25.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer25.ReportSource = CRRpt25;

            CRRpt26.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt26.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer26.ReportSource = CRRpt26;

            CRRpt27.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt27.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer27.ReportSource = CRRpt27;

            CRRpt28.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt28.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer28.ReportSource = CRRpt28;

            CRRpt29.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt29.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer29.ReportSource = CRRpt29;

            CRRpt30.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt30.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer30.ReportSource = CRRpt30;

            CRRpt31.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt31.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer31.ReportSource = CRRpt31;

            CRRpt32.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt32.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer32.ReportSource = CRRpt32;

            CRRpt33.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt33.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer33.ReportSource = CRRpt33;

            CRRpt34.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt34.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer34.ReportSource = CRRpt34;

            CRRpt35.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt35.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer35.ReportSource = CRRpt35;

            CRRpt36.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt36.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer36.ReportSource = CRRpt36;

            CRRpt37.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt37.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer37.ReportSource = CRRpt37;

            CRRpt38.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt38.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer38.ReportSource = CRRpt38;

            CRRpt39.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt39.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer39.ReportSource = CRRpt39;

            CRRpt40.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt40.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer40.ReportSource = CRRpt40;

            CRRpt41.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt41.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer41.ReportSource = CRRpt41;

            CRRpt42.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt42.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer42.ReportSource = CRRpt42;

            CRRpt43.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt43.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer43.ReportSource = CRRpt43;

            CRRpt44.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt44.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer44.ReportSource = CRRpt44;

            CRRpt45.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt45.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer45.ReportSource = CRRpt45;

            CRRpt46.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt46.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer46.ReportSource = CRRpt46;

            CRRpt47.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt47.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer47.ReportSource = CRRpt47;

            CRRpt48.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt48.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer48.ReportSource = CRRpt48;

            CRRpt49.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt49.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer49.ReportSource = CRRpt49;

            CRRpt50.DataSourceConnections[0].SetLogonProperties(logonProps2);
            CRRpt50.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer50.ReportSource = CRRpt50;


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

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx", true);
            GC.Collect();

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