<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS.Common.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>LMS</title>

    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body style="background-color:#d4f0fd" >
    <form id="form1" class="user" runat="server">
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-6 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Login </h1>
                                        </div>

                                        <div class="form-group">

                                            <div class="col-md-"></div>
                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                UserName
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtUserName" CssClass="form-control" placeholder="Enter UserName" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrUserName" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Password  
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter Your Password" class="form-control form-control-user" runat="server" TextMode="Password"></asp:TextBox>

                                                <asp:Label ID="lblErrPassword" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <asp:CheckBox ID="chbRemember" Visible="false" runat="server" Text="Remember" />  
                                                <label class="custom-control-label" for="customCheck">
                                                    Remember
                                                    Me</label>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnLogin" CssClass=" btn-user btn-block" Text="Login" style="background-color:#d4f0fd;width: 100%;color:#000000" OnClientClick="return FunForLoginValidation()" runat="server" OnClick="btnLogin_Click" />  
                                      <asp:Button ID="btnCancel" CssClass=" btn-user btn-block" Text="Cancel" style="background-color:#808080;width: 100%;color:#fff" runat="server" />  
                                        <hr>
                                        <div class="row">
                                            <div class="col-sm-4">
                                                <a class="small" href="ForgetPassword.aspx">Forgot Password?</a>
                                            </div>
                                            <div class="col-sm-6"></div>
                                            <div class="col-sm-2">
                                                <a class="small" href="Register.aspx">Sign Up?</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="../vendor/jquery/jquery.min.js"></script>
        <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin-2.min.js"></script>
        <script>  
            function FunForLoginValidation() {
                var objValid = true;
                var objUserName = $("[id$=txtUserName]").val();
                var objPassword = $("[id$=txtPassword]").val();
                if (objUserName == "") {
                    $('[id$=lblErrUserName]').text("User Name is required");
                    $('[id$=lblErrUserName]').css("color", "#FF0000");
                    $("[id$=txtUserName]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrUserName]').text("");
                    $('[id$=lblErrUserName]').css("color", "#FFFFFF");
                    $("[id$=txtUserName]").removeClass("Error-control");
                }

                if (objPassword == "") {
                    $('[id$=lblErrPassword]').text("Password is required");
                    $('[id$=lblErrPassword]').css("color", "#FF0000");
                    $("[id$=txtPassword]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrPassword]').text("");
                    $('[id$=lblErrPassword]').css("color", "#FFFFFF");
                    $("[id$=txtPassword]").removeClass("Error-control");
                }
                return objValid;
            }
            function AcceptAlphanumeric(evt) {
                var key = evt.keyCode;
                return ((key >= 48 && key <= 57) || (key >= 65 && key <= 90) || (key >= 95 && key <= 122));
            }
            function NotAllowSingleDoubleQuotes(e) {
                var charCode = e.keyCode;
                if (charCode == 34)
                    return false;
                if (charCode == 39)
                    return false;
            }
        </script>
    </form>
</body>
</html>
