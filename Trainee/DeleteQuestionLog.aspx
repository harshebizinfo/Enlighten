<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Exam.master" AutoEventWireup="true" CodeBehind="DeleteQuestionLog.aspx.cs" Inherits="LMS.Trainee.DeleteQuestionLog" %>
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
                 width: 11.11%;
             }
        </style>
    </head>
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
           
            <div class="col-sm-3">
                <label>Select Student\Learner</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlLearner" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Student / Learner" InitialValue="0" ControlToValidate="ddlLearner" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label></label>

                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="btnStartExam" runat="server"  ValidationGroup="CheckQuestionPaper" Style="background-color: #28a745; color: #fff; left: 0px; top: 0px;" Text="Get Details" OnClick="btnStartExam_Click" />
                </div>
            </div>
        </div>
    <div class="row">
        <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        ShowHeaderWhenEmpty="True" PageSize="200" style="text-align:center" class="table table-bordered"
          AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Sr No." DataField="Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Question" DataField="Question" />
                    <asp:BoundField HeaderText="Correct Option" DataField="CorrectOption" />
                    <asp:BoundField HeaderText="Answer" DataField="Answer" />
                    <asp:BoundField HeaderText="Mark" DataField="QuestionMarks" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Attempts" DataField="NumberOfAttempts" />
                    <asp:BoundField HeaderText="Value to Compare" DataField="ValueToCompare" />
                    <asp:BoundField HeaderText="Min Value" DataField="MinValue" />
                    <asp:BoundField HeaderText="Max Value" DataField="MaxValue" />
                    <asp:BoundField HeaderText="Message" DataField="ErrorMessage" />
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
    <div class="row">
           <div class="col-sm-3">
                <label>Enter Attempts Number :</label>

                <div class="form-group">
                    <asp:TextBox ID="txtAttemptsNumber" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="deleteQuestionLog" ErrorMessage="Enter Attempt Number which you have to delete" ControlToValidate="txtAttemptsNumber" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
        <div class="col-sm-2">
            <label></label>

            <div class="form-group">
                <asp:Button class="btn btn-block" ID="btnSave" runat="server" Style="background-color: #28a745; color: #fff; left: 0px; top: 0px;" Text="Delete" OnClick="btnSave_Click" ValidationGroup="deleteQuestionLog"/>
            </div>
        </div>
    </div>
</asp:Content>
