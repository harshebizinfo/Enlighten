<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckExamPaper.aspx.cs" Inherits="LMS.Trainee.CheckExamPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-sm-12 justify-content-center"><center><h2>Student's Question Paper</h2></center></div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="3" ShowHeaderWhenEmpty="True" Width="100%">
                        <Columns>
                            <asp:BoundField HeaderText="Sr No." DataField="Id" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Question" DataField="Question" />
                            <asp:BoundField HeaderText="Correct Option" DataField="CorrectOption" />
                            <asp:BoundField HeaderText="Answer" DataField="Answer" />
                            <asp:BoundField HeaderText="Mark" DataField="QuestionMarks" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <%--<asp:BoundField HeaderText="Obtained Marks" DataField="MarksObtained" ItemStyle-HorizontalAlign="Center"/>--%>
                            <asp:TemplateField HeaderText="Marks Obtained" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMarks" runat="server" Width="100px" Text='<%# Eval("ObtainedMarks") %>' TextMode="Number"></asp:TextBox>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Attempts" DataField="NumberOfAttempts" />
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
                <div class="col-sm-2"></div>
            </div>
           <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-2">
                <label></label>

                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="btnSave" runat="server" Style="background-color: #28a745; color: #fff; left: 0px; top: 0px;" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
