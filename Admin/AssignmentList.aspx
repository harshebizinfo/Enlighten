<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Lesson.master" AutoEventWireup="true" CodeBehind="AssignmentList.aspx.cs" Inherits="LMS.Admin.AssignmentList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                height: 30px;
                /*left: 50%;*/
            }

            .columnwidth {
                width: 16.67%;
            }

            .videocolumnwidth {
                width: 25%;
            }

            .filescolumnwidth {
                width: 20%;
            }

            .assignmentcolumnwidth {
                width: 14.20%;
            }

            .modalBackground {
                height: 100%;
                background-color: black;
                filter: alpha(opacity=20);
                opacity: 0.7;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="card">
            <div class="row">
                <div class="col-sm-12">
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <label>Department/Standard</label>

                    <div class="form-group">
                        <asp:DropDownList class="form-control" ID="ddlassignmentdepartmentList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlassignmentdepartmentList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Select Department / Standard" InitialValue="0" ValidationGroup="AssignmentList" ControlToValidate="ddlassignmentdepartmentList" runat="server" ForeColor="Red" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label>Course/Subject</label>

                    <div class="form-group">
                        <asp:DropDownList class="form-control" ID="ddlassignmentCourseList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlassignmentCourseList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Select Course" InitialValue="0" ValidationGroup="AssignmentList" ControlToValidate="ddlassignmentCourseList" runat="server" ForeColor="Red" />
                    </div>
                </div>
                <div class="col-sm-3">
                    <label>Sequence/Lesson</label>

                    <div class="form-group">
                        <asp:DropDownList class="form-control" ID="ddlassignmentLessonList" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Select Lesson" InitialValue="0" ValidationGroup="AssignmentList" ControlToValidate="ddlassignmentLessonList" runat="server" ForeColor="Red" />
                    </div>
                </div>
                <div class="col-sm-2">
                    <label></label>
                    <div class="form-control">
                        <asp:Button class="btn btn-block" ID="btnAssignmentSearch" runat="server" ValidationGroup="AssignmentList" Style="background-color: #28a745; color: #fff" Text="Search" OnClick="btnAssignmentSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="20" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Department" DataField="DepartmentName" />
                            <asp:BoundField HeaderText="Course" DataField="CourseName" />
                            <asp:BoundField HeaderText="Lesson" DataField="LessonName" />
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="Description" DataField="Description" />
                            <asp:BoundField HeaderText="Submission Date" DataField="SubmissionDate" />
                            <%--<asp:BoundField HeaderText="Assignment File" DataField="AssignmentFilePath" ItemStyle-Width="80" HeaderStyle-Width="80"  ItemStyle-Wrap="true"/>--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkAssignmentFileView" runat="server" Text="View All File" CommandName="EditRow" CssClass="btn btn-success" CommandArgument='<%#Eval("Id") %>'
                                        OnClick="linkAssignmentFileView_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="linkAssignmentDelete" runat="server" Text="Delete" CommandName="DeleteRow" CssClass="btn btn-danger" CommandArgument='<%#Eval("Id") %>'
                                        OnClick="linkAssignmentDelete_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center">No records found.</div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" Width="12.50%" VerticalAlign="Middle" Font-Size="Medium" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <br>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                       <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlpopuptwo" runat="server" BackColor="White" Width="400px" Style="display: none; background-color: white; padding-top: 10px; padding-left: 0px; border: 5px solid white; border-radius: 20px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                        <div style="padding: 10px; box-shadow: 5px 10px 18px #888888; text-align: center; width: 390px">
                            <div class="row">
                                <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                                    <table>
                                        <tr>
                                            <td height="50px"><span font-size="Medium" color="black"><b>Delete Course / Subject</b></span> </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    <br>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    Are you Sure? You want to delete
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <br>
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-3" align="left">
                                </div>
                                <div class="col-sm-8" align="left">
                                    <asp:Button ID="Button1" CssClass="btn btn-danger float-end" BackColor="#dc3545" BorderColor="Black" ForeColor="White" CommandName="Delete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger float-end" BorderColor="Black" ForeColor="White" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%" OnRowCommand="GridView2_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File Path">
                                <ItemTemplate>
                                    <a href='<%# Eval("FilePath") %>' target="_blank">Linked File</a>
                                </ItemTemplate>
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
                <div class="col-sm-2"></div>
            </div>
        </div>
    </div>
</asp:Content>
