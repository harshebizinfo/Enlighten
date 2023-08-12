<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlinePaymentReceipt.aspx.cs" Inherits="LMS.Learner.OnlinePaymentReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Page</title>
    <script type="text/javascript">
        function myFunction() {
            document.getElementById('btnprint').style.display = 'none';
            document.getElementById('btnback').style.display = 'none';
            window.print();
        }
    </script>
    <link href="../receiptcss/bootstrap.min.css" rel="stylesheet" />
    <link href="../receiptcss/style_receipt.css" rel="stylesheet" />
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
        <div id="divreceipt" align="center" runat="server" style="border: 1px solid #ccc; margin-left: 130px; width: 80%;">
            <div class="container" style="border-bottom: 1px solid #ccc;">
                <!--start container-fluid-->
                <div class="row header-top">
                    <div class="col-md-4 col-sm-4 col-xs-4">
                        <asp:Image ID="img_institute_logo" class="img-responsive img1" runat="server" height="110" width="110"/>
                    </div>
                    <div class="col-md-8 col-sm-8 col-xs-8">
                        <h2 style="font-family: 'Trebuchet MS';" id="h1institute" runat="server">Payment Invoice</h2>
                        <h6 style="font-family: 'Trebuchet MS';" id="h1" runat="server"></h6>
                        <h6 style="font-family: 'Trebuchet MS';" id="h2" runat="server"></h6>
                        <h6 style="font-family: 'Trebuchet MS';" id="h3" runat="server"></h6>
                    </div>
                </div>
            </div>
            <!--end container-fluid-->
            <div class="container btm-content">
                <!--start container-->
                <div class="row receipt-content">
                    <div class="col-md-6 col-sm-6 col-xs-6">
                        <h2 style="">Receipt No: 
            <asp:Label ID="lblreceiptno" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-6">
                        <h2 style="float: right;">Receipt Date: 
		                                <asp:Label ID="lblreceiptdate" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                </div>
                <div class="row top-details">
                    <div class="col-md-6 col-sm-6 col-xs-6  name">
                        <h3>Personal Details</h3>
                        <div class="table-responsive">
                            <table class="table" style="text-align: left;">
                                <tbody>
                                    <tr>
                                        <td>Admission number</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lbladdno" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Name</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblfirstname" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Father Name</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Class</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblcourse" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Category</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblcatg" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-6 pay-detail">
                        <h3>Total Fees Details</h3>
                        <div class="table-responsive">
                            <table class="table" style="text-align: center;">
                                <tbody>
                                    <tr>
                                        <td>Fee Amount</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblfeesamount" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Discount</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblDiscount" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Late Fee</td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lbltotallatefee" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Total Fees </td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lbltotalfees" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Now Paid </td>
                                        <td>:</td>
                                        <td>
                                            <asp:Label ID="lblnowpaid" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row bottom-details">
                    &nbsp; &nbsp;  <strong>Amount in Word : &nbsp;</strong><asp:Label ID="lblamount_word" runat="server" Text=""></asp:Label>
                </div>
                <div class="row bottom-details">
                    <div class="col-md-6 col-sm-6 col-xs-6 pay-detail">
                        <h3>Fee Transaction Details</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" Style="text-align: center;" ShowHeaderWhenEmpty="True" EmptyDataText="No Records Found.">
                                <Columns>
                                    <asp:TemplateField HeaderText="Fee Month">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcdc" runat="server" Text='<%#Eval("FeeMonth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbatch" runat="server" Text='<%#Eval("FeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fee Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcour" runat="server" Text='<%#Eval("FeeAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <!--start container-->
                <div class="container btm-content">
                    <div class="row terms">
                        <h3>Terms & Conditions</h3>
                        <ul>
                            <li>Fees once paid will not be Refunded or Transfer to other candidates.</li>
                        </ul>
                        <div class="table-responsive">
                            &nbsp; &nbsp;  <strong>Collected by : </strong>
                            <asp:Label ID="lblusername" runat="server"></asp:Label>
                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<strong> Signature &amp; Stamp</strong>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <!--start container-->
                    <div class="row butn">
                        <asp:Button ID="btnprint" class="btn btn-primary" runat="server" Text="Print" OnClientClick="myFunction()" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnback" class="btn btn-primary" runat="server" Text="Back" OnClick="btnback_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
