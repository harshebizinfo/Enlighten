<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Lesson.master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="LMS.Admin.UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style type="text/css">
            .rbListWrap {
                /*width: 100px;*/
            }

                .rbListWrap tr td {
                    height: 10px;
                    vertical-align: top;
                    padding: 5px;
                }

                .rbListWrap input {
                    float: left;
                }

                .rbListWrap label {
                    position: initial;
                    padding-left: 10px;
                }

            .auto-style1 {
                font-size: x-large;
            }
        </style>
    </head>
    <div class="row">
        <div class="col-sm-12">
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label>Department/ Standard</label>
            <div class="form-group">
                <asp:DropDownList class="form-control" ID="ddlDepartment" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Department" InitialValue="0" ControlToValidate="ddlDepartment" ValidationGroup="video" runat="server" ForeColor="Red" />
            </div>
        </div>
        <div class="col-sm-4">
            <label>Course</label>

            <div class="form-group">
                <asp:DropDownList class="form-control" ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Select Course" InitialValue="0" ControlToValidate="ddlCourse" ValidationGroup="video" runat="server" ForeColor="Red" />
            </div>
        </div>
        <div class="col-sm-4">
            <label>Lesson</label>

            <div class="form-group">
                <asp:DropDownList class="form-control" ID="ddlLesson" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Select Lesson" InitialValue="0" ControlToValidate="ddlLesson" ValidationGroup="video" runat="server" ForeColor="Red" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <label>Select File</label>

            <div class="form-group">
                <asp:FileUpload ID="FileUpload1" runat="server" />

            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-sm-4"></div>
        <div class="col-sm-4">
            <div class="row">

                <div class="col-md-flex">
                    <div class="form-group">
                        <%--<asp:Button class="btn btn-block" ID="Button1" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClientClick="ValidateAge()" ValidationGroup="AddQuestion" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" ValidationGroup="video" OnClick="btnSubmit_Click" />

                    </div>
                </div>
                <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
                <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button class="btn btn-block" Width="150px" ID="Button2" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
