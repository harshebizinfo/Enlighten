<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Lesson.master" AutoEventWireup="true" CodeBehind="AddNewLesson.aspx.cs" Inherits="LMS.Admin.AddNewLesson" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            .assignmentSrNumbercolumnwidth {
                width: 20.20%;
            }
            .modalBackground 
            {
                height:100%;
                background-color:black;
                filter:alpha(opacity=20);
                opacity:0.7;
            }
        </style>
    </head>
    <div class="container-fluid">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-sm-6">
                <asp:Button class="btn btn-primary" ID="btnOverview" runat="server" Text="Overview" OnClick="btnOverview_Click" />
                <asp:Button class="btn btn-primary" ID="btnDetails" runat="server" Text="Details" OnClick="btnDetails_Click" />
                <asp:Button class="btn btn-primary" ID="btnScheduleClass" runat="server" Text="Schedule Class" OnClick="btnScheduleClass_Click" />
                <asp:Button class="btn btn-primary" ID="btnAssignment" runat="server" Text="Assignments" OnClick="btnAssignment_Click" />
                <asp:Button class="btn btn-primary" ID="btnAssignmentList" runat="server" Text="Assignment List" OnClick="btnAssignmentList_Click" />
                <%--<asp:Button class="btn btn-primary" ID="btnHistory" runat="server" Text="History" OnClick="btnHistory_Click" />--%>
            </div>
            <div class="col-sm-12">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="ViewOverview" runat="server">
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
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Course</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddllessonCourse" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Publish</label>

                                    <div class="form-group">
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Lesson Title</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtLessonTitle" runat="server" placeholder="Enter Lesson Title"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-4">
                                    <label>Description</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtLessonDescription" runat="server" placeholder="Enter Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <%--<label>Created Person</label>

                                    <div class="form-group">
                                        <label>Seema Dixit</label>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" width="150px" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                                    </div>
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" width="150px" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewDetails" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
<div class="col-sm-12" style="background-color:lightgray;padding-top:5px;padding-bottom:5px">
                                <div class="col-sm-flex">
                                    <asp:Button class="btn btn-primary" ID="btnVideo" runat="server" Text="Video" OnClick="btnVideo_Click" />
                                    <asp:Button class="btn btn-primary" ID="btnDocument" runat="server" Text="Other File" OnClick="btnDocument_Click" />
                                </div>
