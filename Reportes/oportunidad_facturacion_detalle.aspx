<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="oportunidad_facturacion_detalle.aspx.cs" Inherits="proyecto5.Reportes.oportunidad_facturacion_detalle" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Reportes" runat="server">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" style="margin-top: 1.5cm;"/>

</asp:Content>
