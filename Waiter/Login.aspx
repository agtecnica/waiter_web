<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Waiter.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />
    <link href="Content/Login.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"> 

    </script>
    <style type="text/css">
        .margin_top75 {
            margin-top: 75px;
        }
    </style>

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container h-100">
            <div class="d-flex justify-content-center h-100">
                <div class="user_card margin_top75">
                    <div class="d-flex justify-content-center">
                        <div class="brand_logo_container">
                            <asp:Image runat="server" src="https://cdn.freebiesupply.com/logos/large/2x/pinterest-circle-logo-png-transparent.png" class="brand_logo" alt="Logo" />
                        </div>
                    </div>
                    <div class="d-flex justify-content-center form_container">
                        <div>
                            <div class="input-group mb-3">
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fas fa-user"></i></span>
                                </div>
                                <asp:TextBox runat="server" ID="txtLogin" type="text" name="" class="form-control input_user" value="" placeholder="username" />
                            </div>
                            <div class="input-group mb-2">
                                <div class="input-group-append">
                                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                                </div>
                                <asp:TextBox runat="server"  ID="txtSenha" type="password" name="" class="form-control input_pass" value="" placeholder="password" />
                            </div>
                            <div class="form-group">
                                <div class="custom-control custom-checkbox">
                                    <asp:TextBox runat="server" type="checkbox" class="custom-control-input" ID="customControlInline" />
                                    <label class="custom-control-label" for="customControlInline">Remember me</label>
                                </div>
                            </div>
                            <div class="d-flex justify-content-center mt-3 login_container">
                                <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn login_btn" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="mt-4">
                        <div class="d-flex justify-content-center links">
                            Don't have an account? <a href="#" class="ml-2">Sign Up</a>
                        </div>
                        <div class="d-flex justify-content-center links">
                            <a href="#">Forgot your password?</a>
                        </div>
                        <div class="d-flex justify-content-center links">
                            <label runat="server" id="lblErro" style="color:red;font-weight:bold;"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
