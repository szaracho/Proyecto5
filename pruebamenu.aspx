<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebamenu.aspx.cs" Inherits="proyecto5.pruebamenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <ul> <% foreach (Empresas nombre in registros) { %>
    <li><%= nombre.empresa %></li>
         <li><%= nombre.bd %></li>
        <% } %>
       
        
    </ul>
</div>


</asp:Content>
