<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/ClientMaster.master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="LMS.SuperAdmin.AddClient" %>

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

            .columnwidth {
                width: 16.67%;
            }

            .videocolumnwidth {
                width: 25%;
            }

            .filescolumnwidth {
                width: 20%;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtClientName" runat="server" placeholder="Enter Client Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Client Name" ValidationGroup="AddPC" ControlToValidate="txtClientName" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Email</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtClientEmail" runat="server" placeholder="Enter Client Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Enter Client Email" ValidationGroup="AddPC" ControlToValidate="txtClientEmail" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Contact Number</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtContactNumber" runat="server" placeholder="Enter Contact Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Enter Contact Number" ValidationGroup="AddPC" ControlToValidate="txtContactNumber" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Institute Name</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtInstituteName" runat="server" placeholder="Enter Institute Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Enter Institute Name" ValidationGroup="AddPC" ControlToValidate="txtInstituteName" runat="server" ForeColor="Red" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Logo Path</label>
                <div class="form-group">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="col-sm-4">
                <label>Permanent Address</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtpermanentAddress" runat="server" placeholder="Enter Permanent Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Enter Permanent Address" ValidationGroup="AddPC" ControlToValidate="txtpermanentAddress" runat="server" ForeColor="Red" />

                </div>
            </div>
        </div>
           <div class="row">
            <div class="col-sm-4">
                <label>Is Google Service Included</label>
                 <div class="form-group">
                <asp:CheckBox ID="CheckBox1" runat="server" />
                     </div>
            </div>
               <div class="col-sm-4">
                <label>Select Payment Method</label>
                <div class="form-group">
                    <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Select Payment Type" InitialValue="0" ValidationGroup="AddPC" ControlToValidate="ddlClient" runat="server" ForeColor="Red" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-1"></div>

            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button9" runat="server" ValidationGroup="AddPC" Style="background-color: #28a745; color: #fff" Text="Save" OnClick="Button9_Click"/>
                </div>
            </div>
            <div class="col-sm-1"></div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button class="btn btn-block" ID="Button10" runat="server" Style="background-color: #dc3545; color: #fff" Text="Cancel" OnClick="Button10_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
