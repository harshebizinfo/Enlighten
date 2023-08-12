<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FeesMaster.master" AutoEventWireup="true" CodeBehind="AddFeeStructure.aspx.cs" Inherits="LMS.Admin.AddFeeStructure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style type="text/css">
            .rbListWrap {
                /*width: 100px;*/
            }

                .rbListWrap tr td {
                    height: 10px;
                    vertical-align: top;
                    padding: 2px;
                }

                .rbListWrap input {
                    float: left;
                    padding-bottom: 0px;
                    margin: 5px 0px 0px 0px;
                }

                .rbListWrap label {
                    position: initial;
                    padding-left: 10px;
                    font-size: medium;
                }

            .auto-style1 {
                font-size: x-large;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlStandard" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Standard" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlStandard" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Fee Amount</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFeeAmount" runat="server" placeholder="Enter Fee Amount" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Fee Amount" ValidationGroup="AddFeeType" ControlToValidate="txtFeeAmount" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Fee Name</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlFeeName" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Fee Name" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlFeeName" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Fee Category</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Category" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlCategory" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Fee Month</label>
                <div class="form-group">
                    <div style="overflow: scroll; max-height: 100px">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="rbListWrap" RepeatDirection="Vertical"></asp:CheckBoxList>
                    </div>
                    <%--  <asp:DropDownList class="form-control" ID="ddlMonth" runat="server">
                    </asp:DropDownList>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Month" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlMonth" runat="server" ForeColor="Red" />--%>
                </div>
            </div>
            <div class="col-sm-4" style="left: 0px; top: 0px">
                <label>Publish</label>
                <div class="form-group">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>
            </div>
        </div>
        <%-- <div class="row">
            
        </div>--%>
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
