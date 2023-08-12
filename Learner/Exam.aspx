<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/ExamMaster.master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="LMS.Learner.Exam" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
        </script>
    </head>
    <div class="container-fluid">

        <div class="row">
            <%--<div class="col-sm-3">
                <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlDepartmentStandard" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Department / Standard" InitialValue="0" ControlToValidate="ddlDepartmentStandard" runat="server" ForeColor="Red"  ValidationGroup="exam"/>
                </div>
            </div>--%>
            <div class="col-sm-3">
                <label>Select Subject</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlSubjectCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectCourse_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Select Subject / Course" InitialValue="0" ValidationGroup="exam" ControlToValidate="ddlSubjectCourse" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label>Select Exam</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlExam" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Exam" InitialValue="0" ControlToValidate="ddlExam" ValidationGroup="exam" runat="server" ForeColor="Red" />
                </div>
            </div>
            
            <div class="col-sm-3">
                <label></label>

                <div class="form-group">
                   <asp:Button class="btn btn-block" ID="btnStartExam" runat="server" ValidationGroup="exam" Style="background-color: #28a745; color: #fff" Text="Start" OnClick="btnStartExam_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="80%">
                    <Columns>
                        <asp:BoundField HeaderText="Number Of Attempts" DataField="NoOfAttempts" />
                        <asp:BoundField HeaderText="Attempted On" DataField="CreatedOn" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">No records found.</div>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" Height="30px" VerticalAlign="Middle" Font-Size="Medium"/>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
           
        </div>
    </div>
</asp:Content>
