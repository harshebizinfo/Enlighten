using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AddYoutubeVideo : System.Web.UI.Page
    {
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        ServiceBLL serviceBLL = new ServiceBLL();
        private String UploadedVideoId { get; set; }
       static string videoUploadSucess = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentfulnameName = Session["VideoDepartment"].ToString();
                string coursefulnameName = Session["VideoCourse"].ToString();
                string lessonfullName = Session["VideoLesson"].ToString();
                var departmentName = departmentfulnameName.Replace(" ", "_");
                var courseName = coursefulnameName.Replace(" ", "_");
                var lessonName = lessonfullName.Replace(" ", "_");
                //string credentialPath = Server.MapPath("../CredMain.json");
                //string path = Server.MapPath("../CredentialFIle/CredMain.json");// Path.Combine(System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + "../CredentialFIle/CredMain.json");
                string credentialPath = Server.MapPath("../CredentialFIle/CredMain.json");
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                var category = ddlCategory.SelectedValue;

                string folderPath = Server.MapPath("../Admin/VideoClassFile/Video/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                var clientId = Session["ClientID"].ToString();
                var newFile = clientId + TranTrackid;
                string clientFolderPath = Server.MapPath("../Admin/VideoClassFile/Video/" + newFile + "/");
                if (!Directory.Exists(clientFolderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(clientFolderPath);
                }
                else
                {
                    //Directory.Delete(clientFolderPath, true);
                    Directory.CreateDirectory(clientFolderPath);
                }

                var extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                var completeFileName = clientFolderPath + departmentName + "_" + courseName + "_" + lessonName + "_" + TranTrackid + extension;
                // var filePath = @"E:\HARSH\GoogleSessionAPI\New folder (3)\Youtube\YoutubeVideoUpload\bin\Debug\abc.mp4";
                FileUpload1.SaveAs(completeFileName);


                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                DataTable servicedt = new DataTable();
                servicedt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (servicedt.Rows.Count > 0)
                {
                    serviceEmail = servicedt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = servicedt.Rows[0]["UserEmail"].ToString();
                    privateKey = servicedt.Rows[0]["PrivateKey"].ToString();
                }

                var task = Upload(credentialPath,title,description,category, completeFileName, serviceEmail, serviceOnEmailId, privateKey, clientId);
                var items = await task;
                if(items!="")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Video Uploaded sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
               // Upload().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + exception.Message + "')", true);
                }
            }
        }
        public static YouTubeService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { YouTubeService.Scope.YoutubeUpload };


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
        public static async Task<string> Upload(string credentialPath,string title,string description,string category,string completePath, string serviceEmail, string serviceOnEmailId, string privateKey,string clientId)
        {
            YouTubeService service = GetService(serviceEmail, serviceOnEmailId, privateKey);

            //2.3 Create a video object
            var video = new Video()
            {
                //Id = "PLiSXwwa2HslLSec4boBcNgMe7Yhr5SlNh.",

                Status = new VideoStatus
                {
                    PrivacyStatus = "public"
                },

                Snippet = new VideoSnippet
                {
                    Title = title,
                    Description = description,
                    Tags = new string[] { "myTag1", "myTag2" },
                    CategoryId = category
                }

            };
            //2.4 Read and insert the video in youtubeService

            using (var fileStream = new FileStream(completePath, FileMode.Open))
            {
                var videosInsertRequest = service.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += insertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += insertRequest_ResponseReceived;

                //2.4.1 Wait for the upload process
                await videosInsertRequest.UploadAsync();
            }
            return videoUploadSucess.ToString();
        }
       static void insertRequest_ResponseReceived(Video video)
        {
            videoUploadSucess = video.Id;
            //Label1.Visible = true;
            //Label1.Text = "Video Uploaded sucessfully On Youtube.";
            // video.ID gives you the ID of the Youtube video.
            // you can access the video from
            // http://www.youtube.com/watch?v={video.ID}
        }

        static void insertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            // You can handle several status messages here.
            switch (progress.Status)
            {
                case UploadStatus.Starting:
                    break;
                case UploadStatus.Uploading:
                    break;
                case UploadStatus.Failed:
                    break;
                case UploadStatus.Completed:
                    break;
            }
        }
        public void ProgressChanged(IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Starting:
                    //Console.WriteLine("Start uploading");
                    break;
                case UploadStatus.Uploading:
                    //Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;
                case UploadStatus.Completed:
                    //Console.WriteLine("Upload completed!");
                    break;
                case UploadStatus.Failed:
                    // Console.WriteLine("An error prevented the upload from completing.n{0}", progress.Exception);
                    //videoUploadError="An error prevented the upload from completing. "+ progress.Exception;
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + progress.Exception + "')", true);
                    break;
            }
        }

        public void ResponseReceived(Video video)
        {
            videoUploadSucess = video.Id;
            Console.WriteLine("Video " + txtTitle.Text + " was successfully uploaded.");
            //var result = videobll.AddYoutubeVideo(int.Parse(ddllessonDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue), int.Parse(ddlLesson.SelectedValue), videoUploadSucess);
            //if (result > 0)
            //{
            //    var sucessString = "Video " + txtTitle.Text + " was successfully uploaded.";
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + sucessString + "')", true);
            //}
        }
    }
}