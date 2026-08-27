<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="registrousuario.aspx.cs" Inherits="proyecto5.contenido.registrousuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="contregistro">
            
            <asp:Panel ID="pnlListaUsuario" runat="server">
                <div class="row">
                    
                    <div class="col-md-10 col-md-offset-2">
                        <h5>Lista de Usuarios del Sistema</h5>
                    <div class="form-group">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
                    </div>
                        <asp:GridView ID="grdListaUsuarios" runat="server" CssClass="table" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="codigo,rol_id" DataSourceID="SqlGuardarUsuarios" OnSelectedIndexChanged="grdListaUsuarios_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" />
                                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" OnClientClick="return confirm('Desea Elimnar el usuarios?' );" />
                                    </ItemTemplate>
                                    <ControlStyle CssClass="btn btn-primary" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="codigo" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                                <asp:BoundField DataField="Pwd" HeaderText="Password" SortExpression="Pwd" Visible="False" />
                                <asp:BoundField DataField="rol" HeaderText="Rol" SortExpression="rol" />
                                <asp:BoundField DataField="rol_id" HeaderText="rol_id" SortExpression="rol_id" Visible="False" />
                                <asp:CheckBoxField DataField="modificarpass" HeaderText="Mod" SortExpression="modificarpass" />
                            </Columns>
                        </asp:GridView>
                      
                    </div>
                </div>
            </asp:Panel>



            <asp:Panel ID="pnlRegistro" runat="server" Visible="false">
        <div class="row">
            <!--
             <div class="col-md-12 logo">
             <div >
            <img src="images/logo.png"/>
            </div>
                 </div>-->
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <h3 class="titulologin">Registro de Usuarios</h3>
                 
                    <div class="panel-body">
						<div class="row">
							<div class="col-lg-12">
                                <div class="form-horizontal" id="login-form" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Codigo:</label>
                                                <input id="txtUserName" type="text" runat="server" class="form-control"/>
                                                <!--
                                                <ASP:RequiredFieldValidator ControlToValidate="txtUserName"
                                                    Display="Static" ErrorMessage="*" runat="server" 
                                                    ID="vUserName" />-->
                                            </div>
                                     <div class="form-group">
                                            <label>Nombre:</label>
                                            <input id="txtNombre" type="text" runat="server" class="form-control" />
                                           
                                        </div>
                                        <div class="form-group">
                                            <label>Contraseña:</label>
                                            <input id="txtUserPass"  runat="server" class="form-control" type="password" />
                                           
                                        </div>
                                    <div class="form-group">
                                            <label>Confirmar:</label>
                                            <input id="txtConfirmarPass" type="password" runat="server" class="form-control"  />
                                        
                                     </div>
                                    <div class="form-group">
                                        <label>Selecionar Rol:</label>
                                        <asp:DropDownList ID="drpRol" runat="server" DataSourceID="SqlRolList" DataTextField="rol" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlRolList" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [rol] FROM [roles]"></asp:SqlDataSource>
                                    </div>

                                   
                                        <div class="form-group">
                                            <label>Modificar password en la siguiente conexion:</label>
                                            <label><ASP:CheckBox id="chkModificarpass" runat="server" autopostback="false" /></label>
                                            
                                        </div>
                                   
                                   <div class="form-group">
                                        <asp:Button ID="btnregistrar" runat="server" Text="Registrar"  class="btn btn-primary btn-lg btn-block" OnClick="btnregistrar_Click1" />
                                       
                                   </div>
                                   
                                  
                        </div> 
                </div>
                            <asp:SqlDataSource ID="SqlGuardarUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                DeleteCommand="DELETE FROM [Users] WHERE [codigo] = @codigo" 
                                InsertCommand="INSERT INTO [Users] ([codigo], [nombre], [Pwd], [rol_id], [modificarpass]) VALUES (@codigo, @nombre, HASHBYTES('MD5',@Pwd), @rol_id, @modificarpass)" 
                                SelectCommand="SELECT Users.codigo, Users.nombre, Users.Pwd, Users.rol_id, Users.modificarpass, roles.rol FROM Users INNER JOIN roles ON roles.Id = Users.rol_id" 
                                UpdateCommand="UPDATE [Users] SET [nombre] = @nombre,  [rol_id] = @rol_id, [modificarpass] = @modificarpass WHERE [codigo] = @codigo">
                                <DeleteParameters>
                                    <asp:Parameter Name="codigo" Type="String" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="codigo" Type="String" />
                                    <asp:Parameter Name="nombre" Type="String" />
                                    <asp:Parameter Name="Pwd" Type="String" />
                                    <asp:Parameter Name="rol_id" Type="Int32" />
                                    <asp:Parameter Name="modificarpass" Type="Boolean" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="nombre" Type="String" />
                                    <asp:Parameter Name="rol_id" Type="Int32" />
                                    <asp:Parameter Name="modificarpass" Type="Boolean" />
                                    <asp:Parameter Name="codigo" Type="String" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                           
               </div>
                        
                        
             
                    
            </div><!--panel -->
                    <asp:Panel ID="pnlalert" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">  
                                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
                    <asp:Panel ID="Panelexito" runat="server" Visible="False">
                            <div class="alert alert-success" role="alert">  
                                <asp:Label ID="exito" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
            </div>
                    </div>
         </div>

       </asp:Panel>

            <asp:Panel ID="pnlModificar" runat="server" Visible="false">
                <div class="row">
                     <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                    <h3 class="titulologin">Modificacion de Usuarios</h3>
                 
                    <div class="panel-body">
						<div class="row">
                <div class="col-lg-12">
                                <div class="form-horizontal" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Codigo:</label>
                                                <input disabled id="txtCodigoM" type="text" runat="server" class="form-control"/>
                                                
                                            </div>
                                     <div class="form-group">
                                            <label>Nombre:</label>
                                            <input id="txtNombreM" type="text" runat="server" class="form-control" />
                                           
                                        </div>
                                        
                                    <div class="form-group">
                                        <label>Selecionar Rol:</label>
                                        <asp:DropDownList ID="drpListarRolM" runat="server" DataSourceID="SqlRolList" DataTextField="rol" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                               
                                    </div>

                     
                                        <div class="form-group">
                                            <label>Modificar password en la siguiente conexion:</label>
                                            <label><ASP:CheckBox id="chkmodificarpassM" runat="server" autopostback="false" /></label>
                     
                                        </div>
                                    <div class="form-group">
                                   <asp:Button ID="btnResetPass" runat="server" Text="Reset Password" CssClass="btn btn-warning" OnClick="btnResetPass_Click" />
                                   </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnModficar" runat="server" Text="Modificar"  class="btn btn-primary btn-lg btn-block" OnClick="btnModficar_Click"  />
                                       
                                   </div>
                                    <asp:Panel ID="pnlalertM" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">  
                                <asp:Label ID="lblmensajeM" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
                                    <asp:SqlDataSource ID="SqlUpdate" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Users] WHERE [codigo] = @codigo" InsertCommand="INSERT INTO [Users] ([codigo], [nombre], [Pwd], [rol_id], [modificarpass]) VALUES (@codigo, @nombre, @Pwd, @rol_id, @modificarpass)" SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [nombre] = @nombre, [rol_id] = @rol_id, [modificarpass] = @modificarpass WHERE [codigo] = @codigo">
                                        <DeleteParameters>
                                            <asp:Parameter Name="codigo" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="codigo" Type="String" />
                                            <asp:Parameter Name="nombre" Type="String" />
                                            <asp:Parameter Name="Pwd" Type="String" />
                                            <asp:Parameter Name="rol_id" Type="Int32" />
                                            <asp:Parameter Name="modificarpass" Type="Boolean" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="nombre" Type="String" />
                                            <asp:Parameter Name="rol_id" Type="Int32" />
                                            <asp:Parameter Name="modificarpass" Type="Boolean" />
                                            <asp:Parameter Name="codigo" Type="String" />
                                        </UpdateParameters>
                                            </asp:SqlDataSource>
                                  
                        </div> 
                </div>
            </div>
         </div>
        </div>
    </div>
     </div>

            </asp:Panel>

            <asp:Panel ID="pnlResetPass" runat="server" Visible="false">
                 <div class="row">
                     <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-login">
                    <h3 class="titulologin">Resetear de Password</h3>
                 
                    <div class="panel-body">
						<div class="row">
                <div class="col-lg-12">
                                <div class="form-horizontal" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Codigo:</label>
                                                <input disabled id="txtCodigoR" type="text" runat="server" class="form-control"/>
                                                
                                            </div>
                                      <div class="form-group">
                                            <label>Contraseña:</label>
                                            <input id="txtPasswordReset"  runat="server" class="form-control" type="password" />
                                           
                                        </div>
                                    <div class="form-group">
                                            <label>Confirmar:</label>
                                            <input id="txtConfirmarPasswordR" type="password" runat="server" class="form-control"  />
                                        
                                     </div>
                     
                                       
                                   
                                   <div class="form-group">
                                        <asp:Button ID="btnModificacionReset" runat="server" Text="Modificar"  class="btn btn-primary btn-lg btn-block" OnClick="btnModificacionReset_Click" />
      
                                   </div>
                             <asp:Panel ID="pnlAlertReset" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">  
                                <asp:Label ID="lblmensajeR" runat="server" Text=""></asp:Label>
                                
                            </div>
                        </asp:Panel>
                                    <asp:SqlDataSource ID="SqlResetPass" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [Pwd] =  HASHBYTES('MD5',@Pwd) WHERE [codigo] = @codigo">
                                        <UpdateParameters>
                                            <asp:Parameter Name="Pwd" Type="String" />
                                            <asp:Parameter Name="codigo" Type="String" />
                                        </UpdateParameters>
                                            </asp:SqlDataSource>      
                                  
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


