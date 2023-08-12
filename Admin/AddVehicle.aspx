<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/TransportMaster.master" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="LMS.Admin.AddVehicle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
                <label>Vehicle Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtVehicleNumber" runat="server" placeholder="Enter Vehicle Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Vehicle Number" ForeColor="Red" Text="*" ControlToValidate="txtVehicleNumber" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Vehicle Description</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtVehicleDescription" runat="server" placeholder="Enter Vehicle Description"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Vehicle Description" ForeColor="Red" Text="*" ControlToValidate="txtVehicleDescription" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Pick Up Driver Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPickUpDriverName" runat="server" placeholder="Enter Driver Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Pick Up Driver Name" ForeColor="Red" Text="*" ControlToValidate="txtPickUpDriverName" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Pick Up Driver Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPickUpDriverAddress" runat="server" placeholder="Enter Driver Address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Pick up Driver Address" ForeColor="Red" Text="*" ControlToValidate="txtPickUpDriverAddress" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Pick Up Driver Contact Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPickUpDriverContactNumber" runat="server" placeholder="Enter Pick Up Contact Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Pick up Driver Contact Number" ForeColor="Red" Text="*" ControlToValidate="txtPickUpDriverContactNumber" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Pick Up Driver Adhaar Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtPickUpDriverAdhaarNumber" runat="server" placeholder="Enter Pick Up Adhaar Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Pick up Driver Adhaar Number" ForeColor="Red" Text="*" ControlToValidate="txtPickUpDriverAdhaarNumber" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Drop Driver Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDropDriverName" runat="server" placeholder="Enter Drop Driver Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Drop Driver Name" ForeColor="Red" Text="*" ControlToValidate="txtDropDriverName" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Drop Driver Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDropDriverAddress" runat="server" placeholder="Enter Drop Driver Address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Drop Driver Address" ForeColor="Red" Text="*" ControlToValidate="txtDropDriverAddress" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Drop Driver Contact Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDropDriverContactNumber" runat="server" placeholder="Enter Drop Driver Contact Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Drop Driver Contact Number" ForeColor="Red" Text="*" ControlToValidate="txtDropDriverContactNumber" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Drop Driver Adhaar Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtDropriverAdhaarNumber" runat="server" placeholder="Enter Drop Driver Adhaar Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Drop Driver Adhaar Number" ForeColor="Red" Text="*" ControlToValidate="txtDropriverAdhaarNumber" ValidationGroup="AddVehicle"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Publish</label>
                <div class="form-group">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Select Vehicle Mode</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="ddlVehicleMode" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqFavoriteColor" Text="Select Vehicle Mode" InitialValue="0" ValidationGroup="AddVehicle" ControlToValidate="ddlVehicleMode" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" Width="150px" ID="Button9" runat="server" ValidationGroup="AddVehicle" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click" />
                </div>
            </div>
            <div class="col-sm-flex">&nbsp;&nbsp;&nbsp;&nbsp;</div>
            <div class="col-md-flex">
                <div class="form-group">
                    <asp:Button class="btn btn-block" Width="150px" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button10_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
