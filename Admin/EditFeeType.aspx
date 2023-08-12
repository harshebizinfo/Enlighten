<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/FeesMaster.master" AutoEventWireup="true" CodeBehind="EditFeeType.aspx.cs" Inherits="LMS.Admin.EditFeeType" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" readonly="true" enabled="false" ID="ddlStandard" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor"  Text="Select Standard" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlStandard" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Schedule Due Date Fee</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtstartDatetime" runat="server" placeholder="Enter Start DateTime" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtstartDatetime" Format="dd/MM/yyyy"></asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Selec Last Fee Date" ValidationGroup="AddFeeType" ControlToValidate="txtstartDatetime" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Fee Name</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlFeeName" readonly="true" enabled="false" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Fee Name" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlFeeName" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Late Fee Charge</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtLateFee" runat="server" placeholder="Enter Late Fee Charge" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Enter Late fee Charge" ValidationGroup="AddFeeType" ControlToValidate="txtLateFee" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Fee Month</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlMonth" enabled="false" readonly="true" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Month" InitialValue="0" ValidationGroup="AddFeeType" ControlToValidate="ddlMonth" runat="server" ForeColor="Red" />
                </div>
            </div>
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
                    <asp:Button ID="btnSubmit"  Width="150px"  runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="AddFeeType" OnClick="btnSubmit_Click" />
                    
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
