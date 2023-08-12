<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AttendanceMaster.master" AutoEventWireup="true" CodeBehind="TakeTraineeAttendance.aspx.cs" Inherits="LMS.Admin.TakeTraineeAttendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
         <div class="row">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Date</label>
                <div class="form-group">
                    <asp:TextBox ID="txtDate" class="form-control" autoComplte="off" runat="server" placeholder="Select Attendance DateTime" AutoPostBack="true" OnTextChanged="txtDate_TextChanged1"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Date of Attendance" ControlToValidate="txtDate" ValidationGroup="studAttendance" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ApplicationUserId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trainee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblTraineeName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblTraineeEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EmailId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                 <HeaderTemplate>
                                    Attendance:
                                    <asp:DropDownList ID="ddlAttendance" runat="server" class="form-control" AutoPostBack="true" AppendDataBoundItems="true"
                                        OnSelectedIndexChanged="CountryChanged">
                                        <asp:ListItem Text="-- Select Attendance --" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Abscent" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Half Day" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Holiday" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Leave" Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:RadioButton ID="rbtnPresent" runat="server" Text="Present" GroupName="Attendance" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbtnAbsent" runat="server" Text="Absent" GroupName="Attendance"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbtnHalfDay" runat="server" Text="Half Day" GroupName="Attendance"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbtnHoliday" runat="server" Text="Holiday" GroupName="Attendance"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbtnLeave" runat="server" Text="Leave" GroupName="Attendance"/>
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
        <div class="row">
            <asp:Button ID="btnSave" runat="server"  Width="150px"  Text="Save Attendance" ValidationGroup="studAttendance" OnClick="btnSave_Click" class="btn btn-block" Style="background-color: #28a745; color: #fff"/>
</div>
    </div>
</asp:Content>
