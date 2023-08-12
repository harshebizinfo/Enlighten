<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Dashboard.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS.Trainee.Dashboard1" %>

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
                height: 50px;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div id="course" runat="server">
            <div class="row">
                <div class="col-sm-5">
                    <h4>Today's Courses</h4>
                    <%--<div class="vertical"></div>
                            <h4>Calender View</h4>--%>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12" style="float: left">
                    <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                        <ItemTemplate>
                            <div style="padding: 10px;">
                                <div class="row" style="padding: 10px;">
                                    <div class="col-sm-flex">
                                        <div>
                                            <div class="card  text-center" style="background-color: #d4f0fd; display: table">
                                                <div class="card-body">
                                                    <h5 class="card-title">
                                                        <asp:Label ID="lblAssignmentTitle" runat="server" Text='<%#Eval("Summary")%>'></asp:Label></h5>
                                                    <%--<asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Description")%>'></asp:Label>--%>
                                
                                    Start Date -
                                <asp:Label ID="lblsubmittiondate" runat="server" Text='<%#Eval("StartTime")%>'></asp:Label><br />
                                                    End Date -
                                <asp:Label ID="lbldepartment" runat="server" Text='<%#Eval("EndTime")%>'></asp:Label>
                                                    <%--<button type="button" class="btn btn-primary">Button</button>--%>
                                                    <br />
                                                    <asp:LinkButton ID="linkpay" runat="server" Text="Start Session" Style="background-color: #8bc4bf; color: white" CssClass="btn btn-success" CommandArgument='<%#Eval("MeetLink") %>'
                                                        OnClick="linkrequestFeedback_Click"></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <br />
                </div>
            </div>
            <div class="row">
                <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="More Courses" Style="background-color: #8bc4bf; color: white" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button type="button" class="btn btn-primary">Calender View</button>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-5">
                <h4>Assignments</h4>
                <%--<div class="vertical"></div>
                            <h4>Calender View</h4>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12" style="float: left">
                <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                    <ItemTemplate>
                        <div style="padding: 10px;">
                            <div class="row" style="padding: 10px;">
                                <div class="col-sm-flex">
                                    <div>
                                        <div class="card  text-center" style="background-color: #d4f0fd; display: table">
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <asp:Label ID="lblassignmentSubmitted" runat="server" Text='<%#Eval("AssignmentSubmitted")%>'></asp:Label>/
                                        <asp:Label ID="lbltotalStudent" runat="server" Text='<%#Eval("TotalLearner")%>'></asp:Label></h5>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("CourseName")%>'></asp:Label>
                                                -
                                <asp:Label ID="lblAssignmentTitle" runat="server" Text='<%#Eval("AssignmentTitle")%>'></asp:Label><br />
                                                <asp:Label ID="lblassignmentSubmittwo" runat="server" Text='<%#Eval("AssignmentSubmitted")%>'></asp:Label>
                                                - Submitted<br />
                                                <asp:Label ID="lblassignmentpending" runat="server" Text='<%#Eval("AssignmentPending")%>'></asp:Label>
                                                - Pending<br />
                                                Last Date -
                                <asp:Label ID="lblsubmittiondate" runat="server" Text='<%#Eval("SubmissionDate","{0: dd/MM/yyyy}")%>'></asp:Label><br />
                                                Standard -
                                <asp:Label ID="lbldepartment" runat="server" Text='<%#Eval("DepartmentStandardName")%>'></asp:Label>
                                                <%--<button type="button" class="btn btn-primary">Button</button>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="More Assignment" OnClick="Button1_Click" Style="background-color: #8bc4bf; color: white" />
        </div>
        <br />
        <div class="row">
            <div class="col-sm-5">
                <h4>Task For Me</h4>
                <%--<div class="vertical"></div>
                            <h4>Calender View</h4>--%>
            </div>
        </div>
        <div class="row">
            <button type="button" class="btn btn-primary">Schedule Papers</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button type="button" class="btn " style="background-color: #edb266; color: white">Assignments Check</button>
        </div>
    </div>
</asp:Content>
