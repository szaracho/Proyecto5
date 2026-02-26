<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proyecto5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   <div class="page-header">
       <div class="menuinicio">

              <a class="linkempresa" href="<%=ResolveClientUrl("~/Reportes/informe_directorio.aspx") %>">
                <div class="jumbotron botonempresa default">
                    <h1 class="tituloempresa"> ALTAMIRA GROUP S.A.</h1>
                </div>
            </a>


       <% foreach (Empresas nombre in registros) { %>
            <a class="linkempresa" href="<%=ResolveClientUrl("~/contenido/empresas.aspx?bd="+nombre.bd+"&empresa="+nombre.empresa) %>">
                <div class="jumbotron botonempresa default">
                    <h1 class="tituloempresa"><%= nombre.empresa %></h1>
                </div>
            </a>
        <% } %>
        </div>
   </div>
</asp:Content>
