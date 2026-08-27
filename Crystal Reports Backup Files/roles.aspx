<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="roles.aspx.cs" Inherits="proyecto5.roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contregistro">
        <asp:Panel ID="pnlListaRoles" runat="server">
            <div class="row">
                <div class="col-md-10 col-md-offset-2">
                        <h5>Lista de Roles del Sistema</h5>
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
                    </div>
                    <asp:GridView ID="grdListaRoles" CssClass="table" runat="server" DataSourceID="SqlRoles" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
                                    &nbsp;
                                    &nbsp;<asp:Button ID="Button3" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Desea Elimnar el rol?' );" />
                                </ItemTemplate>
                                <ControlStyle CssClass="btn btn-primary" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="rol" HeaderText="rol" SortExpression="rol" />
                        </Columns>
                        </asp:GridView>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlNuevoRol" runat="server" Visible="false">
    <div class="row">
                     <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                    <h3 class="titulologin">Registrar Roles</h3>
                 
                    <div class="panel-body">
						<div class="row">
                <div class="col-lg-12">
                                <div class="form-horizontal" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Rol:</label>
                                                <input id="txtRol" type="text" runat="server" class="form-control" style="text-transform:uppercase"/>
                                                 
                                            </div>
      
                                   <div class="form-group">
                                        <asp:Button ID="btnGuardar" runat="server" Text="Registrar"  class="btn btn-primary btn-lg btn-block" OnClick="btnGuardar_Click"  />
      
                                   </div>
                             <asp:Panel ID="pnlalert" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">  
                                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
                                  
                        </div> 
                </div>
                            <asp:SqlDataSource ID="SqlRoles" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [roles] WHERE [Id] = @Id" InsertCommand="INSERT INTO [roles] ([rol]) VALUES (@rol)" SelectCommand="SELECT id, rol FROM [roles]" UpdateCommand="UPDATE [roles] SET [rol] = @rol WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="rol" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="rol" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
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
