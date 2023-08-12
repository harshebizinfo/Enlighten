<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Learner.master" AutoEventWireup="true" CodeBehind="UploadStudent.aspx.cs" Inherits="LMS.Admin.UploadStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
        .columnwidth {
            width: 20%;
        }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-flex">Select Excel File &nbsp;&nbsp;:</div>
            <div class="col-sm-4">
                <div class="form-group">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-md-flex">
                <div class="form-group">
                    <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="video" OnClick="btnSubmit_Click" />

                </div>
            </div>
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                </div>
            </div>
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <button id="btnDownload" cssclass="btn btn-success" style="border: none; outline: none; background-color: green; color: white; font-size: large;">
                        <a href="../Script/LMSStudent.xlsx" target="_blank" style="color: white; font-family: inherit; font-size: 1rem; line-height: 1.5;">Download Excel Format</a></button>
                </div>
            </div>
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-sm-flex">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <div class="col-sm-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                        AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                            <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                            <asp:BoundField HeaderText="Email ID" DataField="EmailId" />
                            <asp:BoundField HeaderText="Father Name" DataField="FatherName" />
                            <asp:BoundField HeaderText="Father Contact No." DataField="FatherContactNumber" />
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
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
