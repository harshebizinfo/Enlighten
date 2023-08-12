<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Payment.master" AutoEventWireup="true" CodeBehind="PaidPaymentList.aspx.cs" Inherits="LMS.SuperAdmin.PaidPaymentList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
    function RefreshUpdatePanel() {
        __doPostBack('<%= txtSearch.ClientID %>', '');
    };
    </script>
    <div class="container-fluid">
        <div class="row">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <div class="row">
            <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text" AutoPostBack="true" onkeyup="RefreshUpdatePanel();"></asp:TextBox>
                </div>
                <div class="col-md-flex">
                    &nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-md-flex">
                    <asp:Button ID="src" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="src_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <label>From Date</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Select From DateTime" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                </div>
            </div>
            <div class="col-sm-3">
                <label>Till Date</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server" placeholder="Select Till DateTime" AutoPostBack="true" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Application UserId" DataField="ApplicationUserId" />
                            <asp:BoundField HeaderText="Paid Amount" DataField="TotalReceivedAmount" />
                            <asp:BoundField HeaderText="Service Tax" DataField="ServiceTax" />
                            <asp:BoundField HeaderText="Transaction Id" DataField="TransactionId" />
                            <asp:BoundField HeaderText="Transaction Date" DataField="TransactionDate" />
                            <asp:BoundField HeaderText="Refference Number" DataField="ReferenceNumber" />
                            <asp:BoundField HeaderText="Institute Name" DataField="InstituteName" />
                            <asp:BoundField HeaderText="Paid On" DataField="CreatedOn" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center">No records found.</div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" ForeColor="white" />
                        <PagerStyle />
                        <RowStyle />
                        <SelectedRowStyle />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
