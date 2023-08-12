using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.FileClassFile;
using LMS.Admin.LessonClassFile;
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

namespace LMS.Admin
{
    public partial class UploadFile : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        LessonBLL bll = new LessonBLL();
        FileBLL fileBLL = new FileBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddepartmentddl();
            }
            
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataBind();
            ddlDepartment.DataTextField = "DepartmentStandardName";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlDepartment.SelectedValue));
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
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddlDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue));
            ddlLesson.DataSource = dt;
            ddlLesson.DataBind();
            ddlLesson.DataTextField = "LessonTitle";
            ddlLesson.DataValueField = "Id";
            ddlLesson.DataBind();
            ddlLesson.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindlessonddl();
        }
        public static DriveService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { Google.Apis.Drive.v3.DriveService.Scope.Drive };

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
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DriveAPI",
            });

            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
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
                DriveService service = GetService(serviceEmail, serviceOnEmailId, privateKey);


                string folderPath = Server.MapPath("FileClassFile/Document/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                //var clientId = Session["ClientID"].ToString();
                var newFile = clientId + TranTrackid;
                string clientFolderPath = Server.MapPath("FileClassFile/Document/" + newFile + "/");
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
                var completeFileName = clientFolderPath + ddlDepartment.SelectedItem + "_" + ddlCourse.SelectedItem + "_" + ddlLesson.SelectedItem + "_" + TranTrackid + extension;
                // var filePath = @"E:\HARSH\GoogleSessionAPI\New folder (3)\Youtube\YoutubeVideoUpload\bin\Debug\abc.mp4";
                FileUpload1.SaveAs(completeFileName);
                List<Permission> permissionsResources = new List<Permission>();
                permissionsResources.Add(new Permission { Role = "reader", Type = "anyone" });
                var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(FileUpload1.PostedFile.FileName),
                    MimeType = MimeMapping.GetMimeMapping(completeFileName),
                    //Permissions = permissionsResources
                    //Parents = new List<string>
                    //    {
                    //        "10qfegs6Ye0dB6JXBWTHNTssnzYd4_jZM"
                    //    }
                };

                Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(completeFileName, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
                var file1 = request.ResponseBody;
                // Google.Apis.Drive.v3.Data.Permission permission = new Google.Apis.Drive.v3.Data.Permission();
                // permission.Type = "anyone";
                // permission.Role = "reader";
                // permission.Id = file1.Id;
                // permission.AllowFileDiscovery = true;
                // PermissionsResource.CreateRequest newRequest = service.Permissions.Create(permission,file1.Id);
                // newRequest.Fields = "Id";
                //var fileLink= newRequest.Execute();
                  var downLoadLink = "https://drive.google.com/uc?id=&#8221; & " + file1.Id;




                var result = fileBLL.AddDocumentInDrive(int.Parse(ddlDepartment.SelectedValue), int.Parse(ddlCourse.SelectedValue), int.Parse(ddlLesson.SelectedValue), file1.Id, downLoadLink);
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('File Uploaded successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('File Uploaded But not updated in database.');", true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}