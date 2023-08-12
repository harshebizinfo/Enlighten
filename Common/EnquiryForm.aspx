<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnquiryForm.aspx.cs" Inherits="LMS.Common.EnquiryForm" %>

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
<body style="background-color: #d4f0fd">
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
                                            <h1 class="h4 text-gray-900 mb-4">Enquiry Form! </h1>
                                        </div>

                                        <div class="form-group">

                                            <div class="col-md-"></div>
                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Full Name
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Enter Full Name" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrFirstName" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <div class="col-md-"></div>
                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Institute Name
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Enter Institute Name" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrLastName" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Contact Number  
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtContactNumber" CssClass="form-control" placeholder="Enter Your Contact Number" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrContactNumber" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Email ID 
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtEmailid" CssClass="form-control" placeholder="Enter Your Email ID" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrEmailId" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <label class="col-md-12 control-label" for="prependedcheckbox">
                                                Permanent Address
                                            </label>
                                            <div class="col-md-12">

                                                <asp:TextBox ID="txtAddress" CssClass="form-control" placeholder="Enter Your Prmanent Address" TextMode="MultiLine" Rows="2" class="form-control form-control-user" runat="server"></asp:TextBox>

                                                <asp:Label ID="lblErrAddress" CssClass="help-block" runat="server" Text="" ForeColor="White"></asp:Label>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnLogin" CssClass=" btn-user btn-block" Text="Register Account" Style="background-color: #d4f0fd; width: 100%; color: #000" OnClientClick="return FunForLoginValidation()" runat="server" OnClick="btnLogin_Click" />
                                        <asp:Button ID="btnCancel" CssClass=" btn-user btn-block" Text="Cancel" Style="background-color: #808080; width: 100%; color: #fff" runat="server" />
                                        <hr />
                                        <div class="text-center">
                                            <a class="small" href="Login.aspx">Login</a>
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
                var objFirstName = $("[id$=txtFirstName]").val();
                var objLastName = $("[id$=txtLastName]").val();
                var objContactNumber = $("[id$=txtContactNumber]").val();
                var objEmailid = $("[id$=txtEmailid]").val();
                var objAddress = $("[id$=txtAddress]").val();
                if (objFirstName == "") {
                    $('[id$=lblErrFirstName]').text("Full Name is required");
                    $('[id$=lblErrFirstName]').css("color", "#FF0000");
                    $("[id$=txtFirstName]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrFirstName]').text("");
                    $('[id$=lblErrFirstName]').css("color", "#FFFFFF");
                    $("[id$=txtFirstName]").removeClass("Error-control");
                }

                if (objLastName == "") {
                    $('[id$=lblErrLastName]').text("Institute Name is required");
                    $('[id$=lblErrLastName]').css("color", "#FF0000");
                    $("[id$=txtLastName]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrLastName]').text("");
                    $('[id$=lblErrLastName]').css("color", "#FFFFFF");
                    $("[id$=txtLastName]").removeClass("Error-control");
                }

                if (objContactNumber == "") {
                    $('[id$=lblErrContactNumber]').text("LContact Number is required");
                    $('[id$=lblErrContactNumber]').css("color", "#FF0000");
                    $("[id$=txtContactNumber]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrContactNumber]').text("");
                    $('[id$=lblErrContactNumber]').css("color", "#FFFFFF");
                    $("[id$=txtContactNumber]").removeClass("Error-control");
                }

                if (objEmailid == "") {
                    $('[id$=lblErrEmailId]').text("Email ID is required");
                    $('[id$=lblErrEmailId]').css("color", "#FF0000");
                    $("[id$=txtEmailid]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrEmailId]').text("");
                    $('[id$=lblErrEmailId]').css("color", "#FFFFFF");
                    $("[id$=txtEmailid]").removeClass("Error-control");
                }

                if (objAddress == "") {
                    $('[id$=lblErrAddress]').text("Address is required");
                    $('[id$=lblErrAddress]').css("color", "#FF0000");
                    $("[id$=txtAddress]").addClass("Error-control");
                    objValid = false;
                }
                else {
                    $('[id$=lblErrAddress]').text("");
                    $('[id$=lblErrAddress]').css("color", "#FFFFFF");
                    $("[id$=txtAddress]").removeClass("Error-control");
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
