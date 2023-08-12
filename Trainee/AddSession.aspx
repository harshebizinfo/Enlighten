<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Lesson.master" AutoEventWireup="true" CodeBehind="AddSession.aspx.cs" Inherits="LMS.Trainee.AddSession" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card">
        <div class="row">
            <div class="col-sm-12">
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Title</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtTitle" runat="server" placeholder="Enter Title"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="event" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Description</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Enter Description"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="event" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Location</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtLocation" runat="server" placeholder="Enter Location"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Location" ControlToValidate="txtLocation" ValidationGroup="event" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Start Date</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtStartDate" runat="server" placeholder="Enter Start Date" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtStartDate" Format="yyyy-MM-dd"> </asp:CalendarExtender> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Start Date" ControlToValidate="txtStartDate" ValidationGroup="event" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Start Time</label>

                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2">
                            Hours</div>
                        <div class="col-sm-4">
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                    <asp:ListItem Text="HH" Value="HH" />
                    <asp:ListItem Text="00" Value="00" />
                    <asp:ListItem Text="01" Value="01" />
                    <asp:ListItem Text="02" Value="02" />
                    <asp:ListItem Text="03" Value="03" />
                    <asp:ListItem Text="04" Value="04" />
                    <asp:ListItem Text="05" Value="05" />
                    <asp:ListItem Text="06" Value="06" />
                    <asp:ListItem Text="07" Value="07" />
                    <asp:ListItem Text="08" Value="08" />
                    <asp:ListItem Text="09" Value="09" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                    <asp:ListItem Text="13" Value="13" />
                    <asp:ListItem Text="14" Value="14" />
                    <asp:ListItem Text="15" Value="15" />
                    <asp:ListItem Text="16" Value="16" />
                    <asp:ListItem Text="17" Value="17" />
                    <asp:ListItem Text="18" Value="18" />
                    <asp:ListItem Text="19" Value="19" />
                    <asp:ListItem Text="20" Value="20" />
                    <asp:ListItem Text="21" Value="21" />
                    <asp:ListItem Text="22" Value="22" />
                    <asp:ListItem Text="23" Value="23" />
                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Select Start Hour" InitialValue="HH" ControlToValidate="DropDownList1" ValidationGroup="event" runat="server" ForeColor="Red" />
                        </div>
                        <div class="col-sm-2">
                            Minutes</div>
                        <div class="col-sm-4">
                 <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                     <asp:ListItem Text="MM" Value="MM" />
                     <asp:ListItem Text="00" Value="00" />
                     <asp:ListItem Text="01" Value="01" />
                     <asp:ListItem Text="02" Value="02" />
                     <asp:ListItem Text="03" Value="03" />
                     <asp:ListItem Text="04" Value="04" />
                     <asp:ListItem Text="05" Value="05" />
                     <asp:ListItem Text="06" Value="06" />
                     <asp:ListItem Text="07" Value="07" />
                     <asp:ListItem Text="08" Value="08" />
                     <asp:ListItem Text="09" Value="09" />
                     <asp:ListItem Text="10" Value="10" />
                     <asp:ListItem Text="11" Value="11" />
                     <asp:ListItem Text="12" Value="12" />
                     <asp:ListItem Text="13" Value="13" />
                     <asp:ListItem Text="14" Value="14" />
                     <asp:ListItem Text="15" Value="15" />
                     <asp:ListItem Text="16" Value="16" />
                     <asp:ListItem Text="17" Value="17" />
                     <asp:ListItem Text="18" Value="18" />
                     <asp:ListItem Text="19" Value="19" />
                     <asp:ListItem Text="20" Value="20" />
                     <asp:ListItem Text="21" Value="21" />
                     <asp:ListItem Text="22" Value="22" />
                     <asp:ListItem Text="23" Value="23" />
                     <asp:ListItem Text="24" Value="24" />
                     <asp:ListItem Text="25" Value="25" />
                     <asp:ListItem Text="26" Value="26" />
                     <asp:ListItem Text="27" Value="27" />
                     <asp:ListItem Text="28" Value="28" />
                     <asp:ListItem Text="29" Value="29" />
                     <asp:ListItem Text="30" Value="30" />
                     <asp:ListItem Text="31" Value="31" />
                     <asp:ListItem Text="32" Value="32" />
                     <asp:ListItem Text="33" Value="33" />
                     <asp:ListItem Text="34" Value="34" />
                     <asp:ListItem Text="35" Value="35" />
                     <asp:ListItem Text="36" Value="36" />
                     <asp:ListItem Text="37" Value="37" />
                     <asp:ListItem Text="38" Value="38" />
                     <asp:ListItem Text="39" Value="39" />
                     <asp:ListItem Text="40" Value="40" />
                     <asp:ListItem Text="41" Value="41" />
                     <asp:ListItem Text="42" Value="42" />
                     <asp:ListItem Text="43" Value="43" />
                     <asp:ListItem Text="44" Value="44" />
                     <asp:ListItem Text="45" Value="45" />
                     <asp:ListItem Text="46" Value="46" />
                     <asp:ListItem Text="47" Value="47" />
                     <asp:ListItem Text="48" Value="48" />
                     <asp:ListItem Text="49" Value="49" />
                     <asp:ListItem Text="50" Value="50" />
                     <asp:ListItem Text="51" Value="51" />
                     <asp:ListItem Text="52" Value="52" />
                     <asp:ListItem Text="53" Value="53" />
                     <asp:ListItem Text="54" Value="54" />
                     <asp:ListItem Text="55" Value="55" />
                     <asp:ListItem Text="56" Value="56" />
                     <asp:ListItem Text="57" Value="57" />
                     <asp:ListItem Text="58" Value="58" />
                     <asp:ListItem Text="59" Value="59" />
                 </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Select Start Minute" InitialValue="MM" ControlToValidate="DropDownList2" ValidationGroup="event" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <label>End Date</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtEndDate" runat="server" placeholder="Enter End Date" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEndDate" Format="yyyy-MM-dd"> </asp:CalendarExtender> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter End Date" ControlToValidate="txtEndDate" ValidationGroup="event" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>End Time</label>
                <div class="form-group">
                     <div class="row">
                        <div class="col-sm-2">
                            Hours</div>
                        <div class="col-sm-4">
                <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                    <asp:ListItem Text="HH" Value="HH" />
                    <asp:ListItem Text="00" Value="00" />
                    <asp:ListItem Text="01" Value="01" />
                    <asp:ListItem Text="02" Value="02" />
                    <asp:ListItem Text="03" Value="03" />
                    <asp:ListItem Text="04" Value="04" />
                    <asp:ListItem Text="05" Value="05" />
                    <asp:ListItem Text="06" Value="06" />
                    <asp:ListItem Text="07" Value="07" />
                    <asp:ListItem Text="08" Value="08" />
                    <asp:ListItem Text="09" Value="09" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="11" Value="11" />
                    <asp:ListItem Text="12" Value="12" />
                    <asp:ListItem Text="13" Value="13" />
                    <asp:ListItem Text="14" Value="14" />
                    <asp:ListItem Text="15" Value="15" />
                    <asp:ListItem Text="16" Value="16" />
                    <asp:ListItem Text="17" Value="17" />
                    <asp:ListItem Text="18" Value="18" />
                    <asp:ListItem Text="19" Value="19" />
                    <asp:ListItem Text="20" Value="20" />
                    <asp:ListItem Text="21" Value="21" />
                    <asp:ListItem Text="22" Value="22" />
                    <asp:ListItem Text="23" Value="23" />
                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Select End Hour" InitialValue="HH" ControlToValidate="DropDownList3" ValidationGroup="event" runat="server" ForeColor="Red" />
                        </div>
                        <div class="col-sm-2">
                            Minutes</div>
                        <div class="col-sm-4">
                 <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                     <asp:ListItem Text="MM" Value="MM" />
                     <asp:ListItem Text="00" Value="00" />
                     <asp:ListItem Text="01" Value="01" />
                     <asp:ListItem Text="02" Value="02" />
                     <asp:ListItem Text="03" Value="03" />
                     <asp:ListItem Text="04" Value="04" />
                     <asp:ListItem Text="05" Value="05" />
                     <asp:ListItem Text="06" Value="06" />
                     <asp:ListItem Text="07" Value="07" />
                     <asp:ListItem Text="08" Value="08" />
                     <asp:ListItem Text="09" Value="09" />
                     <asp:ListItem Text="10" Value="10" />
                     <asp:ListItem Text="11" Value="11" />
                     <asp:ListItem Text="12" Value="12" />
                     <asp:ListItem Text="13" Value="13" />
                     <asp:ListItem Text="14" Value="14" />
                     <asp:ListItem Text="15" Value="15" />
                     <asp:ListItem Text="16" Value="16" />
                     <asp:ListItem Text="17" Value="17" />
                     <asp:ListItem Text="18" Value="18" />
                     <asp:ListItem Text="19" Value="19" />
                     <asp:ListItem Text="20" Value="20" />
                     <asp:ListItem Text="21" Value="21" />
                     <asp:ListItem Text="22" Value="22" />
                     <asp:ListItem Text="23" Value="23" />
                     <asp:ListItem Text="24" Value="24" />
                     <asp:ListItem Text="25" Value="25" />
                     <asp:ListItem Text="26" Value="26" />
                     <asp:ListItem Text="27" Value="27" />
                     <asp:ListItem Text="28" Value="28" />
                     <asp:ListItem Text="29" Value="29" />
                     <asp:ListItem Text="30" Value="30" />
                     <asp:ListItem Text="31" Value="31" />
                     <asp:ListItem Text="32" Value="32" />
                     <asp:ListItem Text="33" Value="33" />
                     <asp:ListItem Text="34" Value="34" />
                     <asp:ListItem Text="35" Value="35" />
                     <asp:ListItem Text="36" Value="36" />
                     <asp:ListItem Text="37" Value="37" />
                     <asp:ListItem Text="38" Value="38" />
                     <asp:ListItem Text="39" Value="39" />
                     <asp:ListItem Text="40" Value="40" />
                     <asp:ListItem Text="41" Value="41" />
                     <asp:ListItem Text="42" Value="42" />
                     <asp:ListItem Text="43" Value="43" />
                     <asp:ListItem Text="44" Value="44" />
                     <asp:ListItem Text="45" Value="45" />
                     <asp:ListItem Text="46" Value="46" />
                     <asp:ListItem Text="47" Value="47" />
                     <asp:ListItem Text="48" Value="48" />
                     <asp:ListItem Text="49" Value="49" />
                     <asp:ListItem Text="50" Value="50" />
                     <asp:ListItem Text="51" Value="51" />
                     <asp:ListItem Text="52" Value="52" />
                     <asp:ListItem Text="53" Value="53" />
                     <asp:ListItem Text="54" Value="54" />
                     <asp:ListItem Text="55" Value="55" />
                     <asp:ListItem Text="56" Value="56" />
                     <asp:ListItem Text="57" Value="57" />
                     <asp:ListItem Text="58" Value="58" />
                     <asp:ListItem Text="59" Value="59" />
                 </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Select End Minutes" InitialValue="MM" ControlToValidate="DropDownList4" ValidationGroup="event" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Color</label>

                <div class="form-group">
                    <asp:DropDownList ID="ddlColors" runat="server" class="form-control">
                        <asp:ListItem Text="Select Colour" Value="0" />
                        <asp:ListItem Text="Blue" Value="1" />
                        <asp:ListItem Text="Green" Value="2" />
                        <asp:ListItem Text="Purple" Value="3" />
                        <asp:ListItem Text="Red" Value="4" />
                        <asp:ListItem Text="Yellow" Value="5" />
                        <asp:ListItem Text="Orange" Value="6" />
                        <asp:ListItem Text="Turquoise" Value="7" />
                        <asp:ListItem Text="Grey" Value="8" />
                        <asp:ListItem Text="Bold Blue" Value="9" />
                        <asp:ListItem Text="Bold Green" Value="10" />
                        <asp:ListItem Text="Bold Red" Value="11" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Text="Select Color" InitialValue="0" ControlToValidate="ddlColors" ValidationGroup="event" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Reminder through</label>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-3"><asp:CheckBox ID="chkPopup" runat="server" Text="PopUp" /></div>
                        <div class="col-sm-3"><asp:CheckBox ID="chkEmail" runat="server" Text="Email" /></div>
                    </div>
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
                <label>Select Frequency</label>
                <div class="form-group">
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" class="form-control">
                        <asp:ListItem Text="Select Frequency" Value="0" />
                        <asp:ListItem Text="Daily" Value="DAILY" />
                        <asp:ListItem Text="Weekly" Value="WEEKLY" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Text="Select Frequency" InitialValue="0" ControlToValidate="DropDownList5" ValidationGroup="event" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-8">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div class="row">
                            <div class="col-sm-3">Select Days :</div>
                            <div class="col-sm-8">
                                <asp:CheckBox ID="chkSunday" runat="server" Text="Sunday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkMonday" runat="server" Text="Monday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkTuesday" runat="server" Text="Tuesday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkWednesday" runat="server" Text="Wednesday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkThursday" runat="server" Text="Thursday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkFriday" runat="server" Text="Friday" />&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chkSaturday" runat="server" Text="Saturday" />
                            </div>
                            <div class="col-sm-3">
                                Enter Till Date :
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtTillDate" runat="server" CssClass="form-control" placeholder="Enter Till Date" autocomplete="off"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="txtTillDate" Format="yyyy-MM-dd"> </asp:CalendarExtender>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <table class="table" id="maintable" style="border: hidden">
                    <thead>
                        <tr>
                            <th>Enter Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="data-contact-person">
                            <td>
                                <input type="text" name="f-name" class="form-control f-name01" /></td>
                            <td>
                                <button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add More</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
       
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-md-2">
                <div class="form-group">
                    <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" OnClientClick="ValidateAge()" ValidationGroup="event" OnClick="Button1_Click" />
                    <asp:HiddenField ID="inpHide" runat="server" />
                    <asp:HiddenField ID="checkedId" runat="server" />
                </div>
            </div>
            <div class="col-sm-1"></div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            $(document).on("click", ".classAdd", function () { //on is used for getting click event for dynamically created buttons

                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
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
</asp:Content>
