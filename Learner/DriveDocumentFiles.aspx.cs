using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.ClassFile;
using LMS.Admin.FileClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class DriveDocumentFiles2 : System.Web.UI.Page
    {
        FileBLL filebll = new FileBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable departmentId = new DataTable();
                departmentId = assignmentBLL.GetLearnerDepartmentId();
                int deptId = 0;
                if (departmentId.Rows.Count > 0)
                {
                    deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
                }
                List<string> driveIdList = new List<string>();
                Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
                if (isGoogleSub == true)
                {
                    driveIdList = filebll.GetDocumentInDriveByDeptId(deptId);
                    GetListOfUploadedFIleList(driveIdList);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Google Task.');", true);
                }
            }
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
        public void GetListOfUploadedFIleList(List<string> documentIdList)
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
                Google.Apis.Drive.v3.DriveService service = GetService(serviceEmail, serviceOnEmailId, privateKey);


                Google.Apis.Drive.v3.FilesResource.ListRequest FileListRequest = service.Files.List();
                FileListRequest.Fields = "nextPageToken, files(createdTime, id, name, size, version, trashed, parents, webContentLink)";

                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
                List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        foreach (var fileID in documentIdList)
                        {
                            if (fileID == file.Id)
                            {
                                GoogleDriveFiles File = new GoogleDriveFiles
                                {
                                    Id = file.Id,
                                    Name = file.Name,
                                    Size = file.Size,
                                    Version = file.Version,
                                    CreatedTime = file.CreatedTime,
                                    WebContentLink = file.WebContentLink //file.Id + "|" + 
                                };
                                FileList.Add(File);
                            }
                        }
                    }
                }
                GridViewdriveDocument.DataSource = FileList;
                GridViewdriveDocument.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gridViewdriveDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "filescolumnwidth";
                e.Row.Cells[2].CssClass = "filescolumnwidth";
                e.Row.Cells[3].CssClass = "filescolumnwidth";
                e.Row.Cells[4].CssClass = "filescolumnwidth";
                e.Row.Cells[5].CssClass = "filescolumnwidth";
            }
        }
    }
}