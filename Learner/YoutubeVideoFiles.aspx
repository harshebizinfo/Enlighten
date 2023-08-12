<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/DriveDocumentFiles.master" AutoEventWireup="true" CodeBehind="YoutubeVideoFiles.aspx.cs" Inherits="LMS.Learner.YoutubeVideoFiles" %>

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
                width: 50%;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Select Subject</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlSubjectCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectCourse_SelectedIndexChanged1">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Lesson</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlAssignmentLesson" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignmentLesson_SelectedIndexChanged1">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select PlayList</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlPlayList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlayList_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <%--<div class="col-sm-4">
                <div class="table-responsive">
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewYoutubePlayList_RowDataBound"
                                    ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                                    AllowPaging="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="VideoPlayList Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVideoPlayListId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PlayListId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Position" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosition" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Position") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkDeleteYoutubePlayList" runat="server" ValidationGroup="ddlAddPlayList" Text="Play" CssClass="btn btn-success" CommandArgument='<%#Eval("PlayListId") %>'
                                                    OnClick="linkAddYoutubePlayList_Click"></asp:LinkButton>
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
            <div class="col-sm-1"></div>--%>
            <div class="col-sm-6">
                <iframe id="ifrmselectedVideo" runat="server" width="100%"  src= ""  height="550" frameborder="0" allowfullscreen></iframe>
                <%--<asp:Literal runat="server" id="MyYoutubeVideo" />--%>
            </div>
        </div>
    </div>
</asp:Content>
