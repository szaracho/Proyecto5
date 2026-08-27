<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registroempresa.aspx.cs" Inherits="proyecto5.contenido.registroempresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlListaEmpresas" runat="server">
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                    <h5>Lista de Empresas</h5>
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click"  />
                    </div>
                    <asp:GridView ID="grdListaEmpresas" runat="server" CssClass="table" AllowPaging="True" AllowSorting="True" DataSourceID="SqlEmpresas" AutoGenerateColumns="False" DataKeyNames="Id">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Esta seguro de eliminar ?' );" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-primary" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="empresa" HeaderText="empresa" SortExpression="empresa" />
                            <asp:BoundField DataField="basedatos" HeaderText="basedatos" SortExpression="basedatos" />
                            <asp:CheckBoxField DataField="activo" HeaderText="activo" SortExpression="activo" />
                            <asp:BoundField DataField="orden" HeaderText="orden" SortExpression="orden" />
                        </Columns>
                    </asp:GridView>

                </div>

            </div>
        </asp:Panel>
        <asp:Panel ID="pnlRegistroEm" runat="server" Visible="false">
            <div class="row">
                     <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                    <h3 class="titulologin">Registrar Empresas</h3>
                 
                    <div class="panel-body">
						<div class="row">
                <div class="col-lg-12">
                                <div class="form-horizontal" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Empresa:</label>
                                                <input id="txtEmpresa" type="text" runat="server" class="form-control" style="text-transform:uppercase"/>
                                                 
                                            </div>
                                             <div class="form-group">
                                                <label > Base de datos:</label>
                                                <input id="txtBaseDatos" type="text" runat="server" class="form-control" style="text-transform:uppercase"/>
                                                 
                                            </div>
                                            <div class="form-group">
                                                <label>Activo</label>
                                                <label><ASP:CheckBox id="chkactivo" runat="server" autopostback="false" /></label>
                                            
                                            </div>
                                             <div class="form-group">
                                                <label > Orden:</label>
                                                <input id="txtOrden" type="text" runat="server" class="form-control"/>
                                            </div>
      
                                   <div class="form-group">
                                        <asp:Button ID="btnGuardar" runat="server" Text="Registrar"  class="btn btn-primary btn-lg btn-block" OnClick="btnGuardar_Click" />
                                       <asp:SqlDataSource ID="SqlEmpresas" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [empresas] WHERE [Id] = @Id" InsertCommand="INSERT INTO [empresas] ([empresa], [basedatos], [activo], [orden]) VALUES (@empresa, @basedatos, @activo, @orden)" SelectCommand="SELECT Id, empresa, basedatos, activo, orden FROM empresas" UpdateCommand="UPDATE [empresas] SET [empresa] = @empresa, [basedatos] = @basedatos, [activo] = @activo, [orden] = @orden WHERE [Id] = @Id">
                                           <DeleteParameters>
                                               <asp:Parameter Name="Id" Type="Int32" />
                                           </DeleteParameters>
                                           <InsertParameters>
                                               <asp:Parameter Name="empresa" Type="String" />
                                               <asp:Parameter Name="basedatos" Type="String" />
                                               <asp:Parameter Name="activo" Type="Boolean" />
                                               <asp:Parameter Name="orden" Type="Int32" />
                                           </InsertParameters>
                                           <UpdateParameters>
                                               <asp:Parameter Name="empresa" Type="String" />
                                               <asp:Parameter Name="basedatos" Type="String" />
                                               <asp:Parameter Name="activo" Type="Boolean" />
                                               <asp:Parameter Name="orden" Type="Int32" />
                                               <asp:Parameter Name="Id" Type="Int32" />
                                           </UpdateParameters>
                                        </asp:SqlDataSource>
                                   </div>
                             <asp:Panel ID="pnlalert" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">  
                                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
                                  
                        </div> 
                </div>
                            
            </div>
         </div>
        </div>
    </div>
     </div>
    
        </asp:Panel>





    </div>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Reportes" runat="server">
</asp:Content>
