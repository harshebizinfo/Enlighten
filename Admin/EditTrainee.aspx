<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Teacher.master" AutoEventWireup="true" CodeBehind="EditTrainee.aspx.cs" Inherits="LMS.Admin.EditTrainee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
         <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
         <div class="row">
            <div class="col-sm-12">
                <h3>Edit Trainee</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>First Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFirstName" runat="server" placeholder="Enter First Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Last Name</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" placeholder="Enter Last Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Contact Number</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtContactNumber" runat="server" placeholder="Enter Contact Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Email ID</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Enter Email ID"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Father Name</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFatherName" runat="server" placeholder="Enter Father Name"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Father Contact Number</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtFatherContactNumber" runat="server" placeholder="Enter Father Contact Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Present Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpresentAddress" runat="server" placeholder="Enter Present Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Present City</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPresentCity" runat="server" placeholder="Enter Present City"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Present State</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPresentState" runat="server" placeholder="Enter Present State"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Permanent Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpermanentAddress" runat="server" placeholder="Enter Permanent Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Permanent City</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpermanentCity" runat="server" placeholder="Enter Permanent City"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Permanent State</label>

                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPermanentState" runat="server" placeholder="Enter Permanent State"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button9" runat="server" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                </div>
            </div>
            <div class="col-sm-1"></div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
