<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proyecto5._Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   <div class="page-header">
       <div class="menuinicio">
           <% if (rol == "4" || rol=="6" || rol=="1" ){  %>
              <a class="linkempresa" style="margin-top: 30px" href="<%=ResolveClientUrl("~/Reportes/informe_directorio.aspx") %>">
                <div class="botonempresa">
                    <h2 class="tituloempresa"> ALTAMIRA GROUP S.A.</h2>
                </div>
              </a>
               <a class="linkempresa" style="margin-top: 30px" href="<%=ResolveClientUrl("~/Reportes/2024.aspx") %>">
                <div class="botonempresa">
                    <h2 class="tituloempresa"> 2024</h2>
                </div>
              </a> 
           <% } %>

           <% if (rol == "14"  ){  %>
                <a class="linkempresa" href="Default.aspx">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> INICIO</h2>
                    </div>
               </a>
                <a class="linkempresa" href="<%=ResolveClientUrl("~/contenido/empresas.aspx?bd=URBANAGGSA&empresa=URBANA GG S.A.") %>">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> URBANA GG S.A.</h2>
                    </div>
               </a> 
           <% } %>

           <% if (rol == "15"  ){  %>
                <a class="linkempresa" href="Default.aspx">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> INICIO</h2>
                    </div>
               </a>
                <a class="linkempresa" href="<%=ResolveClientUrl("~/contenido/empresas.aspx?bd=ALTAZENTA_NORTE_SA&empresa=ALTAZENTA NORTE S.A.") %>">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> ALTAZENTA NORTE S.A.</h2>
                    </div>
               </a> 
           <% } %>

           <% if (rol == "16"  ){  %>
                <a class="linkempresa" href="Default.aspx">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> INICIO</h2>
                    </div>
               </a>
                <a class="linkempresa" href="<%=ResolveClientUrl("~/contenido/empresas.aspx?bd=ALTACREOSA&empresa=ALTACREO S.A.") %>">
                    <div class="botonempresa">
                        <h2 class="tituloempresa"> ALTACREO S.A.</h2>
                    </div>
               </a> 
           <% } %>

<% if (rol == "4" || rol=="6" || rol=="1" ){  %>
       <asp:Panel ID="pnlEmpresasLateral" runat="server" Visible="false">
    <asp:Repeater ID="rptEmpresasLateral" runat="server">
        <ItemTemplate>
            <a class="linkempresa"
               href='<%# ResolveClientUrl("~/contenido/empresas.aspx?bd=" + Eval("bd") + "&empresa=" + Eval("empresa")) %>'>
                <div class="botonempresa">
                    <h3 class="tituloempresa"><%# Eval("empresa") %></h3>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>
<% } %>
        </div>
       
   </div>
</asp:Content>


<asp:Content ID="Content" ContentPlaceHolderID="Reportes" runat="server" >
    <link rel="stylesheet" href="Content\css\Styles.css" />
    <asp:UpdatePanel runat="server" ID="upReportes" UpdateMode="Conditional" ChildrenAsTriggers="false">
    <ContentTemplate>

    <asp:Panel ID="pnlReportes" runat="server" Visible="false">

    <div class="main-content">
        


    <div class="title-container">
        <h2>FACTURACION Y COBRANZAS</h2>
    </div>

        <asp:Panel runat="server" ID="row1"> 
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/facturacion_anual_historico.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/facturacion_mensual_historico.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/efectividad_mensual_historico.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
           
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row2"> 
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_anual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_mensual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer6" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/efectividad_mensual_historico_unidades.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row3"> 
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer7" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_anual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer8" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_mensual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer9" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/efectividad_mensual_historico_m2.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
        </asp:Panel>


        <asp:Panel runat="server" ID="row4" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer10" runat="server" Visible="True" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/facturacion_entre_anhos.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer11" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    
                </div>
                <div class="div3">
                     <CR:CrystalReportViewer ID="CrystalReportViewer15" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Recobranza_entre_anhosportes/cobranza_entre_anhos.aspx") %>">Ver Detalle</a>
                    </div>
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer16" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
<%--                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/detalle_disponibilidad.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
<%--                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer12" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/detalle_disponibilidad.aspx") %>">Ver Detalle</a>
                    </div>
                </div>--%>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row5" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer13" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/cobranza_anual_historico.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer14" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/cobranza_mensual_historico.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                      
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer15" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/cobranza_entre_anhos.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row6" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer17" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/por_cobrar_anho_detalle.aspx") %>">Ver Detalle</a>
                    </div>
<%--                      <CR:CrystalReportViewer ID="CrystalReportViewer13" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/cobranza_anual_historico.aspx") %>">Ver Detalle</a>
                    </div>--%>
