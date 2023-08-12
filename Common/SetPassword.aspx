<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPassword.aspx.cs" Inherits="LMS.Common.SetPassword" %>

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
                                            <h1 class="h4 text-gray-900 mb-4">Set Password </h1>
                                        </div>
                                        
                                         <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                New Password  
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtNewPassword" CssClass="form-control" placeholder="Enter Your New Password" class="form-control form-control-user" runat="server" TextMode="Password"></asp:TextBox>

                                                <asp:Label ID="lblErrNewPassword" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Conform New Password  
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtConNewPassword" CssClass="form-control" placeholder="Enter Your New Password" class="form-control form-control-user" runat="server" TextMode="Password"></asp:TextBox>

                                                <asp:Label ID="lblErrConNewPassword" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnResetPassword" CssClass=" btn-user btn-block" Text="Set Password" style="background-color:#d4f0fd;color:#000;width: 100%" OnClientClick="return FunForLoginValidation()" runat="server" OnClick="btnResetPassword_Click" />  
                                     
                                      <hr>
                                      <div class="text-center">
                                            <a class="small" href="Login.aspx">Login!</a>
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
                var objNewPassword = $("[id$=txtNewPassword]").val();
                var objConNewPassword = $("[id$=txtConNewPassword]").val();

                if (objNewPassword == "") {
                    $('[id$=lblErrNewPassword]').text("New Password is required");
                    $('[id$=lblErrNewPassword]').css("color", "#FF0000");
                    $("[id$=txtNewPassword]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrNewPassword]').text("");
                    $('[id$=lblErrNewPassword]').css("color", "#FFFFFF");
                    $("[id$=txtNewPassword]").removeClass("Error-control");
                }

                if (objConNewPassword == "") {
                    $('[id$=lblErrConNewPassword]').text("Conform New Password is required");
                    $('[id$=lblErrConNewPassword]').css("color", "#FF0000");
                    $("[id$=txtConNewPassword]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrConNewPassword]').text("");
                    $('[id$=lblErrConNewPassword]').css("color", "#FFFFFF");
                    $("[id$=txtConNewPassword]").removeClass("Error-control");
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
