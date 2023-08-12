<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Exam.master" AutoEventWireup="true" CodeBehind="CreateQuestionPaper.aspx.cs" Inherits="LMS.Trainee.CreateQuestionPaper" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <head>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <%--<script src="jquery-3.6.0.min.js" type="text/javascript"></script>--%>
        <script src="https://code.jquery.com/jquery-3.1.1.min.js"> </script>
        <style type="text/css">
            .modalBackground {
                height: 100%;
                background-color: black;
                filter: alpha(opacity=20);
                opacity: 0.7;
            }
            .columnwidth
             {
                 width: 14.29%;
             }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3">
                <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlDepartmentStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentStandard_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Department / Standard" InitialValue="0" ValidationGroup="createQuestionPaper" ControlToValidate="ddlDepartmentStandard" runat="server" ForeColor="Red" />
                </div>
            </div>
             <div class="col-sm-3">
                <label>Select Subject</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlSubjectCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectCourse_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Select Subject / Course" InitialValue="0" ValidationGroup="createQuestionPaper" ControlToValidate="ddlSubjectCourse" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label>Select Exam</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlExam" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Exam" InitialValue="0" ValidationGroup="createQuestionPaper" ControlToValidate="ddlExam" runat="server" ForeColor="Red" />
                </div>
            </div>
           
            <div class="col-sm-3">
                <label></label>

                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="btnStartExam" runat="server" ValidationGroup="createQuestionPaper" Style="background-color: #28a745; color: #fff; left: 0px; top: 1px;" Text="Get Questions" OnClick="btnStartExam_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="row">
                    <label>Add Question</label>
                </div>

                <div class="row">
                    <div class="col-sm-6">
                        <label>Untitled Question</label>

                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtQuestion" runat="server" placeholder="Enter Question"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="AddQuestion" ErrorMessage="Enter Question" ControlToValidate="txtQuestion" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Select Answer Type</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlQuestionAnswerType" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Select Question's answer type" ValidationGroup="AddQuestion" InitialValue="0" ControlToValidate="ddlQuestionAnswerType" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-10">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="viewShortAnswer" runat="server">
                                <div class="card">
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm">
                                            <label>Apply Validation</label>

                                            <div class="form-group">
                                                <asp:CheckBox ID="chktext" runat="server" />&nbsp;&nbsp;Required
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label>Answer Type</label>

                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="ddlValidationAnswertype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <asp:DropDownList class="form-control" ID="DropDownList6" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <asp:MultiView ID="mltvalidation" runat="server">
                                                    <asp:View ID="vewNumber" runat="server">
                                                        <div class="card">
                                                            <div class="row">
                                                                <div class="col-sm">
                                                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Value to Compare" TextMode="Number"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:View>
                                                    <asp:View ID="vewbetween" runat="server">
                                                        <div class="card">
                                                            <div class="row">
                                                                <div class="col-sm">
                                                                    <asp:TextBox CssClass="form-control" ID="txtfrom" runat="server" placeholder="Enter start range value" TextMode="Number"></asp:TextBox>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp; And &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:TextBox CssClass="form-control" ID="txttill" runat="server" placeholder="Enter end range value" TextMode="Number"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:View>
                                                    <asp:View ID="vewtext" runat="server">
                                                        <div class="card">
                                                            <div class="row">
                                                                <div class="col-sm">
                                                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter Value to Compare"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </asp:View>
                                                </asp:MultiView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtcustomerrormessage" runat="server" placeholder="Enter Error Message"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm">
                                            <label>Enter Correct Answer</label>

                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtCorrectAnswer" runat="server" placeholder="Enter Correct Answer"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Correct Answer" ControlToValidate="txtCorrectAnswer" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="viewParagraph" runat="server">
                                <div class="card">
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="" TextMode="MultiLine" ReadOnly="true" Rows="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm">
                                            <label>Apply Validation</label>

                                            <div class="form-group">
                                                <asp:CheckBox ID="chkmultitext" runat="server" />&nbsp;&nbsp;Required
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="ViewMultipleChoice" runat="server">
                                <div class="card">
                                    <div class="row">
                                        <div class="col-sm-10" style="overflow:scroll;max-height:250px">
                                            <table class="table" id="maintable" style="border: hidden">
                                                <thead>
                                                    <tr>
                                                        <th>Correct Option</th>
                                                        <th>Enter Options</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr class="data-contact-person">
                                                        <td style="width: 20px">
                                                            <input type="checkbox" id="contactChoice3" name="contact" value="1">
                                                        </td>
                                                        <td>
                                                            <input type="text" name="f-name" class="form-control f-name01" /></td>
                                                        <td>
                                                            <button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add More</button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="col-sm-4">
                                            <label>Apply Validation</label>

                                            <div class="form-group">
                                                <asp:CheckBox ID="chkmultipleoptions" runat="server" />&nbsp;&nbsp;Required
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="viewUploadFiles" runat="server">
                                <div class="card">
                                    <div class="row">
                                        <div class="col-sm-9">
                                            <asp:FileUpload ID="FileUpload1" Enabled="false" runat="server" />
                                        </div>
                                        <div class="col-sm-4">
                                            <label>Apply Validation</label>

                                            <div class="form-group">
                                                <asp:CheckBox ID="chkuploadfile" runat="server" />&nbsp;&nbsp;Required
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <%--<asp:View ID="viewCheckBoxes" runat="server"></asp:View>
                    <asp:View ID="viewDropdown" runat="server"></asp:View>
                    <asp:View ID="viewDate" runat="server"></asp:View>--%>
                        </asp:MultiView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label>Enter Marks </label>

                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtMarks" runat="server" placeholder="Enter Marks"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddQuestion" runat="server" ErrorMessage="Enter Marks For Question" ControlToValidate="txtMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="col-sm-12">
                        <asp:MultiView ID="MultiAnswer" runat="server">
                            <asp:View ID="textAnswer" runat="server">
                                <div class="card">
                                    <div class="row">
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View1" runat="server">
                                <table class="table" id="optionstable" style="border: hidden">
                                    <thead>
                                        <tr>
                                            <th>Select Correct Options</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="data-contact-person">
                                            <td>
                                                <input type="radio" id="contactChoice3" name="contact" value="Option-1">
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:View>
                        </asp:MultiView>

                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-md pull-right btn-sm" Text="Submit" Style="color: white" OnClick="btnSubmit_Click" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" />
                        <%-- <button type="button" id="btnSubmit" class="btn btn-primary btn-md pull-right btn-sm" style="color: white">Submit</button>--%>
                        <asp:HiddenField ID="inpHide" runat="server" />
                        <asp:HiddenField ID="checkedId" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
               <%--<div class="row">
                   <div class="col-md-flex">
                    <asp:Button ID="btnListDelete" CssClass="btn btn-primary" runat="server" Text="Delete Question" OnClick="btnListDelete_Click"/>&nbsp;&nbsp;&nbsp;
                    </div>
               </div>--%>
                <br />
                <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                    AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Sr No." DataField="Id" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:BoundField HeaderText="Question" DataField="Question" />
                        <asp:BoundField HeaderText="Option's" DataField="QuestionOptionMetaData" />
                        <asp:BoundField HeaderText="Answer" DataField="CorrectOption" />
                        <asp:BoundField HeaderText="Answer Type" DataField="AnswerTypeName" />
                        <asp:BoundField HeaderText="Marks" DataField="Marks" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Is Required" DataField="IsRequired" />
                        <%--<asp:BoundField HeaderText="Action" />--%>
                         <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                             <ItemTemplate>
                                 <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                             </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="LkB11" runat="server" CommandName="DeleteRow" Text="Delete" CssClass="btn btn-danger" OnClick="imgdeletebtn_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:LinkButton>
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
                <br />
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopuptwo" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
             <div class="row"  style="margin:0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color:#bae7e3">
                               <table>
                                <tr>
                                <td height="50px"> <span Font-Size="Medium" color="black"><b>Delete Lesson</b></span> </td>
                                </tr>
                                </table>
                             </div>
                        </div>
                    <div style=" padding: 10px;box-shadow: 0px 0px 0px #888888;text-align:center;width:390px" BackColor="White">
                        
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <br>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <font size="4">Are you Sure? You want to delete</font>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" ><br></div>
                            <div class="col-sm-1" ></div>
                            <div class="col-sm-3" align="left">
                                
                             </div>
                            <div class="col-sm-8" align="left">
                                <asp:Button ID="Button1" CssClass="btn btn-success float-end" BorderColor="White" ForeColor="White" CommandName="Delete" runat="server" Text="Yes" onclick="btnDelete_Click"/>
                                    <asp:Button ID="btnCancel" runat="server" Text="No" class="btn btn-danger float-end" BorderColor="White" ForeColor="White" />
                             </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>

    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            $(document).on("click", ".classAdd", function () { //on is used for getting click event for dynamically created buttons

                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
                    '<td><input type="checkbox" id="contactChoice' + rowCount + '" name="contact" value="' + rowCount + '">' +
                    '<td><input type="text" name="f-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add More</button>&nbsp;&nbsp;' +
                    '&nbsp;&nbsp;<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                    '</tr>';
                $('#maintable').append(contactdiv); // Adding these controls to Main table class

                //var optiondiv = '<tr class="data-contact-person">' +
                //    '<td><input type="radio" id="contactChoice' + rowCount + '" name="contact" value="Option-' + rowCount + '">' +
                //    '&nbsp;&nbsp;<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                //    '</tr>';
                //$('#optionstable').append(optiondiv);
            });

            $(document).on("click", ".deleteContact", function () {
                $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls 
            });
            //$(document).on("click", "", function () {
            //    $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls 
            //});

            $("#btnSubmit").click(function () {
                var data = JSON.stringify(getAllEmpData());
                //console.log(data);
                document.getElementById('<%= inpHide.ClientID%>').value = data;
            });
        });
        function getAllEmpData() {
            debugger;
            var data = [];
            $('tr.data-contact-person').each(function () {
                var firstName = $(this).find('.f-name01').val();
                var alldata = {
                    'Option': firstName
                }
                data.push(alldata);
            });
            console.log(data);
            return data;
        }
        function ValidateAge() {
            debugger;
            var data = JSON.stringify(getAllEmpData());
            //console.log(data);
            document.getElementById('<%= inpHide.ClientID%>').value = data;

            var x = document.getElementsByName("contact");
            var i;
            var m = [];
            for (i = 0; i < x.length; i++) {
                if (x[i].checked == true) {
                    m.push(x[i].value);

                }
            }
            document.getElementById('<%= checkedId.ClientID%>').value = m.toString();

        }
    </script>
    <script type="text/javascript" src="//cdn.jsdelivr.net/jquery/1/jquery.min.js"></script>
    <link media="screen" rel="stylesheet" type="text/css" href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script type="text/javascript">
        function showpop1(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }
    </script>
    <%--//for chatprocess of client--%>
    <script type="text/javascript">
        function showpop5(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.success(msg, title);
            return false;
        }
    </script>
    <%--for chat process of consultant--%>
    <script type="text/javascript">
        function showpop6(msg, title) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.error(msg, title);
            return false;
        }
    </script>
</asp:Content>
