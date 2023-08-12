<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Payment.master" AutoEventWireup="true" CodeBehind="EditPaymentConfiguration.aspx.cs" Inherits="LMS.SuperAdmin.EditPaymentConfiguration" %>
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
                <label>Payment Gateway</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPaymentGateway" runat="server" placeholder="Enter Payment Gateway" Text="ATOM" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Merchant ID</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtmerchantid" runat="server" placeholder="Enter Merchant ID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Merchant ID" ValidationGroup="AddPC" ControlToValidate="txtmerchantid" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Password</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpassword" runat="server" placeholder="Enter Payment Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Enter Payment Password" ValidationGroup="AddPC" ControlToValidate="txtpassword" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Request Hash Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtRequestHashKey" runat="server" placeholder="Enter Request Hash Key"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Enter Request Hash Key" ValidationGroup="AddPC" ControlToValidate="txtRequestHashKey" runat="server" ForeColor="Red" />
                </div>
            </div>
             <div class="col-sm-4">
                <label>Response Hash Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtResponseHashKey" runat="server" placeholder="Enter Response Hash Key"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Enter Response Hash Key" ValidationGroup="AddPC" ControlToValidate="txtResponseHashKey" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Request AES Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtRequestAESKey" runat="server" placeholder="Enter Request AES Key"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Enter Request AES Key" ValidationGroup="AddPC" ControlToValidate="txtRequestAESKey" runat="server" ForeColor="Red" />
                </div>
            </div>
             <div class="col-sm-4">
                <label>Response AES Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtResponseAESKey" runat="server" placeholder="Enter Response AES Key"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Enter Response AES Key" ValidationGroup="AddPC" ControlToValidate="txtResponseAESKey" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Transaction Type</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtTransactionType" runat="server" placeholder="Enter Transaction Type"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Enter Transaction Type" ValidationGroup="AddPC" ControlToValidate="txtTransactionType" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Product ID</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtProductId" runat="server" placeholder="Enter Product ID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Razor Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtRazorKey" runat="server" placeholder="Enter Razor Key"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Razor Secret Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtRazorSecretKey" runat="server" placeholder="Enter Razor Secret Key"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Merchant Code</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtMerchantCode" runat="server" placeholder="Enter Merchant Code"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Is Key</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtKey" runat="server" placeholder="Enter Is Key"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Is Iv</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtIsIv" runat="server" placeholder="Enter Is Iv"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Enter Product ID" ValidationGroup="AddPC" ControlToValidate="txtProductId" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
        </div>
        <div class="row">
             <div class="col-sm-4" style="left: 0px; top: 0px">
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
                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="AddPC" OnClick="btnSubmit_Click" />

                    </div>
                </div>
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
