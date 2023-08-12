﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/Assignment.master" AutoEventWireup="true" CodeBehind="UploadAssignmentFile.aspx.cs" Inherits="LMS.Learner.UploadAssignmentFile" %>
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

            .assignmentcolumnwidth {
                width: 20%;
            }
            .assignmentSrNumbercolumnwidth {
                width: 20.20%;
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
        <div class="row">
            <div class="col-sm-4">
                <label>Department/Standard</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlassignmentList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlassignmentList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Select Assignment" InitialValue="0" ValidationGroup="uploadAssignment" ControlToValidate="ddlassignmentList" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Assignment File</label>
                <div class="form-group">
                    <asp:FileUpload ID="FileUploadAssignment" runat="server" CssClass="form-control" AllowMultiple="true" />
                </div>
            </div>
            <div class="col-sm-4">
                <label></label>
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="btnAssignmentSubmit" runat="server" Width="50%" Style="background-color: #28a745; color: #fff" Text="Save" ValidationGroup="uploadAssignment" OnClick="btnAssignmentSubmit_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
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
                        <%--<asp:BoundField HeaderText="Late Submission" DataField="IsLateSubmitted" />--%>
                        <asp:TemplateField HeaderText="Late Submission">
                            <ItemTemplate>
                                <asp:Label ID="lbllateSubmission" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsLateSubmitted").ToString()=="True"?"Yes":"No" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkAssignmentFileView" runat="server" Text="View All File" CommandName="EditRow" CssClass="btn btn-success" CommandArgument='<%#Eval("Id") %>'
                                    OnClick="linkAssignmentFileView_Click"></asp:LinkButton>
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
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="btnShowPopup" popupcontrolid="pnlpopup"
                    cancelcontrolid="btnCancel" BackgroundCssClass="modalBackground" dropshadow="false">
                </cc1:modalpopupextender>
                <asp:Panel ID="pnlpopup" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
<div class="row" style="margin:0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color:#bae7e3">
                               <table>
                                <tr>
                                <td height="50px"> <span Font-Size="Medium" color="black"><b>Uploaded Documents</b></span> </td>
                                </tr>
                                </table>
                             </div>
                        </div>
                    <div style=" padding: 10px;box-shadow: 0px 0px 0px #888888;text-align:center;width:390px" BackColor="White">
                         <div class="row">
                             <div class="col-sm-12" ><br></div>
                             <div class="col-sm-12" align="left">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid"
                    BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%" OnRowCommand="GridView2_RowCommand"  OnRowDataBound="GridView2_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <a href='<%# Eval("FilePath") %>' target="_blank"><font color="blue">Download File</font></a>
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
                        </div>
                        <div class="row">
                            <div class="col-sm-12" ><br></div>
                            <div class="col-sm-1" ></div>
                            <div class="col-sm-2" align="left">
                                
                             </div>
                            <div class="col-sm-12" align="left">
                                 <%--<asp:Button ID="btnUpdate" CssClass="btn btn-success float-end" BackColor="#28a745" BorderColor="White" ForeColor="White" CommandName="Update" runat="server" Text="Update" onclick="btnUpdate_Click"/>--%>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger float-end" BackColor="#dc3545" BorderColor="White" ForeColor="White" />
                             </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
               <%-- <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="50%" OnRowCommand="GridView2_RowCommand">
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
                </asp:GridView>--%>
            </div>
        </div>
    </div>
</asp:Content>
