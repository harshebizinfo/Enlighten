<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionPaper.aspx.cs" Inherits="LMS.Learner.QuestionPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LMS</title>
    <link href="../css/style.css" rel="stylesheet" />
    <style type="text/css">
        .rbListWrap {
            /*width: 100px;*/
        }

            .rbListWrap tr td {
                height: 20px;
                vertical-align: top;
                padding: 5px;
            }

            .rbListWrap input {
                float: left;
            }

            .rbListWrap label {
                position: initial;
                padding-left: 20px;
            }

        .auto-style1 {
            font-size: x-large;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
    $(function () {
        $(document).keydown(function (e) {
            return (e.which || e.keyCode) != 116;
        });
    });
    </script>
    <script type="text/javascript">  
    window.onload = function () {
        document.onkeydown = function (e) {
            return (e.which || e.keyCode) != 116;
        };
    }
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.js"></script>
    <script type="text/javascript" src="jquery.idle-timer.js"></script>
    <script type="text/javascript">

    $(function () {
        var timeout = 120000;
        $(document).bind("idle.idleTimer", function () {
            /*alert("You are not active since " + (timeout / 1000) + " secs")*/
            $find('RequoteModal').show();
        });
        //$(document).bind("active.idleTimer", function () {
        //    alert("user idle for more than secs")
        //});
        $.idleTimer(timeout);
    });
    </script>
    <script type="text/javascript">
    window.addEventListener('blur', function (e) {
        alert("abc " + (timeout / 1000) + " secs")
    });
    </script>
</head>
<body onkeydown="return (event.keyCode != 116)">
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="card" style="background-color: #bae7e3">
                    <div class="row">
                        <div class="col-sm-12 text-center h1">
                            <asp:Label ID="lblClientName" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-12 text-center h4">
                            <asp:Label ID="lblusername" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3"></div>
                        <div class="col-sm-2 h5">
                            <b>Department/Standard :</b>
                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2 h5">
                            <b>Course/Subject :</b>
                            <asp:Label ID="lblSubject" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-2 h5">
                            <b>Exam :</b>
                            <asp:Label ID="lblExam" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-3"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <br />
                    </div>
                    <div class="col-sm-12">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                   
                                    <asp:Timer ID="Timer1" runat="server" OnTick="timer1_Tick" Interval="1000"></asp:Timer>
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        <asp:Timer ID="Timer2" runat="server" Interval="1000" OnTick="Timer2_Tick">
                        </asp:Timer>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="col-sm-2">
                                        <strong>
                                            <asp:Label ID="lblMinute" runat="server" CssClass="auto-style1"></asp:Label>
                                            <asp:Label ID="lblcolon" runat="server" CssClass="auto-style1" Text=":"></asp:Label>
                                            <asp:Label ID="lblSecond" runat="server" CssClass="auto-style1"></asp:Label>
                                        </strong>
                                    </div>
                                    <div class="col-sm-8">
                                        <asp:Label runat="server" ID="lblmultiViewActiveIndexId" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                    <div class="col-sm-2" style="text-align: right;">
                                       Number of Question :  <asp:Label ID="lblmultiViewId" runat="server" CssClass="auto-style1"></asp:Label><br>
                                       Attainding Question :  <asp:Label ID="lblPer1" runat="server" CssClass="auto-style1"></asp:Label>
                                       <%-- <div class="progress" style="height:30px">
                                            <div class="progress-bar" runat="server" id="divprogress1">
                                                <asp:Label ID="lblPer1" runat="server"></asp:Label>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                    <div class="col-sm-9"></div>
                    <%--<div class="col-sm-1">
                           <asp:Label ID="lblcurrentSequence" runat="server" CssClass="auto-style1"></asp:Label> 
                           <asp:Label ID="lblbackslash" runat="server" CssClass="auto-style1" Text="/"></asp:Label>
                           <asp:Label ID="lbllastSequence"  CssClass="auto-style1" runat="server"></asp:Label>
                       </div>--%>
                    <div class="col-sm-12">
                    </div>
                    <div class="col-sm-12 justify-content-end">
                        <br />
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6 text-center">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-sm-9 text-xl-left h4">
                                            Question :
                                            <asp:Label ID="lblQuestion" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:MultiView ID="MultiView1" runat="server">
                                                <asp:View ID="ViewshortAnswer" runat="server">
                                                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                                                </asp:View>
                                                <asp:View ID="ViewPawagraph" runat="server">
                                                    <asp:TextBox ID="txtparagraph" runat="server" Rows="4"></asp:TextBox>
                                                </asp:View>
                                                <asp:View ID="ViewUploadImage" runat="server">
                                                    <%-- <asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" AllowMultiple="false"/>
                                                    <%--<asp:Button ID="btnAsyncUpload" runat="server" Text="Async_Upload" OnClick="btnAsyncUpload_Click"  />--%>
                                                    <br />
                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                                    <br>
                                                    <strong>
                                                    <asp:Label ID="lblUploadSucess" runat="server" ForeColor="#009933" Text="File Uploaded Sucessfully" Visible="False"></asp:Label>
                                                    </strong>
                                                </asp:View>
                                                <asp:View ID="ViewMultipleChoice" runat="server">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="12pt" CssClass="rbListWrap"></asp:RadioButtonList>
                                                </asp:View>
                                                <asp:View ID="ViewCheckBox" runat="server">
                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="rbListWrap"></asp:CheckBoxList>
                                                </asp:View>
                                                <asp:View ID="Viewdropdown" runat="server">
                                                    <asp:DropDownList ID="ddlanswer" runat="server"></asp:DropDownList>
                                                </asp:View>
                                            </asp:MultiView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <br />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 text-center">
                                            <asp:MultiView ID="mltbutton" runat="server">
                                                <asp:View ID="ViewNext" runat="server">
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-sm-3"></div>
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnNextQuestion" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Next" Style="color: white" OnClick="btnNextQuestion_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:View>
                                                <asp:View ID="Viewnextprev" runat="server">
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnPrevious" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Previous" Style="color: white" OnClick="btnPrevious_Click" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnNext" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Next" Style="color: white" OnClick="btnNext_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:View>
                                                <asp:View ID="Viewprevsubmit" runat="server">
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnprevi" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Previous" Style="color: white" OnClick="btnprevi_Click" />
                                                            </div>
                                                            <div class="col-sm-3">
                                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Submit" Style="color: white" OnClick="btnSubmit_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:View>
                                            </asp:MultiView>
                                        </div>

                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:AsyncPostBackTrigger ControlID="btnAsyncUpload"
                                    EventName="Click" />--%>
                                <asp:PostBackTrigger ControlID="btnUpload" />

                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none" />
                        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" Style="display: none" />
                    </div>
                </div>
            </div>
        </div>
        <%--<asp:Button ID="btnShowPopup" runat="server" Style="" />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Width="400px" Style="">
            <div style="">
                <div class="row">
                    <div class="col-sm-12" align="left" style="">
                        <table>
                            <tr>
                                <td height="50px"><span font-size="Medium" color="black"><b>Update Course / Subject</b></span> </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <br>
                    </div>
                    <div class="col-sm-1"></div>
                    <div class="col-sm-3" align="left">
                    </div>
                    <div class="col-sm-8" align="right">
                        
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger float-end" BackColor="#dc3545" BorderColor="Black" ForeColor="White" />
                    </div>
                </div>
            </div>
        </asp:Panel>--%>

        <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" BehaviorID="RequoteModal" DropShadow="false">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlpopuptwo" runat="server" BackColor="White" Width="400px" Style="display: none; background-color: white; padding-top: 10px; padding-left: 0px; border: 5px solid white; border-radius: 20px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
            <div style="padding: 10px; box-shadow: 5px 10px 18px #888888; text-align: center; width: 390px">
                <div class="row">
                    <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                        <table>
                            <tr>
                                <td height="50px"><span font-size="Medium" color="black"><b>System is IDLE</b></span> </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12" align="center">
                        <br>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12" align="center">
                        Your system is in Idle mode. you have not done any movement since last 2 mins
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <br>
                    </div>
                    <div class="col-sm-1"></div>
                    <div class="col-sm-3" align="left">
                    </div>
                    <div class="col-sm-8" align="left">
                        <%--<asp:Button ID="Button3" CssClass="btn btn-danger float-end" BackColor="#dc3545" BorderColor="Black" ForeColor="White" CommandName="Delete" runat="server" Text="Delete" onclick="btnDelete_Click"/>--%>
                        <asp:Button ID="btnCancel" runat="server" Text="OK" class="btn btn-danger float-end" OnClick="Button4_Click" BorderColor="Black" ForeColor="White" />
                    </div>
                </div>
            </div>
        </asp:Panel>

    </form>
    <script>
    window.addEventListener('blur', function (e) {
        debugger;
        var value = document.getElementById('<%= HiddenField1.ClientID%>').value; /*$("#HiddenField1").text();*/
        if (value != '2') {
            document.getElementById('<%= Button1.ClientID %>').click();
        }
    });
    window.addEventListener('beforeunload', function (e) {

        document.getElementById('<%= Button2.ClientID %>').click();
            <%--document.getElementById('<%# Button1 %>').click();--%>

    });
    </script>
    <script type="text/javascript">
    function promptName() {
        document.getElementById('<%= Button2.ClientID %>').click();
        /*return userName;*/
    }

    </script>
</body>
</html>
