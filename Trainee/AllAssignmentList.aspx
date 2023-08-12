<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Dashboard.master" AutoEventWireup="true" CodeBehind="AllAssignmentList.aspx.cs" Inherits="LMS.Trainee.AllAssignmentList" %>
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
                width: 12.5%;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text" AutoPostBack="true" onkeyup="RefreshUpdatePanel();"></asp:TextBox>
                </div>
                 <div class="col-sm"><asp:Button ID="src" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="src_Click" /></div>
                 
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                    AllowPaging="true" OnRowDataBound="GridView1_RowDataBound"  OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No." Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Department" DataField="DepartmentStandardName" />
                        <asp:BoundField HeaderText="Course" DataField="CourseName" />
                        <asp:BoundField HeaderText="Title" DataField="AssignmentTitle" />
                        <asp:BoundField HeaderText="No. Of Student" DataField="TotalLearner" />
                        <asp:BoundField HeaderText="Submitted" DataField="AssignmentSubmitted" />
                        <asp:BoundField HeaderText="Pending" DataField="AssignmentPending" />
                        <asp:TemplateField HeaderText="Submission Date">
                            <ItemTemplate>
                                <asp:Label ID="lblSubmissionDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SubmissionDate","{0: dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Submission Date" DataField='<%# Eval("SubmissionDate","{0: dd/MM/yyyy}")%>' />--%>
                        <%--<asp:BoundField HeaderText="Assignment File" DataField="AssignmentFilePath" ItemStyle-Width="80" HeaderStyle-Width="80"  ItemStyle-Wrap="true"/>--%>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkAssignmentFileView" runat="server" Text="View Student" CommandName="EditRow" CssClass="btn btn-success" CommandArgument='<%#Eval("Id") %>'
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
            </div>
        </div>
    </div>
</asp:Content>
