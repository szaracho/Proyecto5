<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empresas.aspx.cs" Inherits="proyecto5.inversiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <div class="jumbotron botonempresa">
        <h1 class="tituloempresa"><%= tituloempresa %></h1>
    </div>
    <div class="container">
                <div class="navbar-nav">
                    <ul class="nav navbar-nav">
                         
                        <% if (rol == "2" || rol=="6" || rol=="1" ){  %>
                         <li class="dropdown interno">
                             <div class="grupo">
                              <button type="button"  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown" aria-expanded="true"  runat="server">VENTAS
                                  
                              </button>
                             <ul class="dropdown-menu fondito">
               
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/mix_de_ventas.aspx?bd=" +bd) %>">Mix de Ventas</a></li>
                                 <li role="separator" class="divider"></li>
                                  <li><a href="<%=ResolveClientUrl("~/Reportes/resumen_general_articulos.aspx?bd=" +bd) %>">Resumen General de Articulos</a></li>
                                  <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/estado_cuenta_general_clientes.aspx?bd=" +bd) %>">Estado de Cuenta General de Clientes</a></li>

                             </ul>
                                 </div>
                        </li>
                          <% } %>

                         <% if (rol == "4" || rol=="6" || rol=="1" ){  %>
                         <li class="dropdown interno">
                             <div class="grupo">
                              <button class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">CRM</button>
                             <ul class="dropdown-menu fondito">
               
                                  <li><a href="<%=ResolveClientUrl("~/Reportes/informe_comercial_crm.aspx?bd=" +bd) %>">Informe Comercial CRM</a></li>
                                  <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/status_leads.aspx?bd=" +bd) %>">Status de Leads</a></li>
                                 <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/informe_de_lista_de_precios.aspx?bd=" +bd) %>">Informe de Lista de Precios</a></li>
                             </ul>
                              </div>
                        </li>
                         <% } %>

                         <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">FINANZAS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/presupuesto.aspx?bd=" +bd) %>">Presupuesto</a></li>
                                <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/flujo_caja.aspx?bd=" +bd) %>">Flujo de Caja</a></li>
                                 <li role="separator" class="divider"></li>
                                 <li><a href="<%=ResolveClientUrl("~/Reportes/informe_consolidado.aspx?bd=" +bd) %>">Informe Consolidado</a></li>
                             </ul>
                                </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">LEGAL</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/resumenlegal.aspx?bd=" +bd) %>">Resumen Legal</a></li>
                                
                             </ul>
                           </div>
                        </li>
                         <% } %>
                       
                         <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">COBRANZAS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/resumengeneralcobranzas.aspx?bd=" +bd) %>">Resumen General de Cobranzas</a></li>
                                
                             </ul>
                           </div>
                        </li>
                         <% } %>

                         <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
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

                        <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">PROYECTOS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/permisologia.aspx?bd=" +bd) %>">Permisologia</a></li>
                                 
                             </ul>
                           </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
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

                         <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">OBRAS</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/avanceedificacion.aspx?bd=" +bd) %>">Avance Edificacion</a></li>
                                 <li role="separator" class="divider"></li>
                                <li><a href="<%=ResolveClientUrl("~/Reportes/avanceurbanismo.aspx?bd=" +bd) %>">Avance Urbanismo</a></li>
                             </ul>
                           </div>
                        </li>
                         <% } %>

                        <% if (rol == "3" || rol=="6" || rol=="1" ){  %>
                       <li class="dropdown interno">
                           <div class="grupo">
                              <button  class="dropdown-toggle btn btn-primary btn-lg btn-block btnespecial" data-toggle="dropdown"  runat="server">CONSOLIDADO</button>
                             <ul class="dropdown-menu fondito">
                                <li><a href="<%=ResolveClientUrl("~/Reportes/informeconsolidado.aspx?bd=" +bd) %>">Informe Consolidado</a></li>
                                 
                             </ul>
                           </div>
                        </li>
                         <% } %>

                    </ul>
                </div>
            </div>
</div>

    <div class="contenido">



    </div>
</asp:Content>
