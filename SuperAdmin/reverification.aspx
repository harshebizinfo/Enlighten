<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/Payment.master" AutoEventWireup="true" CodeBehind="reverification.aspx.cs" Inherits="LMS.SuperAdmin.reverification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
           .columnwidth
             {
                 width: 14.29%;
                  text-wrap:initial;
                word-wrap:initial;
             }
        </style>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
    </script>
    <div class="container-fluid">
        <div class="row">
             <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-md-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;
                    </div>
                <div class="col-sm-2">
               <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text" AutoPostBack="true" onkeyup="RefreshUpdatePanel();"></asp:TextBox></div>
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
                    <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlClient" runat="server" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                </div>
                <div class="col-sm-3">
                      <label></label>
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button9" width="150px" runat="server" Style="background-color: #28a745; color: #fff" Text="Verify" OnClick="Button9_Click"/>
                    </div>
                </div>
            
            <div class="col-sm-12">
                <br />
            </div>
            <div class="col-sm-12">
                <div class="row">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        ShowHeaderWhenEmpty="True" PageSize="200" style="text-align:center" class="table table-bordered"
          AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                         <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblregistrationnumber" runat="server" Text='<%#Eval("ApplicationUserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reference Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblreferencenumber" runat="server" Text='<%#Eval("ReferenceNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Standard Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcoursename" runat="server" Text='<%#Eval("DepartmentStandardName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Fee">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotalfeeofcourse" runat="server" Text='<%#Eval("GrandTotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbltransactiondate" runat="server" Text='<%#Eval("TransactionDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">No records found.</div>
                    </EmptyDataTemplate>
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" ForeColor="white"/>
                    <PagerStyle />
                    <RowStyle  />
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
