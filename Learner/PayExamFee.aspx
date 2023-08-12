<%@ Page Title="" Language="C#" MasterPageFile="~/Learner/Payment.master" AutoEventWireup="true" CodeBehind="PayExamFee.aspx.cs" Inherits="LMS.Learner.PayExamFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%-- <div class="row">
            <div class="col-sm-3">
                <label>Select Exam</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlExam" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Exam" InitialValue="0" ControlToValidate="ddlExam" ValidationGroup="exam" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label>Select Subject</label>

                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlSubjectCourse" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Select Subject / Course" InitialValue="0" ValidationGroup="exam" ControlToValidate="ddlSubjectCourse" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-3">
                <label></label>

                <div class="form-group">
                   <asp:Button class="btn btn-block" ID="btnStartExam" runat="server" ValidationGroup="exam" Style="background-color: #28a745; color: #fff" Text="Pay" OnClick="btnStartExam_Click" />
                </div>
            </div>
        </div>--%>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-flex">
                <div class="table-responsive">
                    <fieldset>
                        <legend style="font-family: 'Times New Roman';">Select Month for payment :</legend>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" PageSize="200" Style="text-align: center" class="table table-bordered"
                            AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkfield2" runat="server" Enabled='<%# Eval("status").ToString() == "Deposited"?false:true %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontrolid1" CssClass="form-control" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Month Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontrolname1" CssClass="form-control" runat="server" Text='<%#Eval("FeeType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fee Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeestatus1" CssClass="form-control" runat="server" Text='<%#Eval("status") %>'></asp:Label>
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
                    </fieldset>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" PageSize="2" Style="text-align: center" class="table table-bordered"
                            AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkfield2" runat="server" Enabled='<%# Eval("status").ToString() == "Deposited"?false:true %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontrolid1" CssClass="form-control" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Month Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontrolname1" CssClass="form-control" runat="server" Text='<%#Eval("FeeType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fee Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeestatus1" CssClass="form-control" runat="server" Text='<%#Eval("status") %>'></asp:Label>
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
                    <asp:Button ID="btngo" runat="server" Text="GO" CssClass="btn btn-primary btn-block" OnClick="btngo_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
