<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Lesson.master" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="LMS.Trainee.Session" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-1">
                        <div style="height: 700px; overflow-y: scroll;">
                            <asp:Repeater ID="Repeater1" runat="server"  EnableViewState="False">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-sm-4"></div>
                                        <div class="col-sm-6" style="background-color: #8fcccc">
                                            <center>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <center>
                                                                <label style="color: white"><%#DataBinder.Eval(Container,"DataItem.MonthDay")%> </label>
                                                            </center>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <center>
                                                                <label style="color: white"><%#DataBinder.Eval(Container,"DataItem.CurrentMonthName")%> </label>
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="col-sm-11">
                        <%-- <video src="https://www.youtube.com/watch?v=fkdMdZmdBs4" width="50%" height="550px" controls>
                                    </video>--%>
                        <iframe width="50%" height="550" src="https://www.youtube.com/embed/fkdMdZmdBs4" frameborder="0" allowfullscreen></iframe>
                    </div>
                    <%--<div class="col-sm-9">
                                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" SelectionMode="Day" BorderWidth="1px" DayNameFormat="Shortest" 
                                        Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="300px" Width="50%" CellPadding="1">
                                        <DayHeaderStyle HorizontalAlign="Center" BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                        <OtherMonthDayStyle ForeColor="#999999" VerticalAlign="Top" />
                                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SelectorStyle BackColor="#99CCCC"  ForeColor="#336666" />
                                        <TitleStyle BackColor="#04abab" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" Height="25px" />
                                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                        <WeekendDayStyle BackColor="#CCCCFF" />
                                    </asp:Calendar>
                                </div>
                                <div class="col-sm-2"></div>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
