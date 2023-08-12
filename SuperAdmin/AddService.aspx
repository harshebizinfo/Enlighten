<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/ServiceAccountMaster.master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="LMS.SuperAdmin.AddService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Select Client</label>
                <div class="form-group">
                    <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Client" InitialValue="0" ValidationGroup="AddPC" ControlToValidate="ddlClient" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Service Account Email</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtserviceAccountEmail" runat="server" placeholder="Enter Service Account Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Merchant ID" ValidationGroup="AddPC" ControlToValidate="txtserviceAccountEmail" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>User Email</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtUserEmail" runat="server" placeholder="Enter User Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Enter Merchant ID" ValidationGroup="AddPC" ControlToValidate="txtUserEmail" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Private Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPrivateKey" runat="server" placeholder="Enter Private Key"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Enter Private Key" ValidationGroup="AddPC" ControlToValidate="txtPrivateKey" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select JSON File</label>
                <div class="form-group">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Publish</label>
                <div class="form-group">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div class="col-md-flex">
                    <div class="form-group">
                        <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="AddFeeType" OnClick="btnSubmit_Click" />

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
    </div>
</asp:Content>
