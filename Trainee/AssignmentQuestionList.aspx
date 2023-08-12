<%@ Page Title="" Language="C#" MasterPageFile="~/Trainee/Lesson.master" AutoEventWireup="true" CodeBehind="AssignmentQuestionList.aspx.cs" Inherits="LMS.Trainee.AssignmentQuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-4">
                        <label>Department/Standard</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                <asp:ListItem Text="Select Department/Standard" Value="select" />
                                <asp:ListItem Text="Nursery" Value="Nursery" />
                                <asp:ListItem Text="LKG" Value="LKG" />
                                <asp:ListItem Text="UKG" Value="UKG" />
                                <asp:ListItem Text="1st" Value="1st" />
                                <asp:ListItem Text="2nd" Value="2nd" />
                                <asp:ListItem Text="3rd" Value="3rd" />
                                <asp:ListItem Text="4th" Value="4th" />
                                <asp:ListItem Text="5th" Value="5th" />
                                <asp:ListItem Text="6th" Value="6th" />
                                <asp:ListItem Text="7th" Value="7th" />
                                <asp:ListItem Text="8th" Value="8th" />
                                <asp:ListItem Text="9th" Value="9th" />
                                <asp:ListItem Text="10th" Value="10th" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Course/Subject</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                <asp:ListItem Text="Select Course/Subject" Value="select" />
                                <asp:ListItem Text="English" Value="English" />
                                <asp:ListItem Text="Hindi" Value="Hindi" />
                                <asp:ListItem Text="Marathi" Value="Marathi" />
                                <asp:ListItem Text="Maths" Value="Maths" />
                                <asp:ListItem Text="Science" Value="Science" />
                                <asp:ListItem Text="History" Value="History" />
                                <asp:ListItem Text="Geography" Value="Geography" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Sequence/Lesson</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                <asp:ListItem Text="Select Sequence/Lesson" Value="select" />
                                <asp:ListItem Text="Addition" Value="Addition" />
                                <asp:ListItem Text="Subtraction" Value="Subtraction" />
                                <asp:ListItem Text="Division" Value="Division" />
                                <asp:ListItem Text="Multiplication" Value="Multiplication" />
                                <asp:ListItem Text="Division" Value="Division" />
                                <asp:ListItem Text="Circle" Value="Circle" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
