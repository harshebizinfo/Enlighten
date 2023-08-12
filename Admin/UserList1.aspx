<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/User.master" AutoEventWireup="true" CodeBehind="UserList1.aspx.cs" Inherits="LMS.Admin.UserList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="container-fluid">
          <div class="row">
            <div class="breadcrumb col-sm-12" style="height: 60px">
                <div class="col-sm-1">
                    <!-- Button to Open the Modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                Add User
            </button>

            <!-- The Modal -->
            <div class="modal" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Add User</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div class="mb-3">
                                <label class="form-label">Email Address</label>
                                <input type="text" class="form-control" id="username" name="username" placeholder="Username" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Password</label>
                                <input type="password" class="form-control" id="password" name="password" placeholder="Password" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Assign Role</label>
                                <asp:DropDownList class="form-control" ID="DropDownList5" runat="server">
                                            <asp:ListItem Text="Select Role" Value="select" />
                                            <asp:ListItem Text="Admin" Value="Admin" />
                                            <asp:ListItem Text="Trainee" Value="Trainee" />
                                            <asp:ListItem Text="Learner" Value="Learner" />
                                        </asp:DropDownList>
                            </div>

                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <div class="">
                                <%--<p class="float-start">Not yet account <a href="#">Sign Up</a></p>--%>
                                <button type="submit" class="btn btn-success float-end">Submit</button>
                                <button type="submit" class="btn btn-danger float-end">Cancel</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" placeholder="Enter Search Text"></asp:TextBox>
                </div>
            </div>
        </div>
          <div class="row">
            <div class="col-sm-8">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="80%" Height="350px">
                    <Columns>
                        <asp:BoundField HeaderText="Sr No." DataField="ApplicationUserId"  ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="User Name" DataField="UserName" />
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                        <asp:BoundField HeaderText="Surname" DataField="Surname" />
                        <asp:BoundField HeaderText="Roles" DataField="Roles" />
                        <%--<asp:BoundField HeaderText="Action" />--%>
                        <asp:TemplateField HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit"><i class="fa fa-pencil-square-o" style="color:navy;font-size:20px"></i></asp:LinkButton>
                                <asp:LinkButton ID="LkB11" runat="server" CommandName="Delete"><i class="fa fa-trash" style="color:red;font-size:20px"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LkB2" runat="server" CommandName="Update"><i class="fa fa-refresh"></i></asp:LinkButton>
                                <asp:LinkButton ID="LkB3" runat="server" CommandName="Cancel"><i class="fa fa-times"></i></asp:LinkButton>
                            </EditItemTemplate>

<HeaderStyle Width="50px"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center">No records found.</div>
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center" VerticalAlign="Middle" Height="40px" Font-Size="Medium" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
