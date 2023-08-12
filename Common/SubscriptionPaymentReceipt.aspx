<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubscriptionPaymentReceipt.aspx.cs" Inherits="LMS.Common.SubscriptionPaymentReceipt" %>

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
                                            <h1 class="h4 text-gray-900 mb-4">Subscribed List </h1>
                                        </div>

                                        <div class="form-group">

                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" Style="text-align: center" class="table table-bordered"
                            AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="TypeName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontrolname1" CssClass="form-control" runat="server" Text='<%#Eval("TypeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IsIncluded">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeestatus1" CssClass="form-control" runat="server" Text='<%#Eval("IsIncluded") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeestatus1" CssClass="form-control" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center">No records found.</div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" ForeColor="white" />
                            <PagerStyle />
                            <RowStyle />
                            <SelectedRowStyle />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>

                                        </div>
                                        <%--<asp:Button ID="btnLogin" CssClass=" btn-user btn-block" Text="Register Account" Style="background-color: #d4f0fd; width: 100%; color: #000"  runat="server" />
                                        <asp:Button ID="btnCancel" CssClass=" btn-user btn-block" Text="Cancel" Style="background-color: #808080; width: 100%; color: #fff" runat="server" />--%>
                                        Please Login and Sync Again
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
        
    </form>
</body>
</html>
