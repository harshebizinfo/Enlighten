<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Dashboard.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMS.Admin.Dashboard1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style>
            .chart {
                width: 100% !important;
                /* height: 100% !important;*/
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3">
                <a href="TraineeList.aspx">
                    <div class="card  text-center" style="background-color: #dada90; display: table; width: 100%">
                        <div class="card-body">
                            <h2 class="card-title">
                                <asp:Label ID="lblFaculty" runat="server" Text="Label"></asp:Label></h2>
                            <p class="card-text">
                                <font size="4" color="grey">Faculty</font>
                            </p>
                            <%--<button type="button" class="btn btn-primary">Button</button>--%>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-sm-3">
                <a href="LearnerList.aspx">
                    <div class="card text-center" style="background-color: #facd91; display: table; width: 100%">
                        <div class="card-body">
                            <h2 class="card-title">
                                <asp:Label ID="lblStudent" runat="server" Text="Label"></asp:Label></h2>
                            <p class="card-text">
                                <font size="4" color="grey">Total Students</font>
                            </p>
                            <%--<button type="button" class="btn btn-primary">Button</button>--%>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-sm-3">
                <a href="DepartmentStandard.aspx">
                    <div class="card text-center" style="background-color: #d4f0fd; display: table; width: 100%">
                        <div class="card-body">
                            <h2 class="card-title">
                                <asp:Label ID="lblDepartment" runat="server" Text="Label"></asp:Label></h2>
                            <p class="card-text">
                                <font size="4" color="grey">Department</font>
                            </p>
                            <%--<button type="button" class="btn btn-primary">Button</button>--%>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-sm-3">
                <a href="CourseORSubjectList.aspx">
                    <div class="card text-center" style="background-color: #0084ff80; display: table; width: 100%">
                        <div class="card-body">
                            <h2 class="card-title">
                                <asp:Label ID="lblCourse" runat="server" Text="Label"></asp:Label></h2>
                            <p class="card-text">
                                <font size="4" color="grey">Course Running </font>
                            </p>
                            <%--<button type="button" class="btn btn-primary">Button</button>--%>
                        </div>
                    </div>
                </a>
            </div>
        </div>
        <div class="row">
            <dib class="col-sm-12">
                <br />
            </dib>
            <div class="col-sm-6">
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <hr />
                <cc1:LineChart ID="LineChart1" runat="server" ChartHeight="400" ChartWidth="1000"
                    ChartType="Basic" ChartTitleColor="#0E426C" Visible="false" CategoryAxisLineColor="#D08AD9"
                    ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                </cc1:LineChart> 
                     SkinStyle="Emboss"
                    Area3DStyle-Enable3D="true"
                    --%>
               <%-- <asp:Chart ID="Chart1" runat="server" CssClass="chart" Height="500px">
                    <BorderSkin BackColor="Transparent" PageColor="Transparent"
                        />
                    <Series>
                        <asp:Series Name="Series1" XValueMember="0" YValueMembers="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"  BackColor="lightgray"  >

                            <AxisX IsLabelAutoFit="False" LabelAutoFitMinFontSize="7"
                                IntervalAutoMode="VariableCount" TitleFont="Verdana, 9.75pt">
                                <LabelStyle Angle="90" Interval="Auto" Font="Arial Narrow, 8.25pt" />
                                <ScaleBreakStyle Enabled="True" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>--%>
            </div>
        </div>
    </div>

</asp:Content>
