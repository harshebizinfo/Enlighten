<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Learner.master" AutoEventWireup="true" CodeBehind="StudentAdmissionReport.aspx.cs" Inherits="LMS.Admin.StudentAdmissionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" CssClass="form-control alert-success" OnClick="btnGenerateReport_Click"/>
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnOpenPDF" runat="server" Text="Open PDF" CssClass="form-control alert-success" OnClick="btnOpenPDF_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
