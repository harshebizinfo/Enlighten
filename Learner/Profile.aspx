<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/ProfileMaster.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LMS.Learner.Profile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    </head>
    <div class="container-fluid">
        <%-- <div class="row">
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
                            <br />--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                   <asp:TextBox CssClass="form-control" ID="txtFatherName" runat="server" placeholder="Enter Father Name"></asp:TextBox>
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
            <div class="row">
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button class="btn btn-block" Width="150px" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                    </div>
                </div>
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button class="btn btn-block" Width="150px" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button10_Click" />
                    </div>
                </div>
            </div>
            <%--    </div>
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
                            </div>
        </div>
        </asp:View>
                </asp:MultiView>
    </div>
    </div>--%>
    </div>
</asp:Content>
