<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Student.master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="LMS.Trainee.StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <style type="text/css">
           .columnwidth
             {
                 width: 12.5%;
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
            <div class="col-sm-12">
                <div class="col-sm-3">
                    <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlDepartmentStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentStandard_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
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
                        <asp:BoundField HeaderText="Roll Number" DataField="ApplicationUserId" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                        <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                        <asp:BoundField HeaderText="Email ID" DataField="EmailId" />
                        <asp:BoundField HeaderText="Father Name" DataField="FatherName" />
                        <asp:BoundField HeaderText="Father Contact No." DataField="FatherContactNumber" />
                        <asp:BoundField HeaderText="Standard " DataField="DepartmentStandardName" />
                        <asp:BoundField HeaderText="Division " DataField="Section" />
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
