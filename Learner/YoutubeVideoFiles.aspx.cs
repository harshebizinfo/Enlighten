using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.LessonClassFile;
using LMS.Admin.VideoClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class YoutubeVideoFiles : System.Web.UI.Page
    {
        CourseBLL coursebll = new CourseBLL();
        LessonBLL bll = new LessonBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        VideoBLL videoBLL = new VideoBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        public List<ListOfPlayList> listOfPlayList = new List<ListOfPlayList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable departmentId = new DataTable();
                //departmentId = assignmentBLL.GetLearnerDepartmentId();
                //int deptId = 0;
                //if (departmentId.Rows.Count > 0)
                //{
                //    deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
                //}
                //List<string> playListUnderDepartmentId = new List<string>();
                //playListUnderDepartmentId = videoBLL.GetPlayListByDeptId(deptId);
                bindCourseddl();
            }
        }
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseSubjectListOfLearner();
            ddlSubjectCourse.DataSource = dt;
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.DataTextField = "CourseSubjectName";
            ddlSubjectCourse.DataValueField = "Id";
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
            ViewState["departmentStandardId"] = int.Parse(dt.Rows[0]["DepartmentStandardID"].ToString());
        }
        public void bindAssignmentlessonddl()
        {
            var departmentId = ViewState["departmentStandardId"].ToString();
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(departmentId), int.Parse(ddlSubjectCourse.SelectedValue));
            ddlAssignmentLesson.DataSource = dt;
            ddlAssignmentLesson.DataBind();
            ddlAssignmentLesson.DataTextField = "LessonTitle";
            ddlAssignmentLesson.DataValueField = "Id";
            ddlAssignmentLesson.DataBind();
            ddlAssignmentLesson.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void GridViewYoutubePlayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
            }
        }
        public void bindAddItemPL(List<string> playListId)
        {
            List<ListOfPlayList> dt = new List<ListOfPlayList>();
            dt = GetAllListOfPlayList(playListId).ToList();
            ddlPlayList.DataSource = dt;
            ddlPlayList.DataBind();
            ddlPlayList.DataTextField = "Title";
            ddlPlayList.DataValueField = "PlayListId";
            ddlPlayList.DataBind();
            ddlPlayList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public static YouTubeService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public List<ListOfPlayList> GetAllListOfPlayList(List<string> playListId)
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
            YouTubeService service = GetService(serviceEmail, serviceOnEmailId, privateKey);

            var request = service.Playlists.List("snippet,contentDetails");
            //var playListResult = request.List("snippet,contentDetails");
            request.Mine = true;
            request.MaxResults = 25;
            //.list("snippet,contentDetails");
            PlaylistListResponse response = request.Execute();
            listOfPlayList.Clear();
            foreach (var item in response.Items)
            {
                if (playListId.Contains(item.Id))
                {
                    listOfPlayList.Add(new ListOfPlayList { PlayListId = item.Id, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString() });
                }
            }
            return listOfPlayList;
        }
        protected void linkAddYoutubePlayList_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string id = (btndetails.CommandArgument).ToString();
            Label labelPosition = gvrow.FindControl("lblPosition") as Label;

            string Url = "https://www.youtube.com/embed?listType=playlist&list=" + ddlPlayList.SelectedValue.ToString() + "";
            ifrmselectedVideo.Attributes.Add("src", Url);
        }
        protected void ddlSubjectCourse_SelectedIndexChanged1(object sender, EventArgs e)
        {
            bindAssignmentlessonddl();
        }

        protected void ddlAssignmentLesson_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var departmentId = ViewState["departmentStandardId"].ToString();
            List<string> playListId = new List<string>();
            playListId = videoBLL.GetPlayListUnderLesson(int.Parse(departmentId), int.Parse(ddlSubjectCourse.SelectedValue), int.Parse(ddlAssignmentLesson.SelectedValue));
            bindAddItemPL(playListId);
        }

        protected void ddlPlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
            if (isGoogleSub == true)
            {
                // PlayListItemList(ddlPlayList.SelectedValue);
                string Url = "https://www.youtube.com/embed?listType=playlist&list=" + ddlPlayList.SelectedValue.ToString() + "";//"&index=" + labelPosition.Text +
                ifrmselectedVideo.Attributes.Add("src", Url);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Google Task.');", true);
            }
        }
        //private void PlayListItemList(string playlistId)
        //{
        //    UserCredential credential;
        //    //string path = Server.MapPath("../bin/CredMain.json");
        //    string path = Server.MapPath("../CredentialFIle/CredMain.json");// Path.Combine(System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + "../CredentialFIle/CredMain.json");
        //    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    {
        //        string credPath = "learnerVideounderPlaylist.json";
        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            // This OAuth 2.0 access scope allows for full read/write access to the
        //            // authenticated user's account.
        //            new[] { YouTubeService.Scope.Youtube },
        //            "user",
        //            CancellationToken.None,
        //            new FileDataStore(credPath, false)
        //        ).Result;
        //    }

        //    var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = Assembly.GetExecutingAssembly().GetName().Name//this.GetType().ToString()
        //    });

        //    var request = youtubeService.PlaylistItems.List("snippet");
        //    request.MaxResults = 100;
        //    request.PlaylistId = playlistId;
        //    var response = request.Execute();
        //    List<ListOfPlayList> playlistItemInPlayList = new List<ListOfPlayList>();
        //    foreach (var item in response.Items)
        //    {
        //        playlistItemInPlayList.Add(new ListOfPlayList { PlayListId = item.Snippet.ResourceId.VideoId, Title = item.Snippet.Title, Description = item.Snippet.Description, PublishedAt = item.Snippet.PublishedAt.ToString(), Position = item.Snippet.Position });
        //    }
        //    GridView1.DataSource = playlistItemInPlayList;
        //    GridView1.DataBind();
        //}
    }
}