<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Payment.master" AutoEventWireup="true" CodeBehind="PaymentConfiguration.aspx.cs" Inherits="LMS.SuperAdmin.PaymentConfiguration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style type="text/css">
            .GridviewDiv {
                font-size: 100%;
                font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
                color: #303933;
            }

            .headerstyle {
                color: #FFFFFF;
                border-right-color: #abb079;
                border-bottom-color: #abb079;
                background-color: #8fcccc;
                padding: 0.5em 0.5em 0.5em 0.5em;
                text-align: center;
                max-height: 25px;
                min-height: 25px;
            }

            .vertical {
                border-left: 1px solid grey;
                height: 30px;
                /*left: 50%;*/
            }

            .filescolumnwidth {
                width: 11.11%;
            }
            .modalBackground {
                height: 100%;
                background-color: black;
                filter: alpha(opacity=20);
                opacity: 0.7;
            }
        </style>
    </head>
    <script type="text/javascript">
    function RefreshUpdatePanel() {
        __doPostBack('<%= txtSearch.ClientID %>', '');
    };
    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="breadcrumb" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="Publish" OnClick="btnPublish_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <%--<div class="col-md-flex">
                    <asp:Button ID="btnListDelete" CssClass="btn btn-primary" runat="server" Text="Delete" OnClick="btnListDelete_Click" />&nbsp;&nbsp;&nbsp;
                </div>--%>
                <div class="col-sm-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-md-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text" AutoPostBack="true" onkeyup="RefreshUpdatePanel();" OnTextChanged="txtSearch_TextChanged1"></asp:TextBox>
                    <%--AutoPostBack="true" onkeyup="RefreshUpdatePanel();"--%>
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
            <div class="col-sm-12">
                <div class="row">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                            AllowPaging="true" OnRowDataBound="gridViewdriveDocument_RowDataBound">
                            <Columns>
                             <%--   <asp:BoundField HeaderText="Roll Number" DataField="Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>--%>
                                       <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publish" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkIsActive" Checked='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Merchant Id" DataField="MerchantId" />
                                <asp:BoundField HeaderText="Password" DataField="PaymentPassword" />
                                <asp:BoundField HeaderText="Payment Gateway" DataField="PaymentGateWay" />
                                <asp:BoundField HeaderText="Transaction Type " DataField="TransactionType" />
                                <asp:BoundField HeaderText="Product Id " DataField="ProductId" />
                                
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive").ToString()=="True"?"Active":"InActive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkConfigDriveFile" runat="server" Text="Edit" CssClass="btn btn-success" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgbtn_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="LkB2" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgdeletebtn_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                            CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="pnlpopuptwo" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                            <div class="row" style="margin:0px 0px -20px 0px">
                                    <div class="col-sm-12" align="left" style="background-color:#bae7e3">
                                        <table>
                                            <tr>
                                                <td height="50px"><span font-size="Medium" color="black"><b>Delete Payment Configuration</b></span> </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            <div style="padding: 10px; box-shadow: 0px 0px 0px #888888; text-align: center; width: 390px">
                                
                                <div class="row">
                                    <div class="col-sm-12" align="center">
                                        <br>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12" align="center">
                                       <font size="4"> Are you Sure? You want to delete</font>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <br>
                                    </div>
                                    <div class="col-sm-1"></div>
                                    <div class="col-sm-3" align="left">
                                    </div>
                                    <div class="col-sm-8" align="left">
                                        <asp:Button ID="Button1" CssClass="btn btn-success float-end" BorderColor="White" ForeColor="White" CommandName="Delete" runat="server" Text="Yes" OnClick="btnDelete_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="No" class="btn btn-danger float-end" BorderColor="White" ForeColor="White" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
