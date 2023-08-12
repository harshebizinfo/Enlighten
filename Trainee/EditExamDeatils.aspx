<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Exam.master" AutoEventWireup="true" CodeBehind="EditExamDeatils.aspx.cs" Inherits="LMS.Trainee.EditExamDeatils" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
      
    </head>
    <div class="container-fluid">
        <div class="row">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Exam</label>

                <div class="form-group">
                   <%-- <asp:DropDownList class="form-control" ID="ddlExam" runat="server">
                    </asp:DropDownList>--%>
                    <asp:TextBox CssClass="form-control" ReadOnly="true" ID="txtExamName" runat="server" autocomplete="off" placeholder="Enter Exam Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Schedule Start Date of Exam/Test</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtstartDatetime" runat="server" placeholder="Enter Start DateTime" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtstartDatetime" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                </div>
            </div>
            <div class="col-sm-4">
                <label>Schedule End Date of Exam/Test</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtEndDatetime" runat="server" placeholder="Enter End DateTime" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEndDatetime" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Total Marks</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtTotalMarks" runat="server" autocomplete="off" placeholder="Enter Total Marks"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-3">
                 <label>Number of questions to be asked</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtnumberofQuestion" runat="server" placeholder="Enter Number of Question" TextMode="Number"></asp:TextBox>
                </div>
            </div>
             <div class="col-sm-3">
                 <label>Duration Of Exam in Minutes</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDuration" runat="server" placeholder="Enter Duration of Exam in minutes" TextMode="Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4"></div>
<div class="col-sm-4"></div>
<div class="col-sm-4"><div class="row">

            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" width="150px" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button1_Click" />
                </div>
            </div>
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                </div>
            </div>
</div></div>
        </div>
    </div>
</asp:Content>
