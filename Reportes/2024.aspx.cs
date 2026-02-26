using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace proyecto5.Reportes
{
    public partial class _2024 :Page
    {

        public string userName;
        public String basedatos;
        public string rol;
       // public List<Empresas> registros = new List<Empresas>();
        public String fondocss;
        protected void Page_Load(object sender, EventArgs e)
        {
            //VARIABLES DE SESION
            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string rol = ticket.UserData;

            


            }
        }


        public String basedatoss;
        public string roll = "4";
        private List<ReportDocument> reportDocuments = new List<ReportDocument>();

        protected void Page_Init(object sender, EventArgs e)
        {
            basedatoss = Request.QueryString["bd"];
            basedatoss = "INVERSIONESGGSA";
            ReportDocument CRRpt = new ReportDocument();
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
            ReportDocument CRRpt52 = new ReportDocument();
            //---------------------------------------------------------------------------------//
            reportDocuments.Add(CRRpt);
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
            reportDocuments.Add(CRRpt52);

            //-------------------------------------------------------------------------------------------------------------------//
            string SAP_Server = "192.168.0.5:30015";
            string SAP_DBUID = "SYSTEM";
            string SAP_DBPass = "V1nsoc4!";
            //string SAP_DBName = "DESARROLLADORAGGSA";
            string SAP_DBName = basedatos;
            //--------------------------------------------------------------------------------------------------------------------//
            CRRpt1.Load("C:\\Reportes_Sap\\Dashboard\\2024\\1-Facturación Anual Año en Curso.rpt");
            CRRpt2.Load("C:\\Reportes_Sap\\Dashboard\\2024\\2-Facturación Mes en Curso.rpt");
            CRRpt3.Load("C:\\Reportes_Sap\\Dashboard\\2024\\3-Unidades Vendidas Año en Curso.rpt");
            CRRpt4.Load("C:\\Reportes_Sap\\Dashboard\\2024\\4-Unidades Vendidas Mes en Curso.rpt");
            CRRpt5.Load("C:\\Reportes_Sap\\Dashboard\\2024\\M2 facturados año.rpt");
            CRRpt6.Load("C:\\Reportes_Sap\\Dashboard\\2024\\M2 facturados mes.rpt");
            CRRpt7.Load("C:\\Reportes_Sap\\Dashboard\\2024\\19-% Crecimiento Año pasado vs Actual.rpt");
            CRRpt8.Load("C:\\Reportes_Sap\\Dashboard\\2024\\20-% Crecimiento Mes Actual vs Mes año pasado.rpt");
            CRRpt9.Load("C:\\Reportes_Sap\\Dashboard\\2024\\13- Disponible Grupo.rpt");
            CRRpt10.Load("C:\\Reportes_Sap\\Dashboard\\2024\\5-Cobranza Año en Curso.rpt");
            CRRpt11.Load("C:\\Reportes_Sap\\Dashboard\\2024\\6-Cobranza Mes en Curso.rpt");
            CRRpt12.Load("C:\\Reportes_Sap\\Dashboard\\2024\\21-% Crecimiento Año Actual vs Año pasado Cobranza.rpt");
            CRRpt13.Load("C:\\Reportes_Sap\\Dashboard\\2024\\22-% Crecimiento Mes Actual vs  Mes Año pasado.rpt");
            CRRpt14.Load("C:\\Reportes_Sap\\Dashboard\\2024\\14-Por Cobrar Grupo.rpt"); //por cobrar año
            CRRpt15.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Por Cobrar Grupo mes.rpt");//Por cobrar mes
            CRRpt16.Load("C:\\Reportes_Sap\\Dashboard\\2024\\15-Cartera Total.rpt");
            CRRpt17.Load("C:\\Reportes_Sap\\Dashboard\\2024\\16-Morosidad.rpt");
            CRRpt18.Load("C:\\Reportes_Sap\\Dashboard\\2024\\11-Inmuebles.rpt");
            CRRpt19.Load("C:\\Reportes_Sap\\Dashboard\\2024\\11- Construidos.rpt");
            CRRpt20.Load("C:\\Reportes_Sap\\Dashboard\\2024\\11- En construccion.rpt");
            CRRpt21.Load("C:\\Reportes_Sap\\Dashboard\\2024\\11- Por construir.rpt");
            CRRpt22.Load("C:\\Reportes_Sap\\Dashboard\\2024\\12-Pasivos del Grupo.rpt");
            CRRpt23.Load("C:\\Reportes_Sap\\Dashboard\\2024\\18- Pasivos Bancos.rpt");
            CRRpt24.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Pasivos Accionistas.rpt");//pasivos Accionistas
            //Amortizacion Año en curso
            //Amortizacion Mes en curso
            CRRpt25.Load("C:\\Reportes_Sap\\Dashboard\\2024\\17- Tasa Promedio Pasivos Financieros.rpt");

            CRRpt26.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Unidades en alquiler al dia.rpt");//unidades en alquiler al día
            CRRpt27.Load("C:\\Reportes_Sap\\Dashboard\\2024\\unidades alquiladas año.rpt");
            CRRpt28.Load("C:\\Reportes_Sap\\Dashboard\\2024\\unidades alquiladas mes.rpt");
            CRRpt29.Load("C:\\Reportes_Sap\\Dashboard\\2024\\9-Facturacion Alquileres Año en Curso.rpt");
            CRRpt30.Load("C:\\Reportes_Sap\\Dashboard\\2024\\10-Facturacion Alquileres Mes en Curso.rpt");
            CRRpt31.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Alquiler simple vs coc.rpt");//Alquiler simple / Con opcion a compra


            CRRpt32.Load("C:\\Reportes_Sap\\Dashboard\\2024\\25-Leads_del_anho.rpt");
            CRRpt33.Load("C:\\Reportes_Sap\\Dashboard\\2024\\26-Leads_mes_actual.rpt");
            CRRpt34.Load("C:\\Reportes_Sap\\Dashboard\\2024\\25-Leads_del_anho - Inbound.rpt");//Leads inbound año
            CRRpt35.Load("C:\\Reportes_Sap\\Dashboard\\2024\\26-Leads_mes_actual - inbound.rpt");//Leads inbound mes
            CRRpt36.Load("C:\\Reportes_Sap\\Dashboard\\2024\\25-Leads_del_anho - organicos.rpt");//Leads organicos año
            CRRpt37.Load("C:\\Reportes_Sap\\Dashboard\\2024\\26-Leads_mes_actual - organicos.rpt");//Leads Organicos mes
            CRRpt38.Load("C:\\Reportes_Sap\\Dashboard\\2024\\29-visitas_ganadas_del_anho.rpt");//Agendamientos inbound año
            CRRpt39.Load("C:\\Reportes_Sap\\Dashboard\\2024\\30-visitas_ganadas_del_mes.rpt");//Agendamientos inbound mes
            CRRpt40.Load("C:\\Reportes_Sap\\Dashboard\\2024\\31-efectivas_del_anho.rpt");//Visitas inbound año
            CRRpt41.Load("C:\\Reportes_Sap\\Dashboard\\2024\\32-efectivas_del_mes.rpt");//visitas inbound mes
            CRRpt42.Load("C:\\Reportes_Sap\\Dashboard\\2024\\31-efectivas_del_anho - organicas.rpt");//Visitas organicas año
            CRRpt43.Load("C:\\Reportes_Sap\\Dashboard\\2024\\32-efectivas_del_mes - organicos.rpt");//Visitas organicas mes
            CRRpt44.Load("C:\\Reportes_Sap\\Dashboard\\2024\\33-visitas_del_anho.rpt"); // Visitas totales año
            CRRpt45.Load("C:\\Reportes_Sap\\Dashboard\\2024\\34-visitas_del_mes.rpt"); //Visitas Totales mes
            CRRpt46.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Ventas Inbound del Año.rpt");//Ventas Inbound año
            CRRpt47.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Ventas Inbound del Mes.rpt");//Ventas Inbound mes
            CRRpt48.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Ventas Organicas del Año.rpt");//Ventas organicas año
            CRRpt49.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Ventas Organicas del Mes.rpt");//Ventas organicas mes
            CRRpt50.Load("C:\\Reportes_Sap\\Dashboard\\2024\\35-oportunidades_activas_del_anho.rpt");
            CRRpt51.Load("C:\\Reportes_Sap\\Dashboard\\2024\\36-oportunidades_activas_del_mes.rpt");
            CRRpt52.Load("C:\\Reportes_Sap\\Dashboard\\2024\\Oportunidades Facturacion.rpt");//Oportunidad de facturacion

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


            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
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

            //---------------------------------------------------------------------------------------------------------//
            NameValuePairs2 logonProps3 = CRRpt1.DataSourceConnections[0].LogonProperties;
            logonProps3.Set("Provider", "B1CRHPROXY");
            logonProps3.Set("Server Type", "B1CRHPROXY");
            logonProps3.Set("Connection String", strConnection);

            CRRpt4.DataSourceConnections[0].SetLogonProperties(logonProps3);
            CRRpt4.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer4.ReportSource = CRRpt4;

            CRRpt5.DataSourceConnections[0].SetLogonProperties(logonProps3);
            CRRpt5.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer5.ReportSource = CRRpt5;

            CRRpt6.DataSourceConnections[0].SetLogonProperties(logonProps3);
            CRRpt6.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer6.ReportSource = CRRpt6;

            //---------------------------------------------------------------------------------------------------------//
            NameValuePairs2 logonProps4 = CRRpt1.DataSourceConnections[0].LogonProperties;
            logonProps4.Set("Provider", "B1CRHPROXY");
            logonProps4.Set("Server Type", "B1CRHPROXY");
            logonProps4.Set("Connection String", strConnection);

            CRRpt7.DataSourceConnections[0].SetLogonProperties(logonProps4);
            CRRpt7.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer7.ReportSource = CRRpt7;

            CRRpt8.DataSourceConnections[0].SetLogonProperties(logonProps4);
            CRRpt8.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer8.ReportSource = CRRpt8;

            CRRpt9.DataSourceConnections[0].SetLogonProperties(logonProps4);
            CRRpt9.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer9.ReportSource = CRRpt9;

            //---------------------------------------------------------------------------------------------------------//
            NameValuePairs2 logonProps5 = CRRpt1.DataSourceConnections[0].LogonProperties;
            logonProps5.Set("Provider", "B1CRHPROXY");
            logonProps5.Set("Server Type", "B1CRHPROXY");
            logonProps5.Set("Connection String", strConnection);

            CRRpt10.DataSourceConnections[0].SetLogonProperties(logonProps5);
            CRRpt10.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer10.ReportSource = CRRpt10;

            CRRpt11.DataSourceConnections[0].SetLogonProperties(logonProps5);
            CRRpt11.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer11.ReportSource = CRRpt11;

            CRRpt12.DataSourceConnections[0].SetLogonProperties(logonProps5);
            CRRpt12.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer12.ReportSource = CRRpt12;

            //---------------------------------------------------------------------------------------------------------//
            NameValuePairs2 logonProps6 = CRRpt1.DataSourceConnections[0].LogonProperties;
            logonProps6.Set("Provider", "B1CRHPROXY");
            logonProps6.Set("Server Type", "B1CRHPROXY");
            logonProps6.Set("Connection String", strConnection);

            CRRpt13.DataSourceConnections[0].SetLogonProperties(logonProps6);
            CRRpt13.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer13.ReportSource = CRRpt13;

            CRRpt14.DataSourceConnections[0].SetLogonProperties(logonProps6);
            CRRpt14.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer14.ReportSource = CRRpt14;

            CRRpt15.DataSourceConnections[0].SetLogonProperties(logonProps6);
            CRRpt15.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer15.ReportSource = CRRpt15;

            //---------------------------------------------------------------------------------------------------------//
            NameValuePairs2 logonProps7 = CRRpt16.DataSourceConnections[0].LogonProperties;
            logonProps7.Set("Provider", "B1CRHPROXY");
            logonProps7.Set("Server Type", "B1CRHPROXY");
            logonProps7.Set("Connection String", strConnection);

            CRRpt16.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt16.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer16.ReportSource = CRRpt16;

            CRRpt17.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt17.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer17.ReportSource = CRRpt17;

            CRRpt18.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt18.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer18.ReportSource = CRRpt18;

            CRRpt19.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt19.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer19.ReportSource = CRRpt19;

            CRRpt20.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt20.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer20.ReportSource = CRRpt20;

            CRRpt21.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt21.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer21.ReportSource = CRRpt21;

            CRRpt22.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt22.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer22.ReportSource = CRRpt22;

            CRRpt23.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt23.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer23.ReportSource = CRRpt23;

            CRRpt24.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt24.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer24.ReportSource = CRRpt24;

            CRRpt25.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt25.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer25.ReportSource = CRRpt25;

            CRRpt26.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt26.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer26.ReportSource = CRRpt26;

            CRRpt27.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt27.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer27.ReportSource = CRRpt27;

            CRRpt28.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt28.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer28.ReportSource = CRRpt28;

            CRRpt29.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt29.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer29.ReportSource = CRRpt29;

            CRRpt30.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt30.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer30.ReportSource = CRRpt30;

            CRRpt31.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt31.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer31.ReportSource = CRRpt31;

            CRRpt32.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt32.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer32.ReportSource = CRRpt32;

            CRRpt33.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt33.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer33.ReportSource = CRRpt33;

            CRRpt34.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt34.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer34.ReportSource = CRRpt34;

            CRRpt35.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt35.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer35.ReportSource = CRRpt35;

            CRRpt36.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt36.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer36.ReportSource = CRRpt36;

            CRRpt37.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt37.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer37.ReportSource = CRRpt37;

            CRRpt38.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt38.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer38.ReportSource = CRRpt38;

            CRRpt39.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt39.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer39.ReportSource = CRRpt39;

            CRRpt40.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt40.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer40.ReportSource = CRRpt40;

            CRRpt41.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt41.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer41.ReportSource = CRRpt41;

            CRRpt42.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt42.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer42.ReportSource = CRRpt42;

            CRRpt43.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt43.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer43.ReportSource = CRRpt43;

            CRRpt44.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt44.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer44.ReportSource = CRRpt44;

            CRRpt45.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt45.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer45.ReportSource = CRRpt45;

            CRRpt46.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt46.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer46.ReportSource = CRRpt46;

            CRRpt47.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt47.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer47.ReportSource = CRRpt47;

            CRRpt48.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt48.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer48.ReportSource = CRRpt48;

            CRRpt49.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt49.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer49.ReportSource = CRRpt49;

            CRRpt50.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt50.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer50.ReportSource = CRRpt50;

            CRRpt51.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt51.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer51.ReportSource = CRRpt51;

            CRRpt52.DataSourceConnections[0].SetLogonProperties(logonProps7);
            CRRpt52.DataSourceConnections[0].SetConnection(SAP_Server, SAP_DBName, false);
            CrystalReportViewer52.ReportSource = CRRpt52;

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