<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facturacion_anual_historico.aspx.cs" Inherits="proyecto5.Reportes.facturacion_anual_historico" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Reportes" runat="server">
     <%-- ✅ BOTÓN NUEVO 
    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnExportPDF" runat="server" 
                    Text="Exportar PDF" 
                    OnClick="btnExportPDF_Click"
                    CssClass="btn btn-danger" />
    </div>--%>
    <CR:CrystalReportViewer ID="CrystalReportViewer2" 
        runat="server" 
        AutoDataBind="true" 
        PageZoomFactor="62" 
        ToolPanelView="None" 
        style="margin-top: 1.5cm;" />

</asp:Content>