<%--                  <CR:CrystalReportViewer ID="CrystalReportViewer15" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Recobranza_entre_anhosportes/cobranza_entre_anhos.aspx") %>">Ver Detalle</a>
                    </div>--%>

                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer16" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer18" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/por_cobrar_mes_detalle.aspx") %>">Ver Detalle</a>
                    </div>

                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer16" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
<%--                     <CR:CrystalReportViewer ID="CrystalReportViewer17" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/por_cobrar_anho_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                    
                </div>

            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="rowMorosidadActual2" Visible="true">
        <div class="container">
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer20" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/morosidad_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
            </div>
            <div class="div2">
                <!-- vacío o agrega otro viewer -->
            </div>
            <div class="div3">
                <!-- vacío o agrega otro viewer -->
            </div>
        </div>
    </asp:Panel>



      
        <div class="title-container">
            <h2>ACTIVOS - PASIVOS</h2>
        </div>

        <asp:Panel runat="server" ID="row7" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer19" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/cartera_total_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer20" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/morosidad_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer21" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/activos_inmuebles_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                
                </div>
            </div>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="row8" Visible="false">
           <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer22" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/activos_construidos_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer23" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/activos_en_construccion_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer24" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/activos_por_construir_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
        </asp:Panel>


        <asp:Panel runat="server" ID="row9" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer25" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/pasivos_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer26" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/deudas_bancos_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer27" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/deudas_accionistas_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                
                </div>
            </div>
        </asp:Panel>
        
        <div class="containerf"></div>

        <asp:Panel runat="server" ID="row10" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer28" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer27" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/deudas_accionistas_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                <div class="div2">
                     <CR:CrystalReportViewer ID="CrystalReportViewer29" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link">
                        <a href="<%=ResolveClientUrl("~/Reportes/detalle_cobertura.aspx") %>">Ver Detalle</a>
                    </div>
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer28" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer70" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
        
                </div>
            </div>
        </asp:Panel>


        <div class="title-container">
            <h2>CAJA</h2>
        </div>

        <asp:Panel runat="server" ID="row11" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer12" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/detalle_disponibilidad.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div2">
                     <CR:CrystalReportViewer ID="CrystalReportViewer36" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/operaciones_no_conciliadas_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer37" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/monto_no_conciliado_detalle.aspx") %>">Ver Detalle</a>
                    </div>                
                </div>
            </div>
        </asp:Panel>

        <div class="title-container">
            <h2>OPORTUNIDADES</h2>
        </div>


        <asp:Panel runat="server" ID="row12" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer65" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/oportunidad_facturacion_detalle.aspx") %>">Ver Detalle</a>
                    </div>               
                </div>
                <div class="div2">
                   
                </div>
                <div class="div3">
                 
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row13" Visible="false">
            <div class="container">
                <div class="div1">
                     <CR:CrystalReportViewer ID="CrystalReportViewer41" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer36" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/operaciones_no_conciliadas_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                <div class="div2">
                      <CR:CrystalReportViewer ID="CrystalReportViewer42" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer37" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/monto_no_conciliado_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer43" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                  
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row14" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer48" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer49" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                </div>
                <div class="div3">
                     <CR:CrystalReportViewer ID="CrystalReportViewer50" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer41" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row15" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer51" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                  <%--  <CR:CrystalReportViewer ID="CrystalReportViewer42" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div2">
                      <CR:CrystalReportViewer ID="CrystalReportViewer52" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                  <%--  <CR:CrystalReportViewer ID="CrystalReportViewer43" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div3">
                     <CR:CrystalReportViewer ID="CrystalReportViewer53" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer44" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

        <div class="title-container">
            <h2>ALQUILERES</h2>
        </div>

        <asp:Panel runat="server" ID="row16" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer30" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/alquileres_anual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer45" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer31" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/alquileres_mensual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer46" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div3">
                      <CR:CrystalReportViewer ID="CrystalReportViewer32" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer47" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="row17" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer33" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer48" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer34" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer49" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div3">
                     <CR:CrystalReportViewer ID="CrystalReportViewer35" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer50" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

        <div class="title-container">
            <h2>RRHH</h2>
        </div>

        <asp:Panel runat="server" ID="row18" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer40" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                        <div class="centered-link"> 
                            <a href="<%=ResolveClientUrl("~/Reportes/colaboradores_detalle.aspx") %>">Ver Detalle</a>
                        </div>                                
                    </div>
                <div class="div2">
                     <CR:CrystalReportViewer ID="CrystalReportViewer39" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" /> 
                  <%--  <CR:CrystalReportViewer ID="CrystalReportViewer52" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
                <div class="div3">
                      <CR:CrystalReportViewer ID="CrystalReportViewer38" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer53" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

       <div class="title-container">
            <h2>POSTVENTA</h2>
        </div>

        <asp:Panel runat="server" ID="row19" Visible="false">
            <div class="container">
                <div class="div1">
                   <CR:CrystalReportViewer ID="CrystalReportViewer66" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" /> 
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_anho_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer54" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>     
                </div>
                 <div class="div2">
                      <CR:CrystalReportViewer ID="CrystalReportViewer67" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                     <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_mes_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                   <%-- <CR:CrystalReportViewer ID="CrystalReportViewer55" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                 
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer68" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_pendientes_detalle.aspx") %>">Ver Detalle</a>
                    </div>
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer56" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />--%>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="rowMaquinaria1" Visible="true">
                    <div class="container">
                        <div class="div1">
                            <CR:CrystalReportViewer ID="CrystalReportViewer69" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                               <div class="centered-link"> 
                                  <%--<a href="<%=ResolveClientUrl("~/Reportes/ingreso_maquinarias_detalle.aspx") %>">Ver Detalle</a>--%>
                                </div>
                        </div>
                        <div class="div2">
                             <CR:CrystalReportViewer ID="CrystalReportViewer71" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                     
                        </div>
                        <div class="div3">
                        <CR:CrystalReportViewer ID="CrystalReportViewer72" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                            
                        </div>
                    </div>    
        </asp:Panel>

        <asp:panel runat="server" ID="costosMaquinariasEquipos" Visible="true">
                    <div class="container">
                        <div class="div1">
                             <CR:CrystalReportViewer ID="CrystalReportViewer73" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                        </div> 
                        <div class="div2">
                                <CR:CrystalReportViewer ID="CrystalReportViewer74" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                        </div>
                        <div class="div3">
                            <CR:CrystalReportViewer ID="CrystalReportViewer75" runat="server" Visible="true" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                        </div>
                    </div>              
        </asp:Panel>



     
     <!--  <asp:Panel runat="server" ID="row20" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer57" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                       <%-- <a href="<%=ResolveClientUrl("~/Reportes/ventas_inbound_anual_detalle.aspx") %>">Ver Detalle</a>--%>
                    </div>
                
                </div>
                 <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer58" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                     <div class="centered-link"> 
                       <%-- <a href="<%=ResolveClientUrl("~/Reportes/ventas_inbound_mensual_detalle.aspx") %>">Ver Detalle</a>--%>
                    </div>
                </div>
                <div class="div3">
                    <CR:CrystalReportViewer ID="CrystalReportViewer59" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                </div>
            </div>
        </asp:Panel>

         <asp:Panel runat="server" ID="row21" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer60" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />                
                </div>
                 <div class="div2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer61" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                </div>
                <div class="div3">              
                    <CR:CrystalReportViewer ID="CrystalReportViewer62" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />          
                </div>         
            </div>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="row22" Visible="false">
            <div class="container">
                <div class="div1">
                    <CR:CrystalReportViewer ID="CrystalReportViewer63" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" /> 
                </div>
                 <div class="div2">  
                     <CR:CrystalReportViewer ID="CrystalReportViewer64" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                </div>
                <div class="div3">
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer65" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/oportunidad_facturacion_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
            </div>
        </asp:Panel>
       
        <asp:Panel runat="server" ID="row23" Visible="false">
            <div class="container">
                <div class="div1">
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer66" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" /> 
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_anho_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                 <div class="div2">  
<%--                     <CR:CrystalReportViewer ID="CrystalReportViewer67" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                     <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_mes_actual_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
                <div class="div3">
