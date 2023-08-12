<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMainMaster.Master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="LMS.Admin.DepartmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
         <div class="row">
            <!-- Button to Open the Modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                Add Department
            </button>

            <!-- The Modal -->
            <div class="modal" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Add Department</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">
                            <div class="mb-3">
                                <label class="form-label">Department Title</label>
                                <input type="text" class="form-control" id="departmentTitle" name="departmentTitle" placeholder="Enter Department Title" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Department Name</label>
                                <input type="password" class="form-control" id="departmentName" name="departmentName" placeholder="departmentName" />
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <div class="">
                                <p class="float-start">Not yet account <a href="#">Sign Up</a></p>
                                <button type="submit" class="btn btn-success float-end">Submit</button>
                                <button type="submit" class="btn btn-danger float-end">Cancel</button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
