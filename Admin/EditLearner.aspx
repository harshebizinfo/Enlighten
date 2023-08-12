<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Learner.master" AutoEventWireup="true" CodeBehind="EditLearner.aspx.cs" Inherits="LMS.Admin.EditLearner" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
         <div class="row">
            <div class="col-sm-12">
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-12">
                <h3>Edit Student</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
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
                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Enter Email ID"></asp:TextBox>
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
                    <asp:TextBox CssClass="form-control" ID="txtFatherContactNumber" runat="server" placeholder="Enter Father Contact Number"></asp:TextBox>
                </div>
            </div>
        </div>
         <div class="row">
                <div class="col-sm-4">
                 <label>Date Of Birth</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="txtDateOfBirth" runat="server" placeholder="Enter Date of Birth" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDateOfBirth" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                    </div>
                    </div>
                <div class="col-sm-4">
                    <label>Language</label>
                    <div class="form-group">
                        <asp:DropDownList class="form-control" ID="ddlLanguage" runat="server">
                            <asp:ListItem Text="Select Language" Value="select" />
                            <asp:ListItem Text="Hindi" Value="Hindi" />
                            <asp:ListItem Text="English" Value="English" />
                            <asp:ListItem Text="Marathi" Value="Marathi" />
                            <asp:ListItem Text="Sanskrit" Value="Sanskrit" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-4">
                    <label>Nationality</label>
                    <div class="form-group">
                        <asp:DropDownList class="form-control" ID="ddlnationality" runat="server">
                            <asp:ListItem Text="Select Nationality" Value="select" />
                            <asp:ListItem Text="India" Value="India" />
                            <asp:ListItem Text="China" Value="China" />
                            <asp:ListItem Text="Nepal" Value="Nepal" />
                            <asp:ListItem Text="Bangladesh" Value="Bangladesh" />
                            <asp:ListItem Text="Bhutan" Value="Bhutan" />
                            <asp:ListItem Text="Sri Lanka" Value="Sri Lanka" />
                            <asp:ListItem Text="Pakistan" Value="Pakistan" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Tehseel</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddltehseel" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select City</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlcity" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Previous School Name</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtPevSchoolName" runat="server" placeholder="Enter Prev. School Name"></asp:TextBox>
                    </div>
                </div>
        </div>
        <%--<div class="row">
            <div class="col-sm-4">
                <label>Select Tehseel</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select City</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Previous School Name</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Enter Prev. School Name"></asp:TextBox>
                    </div>
                </div>
        </div>--%>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Prev. Medium</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlprevMedium" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Prev. Stream</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlprevStream" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Previous Marks</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtPrevMarks" runat="server" placeholder="Enter Prev. Marks"></asp:TextBox>
                    </div>
                </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Prev. Class</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlPrevClass" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Prev. Total Marks</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPrevTotalMarks" runat="server" placeholder="Enter Prev. Total Marks"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Previous Address</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txtprevAddress" runat="server" placeholder="Enter Prev. Address"></asp:TextBox>
                    </div>
                </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Father Name</label>
                <div class="form-group">
                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Enter Father Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Father Phone</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFatherPhone" runat="server" placeholder="Enter Father Phone"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Father Education</label>
                    <div class="form-group">
                         <asp:DropDownList class="form-control" ID="ddlFatherEducation" runat="server">
                    </asp:DropDownList>
                    </div>
                </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
                <label>Father Occupation</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlFatherOccupation" runat="server">
                    </asp:DropDownList>
                   
                </div>
            </div>
            <div class="col-sm-4">
                <label>Father Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFatherAddress" runat="server" placeholder="Enter Father Address"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Mother Name</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="txtMotherName" runat="server" placeholder="Enter Mother Name"></asp:TextBox>
                    </div>
                </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Mother Phone</label>
                <div class="form-group">
                   <asp:TextBox CssClass="form-control" ID="txtMotherPhone" runat="server" placeholder="Enter Mother Phone"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Mother Education</label>
                <div class="form-group">
                     <asp:DropDownList class="form-control" ID="ddlMotherEducation" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Mother Occupation</label>
                    <div class="form-group">
                         <asp:DropDownList class="form-control" ID="ddlMotherOccupation" runat="server">
                    </asp:DropDownList>
                    </div>
                </div>
        </div>
         <div class="row">
            <div class="col-sm-4">
                <label>Mother Address</label>
                <div class="form-group">
                   <asp:TextBox CssClass="form-control" ID="txtMotherAddress" runat="server" placeholder="Enter Mother Address"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Guardian Name</label>
                <div class="form-group">
                     <asp:TextBox CssClass="form-control" ID="txtGuardianName" runat="server" placeholder="Enter Guardian Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Guardian Phone</label>
                    <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="txtGuardianPhone" runat="server" placeholder="Enter Guardian Phone"></asp:TextBox>
                    </div>
                </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Guardian Relationship</label>
                <div class="form-group">
                   <asp:TextBox CssClass="form-control" ID="txtGuardianRelationship" runat="server" placeholder="Enter Guardian Relationship"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Guardian Address</label>
                <div class="form-group">
                     <asp:TextBox CssClass="form-control" ID="txtGuardianAddress" runat="server" placeholder="Enter Guardian Address"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                    <label>Document</label>
                    <div class="form-group">
                         <asp:DropDownList class="form-control" ID="ddlDocument" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
        </div>
            <div class="row">
                <div class="col-sm-4">
                    <label>Adhaar Card Number</label>

                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Enter Adhaar Card Number" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-4">
                    <label>Is Pervious School Included</label>

                    <div class="form-group">
                        <asp:CheckBox ID="chkbIsPreviousSchool" runat="server" />
                    </div>
                </div>
                <div class="col-sm-4">
                    <label>Is Sibilings Included</label>

                    <div class="form-group">
                        <asp:CheckBox ID="IsSibilingsIncluded" runat="server" />
                    </div>
                </div>
               
            </div>
       <%-- <div class="row">
            <div class="col-sm-4">
                <label>Present Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpresentAddress" runat="server" placeholder="Enter Present Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Present City</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPresentCity" runat="server" placeholder="Enter Present City"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Present State</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPresentState" runat="server" placeholder="Enter Present State"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Permanent Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpermanentAddress" runat="server" placeholder="Enter Permanent Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                    <asp:TextBox CssClass="form-control" ID="txtPermanentState" runat="server" placeholder="Enter Permanent State"></asp:TextBox>
                </div>
            </div>
        </div>--%>
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                </div>
            </div>
            <div class="col-sm-1"></div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
