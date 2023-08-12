<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NoticeMaster.master" AutoEventWireup="true" CodeBehind="NoticeList.aspx.cs" Inherits="LMS.Admin.NoticeList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <head>
        <style type="text/css">
            .modalBackground {
                height: 100%;
                background-color: black;
                filter: alpha(opacity=20);
                opacity: 0.7;
            }

            .columnwidth {
                width: 16.67%;
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
            <%--<div class="col-sm-6">--%>
            <%--<asp:Button ID="btnCOurseSubject" runat="server" Text="Add Course/Subject" data-toggle="modal" data-target="#myModal"/>--%>
        </div>
        <div class="row">
            <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-sm-flex">
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal" style="color: black">
                        Add Notice
                    </button>
                    &nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-sm-flex">
                    <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="Publish" OnClick="btnPublish_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-sm-flex">
                    <asp:Button ID="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />&nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-sm-flex">
                    <%--<asp:Button ID="btnListDelete" CssClass="btn btn-primary" runat="server" Text="Delete" OnClick="btnListDelete_Click" />--%>
                    <%--</div>--%>
                    <!-- The Modal -->
                    <div class="modal" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <%--<div class="row"><div class="col-sm-12"><br></div></div>--%>
                                <!-- Modal Header -->
                                <div class="modal-header" style="background-color: #bae7e3">
                                    <span font-size="Medium" color="black"><b>Add Notice</b></span>
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                </div>

                                <!-- Modal body -->
                                <div class="modal-body">
                                    <div class="mb-3">
                                        <%--<label class="form-label">Department / Standard Name</label>--%>
                                        <asp:TextBox CssClass="form-control" ID="txtSubjectName" runat="server" placeholder="Notice Title"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Notice Title" ForeColor="Red" Text="*" ControlToValidate="txtSubjectName" ValidationGroup="addNotice"></asp:RequiredFieldValidator>
                                    </div>
                                     <div class="mb-3">
                                        <%--<label class="form-label">Department / Standard Name</label>--%>
                                        <asp:TextBox CssClass="form-control" ID="txtNoticeDescription" runat="server" placeholder="Notice Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Notice Description" ForeColor="Red" Text="*" ControlToValidate="txtNoticeDescription" ValidationGroup="addNotice"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="mb-3">
                                        <asp:CheckBox ID="CheckBox1" runat="server" />&nbsp; Publish
                                    </div>
                                </div>

                                <!-- Modal footer -->
                                <div class="modal-footer" style="justify-content: flex-start;">
                                    <div class="">
                                        <asp:Button class="btn btn-block" ID="Button9" runat="server" CssClass="btn btn-success float-end" Style="background-color: #28a745; color: #fff" Text="Submit" OnClick="Button9_Click"  ValidationGroup="addNotice"/>
                                        <%--<button type="submit" id="saveDepartment" class="btn btn-success float-end">Submit</button>--%>
                                        <button type="submit" class="btn btn-danger float-end">Cancel</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <%--&nbsp;&nbsp;&nbsp;--%>
                </div>
                <div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text" AutoPostBack="true" onkeyup="RefreshUpdatePanel();"></asp:TextBox>
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
                        ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
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
                            <asp:TemplateField HeaderText="Title">
                                <ItemTemplate>
                                    <asp:Label ID="lbldepartmentname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Title") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoticeDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NoticeDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreatedOn" HeaderText="Created On" ItemStyle-Width="150" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsActive").ToString()=="True"?"Active":"InActive" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--  <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                             <ItemTemplate>
                                 <asp:CheckBox runat="server" ID="chkDelete"></asp:CheckBox>
                             </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>--%>
                            <%--<asp:BoundField HeaderText="Action" />--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="imgbtndetails" runat="server"  Height="30px" Width="30px" OnClick="imgbtn_Click" ><i class="fa fa-pencil-square-o" style="color:navy;font-size:20px"></i></asp:ImageButton>--%>
                                    <%--<asp:LinkButton ID="LkB1" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="EditRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgbtn_Click"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="LkB2" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgdeletebtn_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Assign" CssClass="btn btn-warning" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' OnClick="imgAssignbtn_Click"></asp:LinkButton>

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
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlpopup" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                        <div class="row" style="margin: 0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                                <table>
                                    <tr>
                                        <td height="50px"><span font-size="Medium" color="black"><b>Update Notice</b></span> </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="padding: 10px; box-shadow: 0px 0px 0px #888888; text-align: center; width: 390px" backcolor="White">

                            <div class="row">
                                <div class="col-sm-1"></div>
                                <div class="col-sm-4" align="left">
                                </div>
                                <div class="col-sm-6" align="left">
                                    <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                    <br>
                                    <%--<asp:HiddenField ID="inpHide" runat="server" />--%>
                                </div>
                                <div class="col-sm-1"></div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="left">
                                    <label class="form-label">Notice Title</label>
                                    <asp:TextBox ID="txtname" CssClass="form-control" placeholder="Enter Notice Title" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Notice Title" ForeColor="Red" Text="*" ControlToValidate="txtname" ValidationGroup="updateNotice"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="left">
                                    <label class="form-label">Notice Decription</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Enter Notice Description" runat="server" TextMode="MultiLine" Rows="2" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Notice Description" ForeColor="Red" Text="*" ControlToValidate="TextBox1" ValidationGroup="updateNotice"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="left">
                                    <asp:CheckBox ID="CheckBox2" runat="server" />&nbsp;&nbsp;&nbsp;Publish
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <br>
                                </div>
                                <div class="col-sm-12" align="left">
                                    <asp:Button ID="btnUpdate" CssClass="btn btn-success float-end" BackColor="#28a745" BorderColor="white" ForeColor="White" ValidationGroup="updateNotice" CommandName="Update" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger float-end" BackColor="#dc3545" BorderColor="white" ForeColor="White" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                        CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlpopuptwo" runat="server" Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                        <div class="row" style="margin: 0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                                <table>
                                    <tr>
                                        <td height="50px"><span font-size="Medium" color="black"><b>Delete Notice</b></span> </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div style="padding: 10px; box-shadow: 0px 0px 0px #888888; text-align: center; width: 390px" backcolor="White">

                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    <br>
                                    <asp:Label runat="server" ID="lblDeleteAdminDepartmentId" Text="Label" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12" align="center">
                                    <font size="4">Are you Sure? You want to delete</font>
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
                                    <asp:Button ID="Button1" CssClass="btn btn-success float-end" BorderColor="White" ForeColor="White" CommandName="Delete" runat="server" Text="Yes" OnClick="btnDelete_Click" />
                                    <asp:Button ID="Button2" runat="server" Text="No" class="btn btn-danger float-end" BorderColor="White" ForeColor="White" />
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
