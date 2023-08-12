<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/ClientMaster.master" AutoEventWireup="true" CodeBehind="ClientList.aspx.cs" Inherits="LMS.SuperAdmin.ClientList" %>

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
                width: 9.09%;
            }
            .singleValuecolumnwidth {
                width: 5%;
            }
            .emailActioncolumnwidth {
                width: 12%;
            }
            .Actioncolumnwidth {
                width: 16%;
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
                                <asp:BoundField HeaderText="Name" DataField="ClientName" />
                                <asp:BoundField HeaderText="Email ID" DataField="EmailID" />
                                <asp:BoundField HeaderText="Contact No." DataField="ContactNumber" />
                                <asp:BoundField HeaderText="Institute Name " DataField="InstituteName" />
                                <asp:BoundField HeaderText="Database Name " DataField="DatabaseName" />
                                <asp:TemplateField HeaderText="Logo">
                                    <ItemTemplate>
                                        <%--<img src="../SuperAdmin/ClientLogo/<%#Eval("LogoPath") %>" height="110" width="110" />--%>
                                         <img src="data:image/jpeg;base64,<%# Eval("LogoPath") %>" height="110" width="110" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Logo">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("LogoPath") %>' height="110px" width="110px" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive").ToString()=="True"?"Active":"InActive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField HeaderText="Exam Name" DataField="ExamName" />
                        <asp:BoundField HeaderText="Is Active" DataField="IsActive" />--%>
                                <asp:TemplateField HeaderText="Configured" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsDatabaseActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DatabaseIsActive").ToString()=="True"?"Yes":"No" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkEditClient" runat="server" Text="Edit" CssClass="btn btn-success" CommandArgument='<%#Eval("ClientID") %>' OnClick="linkEditClient_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="linkConfigDriveFile" runat="server" Text="Configure" CssClass="btn btn-success" CommandArgument='<%#Eval("ClientID") %>' OnClick="imgbtn_Click"></asp:LinkButton>
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
                                                <td height="50px"><span font-size="Medium" color="black"><b>Delete Client</b></span> </td>
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
