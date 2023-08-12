<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/DriveDocumentFiles.master" AutoEventWireup="true" CodeBehind="DriveDocumentFiles.aspx.cs" Inherits="LMS.Learner.DriveDocumentFiles2" %>

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
                width: 20%;
                text-wrap:initial;
                word-wrap:initial;
            }
        </style>
    </head>
    <div class="row">
        <div class="col-sm-12">
            <br />
        </div>
        <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
            <div class="table-responsive">
                <asp:GridView ID="GridViewdriveDocument" runat="server" AutoGenerateColumns="False" OnRowDataBound="gridViewdriveDocument_RowDataBound"
                    ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                    AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Event Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEventId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Size") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Version">
                            <ItemTemplate>
                                <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Version") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Created Time">
                            <ItemTemplate>
                                <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CreatedTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <button id="btnDownload" cssclass="btn btn-success" style="border: none; outline: none; background-color: green; color: white; font-size: large;">
                                    <a href='<%# Eval("WebContentLink") %>' target="_blank" style="color: white; font-family: inherit; font-size: 1rem; line-height: 1.5;">Download</a></button>
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
</asp:Content>
