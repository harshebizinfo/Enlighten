<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Teacher.master" AutoEventWireup="true" CodeBehind="AddTrainee1.aspx.cs" Inherits="LMS.Admin.AddTrainee1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <asp:Button ID="btnPersonalDetail" class="btn btn-primary" runat="server" Text="Personal Info" OnClick="btnPersonalDetail_Click" />
                <asp:Button ID="btnEducation" class="btn btn-primary" runat="server" Text="Education" OnClick="btnEducation_Click" />
                <asp:Button ID="btnExperience" class="btn btn-primary" runat="server" Text="Experience" OnClick="btnExperience_Click" />
                <asp:Button ID="btnDocuments" class="btn btn-primary" runat="server" Text="Documents" OnClick="btnDocuments_Click" />
                <asp:Button ID="btnBankAccount" class="btn btn-primary" runat="server" Text="Bank Account" OnClick="btnBankAccount_Click" />
                <asp:Button ID="btnAssignStandard" class="btn btn-primary" runat="server" Text="Assign Standard" OnClick="btnAssignStandard_Click" />
            </div>
            <div class="col-sm-12">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="ViewPersonalDetail" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>First Name <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter First Name" Text="*" ToolTip="Enter First Name" ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Last Name <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Enter Last Name" Text="*" ToolTip="Enter Last Name" ControlToValidate="txtLastName" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Contact Number <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Enter Contact Number" Text="*" ToolTip="Enter Contact Number" ControlToValidate="txtContactNumber" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Contact Number" Text="*" ToolTip="Enter Valid Contact Number" ControlToValidate="txtContactNumber" ForeColor="Red" ValidationGroup="teacherPersonalDtl" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtContactNumber" runat="server" placeholder="Enter Contact Number"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Email ID <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Enter Email ID" Text="*" ToolTip="Enter Email ID" ControlToValidate="txtemail" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Email ID" Text="*" ToolTip="Enter Valid Email ID" ControlToValidate="txtemail" ForeColor="Red" ValidationGroup="teacherPersonalDtl" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtemail" runat="server" placeholder="Enter Email ID"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Father Name</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtFatherName" runat="server" placeholder="Enter Father Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Father Contact Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtfathercontactNumber" runat="server" placeholder="Enter Father Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Present Address <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Enter Present Address" Text="*" ToolTip="Enter Present Address" ControlToValidate="txtpresentAddress" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpresentAddress" runat="server" placeholder="Enter Present Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Present City <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Enter Present City" Text="*" ToolTip="Enter Present City" ControlToValidate="txtpresentCity" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpresentCity" runat="server" placeholder="Enter Present City"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Present State <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Enter Present State" Text="*" ToolTip="Enter Present State" ControlToValidate="txtpresentstate" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpresentstate" runat="server" placeholder="Enter Present State"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Permanent Address</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpermanentaddress" runat="server" placeholder="Enter Permanent Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Permanent City</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpermanentCity" runat="server" placeholder="Enter Permanent City"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Permanent State</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpermanentState" runat="server" placeholder="Enter Permanent State"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Gender <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ErrorMessage="Select Gender" Text="*" ToolTip="Enter Gender" InitialValue="select" ControlToValidate="ddlGender" runat="server" ForeColor="Red" ValidationGroup="teacherPersonalDtl" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlGender" runat="server">
                                            <asp:ListItem Text="Select Gender" Value="select" />
                                            <asp:ListItem Text="Male" Value="Male" />
                                            <asp:ListItem Text="Female" Value="Female" />
                                            <asp:ListItem Text="Others" Value="Others" />
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Adhaar Card Number <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="Enter Adhaar Card Number" Text="*" ToolTip="Enter Adhaar Card Number" ControlToValidate="txtadhaarnumber" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Adhaar Card Number" Text="*" ToolTip="Enter Valid Adhaar Card Number" ControlToValidate="txtadhaarnumber" ForeColor="Red" ValidationGroup="teacherPersonalDtl" ValidationExpression="^[0-9]{12}$"></asp:RegularExpressionValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtadhaarnumber" runat="server" placeholder="Enter Adhaar Card Number"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>PAN Card Number <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Enter PAN Card Number" Text="*" ToolTip="Enter PAN Card Number" ControlToValidate="txtpannumber" ForeColor="Red" ValidationGroup="teacherPersonalDtl"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtpannumber" runat="server" placeholder="Enter PAN Card Number"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--<div class="col-sm-4"></div>
                                <div class="col-sm-4"></div>--%>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="btnSave" Width="150px" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="btnSave_Click" ValidationGroup="teacherPersonalDtl" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="btnCancel" Width="150px" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="btnCancel_Click" />
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
                                    <label>Select Trainee <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ErrorMessage="Select Trainee" ToolTip="Select Trainee" Text="*" InitialValue="0" ControlToValidate="ddlEducationalTrainee" runat="server" ForeColor="Red" ValidationGroup="EducationalDetails" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlEducationalTrainee" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select Higher Education Document</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="" AllowMultiple="true" />
                                    </div>
                                </div>
                                <div class="col-sm-4"></div>
                            </div>
                            <div class="row">
                                <%--<div class="col-sm-4"></div>
                                <div class="col-sm-4"></div>--%>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button1" runat="server" ValidationGroup="EducationalDetails" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button5" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
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
                                    <label>Select Trainee <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ErrorMessage="Select Trainee" ToolTip="Select Trainee" Text="*" InitialValue="0" ControlToValidate="ddlExperienceTrainee" runat="server" ForeColor="Red" ValidationGroup="ExperienceDetails" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlExperienceTrainee" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select Last Experience Document</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="true" />
                                    </div>
                                </div>
                                <div class="col-sm-4"></div>
                            </div>
                            <div class="row">
                                <%--<div class="col-sm-4"></div>
                                <div class="col-sm-4"></div>--%>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-block" Width="150px" ID="btnExperienceSubmit" ValidationGroup="ExperienceDetails" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="btnExperienceSubmit_Click" />
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
                                    <label>Select Trainee <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ErrorMessage="Select Trainee" ToolTip="Select Trainee" Text="*" InitialValue="0" ControlToValidate="ddlDocumentTrainee" runat="server" ForeColor="Red" ValidationGroup="DocumentDetails" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlDocumentTrainee" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select Document</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload3" runat="server" AllowMultiple="true" />
                                    </div>
                                </div>
                                <div class="col-sm-4"></div>
                            </div>
                            <div class="row">
                                <%--                    <div class="col-sm-4"></div>
                    <div class="col-sm-4"></div>--%>
                                <div class="form-group">
                                    <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" ValidationGroup="DocumentDetails" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button2_Click" />
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button8" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewBankAccount" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-4">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select Trainee <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Select Trainee" ToolTip="Select Trainee" Text="*" InitialValue="0" ControlToValidate="ddltrainee" runat="server" ForeColor="Red" ValidationGroup="BankDetails" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddltrainee" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label></label>
                                    <div class="form-group">
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label></label>

                                    <div class="form-group">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Bank Name <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Bank Name" ToolTip="Enter Bank Name" Text="*" ControlToValidate="txtBankName" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtBankName" runat="server" placeholder="Enter Bank Name"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Account Number <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Account Number" ToolTip="Enter Account Number" Text="*" ControlToValidate="txtAccountNumber" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtAccountNumber" runat="server" placeholder="Enter Account Number"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>IFSC Code <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter IFSC Code" ToolTip="Enter IFSC Code" Text="*" ControlToValidate="txtIFSCCode" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtIFSCCode" runat="server" placeholder="Enter IFSC Code"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Account Holder Name <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Account Holder Name" ToolTip="Enter Account Holder Name" Text="*" ControlToValidate="txtHolderName" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtHolderName" runat="server" placeholder="Enter Holder Name"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Re-enter Account Number <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Re-Enter Account Number" ToolTip="Re-Enter Account Number" Text="*" ControlToValidate="txtReAccountNumber" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Account Number does not match" ToolTip="Account Number does not match" Text="*" ControlToValidate="txtReAccountNumber" ForeColor="Red" ControlToCompare="txtAccountNumber" ValidationGroup="BankDetails"></asp:CompareValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtReAccountNumber" runat="server" placeholder="Enter Re-enter Account Number"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Re-enter IFSC Code <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Re-Enter IFSC Code" ToolTip="Re-Enter IFSC Code" Text="*" ControlToValidate="txtReIFSCName" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="IFSC Code does not match" ToolTip="IFSC Code does not match" Text="*" ControlToValidate="txtReIFSCName" ForeColor="Red" ControlToCompare="txtIFSCCode" ValidationGroup="BankDetails"></asp:CompareValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtReIFSCName" runat="server" placeholder="Enter Re-enter IFSC Code"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Nick Name <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Nick Name" ToolTip="Enter Nick Name" Text="*" ControlToValidate="txtNickName" ForeColor="Red" ValidationGroup="BankDetails"></asp:RequiredFieldValidator></label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtNickName" runat="server" placeholder="Enter Nick Name"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label></label>
                                    <div class="form-group">
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label></label>

                                    <div class="form-group">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--<div class="col-sm-4"></div>
                    <div class="col-sm-4"></div>--%>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="Button3" Width="150px" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button3_Click" ValidationGroup="BankDetails" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" ID="Button4" Width="150px" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewAssignStandard" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select UserName <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Select UserName" ToolTip="Select UserName" Text="*" InitialValue="0" ControlToValidate="ddlUserName" runat="server" ForeColor="Red" ValidationGroup="abc" /></label>
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlUserName" class="form-control" runat="server"></asp:DropDownList>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Select Department/Standard <asp:RequiredFieldValidator ID="reqFavoriteColor" ErrorMessage="Select Department / Standard" ToolTip="Select Department / Standard" Text="*" InitialValue="0" ControlToValidate="ddlassigndepartmentStandard" runat="server" ForeColor="Red" ValidationGroup="abc" /></label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlassigndepartmentStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlassigndepartmentStandard_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Select Course/Subject <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Select Course/Subject" ToolTip="Select Course/Subject" Text="*" InitialValue="0" ControlToValidate="ddlassignCourseSubject" runat="server" ForeColor="Red" ValidationGroup="abc" /></label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlassignCourseSubject" runat="server">
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-sm-2">
                                    <label>Assign Role</label>
                                </div>
                                <div class="form-group col-sm-4">
                                    <asp:DropDownList class="form-control" ID="ddlassignRole" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Role" InitialValue="0" ControlToValidate="ddlassignRole" runat="server" ForeColor="Red" ValidationGroup="abc"/>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block" Width="150px" ID="Button15" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button15_Click" ValidationGroup="abc" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button16" Style="background-color: #dc3545; color: #fff" runat="server" Text="Cancel" />
                                    </div>
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
