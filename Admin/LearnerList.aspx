<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Learner.master" AutoEventWireup="true" CodeBehind="LearnerList.aspx.cs" Inherits="LMS.Admin.LearnerList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style type="text/css">
            .modalBackground {
                height: 100%;
                background-color: black;
                filter: alpha(opacity=20);
                opacity: 0.7;
            }

            .columnwidth {
                width: 10%;
                 text-wrap:initial;
                word-wrap:initial;
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
            <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:Button ID="btnAddLearner" CssClass="btn btn-primary" runat="server" Text="Add Learner/ Student" OnClick="btnAddLearner_Click" />
                    &nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-sm-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <%--<div class="col-sm-flex">
                    <asp:Button ID="btnListDelete" CssClass="btn btn-primary" runat="server" Text="Delete" OnClick="btnListDelete_Click" />&nbsp;&nbsp;&nbsp;
                </div>--%>
                <div class="col-md-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text"></asp:TextBox>
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
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <%-- <asp:BoundField HeaderText="User Id" DataField="ApplicationUserId" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Id" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ApplicationUserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                            <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                            <asp:BoundField HeaderText="Email ID" DataField="EmailId" />
                            <asp:BoundField HeaderText="Father Name" DataField="FatherName" />
                            <asp:BoundField HeaderText="Father Contact No." DataField="FatherContactNumber" />
                            <asp:BoundField HeaderText="Standard " DataField="DepartmentName" />
                            <asp:BoundField HeaderText="Division " DataField="Section" />
                           <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="imgbtndetails" runat="server"  Height="30px" Width="30px" OnClick="imgbtn_Click" ><i class="fa fa-pencil-square-o" style="color:navy;font-size:20px"></i></asp:ImageButton>--%>
                                    <asp:LinkButton ID="LkB1" runat="server" Text="Edit" CssClass="btn btn-success"  CommandName="EditRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ApplicationUserId") %>' OnClick="imgbtn_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LkB2" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ApplicationUserId") %>' OnClick="imgdeletebtn_Click"></asp:LinkButton>

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
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlpopuptwo" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                        <div class="row" style="margin: 0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                                <table>
                                    <tr>
                                        <td height="50px"><span font-size="Medium" color="black"><b>Delete Learner</b></span> </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="padding: 10px; box-shadow: 0px 0px 0px #888888; text-align: center; width: 390px" backcolor="White">
                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    <br>
                                    <asp:Label runat="server" ID="lblDeleteTraineeId" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    <font size="4">Are you Sure? You want to delete</font>
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
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
