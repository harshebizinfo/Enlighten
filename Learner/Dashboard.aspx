<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/Dashboard.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS.Learner.Dashboard1" %>

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
            .singleValuecolumnwidth {
                width: 20%;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-5">
                <h4>School Details :</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    ShowHeaderWhenEmpty="True" PageSize="2" Style="text-align: center" class="table table-bordered"
                    AllowPaging="true" OnRowDataBound="gridViewdriveDocument_RowDataBound">
                    <Columns>
                        <%--   <asp:BoundField HeaderText="Roll Number" DataField="Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Name" DataField="ClientName" />
                        <asp:BoundField HeaderText="Email ID" DataField="EmailID" />
                        <asp:BoundField HeaderText="Contact No." DataField="ContactNumber" />
                        <asp:BoundField HeaderText="Institute Name " DataField="InstituteName" />
                        <asp:BoundField HeaderText="Address " DataField="Address" />
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
            <%--<button type="button" class="btn btn-primary">Calender View</button>--%>
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
                                                    <asp:Label ID="lblAssignmentTitle" runat="server" Text='<%#Eval("AssignmentTitle")%>'></asp:Label></h5>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("CourseName")%>'></asp:Label>
                                                <br />
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
        <%--<br />
        <div class="row">
            <div class="col-sm-5">
                <h4>Task For Me</h4>
                <div class="vertical"></div>
                <h4>Calender View</h4>
            </div>
        </div>
        <div class="row">
            <button type="button" class="btn btn-primary">Schedule Papers</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <button type="button" class="btn " style="background-color: #edb266; color: white">Assignments Check</button>
        </div>--%>
    </div>
</asp:Content>
