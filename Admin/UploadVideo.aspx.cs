using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.LessonClassFile;
using LMS.Admin.VideoClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class UploadVideo : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        LessonBLL bll = new LessonBLL();
        VideoBLL videobll = new VideoBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        public List<ListOfPlayList> listOfPlayList = new List<ListOfPlayList>();
        string videoUploadSucess = "";
        string videoUploadError = "";
        private String UploadedVideoId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiViewVideo.ActiveViewIndex = 0;
                string hex = "#8fcccc";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                string forehex = "#000000";
                Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
                string backColor = "#f2f2f2";
                Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
                string otherbackColor = "#ffffff";
                Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
                btnUploadVideo.BackColor = _backcolor;
                btnUploadVideo.ForeColor = _txtcolor;
                btnCreatePlayList.BackColor = _color;
                btnCreatePlayList.ForeColor = _otherbackcolor;
                btnViewPlayList.BackColor = _color;
                btnViewPlayList.ForeColor = _otherbackcolor;
                btnAddItemInPL.BackColor = _color;
                btnAddItemInPL.ForeColor = _otherbackcolor;
                btnDeleteItemPL.BackColor = _color;
                btnDeleteItemPL.ForeColor = _otherbackcolor;
                btnViewPlaylistByPlayListId.BackColor = _color;
                btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
                binddepartmentddl();
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddllessonDepartment.DataSource = dt;
            ddllessonDepartment.DataBind();
            ddllessonDepartment.DataTextField = "DepartmentStandardName";
            ddllessonDepartment.DataValueField = "Id";
            ddllessonDepartment.DataBind();
            ddllessonDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddllessonDepartment.SelectedValue));
            ddlCourse.DataSource = dt;
            ddlCourse.DataBind();
            ddlCourse.DataTextField = "CourseSubjectName";
            ddlCourse.DataValueField = "Id";
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindlessonddl()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddllessonDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue));
            ddlLesson.DataSource = dt;
            ddlLesson.DataBind();
            ddlLesson.DataTextField = "LessonTitle";
            ddlLesson.DataValueField = "Id";
            ddlLesson.DataBind();
            ddlLesson.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindPlayListdepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddldepartmentplaylist.DataSource = dt;
            ddldepartmentplaylist.DataBind();
            ddldepartmentplaylist.DataTextField = "DepartmentStandardName";
            ddldepartmentplaylist.DataValueField = "Id";
            ddldepartmentplaylist.DataBind();
            ddldepartmentplaylist.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindPlayListCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddldepartmentplaylist.SelectedValue));
            ddlCOursePlayList.DataSource = dt;
            ddlCOursePlayList.DataBind();
            ddlCOursePlayList.DataTextField = "CourseSubjectName";
            ddlCOursePlayList.DataValueField = "Id";
            ddlCOursePlayList.DataBind();
            ddlCOursePlayList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindPlayListlessonddl()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddldepartmentplaylist.SelectedValue), int.Parse(ddlCOursePlayList.SelectedValue));
            ddlLessonPlayList.DataSource = dt;
            ddlLessonPlayList.DataBind();
            ddlLessonPlayList.DataTextField = "LessonTitle";
            ddlLessonPlayList.DataValueField = "Id";
            ddlLessonPlayList.DataBind();
            ddlLessonPlayList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public static YouTubeService GetYouTubeService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { YouTubeService.Scope.Youtube };

            //"SERVICE_ACCOUNT_EMAIL_HERE";
            String serviceAccountEmail = serviceEmail;

            // Scope and user email id which you want to impersonate
            var initializer = new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes,
                User = serviceOnEmailId
            };

            //get private key, from .JSON file
            var credential = new ServiceAccountCredential(initializer.FromPrivateKey(privateKey));

            // Create the service.
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeAPI",
            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        public static YouTubeService GetYouTubeReadonlyService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { YouTubeService.Scope.YoutubeReadonly };

            //"SERVICE_ACCOUNT_EMAIL_HERE";
            String serviceAccountEmail = serviceEmail;

            // Scope and user email id which you want to impersonate
            var initializer = new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes,
                User = serviceOnEmailId
            };

            //get private key, from .JSON file
            var credential = new ServiceAccountCredential(initializer.FromPrivateKey(privateKey));

            // Create the service.
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeAPI",
            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        protected void btnUploadVideo_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 0;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnUploadVideo.BackColor = _backcolor;
            btnUploadVideo.ForeColor = _txtcolor;
            btnCreatePlayList.BackColor = _color;
            btnCreatePlayList.ForeColor = _otherbackcolor;
            btnViewPlayList.BackColor = _color;
            btnViewPlayList.ForeColor = _otherbackcolor;
            btnAddItemInPL.BackColor = _color;
            btnAddItemInPL.ForeColor = _otherbackcolor;
            btnDeleteItemPL.BackColor = _color;
            btnDeleteItemPL.ForeColor = _otherbackcolor;
            btnViewPlaylistByPlayListId.BackColor = _color;
            btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
            binddepartmentddl();
        }

        protected void btnCreatePlayList_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 1;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnCreatePlayList.BackColor = _backcolor;
            btnCreatePlayList.ForeColor = _txtcolor;
            btnUploadVideo.BackColor = _color;
            btnUploadVideo.ForeColor = _otherbackcolor;
            btnViewPlayList.BackColor = _color;
            btnViewPlayList.ForeColor = _otherbackcolor;
            btnAddItemInPL.BackColor = _color;
            btnAddItemInPL.ForeColor = _otherbackcolor;
            btnDeleteItemPL.BackColor = _color;
            btnDeleteItemPL.ForeColor = _otherbackcolor;
            btnViewPlaylistByPlayListId.BackColor = _color;
            btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
            bindPlayListdepartmentddl();
        }

        protected void btnViewPlayList_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 2;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnViewPlayList.BackColor = _backcolor;
            btnViewPlayList.ForeColor = _txtcolor;
            btnUploadVideo.BackColor = _color;
            btnUploadVideo.ForeColor = _otherbackcolor;
            btnCreatePlayList.BackColor = _color;
            btnCreatePlayList.ForeColor = _otherbackcolor;
            btnAddItemInPL.BackColor = _color;
            btnAddItemInPL.ForeColor = _otherbackcolor;
            btnDeleteItemPL.BackColor = _color;
            btnDeleteItemPL.ForeColor = _otherbackcolor;
            btnViewPlaylistByPlayListId.BackColor = _color;
            btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
            GetListOfPlayList();
        }

        protected void ddllessonDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindlessonddl();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //2. Get credentials and upload the file
                //var uploadedNewVideoId = Upload();
                //var uploadedNewVideoId = UploadedVideoId;

                //var result = videobll.AddYoutubeVideo(int.Parse(ddllessonDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue), int.Parse(ddlLesson.SelectedValue), uploadedNewVideoId);
                //if (result > 0)
                //{
                //var sucessString = "Video was successfully uploaded.";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + sucessString + "')", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                //}
                Session["VideoDepartment"] = ddllessonDepartment.SelectedItem;
                Session["VideoCourse"] = ddlCourse.SelectedItem;
                Session["VideoLesson"] = ddlLesson.SelectedItem;

                string url = "AddYoutubeVideo.aspx";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.open('");
                sb.Append(url);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(),
                        "script", sb.ToString());
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + exception.Message + "')", true);
                }
            }
        }

        //public string Upload()
        //{
        //    //2.1 Get credentials
        //    UserCredential credentials;
        //    string[] Scopes2 = { YouTubeService.Scope.Youtube };
        //    //2.1.1 Use https://console.developers.google.com/ to get the json file (Credential section)
        //    string path = Server.MapPath("../CredMain.json");

        //    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    {
        //        string credPath = "token.json";
        //        credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            new[] { YouTubeService.Scope.YoutubeUpload },
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credPath, true)).Result;
        //    }

        //    //2.2 Create a YoutubeService instance using our credentials
        //    var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credentials,
        //        ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
        //    });

        //    //2.3 Create a video object
        //    var video = new Video()
        //    {
        //        //Id = "PLiSXwwa2HslLSec4boBcNgMe7Yhr5SlNh.",

        //        Status = new VideoStatus
        //        {
        //            PrivacyStatus = "public"
        //        },

        //        Snippet = new VideoSnippet
        //        {
        //            Title = txtTitle.Text.Trim(),
        //            Description = txtDescription.Text.Trim(),
        //            Tags = new string[] { "myTag1", "myTag2" },
        //            CategoryId = ddlCategory.SelectedValue
        //        }

        //    };

        //    string folderPath = Server.MapPath("VideoClassFile/Video/");

        //    //Check whether Directory (Folder) exists.
        //    if (!Directory.Exists(folderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(folderPath);
        //    }
        //    var clientId = Session["ClientID"].ToString();
        //    var newFile = clientId + TranTrackid;
        //    string clientFolderPath = Server.MapPath("VideoClassFile/Video/" + newFile + "/");
        //    if (!Directory.Exists(clientFolderPath))
        //    {
        //        //If Directory (Folder) does not exists. Create it.
        //        Directory.CreateDirectory(clientFolderPath);
        //    }
        //    else
        //    {
        //        //Directory.Delete(clientFolderPath, true);
        //        Directory.CreateDirectory(clientFolderPath);
        //    }

        //    var extension = System.IO.Path.GetExtension(FileUpload1.FileName);
        //    var completeFileName = clientFolderPath + ddllessonDepartment.SelectedItem + "_" + ddlCourse.SelectedItem + "_" + ddlLesson.SelectedItem + "_" + TranTrackid + extension;
        //    // var filePath = @"E:\HARSH\GoogleSessionAPI\New folder (3)\Youtube\YoutubeVideoUpload\bin\Debug\abc.mp4";
        //    FileUpload1.SaveAs(completeFileName);
        //    //2.4 Read and insert the video in youtubeService
        //    using (var fileStream = new FileStream(completeFileName, FileMode.Open))
        //    {
        //        var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
        //        videosInsertRequest.ProgressChanged += insertRequest_ProgressChanged;
        //        videosInsertRequest.ResponseReceived += insertRequest_ResponseReceived;

        //        //2.4.1 Wait for the upload process
        //        videosInsertRequest.UploadAsync();

        //    }
        //    return UploadedVideoId;
        //}
        //void insertRequest_ResponseReceived(Video video)
        //{
        //    UploadedVideoId = video.Id;
        //    // video.ID gives you the ID of the Youtube video.
        //    // you can access the video from
        //    // http://www.youtube.com/watch?v={video.ID}
        //}

        //void insertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        //{
        //    // You can handle several status messages here.
        //    switch (progress.Status)
        //    {
        //        case UploadStatus.Starting:
        //            break;
        //        case UploadStatus.Uploading:
        //            break;
        //        case UploadStatus.Failed:
        //            UploadedVideoId = "FAILED";
        //            break;
        //        case UploadStatus.Completed:
        //            break;
        //    }
        //}
        //public void ProgressChanged(IUploadProgress progress)
        //{
        //    switch (progress.Status)
        //    {
        //        case UploadStatus.Starting:
        //            //Console.WriteLine("Start uploading");
        //            break;
        //        case UploadStatus.Uploading:
        //            //Console.WriteLine("{0} bytes sent.", progress.BytesSent);
        //            break;
        //        case UploadStatus.Completed:
        //            //Console.WriteLine("Upload completed!");
        //            break;
        //        case UploadStatus.Failed:
        //            // Console.WriteLine("An error prevented the upload from completing.n{0}", progress.Exception);
        //            //videoUploadError="An error prevented the upload from completing. "+ progress.Exception;
        //            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + progress.Exception + "')", true);
        //            break;
        //    }
        //}

        //public void ResponseReceived(Video video)
        //{
        //    videoUploadSucess = video.Id;
        //    Console.WriteLine("Video " + txtTitle.Text + " was successfully uploaded.");
        //    //var result = videobll.AddYoutubeVideo(int.Parse(ddllessonDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue), int.Parse(ddlLesson.SelectedValue), videoUploadSucess);
        //    //if (result > 0)
        //    //{
        //    //    var sucessString = "Video " + txtTitle.Text + " was successfully uploaded.";
        //    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + sucessString + "')", true);
        //    //}
        //}

        protected void btnPlayListSave_Click(object sender, EventArgs e)
        {
            try
            {
                var playListId = CreatePlayList();
                var result = videobll.AddPlayList(int.Parse(ddldepartmentplaylist.SelectedValue), int.Parse(ddlCOursePlayList.SelectedValue), int.Parse(ddlLessonPlayList.SelectedValue), playListId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PlayList Added Sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
        }
        private string CreatePlayList()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeService(serviceEmail, serviceOnEmailId, privateKey);

            // Create a new, private playlist in the authorized user's channel.
            var newPlaylist = new Playlist();
            newPlaylist.Snippet = new PlaylistSnippet();
            newPlaylist.Snippet.Title = txtpaylisttitle.Text.Trim();
            newPlaylist.Snippet.Description = txtPlaylistdescription.Text.Trim();
            newPlaylist.Status = new PlaylistStatus();
            newPlaylist.Status.PrivacyStatus = "public";
            newPlaylist = service.Playlists.Insert(newPlaylist, "snippet,status").Execute();

            // Add a video to the newly created playlist.
            //var newPlaylistItem = new PlaylistItem();
            //newPlaylistItem.Snippet = new PlaylistItemSnippet();
            //newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
            //newPlaylistItem.Snippet.ResourceId = new ResourceId();
            //newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            //newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
            //newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

            //Console.WriteLine("Added to playlist id {0}.", newPlaylist.Id);
            return newPlaylist.Id;
        }
        protected void btnPlayListCancel_Click(object sender, EventArgs e)
        {
            txtPlaylistdescription.Text = "";
            txtpaylisttitle.Text = "";
        }

        protected void ddldepartmentplaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindPlayListCourseddl();
        }

        protected void ddlCOursePlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindPlayListlessonddl();
        }
        public void GetListOfPlayList()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeReadonlyService(serviceEmail, serviceOnEmailId, privateKey);
            var request = service.Playlists.List("snippet,contentDetails");
            //var playListResult = request.List("snippet,contentDetails");
            request.Mine = true;
            request.MaxResults = 25;
            //.list("snippet,contentDetails");
            PlaylistListResponse response = request.Execute();

            foreach (var item in response.Items)
            {
                listOfPlayList.Add(new ListOfPlayList { PlayListId = item.Id, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString() });
            }
            GridViewYoutubePlayList.DataSource = listOfPlayList;
            GridViewYoutubePlayList.DataBind();
            //.setMaxResults(25L)
            //.setMine(true)
            //.execute();
        }
        protected void GridViewYoutubePlayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "columnwidth";
                //e.Row.Cells[2].CssClass = "columnwidth";
                //e.Row.Cells[3].CssClass = "columnwidth";
                //e.Row.Cells[4].CssClass = "columnwidth";
            }
        }
        public List<ListOfPlayList> GetListOfYoutubeVideoList()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeReadonlyService(serviceEmail, serviceOnEmailId, privateKey);

            var channelsListRequest = service.Channels.List("contentDetails");
            channelsListRequest.Mine = true;

            // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
            var channelsListResponse = channelsListRequest.Execute();
            listOfPlayList.Clear();
            foreach (var channel in channelsListResponse.Items)
            {
                // From the API response, extract the playlist ID that identifies the list
                // of videos uploaded to the authenticated user's channel.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                //Console.WriteLine("Videos in list {0}", uploadsListId);

                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = service.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = playlistItemsListRequest.Execute();

                    foreach (var playlistItem in playlistItemsListResponse.Items)
                    {
                        // Print information about each video.
                        //Console.WriteLine("{0} ({1})", playlistItem.Snippet.Title, playlistItem.Snippet.ResourceId.VideoId);
                        listOfPlayList.Add(new ListOfPlayList { PlayListId = playlistItem.Snippet.ResourceId.VideoId, Title = playlistItem.Snippet.Title, Description = playlistItem.Snippet.Description, PublishedAt = playlistItem.Snippet.PublishedAt.ToString() });
                    }

                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
            return listOfPlayList;
            //GridViewYoutubePlayList.DataSource = listOfPlayList;
            //GridViewYoutubePlayList.DataBind();
        }

        protected void linkDeleteYoutubePlayList_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            DeletePlayList(id);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        public void DeletePlayList(string playListId)
        {

            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeReadonlyService(serviceEmail, serviceOnEmailId, privateKey);

            var request = service.Playlists.Delete(playListId);
            var responseValue = request.Execute();
            if (responseValue == "")
            {
                var result = videobll.DeletePlayList(playListId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PlayList Deleted Sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PlayList Deleted but not updated on database')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
            // channelsListRequest.Mine = true;
        }

        protected void btnAddItemInPL_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 3;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnAddItemInPL.BackColor = _backcolor;
            btnAddItemInPL.ForeColor = _txtcolor;
            btnUploadVideo.BackColor = _color;
            btnUploadVideo.ForeColor = _otherbackcolor;
            btnViewPlayList.BackColor = _color;
            btnViewPlayList.ForeColor = _otherbackcolor;
            btnCreatePlayList.BackColor = _color;
            btnCreatePlayList.ForeColor = _otherbackcolor;
            btnDeleteItemPL.BackColor = _color;
            btnDeleteItemPL.ForeColor = _otherbackcolor;
            btnViewPlaylistByPlayListId.BackColor = _color;
            btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
            bindAddItemPL();
            List<ListOfPlayList> newDtVideoList = new List<ListOfPlayList>();
            newDtVideoList = GetListOfYoutubeVideoList();
            GridView1.DataSource = newDtVideoList;
            GridView1.DataBind();
        }

        protected void btnDeleteItemPL_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 4;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnDeleteItemPL.BackColor = _backcolor;
            btnDeleteItemPL.ForeColor = _txtcolor;
            btnUploadVideo.BackColor = _color;
            btnUploadVideo.ForeColor = _otherbackcolor;
            btnViewPlayList.BackColor = _color;
            btnViewPlayList.ForeColor = _otherbackcolor;
            btnCreatePlayList.BackColor = _color;
            btnCreatePlayList.ForeColor = _otherbackcolor;
            btnAddItemInPL.BackColor = _color;
            btnAddItemInPL.ForeColor = _otherbackcolor;
            btnViewPlaylistByPlayListId.BackColor = _color;
            btnViewPlaylistByPlayListId.ForeColor = _otherbackcolor;
            bindDeleteItemPL();
        }
        public void bindDeleteItemPL()
        {
            List<ListOfPlayList> dt = new List<ListOfPlayList>();
            dt = GetAllListOfPlayList().ToList();
            ddlRemovePlayList.DataSource = dt;
            ddlRemovePlayList.DataBind();
            ddlRemovePlayList.DataTextField = "Title";
            ddlRemovePlayList.DataValueField = "PlayListId";
            ddlRemovePlayList.DataBind();
            ddlRemovePlayList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAddItemPL()
        {
            List<ListOfPlayList> dt = new List<ListOfPlayList>();
            dt = GetAllListOfPlayList().ToList();
            ddlAddPlayList.DataSource = dt;
            ddlAddPlayList.DataBind();
            ddlAddPlayList.DataTextField = "Title";
            ddlAddPlayList.DataValueField = "PlayListId";
            ddlAddPlayList.DataBind();
            ddlAddPlayList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public List<ListOfPlayList> GetAllListOfPlayList()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeReadonlyService(serviceEmail, serviceOnEmailId, privateKey);
            var request = service.Playlists.List("snippet,contentDetails");
            //var playListResult = request.List("snippet,contentDetails");
            request.Mine = true;
            request.MaxResults = 25;
            //.list("snippet,contentDetails");
            PlaylistListResponse response = request.Execute();
            listOfPlayList.Clear();
            foreach (var item in response.Items)
            {
                listOfPlayList.Add(new ListOfPlayList { PlayListId = item.Id, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString() });
            }
            return listOfPlayList;
        }

        //protected void ddlAddPlayList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void linkAddYoutubePlayList_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            var value = AddItemInPL(id);
            DataTable dt = new DataTable();
            dt = videobll.GetPlayList(ddlAddPlayList.SelectedValue);
            int deptId = int.Parse(dt.Rows[0]["DepartmentId"].ToString());
            int courseId = int.Parse(dt.Rows[0]["CourseId"].ToString());
            int lessonId = int.Parse(dt.Rows[0]["LessonId"].ToString());
            var result = videobll.AddPlayListItem(deptId, courseId, lessonId, ddlAddPlayList.SelectedValue, value, id);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('PlayList Item Added successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('PlayList Item Added But not added in database.');", true);
            }
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        private string AddItemInPL(string videoId)
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeService(serviceEmail, serviceOnEmailId, privateKey);

            // Add a video to the newly created playlist.
            var newPlaylistItem = new PlaylistItem();
            newPlaylistItem.Snippet = new PlaylistItemSnippet();
            newPlaylistItem.Snippet.PlaylistId = ddlAddPlayList.SelectedValue;
            newPlaylistItem.Snippet.ResourceId = new ResourceId();
            newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            newPlaylistItem.Snippet.ResourceId.VideoId = videoId;
            newPlaylistItem = service.PlaylistItems.Insert(newPlaylistItem, "snippet").Execute();

            return newPlaylistItem.Id;
        }
        protected void linkDeletePlayListItem_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            RemoveItemFromPL(id);
            // DeletePlayList(id);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        public void RemoveItemFromPL(string playListItemId)
        {

            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeService(serviceEmail, serviceOnEmailId, privateKey);

            var request = service.PlaylistItems.Delete(playListItemId);

            var responseValue = request.Execute();
            if (responseValue == "")
            {
                var result = videobll.DeletePlayListItem(ddlRemovePlayList.SelectedValue, playListItemId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PlayListItem Deleted Sucessfully')", true);
                    var playListId = ddlRemovePlayList.SelectedValue;
                    PlayListItemList(playListId);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('PlayListItem Deleted but not updated on database')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
            // channelsListRequest.Mine = true;
        }

        protected void ddlRemovePlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var playListId = ddlRemovePlayList.SelectedValue;
            PlayListItemList(playListId);
        }
        private void PlayListItemList(string playlistId)
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeService(serviceEmail, serviceOnEmailId, privateKey);

            var request = service.PlaylistItems.List("snippet");
            request.MaxResults = 100;
            request.PlaylistId = playlistId;
            var response = request.Execute();
            List<ListOfPlayList> playlistItemInPlayList = new List<ListOfPlayList>();
            foreach (var item in response.Items)
            {
                playlistItemInPlayList.Add(new ListOfPlayList { PlayListId = item.Id, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString() });
            }
            GridView2.DataSource = playlistItemInPlayList;
            GridView2.DataBind();
        }

        protected void btnViewPlaylistByPlayListId_Click(object sender, EventArgs e)
        {
            MultiViewVideo.ActiveViewIndex = 5;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnViewPlaylistByPlayListId.BackColor = _backcolor;
            btnViewPlaylistByPlayListId.ForeColor = _txtcolor;
            btnUploadVideo.BackColor = _color;
            btnUploadVideo.ForeColor = _otherbackcolor;
            btnViewPlayList.BackColor = _color;
            btnViewPlayList.ForeColor = _otherbackcolor;
            btnCreatePlayList.BackColor = _color;
            btnCreatePlayList.ForeColor = _otherbackcolor;
            btnAddItemInPL.BackColor = _color;
            btnAddItemInPL.ForeColor = _otherbackcolor;
            btnDeleteItemPL.BackColor = _color;
            btnDeleteItemPL.ForeColor = _otherbackcolor;
            bindPlayVideodepartmentddl();
        }
        public void bindPlayVideodepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlplayVideoDepartment.DataSource = dt;
            ddlplayVideoDepartment.DataBind();
            ddlplayVideoDepartment.DataTextField = "DepartmentStandardName";
            ddlplayVideoDepartment.DataValueField = "Id";
            ddlplayVideoDepartment.DataBind();
            ddlplayVideoDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlplayVideoDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> playlistId = new List<string>();
            playlistId = videobll.GetPlayListByDeptId(int.Parse(ddlplayVideoDepartment.SelectedValue));
            bindPlayVideoItemPL(playlistId);
        }
        public void bindPlayVideoItemPL(List<string> playlisttrainee)
        {
            List<ListOfPlayList> dt = new List<ListOfPlayList>();
            dt = GetAllListOfPlayList(playlisttrainee).ToList();
            ddlPlayVideoPlaylist.DataSource = dt;
            ddlPlayVideoPlaylist.DataBind();
            ddlPlayVideoPlaylist.DataTextField = "Title";
            ddlPlayVideoPlaylist.DataValueField = "PlayListId";
            ddlPlayVideoPlaylist.DataBind();
            ddlPlayVideoPlaylist.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public List<ListOfPlayList> GetAllListOfPlayList(List<string> playlisttrainee)
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable servicedt = new DataTable();
            servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (servicedt.Rows.Count > 0)
            {
                serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
            }
            YouTubeService service = GetYouTubeReadonlyService(serviceEmail, serviceOnEmailId, privateKey);
            var request = service.Playlists.List("snippet,contentDetails");
            //var playListResult = request.List("snippet,contentDetails");
            request.Mine = true;
            request.MaxResults = 25;
            //.list("snippet,contentDetails");
            PlaylistListResponse response = request.Execute();
            listOfPlayList.Clear();
            foreach (var item in response.Items)
            {
                foreach (var listId in playlisttrainee)
                {
                    if (listId == item.Id)
                    {
                        listOfPlayList.Add(new ListOfPlayList { PlayListId = item.Id, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString() });
                    }
                }
            }
            return listOfPlayList;
        }
        protected void ddlPlayVideoPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Url = "https://www.youtube.com/embed?listType=playlist&list=" + ddlPlayVideoPlaylist.SelectedValue.ToString() + "";
            ifrmselectedVideo.Attributes.Add("src", Url);
        }
    }
}