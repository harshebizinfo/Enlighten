<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/Event.master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="LMS.Learner.Event1" %>

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
                text-wrap:initial;
                word-wrap:initial;
            }
        </style>
    </head>
    <div class="">
        <div class="row">
            <div class="col-sm-12">
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </div>
        </div>
        <div class="row">
            <div class="breadcrumb col-sm-12" style="width: 100%">
                <div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="txtFromdate" runat="server" placeholder="Enter From Date" OnTextChanged="txtFromdate_TextChanged" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFromdate" Format="yyyy-MM-dd"></asp:CalendarExtender>
                </div>
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;</div>
                <div class="col-sm-flex">
                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Enter To Date" OnTextChanged="TextBox4_TextChanged" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBox4" Format="yyyy-MM-dd"></asp:CalendarExtender>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="GrdViewScheduleClass" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="20" Style="text-align: center" class="table table-bordered"
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
</asp:Content>
