<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Lesson.master" AutoEventWireup="true" CodeBehind="UploadVideo.aspx.cs" Inherits="LMS.Admin.UploadVideo" %>

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
                width: 25%;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-8">
                <asp:Button class="btn btn-primary" ID="btnUploadVideo" runat="server" Text="Upload Video" OnClick="btnUploadVideo_Click" />
                <asp:Button class="btn btn-primary" ID="btnCreatePlayList" runat="server" Text="Create Play List" OnClick="btnCreatePlayList_Click" />
                <asp:Button class="btn btn-primary" ID="btnViewPlayList" runat="server" Text="View Play List" OnClick="btnViewPlayList_Click" />
                <asp:Button class="btn btn-primary" ID="btnAddItemInPL" runat="server" Text="Add Video In Play List" OnClick="btnAddItemInPL_Click" />
                <asp:Button class="btn btn-primary" ID="btnDeleteItemPL" runat="server" Text="Remove Video In Play List" OnClick="btnDeleteItemPL_Click" />
                <asp:Button class="btn btn-primary" ID="btnViewPlaylistByPlayListId" runat="server" Text="Play Video In Play List" OnClick="btnViewPlaylistByPlayListId_Click" />
            </div>
            <div class="col-sm-12">
                <asp:MultiView ID="MultiViewVideo" runat="server">
                    <asp:View ID="ViewUploadVideo" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Department/ Standard</label>
                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddllessonDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddllessonDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Department" InitialValue="0" ControlToValidate="ddllessonDepartment" ValidationGroup="video" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Course</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Select Course" InitialValue="0" ControlToValidate="ddlCourse" ValidationGroup="video" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Lesson</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlLesson" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Lesson" InitialValue="0" ControlToValidate="ddlLesson" ValidationGroup="video" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                            </div>
                         
                            <div class="row">
                                    <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="video" OnClick="btnSubmit_Click" />

                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewCreatePlayList" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label>Department/ Standard</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddldepartmentplaylist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldepartmentplaylist_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Select Department" InitialValue="0" ControlToValidate="ddldepartmentplaylist" ValidationGroup="createPlayList" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <label>Course</label>

                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlCOursePlayList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCOursePlayList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Select Course" InitialValue="0" ControlToValidate="ddlCOursePlayList" ValidationGroup="createPlayList" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <label>Lesson</label>

                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlLessonPlayList" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Select Lesson" InitialValue="0" ControlToValidate="ddlLessonPlayList" ValidationGroup="createPlayList" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label>Title</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtpaylisttitle" runat="server" placeholder="Enter Video Title"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtpaylisttitle" ValidationGroup="video" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-sm-4">
                                <label>Description</label>

                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPlaylistdescription" runat="server" placeholder="Enter Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtPlaylistdescription" ValidationGroup="video" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            <div class="col-md-flex">
                                <div class="form-group">
                                    <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                                    <asp:Button ID="btnPlayListSave" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="createPlayList" OnClick="btnPlayListSave_Click" />

                                </div>
                            </div>
                            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                            <div class="col-md-flex">
                                <div class="form-group">
                                    <asp:Button class="btn btn-block" Width="150px" ID="btnPlayListCancel" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="btnPlayListCancel_Click" />
                                </div>
                            </div>
                        </div>

                    </asp:View>
                    <asp:View ID="ViewPlayList" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                                <asp:GridView ID="GridViewYoutubePlayList" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewYoutubePlayList_RowDataBound"
                                    ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                                    AllowPaging="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Event Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEventId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PlayListId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PublishedAt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkDeleteYoutubePlayList" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("PlayListId") %>'
                                                    OnClick="linkDeleteYoutubePlayList_Click"></asp:LinkButton>
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
                    </asp:View>
                    <asp:View ID="ViewAddItemInPL" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label>Select PlayList :</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlAddPlayList" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Text="Select PlayList" InitialValue="0" ControlToValidate="ddlAddPlayList" ValidationGroup="addPL" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-1">
                                <br />
                            </div>
                            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
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
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PublishedAt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkDeleteYoutubePlayList" runat="server" ValidationGroup="ddlAddPlayList" Text="Add" CssClass="btn btn-success" CommandArgument='<%#Eval("PlayListId") %>'
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
                    </asp:View>
                    <asp:View ID="ViewRemoveItemInPL" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label>Select PlayList :</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlRemovePlayList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRemovePlayList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Select PlayList" InitialValue="0" ControlToValidate="ddlRemovePlayList" ValidationGroup="RemovePL" runat="server" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-1">
                                <br />
                            </div>
                            <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridViewYoutubePlayList_RowDataBound"
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
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StartTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PublishedAt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkDeleteYoutubePlayList" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("PlayListId") %>'
                                                    OnClick="linkDeletePlayListItem_Click"></asp:LinkButton>
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
                    </asp:View>
                    <asp:View ID="ViewPlayVideoOfPL" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <label>Department/ Standard</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlplayVideoDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlplayVideoDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <label>Select PlayList :</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlPlayVideoPlaylist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlayVideoPlaylist_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-sm-1">
                                <br />
                            </div>
                            <div class="col-sm-6">
                                <iframe id="ifrmselectedVideo" runat="server" width="100%"  src= ""  height="550" frameborder="0" allowfullscreen></iframe>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