</div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:MultiView ID="StudyMaterialView" runat="server">
                                        <asp:View ID="Video" runat="server">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-1">
                                                    <asp:Button class="btn btn-primary" Style="color: black" ID="btnUploadVideo" runat="server" Text="Upload Video" OnClick="btnUploadVideo_Click" />
                                                </div>
                                                <div class="col-sm-12">
                                                    <br />
                                                </div>
                                                <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gridviewyoutubevideo" runat="server" AutoGenerateColumns="false" OnRowDataBound="gridviewyoutubevideo_RowDataBound"
                                                            ShowHeaderWhenEmpty="true" PageSize="10" Style="text-align: center" class="table table-bordered"
                                                            AllowPaging="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Video Id" Visible="false">
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
                                                                <asp:TemplateField HeaderText="Published On">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PublishedAt") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="action">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkdeleteyoutubevideo" runat="server" Text="delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("PlayListId") %>'
                                                                            OnClick="linkdeleteyoutubevideo_click"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center">no records found.</div>
                                                            </EmptyDataTemplate>
                                                            <FooterStyle BackColor="white" ForeColor="#000066" />
                                                            <HeaderStyle BackColor="#006699" ForeColor="white" />
                                                            <PagerStyle />
                                                            <RowStyle />
                                                            <SelectedRowStyle />
                                                            <SortedAscendingCellStyle BackColor="#f1f1f1" />
                                                            <SortedAscendingHeaderStyle BackColor="#007dbb" />
                                                            <SortedDescendingCellStyle BackColor="#cac9c9" />
                                                            <SortedDescendingHeaderStyle BackColor="#00547e" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="OtherDocuments" runat="server">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-1">
                                                    <asp:Button class="btn btn-primary" Style="color: black" ID="btnuploadFile" runat="server" Text="Upload Files" OnClick="btnuploadFile_Click" />
                                                </div>
                                                <div class="col-sm-12">
                                                    <br>
                                                </div>
                                                <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridViewdriveDocument" runat="server" AutoGenerateColumns="False" OnRowDataBound="gridViewdriveDocument_RowDataBound"
                                                            ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                                                            AllowPaging="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Event Id" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEventId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Size">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Size") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Version">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Version") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Created Time">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CreatedTime") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkDeleteDriveFile" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("Id") %>'
                                                                            OnClick="linkDeleteDriveFile_Click"></asp:LinkButton>
                                                                        <asp:LinkButton ID="linkPermissionDriveFile" runat="server" Text="Allow to All" CssClass="btn btn-warning" CommandArgument='<%#Eval("Id") %>'
                                                                            OnClick="linkPermissionDriveFile_Click"></asp:LinkButton>
                                                                        <button id="btnDownload" cssclass="btn btn-success" style="border: none; outline: none; background-color: green; color: white; font-size: large;">
                                                                            <a href='<%# Eval("WebContentLink") %>' target="_blank" style="color: white; font-family: inherit; font-size: 1rem; line-height: 1.5;">Download</a></button>
                                                                        <%-- <asp:LinkButton ID="linkDolwnloadDriveFile" runat="server" Text="Download" CssClass="btn btn-success" CommandArgument='<%#Eval("WebContentLink") %>'
                                                                            OnClick="linkDolwnloadDriveFile_Click"></asp:LinkButton>--%>
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
                                            </div>
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewScheduleClass" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="breadcrumb col-sm-12" style="width: 100%">
                                    <div class="col-sm-flex">
                                        <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal" style="color: black">
                                                        Add Session
                                                    </button>--%>
                                        <asp:Button class="btn btn-primary" Style="color: black" ID="Button3" runat="server" Text="Add Session" OnClick="Button3_Click" />
                                    </div>
                                    <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;</div>
                                    <div class="col-sm-flex">
                                        <asp:TextBox CssClass="form-control" ID="txtFromdate" runat="server" placeholder="Enter From Date" OnTextChanged="txtFromdate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFromdate" Format="yyyy-MM-dd"></asp:CalendarExtender>
                                    </div>
                                    <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;</div>
                                    <div class="col-sm-flex">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Enter To Date" OnTextChanged="TextBox4_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBox4" Format="yyyy-MM-dd"></asp:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            </div>
                            <div class="row">
                                <div class="col-sm-flex col-xs-flex col-md-flex col-lg-flex">
                                    <br />
                                    <div class="table-responsive">
                                        <asp:GridView ID="GrdViewScheduleClass" runat="server" AutoGenerateColumns="False"
                                            ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                                            AllowPaging="true" OnRowDataBound="GrdViewScheduleClass_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Event Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEventId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EventId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Title">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSummary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Summary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="StartTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StartTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EndTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"EndTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Organizer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldepartmentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Organizer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkpay" runat="server" Text="Join" CssClass="btn btn-success" CommandArgument='<%#Eval("MeetLink") %>'
                                                            OnClick="linkrequestFeedback_Click"></asp:LinkButton>
                                                        <asp:LinkButton ID="linkfeedback" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("EventId") %>'
                                                            OnClick="linkOpenFeedback_Click"></asp:LinkButton>
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
                                <%--<div class="col-sm-2">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
                                <%--<asp:DataList ID="DataList1" runat="server">
                                        <ItemTemplate>
                                            <asp:Literal ID="Literal1" runat="server" Text='path'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:DataList>--%>
                                <%-- <video width="320" height="240" autoplay="autoplay">
                                        <source type="video/mp4" src='' />
                                    </video>--%>
                                <%--</div>--%>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewAssignment" runat="server">
                        <div class="">
                            <div class="row">
                                <div class="col-sm-12">
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Department/Standard</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlAssignmentDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignmentDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Department / Standard" InitialValue="0" ValidationGroup="CreateAssignment" ControlToValidate="ddlAssignmentDepartment" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Course/Subject</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlAssignmentCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignmentCourse_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Course" InitialValue="0" ValidationGroup="CreateAssignment" ControlToValidate="ddlAssignmentCourse" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Sequence/Lesson</label>

                                    <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="ddlAssignmentLesson" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Select Lesson" InitialValue="0" ValidationGroup="CreateAssignment" ControlToValidate="ddlAssignmentLesson" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Assignment Title</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtQuestion" runat="server" placeholder="Enter Title"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Enter Title" ValidationGroup="CreateAssignment" ControlToValidate="txtQuestion" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Description</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Enter Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Enter Description" ValidationGroup="CreateAssignment" ControlToValidate="TextBox5" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <label>Submission Date of Assignment</label>

                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtSubmissionDate" runat="server" placeholder="Enter Start DateTime" autocomplete="off"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgPopup" runat="server" TargetControlID="txtSubmissionDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Enter Submission Date" ValidationGroup="CreateAssignment" ControlToValidate="txtSubmissionDate" runat="server" ForeColor="Red" />
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-sm-4">
                                    <label>Assignment File</label>
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUploadAssignment" runat="server" CssClass="form-control" AllowMultiple="true" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
<div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-sm-flex">
                                    <asp:Button class="btn btn-block" width="150px" ID="btnAssignmentSubmit" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" ValidationGroup="CreateAssignment" OnClick="btnAssignmentSubmit_Click" />
                                </div>
                                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="col-md-flex">
                                    <div class="form-group">
                                        <asp:Button class="btn btn-block" width="150px" ID="btnassignmentCancel" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewHistory" runat="server">mno</asp:View>
                    <asp:View ID="ViewAssignmentList" runat="server">
                        <div class="">
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
                                    <div class="">
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
                                            <%--<asp:BoundField HeaderText="Submission Date" DataField="SubmissionDate" />--%>
