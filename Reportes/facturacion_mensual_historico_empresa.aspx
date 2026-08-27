<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facturacion_mensual_historico_empresa.aspx.cs" Inherits="proyecto5.Reportes.facturacion_mensual_historico_empresa" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="Reportes" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" style="margin-top: 1.5cm;" />

</asp:Content>