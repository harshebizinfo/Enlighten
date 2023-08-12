<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FeesMaster.master" AutoEventWireup="true" CodeBehind="AddFeeNameMaster.aspx.cs" Inherits="LMS.Admin.AddFeeNameMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Fee Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFeeName" runat="server" placeholder="Enter Fee Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Fee Name" ForeColor="Red" Text="*" ControlToValidate="txtFeeName" ValidationGroup="AddtxtFeeName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Fee Group</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlFeeGroup" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Fee Group" InitialValue="0" ValidationGroup="AddtxtFeeName" ControlToValidate="ddlFeeGroup" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkRefundable" runat="server" />
                            &nbsp;&nbsp;&nbsp;<label>Refundable Fee</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkoptional" runat="server" />
                            &nbsp;&nbsp;&nbsp;<label>Optional Fee</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkdiscount" runat="server" />&nbsp;&nbsp;&nbsp;<label>Discount On</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkConveyance" runat="server" />&nbsp;&nbsp;&nbsp;<label>Conveyance</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkFeeDisplay" runat="server" />&nbsp;&nbsp;&nbsp;<label>Fee Display</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkTransferhead" runat="server" />&nbsp;&nbsp;&nbsp;<label>Transfer Head</label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;&nbsp;&nbsp;<label>Publish</label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12"><br /></div>
        </div>
        <div class="row">
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" Width="150px" ID="Button9" runat="server" ValidationGroup="AddtxtFeeName" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
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
</asp:Content>
