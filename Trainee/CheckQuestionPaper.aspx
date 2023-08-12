<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Exam.master" AutoEventWireup="true" CodeBehind="CheckQuestionPaper.aspx.cs" Inherits="LMS.Trainee.CheckQuestionPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <head>
          <style type="text/css">
            .modalBackground 
            {
                height:100%;
                background-color:black;
                filter:alpha(opacity=20);
                opacity:0.7;
            }
            .columnwidth
             {
                 width: 16.64%;
             }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3">
                <label>Select Standard</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlDepartmentStandard" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartmentStandard_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Department / Standard" InitialValue="0" ValidationGroup="CheckQuestionPaper" ControlToValidate="ddlDepartmentStandard" runat="server" ForeColor="Red" />
                </div>
            </div>
            
            <div class="col-sm-3">
                <label>Select Subject</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlSubjectCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectCourse_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Select Subject / Course" ValidationGroup="CheckQuestionPaper" InitialValue="0" ControlToValidate="ddlSubjectCourse" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label>Select Exam</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlExam" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Exam" InitialValue="0" ValidationGroup="CheckQuestionPaper" ControlToValidate="ddlExam" runat="server" ForeColor="Red" />
                </div>
            </div>
            <%--<div class="col-sm-3">
                <label>Select Student\Learner</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlLearner" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Student / Learner" InitialValue="0" ControlToValidate="ddlLearner" runat="server" ForeColor="Red" />
                </div>
            </div>--%>
            <div class="col-sm-3">
                <label></label>

                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="btnStartExam" runat="server"  ValidationGroup="CheckQuestionPaper" Style="background-color: #28a745; color: #fff; left: 0px; top: 0px;" Text="Get Details" OnClick="btnStartExam_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
        ShowHeaderWhenEmpty="True" PageSize="200" style="text-align:center" class="table table-bordered"
          AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="User Id" DataField="ApplicationUserId" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Email Id" DataField="EmailId" />
                        <asp:BoundField HeaderText="Marks Obtained" DataField="TotalObtainedMarks" />
                        <asp:BoundField HeaderText="TotalMarks" DataField="TotalMarks" />
                        <asp:BoundField HeaderText="Attempts" DataField="NumberOfAttempts" />
                        <asp:TemplateField HeaderStyle-Width="150px" HeaderText="Action">
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="imgbtndetails" runat="server"  Height="30px" Width="30px" OnClick="imgbtn_Click" ><i class="fa fa-pencil-square-o" style="color:navy;font-size:20px"></i></asp:ImageButton>--%>
                                <asp:LinkButton ID="LkB1" runat="server" CommandName="EditRow" OnClick="imgbtn_Click">View Details</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">No records found.</div>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" Height="30px" VerticalAlign="Middle" Font-Size="Medium" />
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
