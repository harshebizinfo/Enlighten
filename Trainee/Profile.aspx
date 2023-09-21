<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Profile.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LMS.Trainee.Profile1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <asp:Button ID="btnPersonalDetail" runat="server" class="btn btn-primary" Text="Personal Info" OnClick="btnPersonalDetail_Click" />
                <asp:Button ID="btnEducation" runat="server" class="btn btn-primary" Text="Education" OnClick="btnEducation_Click" />
                <asp:Button ID="btnExperience" runat="server" class="btn btn-primary" Text="Experience" OnClick="btnExperience_Click" />
                <asp:Button ID="btnDocuments" runat="server" class="btn btn-primary" Text="Documents" OnClick="btnDocuments_Click" />
                <asp:Button ID="btnBankAccount" runat="server" class="btn btn-primary" Text="Bank Account" OnClick="btnBankAccount_Click" />
                <asp:Button ID="btnAssignStandard" runat="server" class="btn btn-primary" Text="Assign Standard" OnClick="btnAssignStandard_Click" />
            </div>
            <div class="col-sm-12">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="ViewPersonalDetail" runat="server">
                        <div class="">
                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>First Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Last Name</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Contact Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtContactNumber" runat="server" placeholder="Enter Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Email ID</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Email ID"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Father Name</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Enter Father Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Father Contact Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Enter Father Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Present Address</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Enter Present Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Present City</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Enter Present City"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Present State</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Enter Present State"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Permanent Address</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Enter Permanent Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Permanent City</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Enter Permanent City"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Permanent State</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Enter Permanent State"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Gender</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                            <asp:ListItem Text="Select Gender" Value="select" />
                                            <asp:ListItem Text="Male" Value="Male" />
                                            <asp:ListItem Text="Female" Value="Female" />
                                            <asp:ListItem Text="Others" Value="Others" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Adhaar Card Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Enter Adhaar Card Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>PAN Card Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Enter PAN Card Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewEducation" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Upload Educational File</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>

                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px"  ID="Button5" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                         <%--   <div class="row">
                                <div class="col-sm-12">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="gvFiles_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File Path">
                                                <ItemTemplate>
                                                    <a href='<%# Eval("FilePath") %>' target="_blank">Linked File</a>
                                                  </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No records found.</div>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" Height="30px" VerticalAlign="Middle" Font-Size="Medium" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </div>
                            </div>--%>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewExperience" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Upload Experience File</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button6" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button6_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button7" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewDocuments" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Upload Experience File</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                               <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="Button2" Width="150px" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button2_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="Button8" Width="150px" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewBankAccount" runat="server">
                        <div class="">
                            <br />
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Bank Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox26" runat="server" ReadOnly="true" placeholder="Enter First Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Account Number</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox27" runat="server" ReadOnly="true" placeholder="Enter Last Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>IFSC Code</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox28" runat="server" ReadOnly="true" placeholder="Enter Contact Number"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Account Holder Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtHolderName" runat="server" ReadOnly="true" placeholder="Enter Account Holder Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Nick Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtNickName" runat="server" ReadOnly="true" placeholder="Enter Nick Name"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <asp:Button class="btn btn-block" ID="Button3" Width="150px" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" />

                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <asp:Button class="btn btn-block" ID="Button4" Width="150px" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />

                                </div>
                            </div>
                            <br />
                        </div>
                    </asp:View>
                    <asp:View ID="ViewAssignStandard" runat="server">
                        <div class="">
                            <br />
                            <%--<div class="row">
                                <div class="col-sm-2">
                                    <label>Full Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox44" runat="server" placeholder="Enter Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Standard</label>
                                </div>
                                <div class="form-group col-sm-4">
                                    <asp:DropDownList class="form-control" ID="DropDownList17" runat="server">
                                        <asp:ListItem Text="Select Standard" Value="select" />
                                        <asp:ListItem Text="Nursery" Value="Nursery" />
                                        <asp:ListItem Text="Jr. Kg" Value="Jr. Kg" />
                                        <asp:ListItem Text="Sr. Kg" Value="Sr. Kg" />
                                        <asp:ListItem Text="1st" Value="1st" />
                                        <asp:ListItem Text="2nd" Value="2nd" />
                                        <asp:ListItem Text="3rd" Value="3rd" />
                                        <asp:ListItem Text="4th" Value="4th" />
                                        <asp:ListItem Text="5th" Value="5th" />
                                        <asp:ListItem Text="6th" Value="6th" />
                                        <asp:ListItem Text="7th" Value="7th" />
                                        <asp:ListItem Text="8th" Value="8th" />
                                        <asp:ListItem Text="9th" Value="9th" />
                                        <asp:ListItem Text="10th" Value="10th" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Subject</label>
                                </div>
                                <div class="form-group col-sm-4">
                                    <asp:DropDownList class="form-control" ID="DropDownList18" runat="server">
                                        <asp:ListItem Text="Select Subject" Value="select" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marathi" Value="Marathi" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Civics" Value="Civics" />
                                        <asp:ListItem Text="Geography" Value="Geography" />
                                        <asp:ListItem Text="Economic" Value="Econimic" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Assign Role</label>
                                </div>
                                <div class="form-group col-sm-4">
                                    <asp:DropDownList class="form-control" ID="DropDownList19" runat="server">
                                        <asp:ListItem Text="Select Role" Value="select" />
                                        <asp:ListItem Text="Admin" Value="Admin" />
                                        <asp:ListItem Text="Trainee" Value="Trainee" />
                                        <asp:ListItem Text="Learner" Value="Learner" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-1"></div>

                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block" ID="Button15" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" />
                                    </div>
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="Button16" Style="background-color: #dc3545; color: #fff" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-sm-8">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="5px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="80%">
                                        <Columns>
                                            <asp:BoundField HeaderText="Standard / Department" DataField="DepartmentStandardName" />
                                            <asp:BoundField HeaderText="Course / Subject" DataField="SubjectName" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No records found.</div>
                                        </EmptyDataTemplate>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <RowStyle ForeColor="#000066" Height="30px" VerticalAlign="Middle" Font-Size="Medium" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("click", ".classAdd", function () { //on is used for getting click event for dynamically created buttons

                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
                    '<td><input type="text" name="q-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><input type="text" name="p-name' + rowCount + '" class="form-control l-name01" /></td>' +
                    '<td><button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">Add More</button>&nbsp;&nbsp;' +
                    '&nbsp;&nbsp;<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                    '</tr>';
                $('#maintable').append(contactdiv); // Adding these controls to Main table class
            });

            $(document).on("click", ".deleteContact", function () {
                $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls 
            });

            function getAllEmpData() {
                var data = [];
                $('tr.data-contact-person').each(function () {
                    var qualification = $(this).find('.q-name01').val();
                    var percentage = $(this).find('.p-name01').val();
                    var alldata = {
                        'Qualification': qualification,
                        'Percentage': percentage
                    }
                    data.push(alldata);
                });
                console.log(data);
                return data;
            }

            $("#btnEducationSubmit").click(function () {
                var data = JSON.stringify(getAllEmpData());
                //console.log(data);
                $.ajax({
                    url: 'AddTrainee1.aspx/SaveEducation',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ 'educationdata': data }),
                    success: function () {
                        alert("Data Added Successfully");
                    },
                    error: function () {
                        alert("Error while inserting data");
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("click", ".classExpAdd", function () { //on is used for getting click event for dynamically created buttons

                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
                    '<td><input type="text" name="o-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><input type="text" name="eim-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><button type="button" id="btnAddExperience" class="btn btn-xs btn-primary classExpAdd">Add More</button>&nbsp;&nbsp;' +
                    '&nbsp;&nbsp;<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                    '</tr>';
                $('#experiencetable').append(contactdiv); // Adding these controls to Main table class
            });

            $(document).on("click", ".deleteContact", function () {
                $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls 
            });

            function getAllExpData() {
                var data = [];
                $('tr.data-contact-person').each(function () {
                    var organization = $(this).find('.o-name01').val();
                    var Experienceinmonth = $(this).find('.eim-name01').val();
                    var alldata = {
                        'Organization': organization,
                        'ExperienceInMonth': Experienceinmonth
                    }
                    data.push(alldata);
                });
                console.log(data);
                return data;
            }

            $("#btnExperienceSubmit").click(function () {
                var data = JSON.stringify(getAllExpData());
                //console.log(data);
                $.ajax({
                    url: 'AddTrainee1.aspx/SaveExperience',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ 'experiencedata': data }),
                    success: function () {
                        alert("Data Added Successfully");
                    },
                    error: function () {
                        alert("Error while inserting data");
                    }
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("click", ".classDocAdd", function () { //on is used for getting click event for dynamically created buttons

                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
                    '<td><input type="text" name="dn-name' + rowCount + '" class="form-control l-name01" /></td>' +
                    '<td><input type="text" name="f-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><button type="button" id="btnAddDocuments" class="btn btn-xs btn-primary classDocAdd">Add More</button>&nbsp;&nbsp;' +
                    '&nbsp;&nbsp;<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">Remove</button></td>' +
                    '</tr>';
                $('#documentstable').append(contactdiv); // Adding these controls to Main table class
            });

            $(document).on("click", ".deleteContact", function () {
                $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls 
            });

            function getAllDocData() {
                var data = [];
                $('tr.data-contact-person').each(function () {
                    var documentName = $(this).find('.dn-name01').val();
                    var filePath = $(this).find('.f-name01').val();
                    var alldata = {
                        'DocumentName': documentName,
                        'FilePath': filePath
                    }
                    data.push(alldata);
                });
                console.log(data);
                return data;
            }

            $("#btnDocumentSubmit").click(function () {
                var data = JSON.stringify(getAllDocData());
                //console.log(data);
                $.ajax({
                    url: 'AddTrainee1.aspx/SaveDocument',
                    type: 'POST',
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ 'documentdata': data }),
                    success: function () {
                        alert("Data Added Successfully");
                    },
                    error: function () {
                        alert("Error while inserting data");
                    }
                });
            });
        });
    </script>
</asp:Content>
