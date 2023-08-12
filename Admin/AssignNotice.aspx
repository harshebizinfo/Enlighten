<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NoticeMaster.master" AutoEventWireup="true" CodeBehind="AssignNotice.aspx.cs" Inherits="LMS.Admin.AssignNotice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <style type="text/css">
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

            .auto-style1 {
                font-size: x-large;
            }
        </style>
    </head>
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-12">
                <h4>Assign Notice</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Select Fee Month</label>
                <div class="form-group">
                    <div style="overflow: scroll; max-height: 200px">
                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Select All"  CssClass="rbListWrap" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="rbListWrap" RepeatDirection="Vertical"></asp:CheckBoxList>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <label>Include Student</label>
                <div class="form-group">
                    <div>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </div>
                </div>
            </div>
             <div class="col-md-flex">
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" Width="150px" runat="server" class="btn btn-block" Text="Submit" Style="background-color: #28a745; color: #fff" OnClick="btnSubmit_Click" />

                    </div>
                </div>
        </div>
    </div>
</asp:Content>
