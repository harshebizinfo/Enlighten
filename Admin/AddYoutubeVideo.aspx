<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddYoutubeVideo.aspx.cs" Async="true" Inherits="LMS.Admin.AddYoutubeVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sidebar 01</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <link href="../css/style.css" rel="stylesheet" />
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12"><br /></div>
                <div class="col-sm-4 col-xs-4 col-md-4 col-lg-4"></div>
                <div class="col-sm-4 col-xs-4 col-md-4 col-lg-4" style="border:1px solid black;border-block-style:double">
                    <div class="row">
                        <div class="col-sm-12">
                            <center class="h1">Upload Video On Youtube</center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-8 col-xs-8 col-md-8 col-lg-8" style="padding-left:50px">
                            <label>Title</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtTitle" runat="server" placeholder="Enter Video Title"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="video" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-8 col-xs-8 col-md-8 col-lg-8" style="padding-left:50px">
                            <label>Description</label>

                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Enter Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtTitle" ValidationGroup="video" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-8 col-xs-8 col-md-8 col-lg-8" style="padding-left:50px">
                            <label>Category</label>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                                    <asp:ListItem Text="Select Category" Value="0" />
                                    <asp:ListItem Text="Film & Animation" Value="1" />
                                    <asp:ListItem Text="Autos & Vehicles" Value="2" />
                                    <asp:ListItem Text="Music" Value="10" />
                                    <asp:ListItem Text="Pets & Animals" Value="15" />
                                    <asp:ListItem Text="Sports" Value="17" />
                                    <asp:ListItem Text="Travel & Events" Value="19" />
                                    <asp:ListItem Text="Gaming" Value="20" />
                                    <asp:ListItem Text="People & Blogs" Value="22" />
                                    <asp:ListItem Text="Comedy" Value="23" />
                                    <asp:ListItem Text="Entertainment" Value="24" />
                                    <asp:ListItem Text="News & Politics" Value="25" />
                                    <asp:ListItem Text="Howto & Style" Value="26" />
                                    <asp:ListItem Text="Education" Value="27" />
                                    <asp:ListItem Text="Science & Technology" Value="28" />
                                    <asp:ListItem Text="Nonprofits & Activism" Value="29" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Select Category" InitialValue="0" ControlToValidate="ddlCategory" ValidationGroup="video" runat="server" ForeColor="Red" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-8 col-xs-8 col-md-8 col-lg-8" style="padding-left:50px">
                            <label>Select Video</label>

                            <div class="form-group">
                                <asp:FileUpload ID="FileUpload1" runat="server" />

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-8 col-xs-8 col-md-8 col-lg-8" style="padding-left:50px">
                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-flex" style="padding-left:50px">&nbsp;&nbsp;&nbsp;&nbsp;</div>
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
                    <div class="col-sm-12">
                        <br />
                        <br />
                    </div>
                </div>
                <div class="col-sm-4 col-xs-4 col-md-4 col-lg-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