<asp:TemplateField HeaderText="Submission Date">
                            <ItemTemplate>
                                <asp:Label ID="lblSubmissionDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SubmissionDate","{0: dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                                     <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
              <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="btnShowPopup" popupcontrolid="pnlpopup"
                    cancelcontrolid="btnCancel" BackgroundCssClass="modalBackground" dropshadow="false">
                </asp:modalpopupextender>
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
                    BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
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
                            <div class="col-sm-12" align="right">
                                 <%--<asp:Button ID="btnUpdate" CssClass="btn btn-success float-end" BackColor="#28a745" BorderColor="White" ForeColor="White" CommandName="Update" runat="server" Text="Update" onclick="btnUpdate_Click"/>--%>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger float-end" BackColor="#dc3545" BorderColor="White" ForeColor="White" />
                             </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                    CancelControlID="Button2" BackgroundCssClass="modalBackground" DropShadow="false">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlpopuptwo" runat="server" BackColor="White" Width="400px" Style="display: none; background-color: white; padding-top: 10px; padding-left: 0px; border: 5px solid white; border-radius: 20px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                    <div style=" padding: 10px;box-shadow: 5px 10px 18px #888888;text-align:center;width:390px">
                         <div class="row">
                            <div class="col-sm-12" align="left" style="background-color:#bae7e3">
                               <table>
                                <tr>
                                <td height="50px"> <span Font-Size="Medium" color="black"><b>Delete Assignment</b></span> </td>
                                </tr>
                                </table>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <br>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <font size="4"> Are you Sure? You want to delete</font>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" ><br></div>
                            <div class="col-sm-1" ></div>
                            <div class="col-sm-3" align="left">
                                
                             </div>
                            <div class="col-sm-8" align="left">
                                <asp:Button ID="Button1" CssClass="btn btn-success float-end" BorderColor="White" ForeColor="White" CommandName="Delete" runat="server" Text="Yes" onclick="btnDelete_Click"/>
                                    <asp:Button ID="Button2" runat="server" Text="No" class="btn btn-danger float-end" BorderColor="White" ForeColor="White" />
                             </div>
                        </div>
                    </div>
                </asp:Panel>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-8">
                                   <%-- <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%" OnRowCommand="GridView2_RowCommand">
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
                                <div class="col-sm-2"></div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
