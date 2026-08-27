<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso1.aspx.cs" Inherits="proyecto5.contenido.Ingreso1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
         <asp:Label ID="Label1" runat="server" Text="ESTAMOS LOGUEADOS"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="uname" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="uname" HeaderText="uname" ReadOnly="True" SortExpression="uname" />
            <asp:BoundField DataField="Pwd" HeaderText="Pwd" SortExpression="Pwd" />
            <asp:BoundField DataField="userRole" HeaderText="userRole" SortExpression="userRole" />
        </Columns>
         </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </div>
   
</asp:Content>
