<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empresas.aspx.cs" Inherits="proyecto5.inversiones" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div class="botonempresa">
        <h2 class="tituloempresa" style="margin-top: 40px"><%= tituloempresa %></h2>
    </div>
    <div class="menuinicio">
                <div class="menuinicio">
                    <ul class="linkempresa" style="margin-left:0">
                       <%--LOS UL QUE ESTÁN CONDICIONADOS POR ROL, SON PORQUE LOS REPORTES QUE SE EJECUTAN SON DISTINTOS PARA CADA EMPRESA--%>
                        
                        <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                         
                     
                        <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                            
                        
                            <div class="grupo">
                              <button type="button"  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown" aria-expanded="true"  runat="server">VENTAS
                                  
                              </button>
                             <ul class="dropdown-menu fondito">
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14" ){  %> 
                                    <li><a href="<%=ResolveClientUrl("~/Reportes/mix_de_ventas.aspx?bd=" +bd) %>">Mix de Ventas</a></li>
                                    <li role="separator" class="divider"></li>
                                 <% } %>
                                 
                                 <% if (rol=="15"){  %> 
                                    <li><a href="<%=ResolveClientUrl("~/Reportes/mix_de_ventas_anorte.aspx?bd=" +bd) %>">Mix de Ventas</a></li>
                                    <li role="separator" class="divider"></li>
                                 <% } %>

                                 <% if (rol=="16"){  %> 
                                    <li><a href="<%=ResolveClientUrl("~/Reportes/mix_de_ventas_veralta.aspx?bd=" +bd) %>">Mix de Ventas</a></li>
                                    <li role="separator" class="divider"></li>
                                 <% } %>


                                 <% if (rol == "15" || rol == "16" || bd  == "ALTACREOSA" || bd == "ALTAZENTA_NORTE_SA"){  %> 
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/resumen_general_articulos_2.aspx?bd=" + bd) %>">Resumen General de Articulos</a></li>
                                 <% } %> 
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %> 
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/resumen_general_articulos.aspx?bd=" +bd) %>">Resumen General de Articulos</a></li>
                                <% } %>
                                 
                                 <li role="separator" class="divider"></li>
                                 
                                  <% if (rol == "15" || rol == "16" || bd  == "ALTACREOSA" || bd == "ALTAZENTA_NORTE_SA"){  %> 
                                    <li><a href="<%=ResolveClientUrl("~/Reportes/estado_cuenta_general_clientes_2.aspx?bd=" +bd) %>">Estado de Cuenta General de Clientes</a></li>
                                 <% }%>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %> 
                                    <li><a href="<%=ResolveClientUrl("~/Reportes/estado_cuenta_general_clientes_.aspx?bd=" +bd) %>">Estado de Cuenta General de Clientes</a></li>
                                 <% } %>

                             </ul>
                                 </div>
                        </li>
                          <% } %>

                         <% if (rol == "4" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                         <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                             <div class="grupo">
                              <button class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">CRM</button>
                             <ul class="dropdown-menu fondito">
                                   <% if (rol == "15" || rol == "16"){  %>      
                                  <li><a href="<%=ResolveClientUrl("~/Reportes/informe_comercial_crm_2.aspx?bd=" + bd)%>">Informe Comercial CRM</a></li>
                                   <% }  %>
                                   <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %>  
                                  <li><a href="<%=ResolveClientUrl("~/Reportes/informe_comercial_crm.aspx?bd=" +bd) %>">Informe Comercial CRM</a></li>
                                   <% } %>

                                  <li role="separator" class="divider"></li>

                                 <% if (rol == "15" || rol == "16"){  %>   
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/status_leads_2.aspx?bd=" +bd) %>">Status de Leads</a></li>
                                 <% } %>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %>  
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/status_leads.aspx?bd=" +bd) %>">Status de Leads</a></li>
                                 <% } %>

                                 <li role="separator" class="divider"></li>
                                 
                                 <% if (rol == "15" || rol == "16"){  %> 
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/informe_de_lista_de_precios_2.aspx?bd=" +bd) %>">Informe de Lista de Precios</a></li>
                                 <% }  %>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %> 
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/informe_de_lista_de_precios.aspx?bd=" +bd) %>">Informe de Lista de Precios</a></li>
                                 <% } %>

                                 <li role="separator" class="divider"></li>

                                 <% if (rol == "15" || rol == "16"){  %>   
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/visitas_efectivas_inbound_2.aspx?bd=" +bd) %>">Informe de Visitas Efectivas Inbound</a></li>
                                 <% } %>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %>  
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/visitas_efectivas_inbound.aspx?bd=" +bd) %>">Informe de Visitas Efectivas Inbound</a></li>
                                 <% } %>
                                 
                                 
                                 <li role="separator" class="divider"></li>

                                 <% if (rol == "15" || rol == "16"){  %>   
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/visitas_asignadas_showrrom_2.aspx?bd=" +bd) %>">Informe de Visitas Asignadas Showroom</a></li>
                                 <% } %>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %>  
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/visitas_asignadas_showrrom.aspx?bd=" +bd) %>">Informe de Visitas Asignadas Showroom</a></li>
                                 <% } %>

                                 
                             </ul>
                              </div>
                        </li>
                         <% } %>

                         <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">FINANZAS</button>
                             <ul class="dropdown-menu fondito">
                                
                                 <% if (rol == "15" ){  %>   
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/presupuesto_anorte.aspx?bd=" +bd) %>">Presupuesto</a></li>
                                 <% } %>
                                 <% if (rol == "16"){  %>   
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/presupuesto_veralta.aspx?bd=" +bd) %>">Presupuesto</a></li>
                                 <% } %>
                                 <% if (rol == "2" || rol=="6" || rol=="1" || rol=="14"){  %>  
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/presupuesto.aspx?bd=" +bd) %>">Presupuesto</a></li>
                                 <% } %>
                                
                                 
                                 <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/flujo_caja.aspx?bd=" +bd) %>">Flujo de Caja</a></li>
                                 <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/informe_consolidado.aspx?bd=" +bd) %>">Informe Consolidado</a></li>
                             </ul>
                                </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">LEGAL</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/resumenlegal.aspx?bd=" +bd) %>">Resumen Legal</a></li>
                                <!-- -->
                             </ul>
                           </div>
                        </li>
                         <% } %>
                       
                         <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">COBRANZAS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/resumengeneralcobranzas.aspx?bd=" +bd) %>">Resumen General de Cobranzas</a></li>
                                
                             </ul>
                           </div>
                        </li>
                         <% } %>

                         <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">CONTABILIDAD</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/balancecomprobacion.aspx?bd=" +bd) %>">Balance de Comprobacion</a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="<%=ResolveClientUrl("~/Reportes/estadoresultado.aspx?bd=" +bd) %>">Estado de Resultado</a></li>
                             </ul>
                           </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" ){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">PROYECTOS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/permisologia.aspx?bd=" +bd) %>">Permisologia</a></li>
                                 
                             </ul>
                           </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">ADMINISTRACION</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/conciliacionbancaria.aspx?bd=" +bd) %>">Conciliacion Bancaria</a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="<%=ResolveClientUrl("~/Reportes/ingresoegresos.aspx?bd=" +bd) %>">Ingresos y Egresos</a></li>
                             </ul>
                           </div>
                        </li>
                         <% } %>

                         <% if (rol == "3" || rol=="6" || rol=="1"  || rol=="14" || rol=="15" || rol=="16"){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">OBRAS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/avance_edificaiones.aspx?bd=" +bd) %>">Avance Edificacion</a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="<%=ResolveClientUrl("~/Reportes/avance_urbanismo.aspx?bd=" +bd) %>">Avance Urbanismo</a></li>
                             </ul>
                           </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" || rol=="14" || rol=="15" || rol=="16" ){  %>
                       <li class="dropdown interno" style=" list-style-type: none; margin-left:0">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">CONSOLIDADO</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/informe_consolidado.aspx?bd=" +bd) %>">Informe Consolidado</a></li> 
                                 
                                 
                             </ul>
                           </div>
                        </li>
                         <% } %>

                    </ul>
                </div>
            </div>
        
</div>


</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Reportes" runat="server">
    <div class="main-content">
        <div class="container ">
            <div class="div1 centered-link">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/facturacion_anual_historico_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div2 centered-link">
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/facturacion_mensual_historico_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_anual_detalle_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_mensual_detalle_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_anual_detalle_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer6" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_mensual_detalle_empresa.aspx?bd=" +bd) %>">Ver Detalle</a>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer7" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer8" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer9" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer10" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer11" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer12" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer13" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer14" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer15" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer16" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer17" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer18" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>
        <div class="container">
            
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer19" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer20" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer21" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer22" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer23" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer24" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer25" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer26" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer27" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer28" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer29" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer30" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer31" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer32" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer33" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer34" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer35" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer36" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer37" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer38" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer39" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer40" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer41" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer42" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer43" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer44" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer45" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer46" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer47" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer48" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">            
            <div class="div1">
               <CR:CrystalReportViewer ID="CrystalReportViewer49" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
               <CR:CrystalReportViewer ID="CrystalReportViewer50" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
               <CR:CrystalReportViewer ID="CrystalReportViewer51" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>
    </div>
</asp:Content>
