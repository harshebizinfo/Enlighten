<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/MigrateMaster.master" AutoEventWireup="true" CodeBehind="MigrateStudentList.aspx.cs" Inherits="LMS.SuperAdmin.MigrateStudentList" %>
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

            .filescolumnwidth {
                width: 20%;
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
                <label>Select Client</label>
                <div class="form-group">
                    <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Client" InitialValue="0" ValidationGroup="AddPC" ControlToValidate="ddlClient" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Application User Id</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPaymentGateway" runat="server" placeholder="Enter Application User Id"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Text="Enter Application User Id" ValidationGroup="AddPC" ControlToValidate="txtPaymentGateway" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>New School Scholar Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtmerchantid" runat="server" placeholder="Enter Merchant ID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Merchant ID" ValidationGroup="AddPC" ControlToValidate="txtmerchantid" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="row">
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>

                <div class="col-md-flex">
                    <div class="form-group">
                        <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="AddPC" OnClick="btnSubmit_Click" />

                    </div>
                </div>
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="row">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" PageSize="20" Style="text-align: center" class="table table-bordered"
                            AllowPaging="true" OnRowDataBound="gridViewdriveDocument_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="ApplicationUser Id" DataField="ApplicationUserId" />
                                <asp:BoundField HeaderText="Old Client Id" DataField="OldClientId" />
                                <asp:BoundField HeaderText="New Client Id" DataField="NewClientId" />
                                <asp:BoundField HeaderText="Old Scholar Id" DataField="OldScholarId" />
                                <asp:BoundField HeaderText="New Scholar Id" DataField="NewScholarId" />
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
        </div>
    </div>
</asp:Content>
