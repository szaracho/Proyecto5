<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="2024.aspx.cs" Inherits="proyecto5.Reportes._2024" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content" ContentPlaceHolderID="Reportes" runat="server">
    <div class="main-content">
        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/facturacion_anual_historico_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/facturacion_mensual_historico_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_anual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer4" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/unidades_vendidas_mensual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer5" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_anual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer6" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/m2_vendidos_mensual_detalle_2.aspx") %>">Ver Detalle</a>
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
                
            </div>
        </div>

        <div class="containerf"></div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer24" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer25" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer26" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/alquileres_general_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer27" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/alquileres_anual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer28" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/alquileres_mensual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer29" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer30" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer31" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer32" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer33" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer34" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer35" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer36" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer37" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer38" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer39" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer40" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer41" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer42" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer43" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer44" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer45" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer46" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/ventas_inbound_anual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer47" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/ventas_inbound_mensual_detalle_2.aspx") %>">Ver Detalle</a>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer48" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer49" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
            <div class="div3">
                <CR:CrystalReportViewer ID="CrystalReportViewer50" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
        </div>

        <div class="container">
            <div class="div1">
                <CR:CrystalReportViewer ID="CrystalReportViewer51" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
            </div>
             <div class="div2">
                <CR:CrystalReportViewer ID="CrystalReportViewer52" runat="server" AutoDataBind="true" PageZoomFactor="62" ToolPanelView="None" DisplayToolbar="False" />
                <div class="centered-link"> 
                    <a href="<%=ResolveClientUrl("~/Reportes/oportunidad_facturacion_detalle.aspx") %>">Ver Detalle</a>
                </div>
            </div>
            <div class="div3">
                
            </div>
        </div>
    </div>
</asp:Content>