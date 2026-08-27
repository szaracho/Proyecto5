<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cambiarpassword.aspx.cs" Inherits="proyecto5.contenido.cambiarpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                                    <asp:SqlDataSource ID="SqlResetPass" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        SelectCommand="SELECT * FROM [Users]" UpdateCommand="UPDATE [Users] SET [Pwd] =  HASHBYTES('MD5',@Pwd), [modificarpass] = 0 WHERE [codigo] = @codigo">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Reportes" runat="server">
</asp:Content>
