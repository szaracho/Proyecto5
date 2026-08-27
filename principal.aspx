<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="principal.aspx.cs" Inherits="proyecto5.principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="height: 125px; width: 434px"></td>
            <td style="height: 125px; width: 434px">
               <asp:Button ID="CONSOLIDADO" runat="server" Height="46px" Text="CONSOLIDADO" Width="249px" BorderStyle="None" CssClass="btn-primary" style="margin-left: 100px" />
            </td>
            <td style="height: 125px"></td>
        </tr>
        <tr>
            <td style="height: 125px; width: 434px">
                <asp:Button ID="INVERSIONES" runat="server" Height="46px" Text="INVERSIONES ALTAMIRA S.A." Width="251px" BorderStyle="None" CssClass="btn-primary" style="margin-left: 100px" />
            </td>
            <td style="height: 125px; width: 434px">
                <asp:Button ID="EDIFICACIONES" runat="server" Height="46px" Text="EDIFICACIONES ALTAMIRA S.A." Width="251px" BorderStyle="None" CssClass="btn-primary" style="margin-left: 100px" />
            </td>
            <td style="height: 125px">
                <asp:Button ID="CORPORACION" runat="server" Height="46px" Text="CORPORACION ALTAMIRA S.A." Width="251px" BorderStyle="None" CssClass="btn-primary" style="margin-left: 100px" />
            </td>
        </tr>
        <tr>
            <td style="height: 125px; width: 434px">&nbsp;</td>
            <td style="height: 125px; width: 434px">
                <asp:Button ID="CONSTRUCTORA" runat="server" Height="46px" Text="ALTAMIRA GROUP S.A." Width="251px" BorderStyle="None" CssClass="btn-primary" style="margin-left: 100px" />
            </td>
            <td style="height: 38px">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
