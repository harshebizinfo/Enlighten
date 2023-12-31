﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Learner.master" AutoEventWireup="true" CodeBehind="AddLearner1.aspx.cs" Inherits="LMS.Admin.AddLearner1" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <asp:Button ID="btnPersonalDetail" class="btn btn-primary" runat="server" Text="Personal Info" OnClick="btnPersonalDetail_Click" />
                <asp:Button ID="btnDocuments" class="btn btn-primary" runat="server" Text="Documents" OnClick="btnDocuments_Click" />
                <%--<asp:Button ID="btnAssignStandard" class="btn btn-primary" runat="server" Text="Login Detail" OnClick="btnAssignStandard_Click" />--%>
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
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Gender</label>

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
                                    <label>Adhaar Card Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtadhaarNumber" runat="server" placeholder="Enter Adhaar Card Number"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="col-sm-4">
                                    <label>PAN Card Number</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Enter PAN Card Number"></asp:TextBox>
                                    </div>
                                </div>--%>
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
                                    <label>Select Student</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlDocumentStudent" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Select Student" InitialValue="0" ControlToValidate="ddlDocumentStudent" runat="server" ForeColor="Red" ValidationGroup="DocumentDetails" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Select Document </label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload3" runat="server" CssClass="" AllowMultiple="false" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button1" runat="server" ValidationGroup="DocumentDetails" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <%--<asp:View ID="ViewAssignStandard" runat="server">
                        <div class="card">
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    Seema Dixit
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>User Name</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUserName" runat="server" placeholder="Enter User Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2">
                                    <label>Password</label>
                                </div>
                                <div class="col-sm-4 form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Enter Password"></asp:TextBox>
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
                            </div>
                        </div>
                    </asp:View>--%>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
