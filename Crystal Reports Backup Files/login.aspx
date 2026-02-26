<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="proyecto5.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <title>Altamira Group</title>
</head>
<body class="fondologin">

   
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="bootstrap" />
            </Scripts>
        </asp:ScriptManager>
        <div class="container">
        <div class="row">
             <div class="col-md-12 logo">
             <div >
            <img src="images/logo.png"/>
            </div>
                 </div>
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <h3 class="titulologin">Acceso al Sistema</h3>
                 
                    <div class="panel-body">
						<div class="row">
							<div class="col-lg-12">
                                <div class="form-horizontal" id="login-form" style="display: block;">
                                    
                                            <div class="form-group">
                                                <label > Usuario:</label>
                                                <input id="txtUserName" type="text" runat="server" class="form-control"/>
                                                <!--
                                                <ASP:RequiredFieldValidator ControlToValidate="txtUserName"
                                                    Display="Static" ErrorMessage="*" runat="server" 
                                                    ID="vUserName" />-->
                                            </div>
                                        <div class="form-group">
                                            <label>Contraseña:</label>
                                            <input id="txtUserPass" type="password" runat="server" class="form-control" />
                                           
                                        </div>
                                    <!--
                                        <div class="form-group">
                                            <label>Persistent Cookie:</label>
                                            <label><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></label>
                                            
                                        </div>
                                    -->
                                   <div class="form-group">
                                        <asp:Button ID="btnlogin" runat="server" Text="Ingresar" OnClick="btnlogin_Click" class="btn btn-primary btn-lg btn-block" />
                                   </div>
                                   
                                  
                        </div> 
                </div>
               </div>
                        
                        
             
                    
            </div><!--panel -->
                    <asp:Panel ID="pnlalert" runat="server" Visible="False">
                            <div class="alert alert-danger" role="alert">     
                                Ingrese un Nombre de Usuario y Clave Validos
                            </div>
                        </asp:Panel>
          </div>
     </div>
        </div>
             </div>
    </form>
   
</body>
</html>
