<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/Payment.master" AutoEventWireup="true" CodeBehind="OnlinePaymentByStudent.aspx.cs" Inherits="LMS.Learner.OnlinePaymentByStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <div>
                    <h5 style="text-align: start"><b>Personal Detail :</b></h5>
                    <font size="4">
                        <table width="80%" style="text-align: center">
                            <tr>
                                <td><b>Admission Number</b></td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblApplicationNumber" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Student Name</b></td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblStudentName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Father Name</b></td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Class</b></td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>Category</b></td>
                                <td>:</td>
                                <td>
                                    <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </font>
                </div>
                <div class="row stu-detail marg-top-off-form">
                    <!--personal details-->
                     <h5 style="text-align: start"><b>Payment Details :</b></h5>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="table-responsive">
                            <!--start table-->
                            <table class="table table-bordered table-hover" style="text-align: center;">
                                <tr>

                                    <td>
                                        <label for="name" class="cols-sm-2 control-label">Total  fee :</label></td>
                                    <td>:</td>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-inr" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txttotalfee" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="name" class="cols-sm-2 control-label">Now Paying</label></td>
                                    <td>:</td>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-inr" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtpayingnow" runat="server" CssClass="form-control" OnKeyPress="return isNumber(event)" MaxLength="14" ReadOnly="true"></asp:TextBox>

                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <label for="name" class="cols-sm-2 control-label">Late Fee Charge</label></td>
                                    <td>:</td>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-inr" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtlatefeecharge" runat="server" CssClass="form-control" MaxLength="14" OnKeyPress="return isNumber(event)" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label for="name" class="cols-sm-2 control-label">Grand Total</label></td>
                                    <td>:</td>
                                    <td>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-inr" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtgrandtotal" runat="server" CssClass="form-control" MaxLength="14" OnKeyPress="return isNumber(event)" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--end table-->
                    </div>

                </div>

                <div class="row">
                        <div class="col-sm-12"></div>
                        <div class="col-sm-12">
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />&nbsp;&nbsp;I have read and accepted the  <a class="Update" href="">terms and conditions</a>.
                       <div id="MyPopup" class="modal fade" role="dialog">
                           <div class="modal-dialog">
                               <div class="modal-content">
                                   <div class="modal-header">
                                       <button type="button" class="close" data-dismiss="modal">
                                           &times;</button>
                                       <h4 class="modal-title">Terms and Conditions
                                       </h4>
                                   </div>
                                   <div class="modal-body">
                                     <ul typeof="disc">
                                         <li>Transaction fee charges would not be refunded/ reversed under any circumstances for any refund/ reversal /chargeback and any other reasons.</li>
                                         <li>Transaction fees charged would be borne by cardholder for any payment.</li>
                                         <li>Fees once paid which are non-refundable for any reason or any clause of school / college</li>
                                         <li> Fees once paid will not be refunded, transferred to other course or other candidate.</li>
                                         <li>No refunds will be processed without original receipts</li>
                                         <li>Cancellation will only be processed after full payment only</li>
                                         <li>I hear by declare that for any refund/cancellation I will contact school / college only.</li>
                                         <li>Transaction fees charged would not be refunded/ reversed for any refund or reversal of any transaction</li>
                                         <li>Transaction fees charged would be borne by cardholder for any payment</li>
                                     </ul>
                                   </div>
                                   <div class="modal-footer">
                                       <input type="button" id="btnClosePopup" value="Close" class="btn btn-danger" data-dismiss="modal" />
                                   </div>
                               </div>
                           </div>
                       </div>
                            <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
                            <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
                            <script type="text/javascript">
                                $(function () {
                                    $("a[class='Update']").click(function () {
                                        $("#MyPopup").modal("show");
                                        return false;
                                    });
                                });
                            </script>

                        </div>
                        <div class="col-sm-12">
                            <br />
                            <br />
                        </div>
                    </div>

                   <div class="row">
                        &nbsp;  &nbsp;  &nbsp;
                          <asp:Button ID="btnpaynow" runat="server" CssClass="btn btn-success" Text="PAY" ValidationGroup="submit"  autopostback="true" Width="40%" OnClick="btnpaynow_Click" />

                        &nbsp;  &nbsp;  
             <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-success " Text="CANCEL" autopostback="true" Width="40%" OnClick="btnCancel_Click"  />
                    </div>
                <div class="row">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-sm-6">
                <h5 style="text-align: start"><b>Fees Details :</b></h5>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="table-responsive">
                        <!--start table-->
                        <table class="table table-bordered table-hover" style="text-align: center;" id="tblFee" runat="server">
                            <tr>
                                <th>Fee Type(Month)</th>
                                <th>Fee Name</th>
                                <th>Fee Amount</th>
                                <th>Fee Head</th>
                            </tr>

                        </table>


                    </div>
                    <!--end table-->
                </div>
            </div>
        </div>
        <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script type="text/javascript">
            function OpenPaymentWindow(key, amountInSubunits, currency, clientname, descritpion, imageLogo, orderId, profileName, profileEmail, profileMobile, notes, courseAmount,q) {
                notes = $.parseJSON(notes);
                var options = {
                    "key": key, // Enter the Key ID generated from the Dashboard
                    "amount": amountInSubunits,
                    "currency": currency,
                    //"transfers": [
                    //    //{
                    //    //    "account": "JmmX8HOUATFMzF",
                    //    //    "amount": courseAmount,
                    //    //    "currency": "INR",
                    //    //    "notes": {
                    //    //        "branch": "Old Panvel Branch",
                    //    //        "name": "Raj Ramchandra Singh"
                    //    //    },
                    //    //    "linked_account_notes": [
                    //    //        "branch"
                    //    //    ],
                    //    //    "on_hold": 0
                    //    //},
                    //    {
                    //        "account": "acc_JmmX8HOUATFMzF",
                    //        "amount": exitAmount,
                    //        "currency": "INR",
                    //        "notes": {
                    //            "branch": "CBD Belapur",
                    //            "name": "Raj Ramchandra Singh"
                    //        },
                    //        "linked_account_notes": [
                    //            "branch"
                    //        ],
                    //        "on_hold": 0
                    //    }
                    //],
                    "name": clientname,
                    "description": descritpion,
                    "image": imageLogo,
                    "order_id": orderId,
                    "handler": function (response) {

                        window.location.href = "RazorFundTransferSuccessNew.aspx?orderId=" + response.razorpay_order_id + "&paymentId=" + response.razorpay_payment_id + "&signature=" + response.razorpay_signature+"&q="+q;

                    },
                    "prefill": {
                        "name": profileName,
                        "email": profileEmail,
                        "contact": profileMobile
                    },
                    "notes": notes,
                    "theme": {
                        "color": "#F37254"
                    }
                };
                var rzp1 = new Razorpay(options);
                rzp1.open();
                rzp1.on('payment.failed', function (response) {
                    console.log(response.error);
                    alert(response.error.code);
                    alert(response.error.description);
                    alert(response.error.source);
                    alert(response.error.step);
                    alert(response.error.reason);
                    alert(response.error.metadata.order_id);
                    alert(response.error.metadata.payment_id);
                    alert("Oops, something went wrong and payment failed. Please try again later");
                });
            }
        </script>
    </div>
</asp:Content>
