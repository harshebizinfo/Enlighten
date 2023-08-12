<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AttendanceMaster.master" AutoEventWireup="true" CodeBehind="ViewTraineeAttendance.aspx.cs" Inherits="LMS.Admin.ViewTraineeAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
           
        </div>
        <div class="row">
            <div class="breadcrumb" style="width:100%">
            <div class="col-sm-flex"><asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click"/>&nbsp;&nbsp;&nbsp;</div>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-3">
                <label>Select Month</label>
                <div class="form-group">
                    <asp:DropDownList ID="ddlMonth" runat="server" class="form-control">
                        <asp:ListItem Text="-- Select Month --" Value="0"></asp:ListItem>
                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="June" Value="6"></asp:ListItem>
                        <asp:ListItem Text="July" Value="7"></asp:ListItem>
                        <asp:ListItem Text="August" Value="8"></asp:ListItem>
                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        <asp:ListItem Text="January" Value="1"></asp:ListItem>
                        <asp:ListItem Text="February" Value="2"></asp:ListItem>
                        <asp:ListItem Text="March" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Month" InitialValue="0" ControlToValidate="ddlMonth" ValidationGroup="studAttendance" runat="server" ForeColor="Red" />
                </div>
            </div>
             <div class="col-sm-3">
                <label></label>
                <div class="form-group">
                    <asp:Button ID="btnSave" runat="server"  Width="200px"  Text="View Attendance" ValidationGroup="studAttendance" class="btn btn-block" Style="background-color: #28a745; color: #fff" OnClick="btnSave_Click"/>
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                <div class="table-responsive" style="width:1000px; height:400px; overflow:scroll">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" >
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
</asp:Content>