<%--                    <CR:CrystalReportViewer ID="CrystalReportViewer68" runat="server" Visible="false" AutoDataBind="false"  PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                    <div class="centered-link"> 
                        <a href="<%=ResolveClientUrl("~/Reportes/entregas_pendientes_detalle.aspx") %>">Ver Detalle</a>
                    </div>--%>
                </div>
            </div>
        </asp:Panel> 
-->

        <div style="text-align:center;margin:24px 0;">
            <asp:Button runat="server" ID="btnLoadMore"
                CssClass="btn btn-primary"
                Text="Cargar más"
                OnClick="btnLoadMore_Click" />
            <asp:Label runat="server" ID="lblStatus" CssClass="small text-muted" />
        </div>

    </div>

    </asp:Panel>
    </ContentTemplate>  
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnLoadMore" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>

  <script type="text/javascript">
    var scrollPosition = 0;

    // Guarda posición antes del postback
    function saveScrollPosition() {
        scrollPosition = window.scrollY || document.documentElement.scrollTop;
    }

    // Restaura posición después del postback
    function restoreScrollPosition() {
        setTimeout(function () {
            window.scrollTo(0, scrollPosition);
        }, 50);
    }

    // Vincula los eventos del UpdatePanel
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function () {
        saveScrollPosition();
    });

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        restoreScrollPosition();
    });
    </script>


    <asp:Label ID="lblGenerado" runat="server" />
</asp:Content>

    
