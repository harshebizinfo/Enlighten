<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/DepartmentStandard.master" AutoEventWireup="true" CodeBehind="AddLearnerInDepartment.aspx.cs" Inherits="LMS.Admin.AddLearnerInDepartment" %>
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
             .rbListWrap {
                /*width: 100px;*/
            }

                .rbListWrap tr td {
                    height: 10px;
                    vertical-align: top;
                    padding: 2px;
                }

                .rbListWrap input {
                    float: left;
                    padding-bottom: 0px;
                    margin: 5px 0px 0px 0px;
                }

                .rbListWrap label {
                    position: initial;
                    padding-left: 10px;
                    font-size: medium;
                }
        </style>
        
    </head>
    <div class="container-fluid">
        <div class="row">
            <%--   <div class="col-sm-12">
                Add Lesson
            </div>--%>
            <div class="col-sm-6">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
            </div>
            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-4">
                        <label>Department/ Standard</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddllessonDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddllessonDepartment_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Standard" InitialValue="0" ValidationGroup="AddStudentInDepartment" ControlToValidate="ddllessonDepartment" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-sm-4" runat="server">
                        <label>Division</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlDivision" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Division" InitialValue="0" ValidationGroup="AddStudentInDepartment" ControlToValidate="ddlDivision" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Select Learner</label>

                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlStudentCourse" runat="server" OnSelectedIndexChanged="ddlStudentCourse_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Select Student" InitialValue="0" ValidationGroup="AddStudentInDepartment" ControlToValidate="ddlStudentCourse" runat="server" ForeColor="Red" />
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label>Category</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlCategory" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Category" InitialValue="0" ValidationGroup="AddStudentInDepartment" ControlToValidate="ddlCategory" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Area</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlArea" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Area" InitialValue="0" ValidationGroup="AddStudentInDepartment" ControlToValidate="ddlArea" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Mode</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="ddlMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <label>Pick Up Vehicle Number</label>
                        <div class="form-group">
                            <%--<asp:TextBox CssClass="form-control" ID="txtPickUpVehicle" runat="server" placeholder="Enter Pick Up Vehicle Number" autocomplete="off"></asp:TextBox>--%>
                            <asp:DropDownList class="form-control" ID="ddlPickUpVehicle" runat="server" AutoPostBack="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Drop Vehicle Number</label>
                        <div class="form-group">
                            <%--<asp:TextBox CssClass="form-control" ID="txtDropVehicle" runat="server" placeholder="Enter Drop Vehicle Number" autocomplete="off"></asp:TextBox>--%>
                            <asp:DropDownList class="form-control" ID="ddlDropVehicle" runat="server" AutoPostBack="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                        &nbsp;&nbsp;&nbsp;<label>Conveyance</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                        &nbsp;&nbsp;&nbsp;<label>Publish</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="CheckBox3" runat="server" />
                                        &nbsp;&nbsp;&nbsp;<label>Is One Way Trip</label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row" runat="server" id="remainingDetail">
                    <div class="col-sm-4" id="fname" runat="server">
                        <label>First Name</label>

                        <div class="form-group">
                            <asp:Label ID="lblFName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Last Name</label>

                        <div class="form-group">
                            <asp:Label ID="lblLName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <label>Email</label>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <%--<div class="col-sm-4">
                        <label>Contact Number</label>

                        <div class="form-group">
                            <asp:Label ID="lblcontactnumber" runat="server" Text=""></asp:Label>
                        </div>
                    </div>--%>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                         <div style="overflow: scroll; max-height: 100px">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="rbListWrap" RepeatDirection="Vertical"></asp:CheckBoxList>
                    </div>
                    </div>
                    <div class="col-sm-4">
                         <label>Start Traveling Date</label>
                <div class="form-group">
                    <asp:TextBox ID="txtDate" class="form-control" autoComplte="off" runat="server" placeholder="Select Traveling DateTime"></asp:TextBox>
                    <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"> </asp:CalendarExtender> 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Date of Transport" ControlToValidate="txtDate" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <div class="col-md-flex">
                        <div class="form-group">
                            <asp:Button class="btn btn-block" Width="150px" ValidationGroup="AddStudentInDepartment" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                        </div>
                    </div>
                    <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                    <div class="col-md-flex">
                        <div class="form-group">
                            <asp:Button class="btn btn-block" Width="150px" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
   <script>
       $('#<%=ddlStudentCourse.ClientID%>').chosen();
   </script>
</asp:Content>
