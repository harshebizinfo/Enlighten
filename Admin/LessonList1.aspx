<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Lesson.master" AutoEventWireup="true" CodeBehind="LessonList1.aspx.cs" Inherits="LMS.Admin.LessonList1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                 width: 16.67%;
                 text-wrap:initial;
                word-wrap:initial;
             }
           .publishedcolumnwidth {
                width: 10%;
            }
        </style>
    </head>
<script type="text/javascript">
    function RefreshUpdatePanel() {
        __doPostBack('<%= txtSearch.ClientID %>', '');
    };
</script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
                <%--<asp:Button ID="btnCOurseSubject" runat="server" Text="Add Course/Subject" data-toggle="modal" data-target="#myModal"/>--%>
                
            </div>

        </div>
        <div class="row">
            <div class="breadcrumb col-sm-12" style="width:100%">
                <div class="col-sm-flex">
                    <asp:Button ID="btnAddLesson" CssClass="btn btn-primary" runat="server" Text="Add Lesson" OnClick="btnAddLesson_Click" />&nbsp;&nbsp;&nbsp;</div>
<div class="col-sm-flex">
                    <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="Publish" OnClick="btnPublish_Click"/>&nbsp;&nbsp;&nbsp;</div>
<div class="col-sm-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;</div>
<%--<div class="col-sm-flex">
                    <asp:Button ID="btnListDelete" CssClass="btn btn-primary"  runat="server" Text="Delete" OnClick="btnListDelete_Click"/>
                &nbsp;&nbsp;&nbsp;</div>--%>
<div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text"  AutoPostBack="true" onkeyup="RefreshUpdatePanel();"></asp:TextBox>
                </div>
<div class="col-md-flex">
                    &nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-md-flex">
                    <asp:Button ID="src" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="src_Click" />
                </div>
            </div>
        </div>

        <div class="row">
<div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
           <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        ShowHeaderWhenEmpty="True" PageSize="200" style="text-align:center" class="table table-bordered"
          AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                         <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
  <asp:TemplateField HeaderText="Publish" ItemStyle-HorizontalAlign="Center">
                             <ItemTemplate>
                                 <asp:CheckBox runat="server" ID="chkIsActive" Checked='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:CheckBox>
                             </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Standard / Department" >
                        <ItemTemplate>
                            <asp:Label ID="lbldepartmentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"DepartmentStandardName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Course / Subject" DataField="CourseSubjectName" />--%>
                    <asp:TemplateField HeaderText="Course / Subject" >
                        <ItemTemplate>
                            <asp:Label ID="lblsubjectname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CourseSubjectName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lesson" >
                        <ItemTemplate>
                            <asp:Label ID="lbllessontitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"LessonTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Lesson" DataField="LessonTitle" />--%>
                        <%--<asp:BoundField HeaderText="Is Active" DataField="IsActive" />--%>
                    <asp:TemplateField HeaderText="Status" >
                        <ItemTemplate>
                            <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive").ToString()=="True"?"Active":"InActive"  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       
                        <%--<asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                             <ItemTemplate>
                                 <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                             </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                        <%--<asp:BoundField HeaderText="Action" />--%>
                        <asp:TemplateField  HeaderText="Action">
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="LkB1" runat="server" Text="Edit" CssClass="btn btn-success"  CommandName="Edit"  Checked='<%# DataBinder.Eval(Container.DataItem,"IsActive") %>'></asp:LinkButton>--%>
                                <asp:LinkButton ID="LkB2" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgdeletebtn_Click"></asp:LinkButton>
                                <%--<asp:LinkButton ID="LkB11" runat="server" CommandName="Delete"><i class="fa fa-trash" style="color:red;font-size:20px"></i></asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">No records found.</div>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" ForeColor="white"/>
                    <PagerStyle />
                    <RowStyle  />
                    <SelectedRowStyle />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <br />
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlpopuptwo" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
<div class="row" style="margin: 0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color:#bae7e3">
                               <table>
                                <tr>
                                <td height="50px"> <span Font-Size="Medium" color="black"><b>Delete Lesson</b></span> </td>
                                </tr>
                                </table>
                             </div>
                        </div>
                    <div style=" padding: 10px;box-shadow: 0px 0px 0px #888888;text-align:center;width:390px" backcolor="White">
                         
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <br>
<asp:Label runat="server" ID="lblDeleteAdminLessonId" Text="Label" Visible="false"></asp:Label>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" align="center" >
                               <font size="4">Are you Sure? You want to delete</font>
                             </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" ><br></div>
                            <div class="col-sm-1" ></div>
                            <div class="col-sm-3" align="left">
                                
                             </div>
                            <div class="col-sm-8" align="left">
                                <asp:Button ID="Button1" CssClass="btn btn-success float-end" BorderColor="White" ForeColor="White" CommandName="Delete" runat="server" Text="Yes" onclick="btnDelete_Click"/>
                                    <asp:Button ID="btnCancel" runat="server" Text="No" class="btn btn-danger float-end" BorderColor="White" ForeColor="White" />
                             </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
</div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
