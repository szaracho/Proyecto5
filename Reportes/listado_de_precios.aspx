<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listado_de_precios.aspx.cs" Inherits="proyecto5.Reportes.listado_de_precios" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Reportes" runat="server">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" HyperlinkTarget="_blank" />

</asp:Content>
