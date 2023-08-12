<%@ Page Title="" Language="C#" MasterPageFile="~/HelpAndSupport/IssueMaster.master" AutoEventWireup="true" CodeBehind="PendingIssueList.aspx.cs" Inherits="LMS.HelpAndSupport.PendingIssueList" %>

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
    <div class="container-fluid">
        <div class="row">
            <div class="breadcrumb" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
                </div>
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
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive").ToString()=="True"?"Active":"InActive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Configured" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsDatabaseActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DatabaseIsActive").ToString()=="True"?"Yes":"No" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
