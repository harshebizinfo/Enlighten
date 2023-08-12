<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Group.master" AutoEventWireup="true" CodeBehind="AssignGroup.aspx.cs" Inherits="LMS.Admin.AssignGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>User</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlapplicationUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlapplicationUser_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select User" InitialValue="0" ValidationGroup="GroupAssign" ControlToValidate="ddlapplicationUser" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Groups</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlGroupList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Group / Role" InitialValue="0" ValidationGroup="GroupAssign" ControlToValidate="ddlapplicationUser" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-2">
                <label></label>
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" ValidationGroup="GroupAssign"/>
                    
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="10" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TenantUserGroupID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GroupName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Primary">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsPrimary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"IsDefault").ToString()=="True"?"✓":"X" %>'  ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Primary Role" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkPrimary"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkDeleteYoutubePlayList" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("TenantUserGroupID") %>'
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
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Button ID="btnShowPopupTwo" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopupTwo" PopupControlID="pnlpopuptwo"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground" DropShadow="false">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlpopuptwo" runat="server"  Width="400px" BackColor="White" Style="display: none; padding-top: 0px; padding-left: 0px; border: 0px solid white; border-radius: 5px; height: auto; margin-top: -10%; transition: transform 200ms ease; z-index: 20;">
                 <div class="row" style="margin: 0px 0px -20px 0px">
                            <div class="col-sm-12" align="left" style="background-color: #bae7e3">
                                <table>
                                    <tr>
                                        <td height="50px"><span font-size="Medium" color="black"><b>Delete Assigned Group Name</b></span> </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    <div style="padding: 10px; box-shadow: 0px 0px 0px #888888; text-align: center; width: 390px" backcolor="White">
                       
                        <div class="row">
                            <div class="col-sm-12" align="center">
                                <br>
                                <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label>
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
            <div class="col-sm-2">
                <asp:Button class="btn btn-block" ID="btnSetIsPrimary" runat="server" Style="background-color: #28a745; color: #fff" Text="Set Primary" OnClick="btnSetIsPrimary_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
