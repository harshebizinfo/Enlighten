﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.EventClassFile;
using LMS.Admin.FileClassFile;
using LMS.Admin.LessonClassFile;
using LMS.Learner.BasicClass;
using LMS.MiliciousFile;
using LMS.SuperAdmin.ServiceClassFile;
using LMS.Trainee;
using Newtonsoft.Json;
using NPOI.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AddNewLesson : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        LessonBLL bll = new LessonBLL();
        FileBLL filebll = new FileBLL();
        EventBLL eventBLL = new EventBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public List<CalenderEvent> GoogleEvents = new List<CalenderEvent>();
        public List<ListOfPlayList> listOfPlayList = new List<ListOfPlayList>();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");

        static string ApplicationName = "Google Calendar API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                string hex = "#8fcccc";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                string forehex = "#000000";
                Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
                string backColor = "#f2f2f2";
                Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
                string otherbackColor = "#ffffff";
                Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
                btnOverview.BackColor = _backcolor;
                btnOverview.ForeColor = _txtcolor;
                btnDetails.BackColor = _color;
                btnDetails.ForeColor = _otherbackcolor;
                btnScheduleClass.ForeColor = _otherbackcolor;
                btnScheduleClass.BackColor = _color;
                btnAssignment.BackColor = _color;
                btnAssignment.ForeColor = _otherbackcolor;
                //btnHistory.BackColor = _color;
                btnAssignmentList.BackColor = _color;
                btnAssignmentList.ForeColor = _otherbackcolor;
                binddepartmentddl();


                // bindCourseddl();
            }
            //List<DateClass> repeaterValue = new List<DateClass>();
            //List<int> monthDates = new List<int>();
            //int currentYear = int.Parse(DateTime.Now.Year.ToString());
            // //int currentMonth = int.Parse(DateTime.Now.Month.ToString());
            //int MonthNumber = int.Parse(DateTime.Now.Month.ToString());
            //int NumberOfDays = DateTime.DaysInMonth(currentYear, MonthNumber);
            //for (int i = 1; i <= NumberOfDays; i++)
            //{
            //    var currentMonthName = getAbbreviatedName(DateTime.Now.Month);
            //    repeaterValue.Add(new DateClass { MonthDay = i, CurrentMonthName = currentMonthName });
            //}
            //Repeater1.DataSource = repeaterValue;
            //Repeater1.DataBind();

            //BuildSocialEventTable();
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
            ddllessonCourse.DataSource = dt;
            ddllessonCourse.DataBind();
            ddllessonCourse.DataTextField = "CourseSubjectName";
            ddllessonCourse.DataValueField = "Id";
            ddllessonCourse.DataBind();
            ddllessonCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        static string getAbbreviatedName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMM");
        }

        protected void btnOverview_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnOverview.BackColor = _backcolor;
            btnOverview.ForeColor = _txtcolor;
            btnDetails.BackColor = _color;
            btnDetails.ForeColor = _otherbackcolor;
            btnScheduleClass.BackColor = _color;
            btnScheduleClass.ForeColor = _otherbackcolor;
            btnAssignment.BackColor = _color;
            btnAssignment.ForeColor = _otherbackcolor;
            //btnHistory.BackColor = _color;
            btnAssignmentList.BackColor = _color;
            btnAssignmentList.ForeColor = _otherbackcolor;
        }


        protected void btnDetails_Click(object sender, EventArgs e)
        {
            Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
            if (isGoogleSub == true)
            {
                MultiView1.ActiveViewIndex = 1;
                string hex = "#8fcccc";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                string forehex = "#000000";
                Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
                string backColor = "#f2f2f2";
                Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
                string otherbackColor = "#ffffff";
                Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
                btnDetails.BackColor = _backcolor;
                btnDetails.ForeColor = _txtcolor;
                btnOverview.BackColor = _color;
                btnOverview.ForeColor = _otherbackcolor;
                btnScheduleClass.BackColor = _color;
                btnScheduleClass.ForeColor = _otherbackcolor;
                btnAssignment.BackColor = _color;
                btnAssignment.ForeColor = _otherbackcolor;
                //btnHistory.BackColor = _color;
                btnAssignmentList.BackColor = _color;
                btnAssignmentList.ForeColor = _otherbackcolor;


                //Video
                StudyMaterialView.ActiveViewIndex = 0;
                btnVideo.BackColor = _backcolor;
                btnVideo.ForeColor = _txtcolor;
                btnDocument.BackColor = _color;
                btnDocument.ForeColor = _otherbackcolor;

                GetListOfYoutubeVideoList();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Google Task.');", true);
            }
        }

        protected void btnScheduleClass_Click(object sender, EventArgs e)
        {
            Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
            if (isGoogleSub == true)
            {
                MultiView1.ActiveViewIndex = 2;
                string hex = "#8fcccc";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                string forehex = "#000000";
                Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
                string backColor = "#f2f2f2";
                Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
                string otherbackColor = "#ffffff";
                Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
                btnScheduleClass.BackColor = _backcolor;
                btnScheduleClass.ForeColor = _txtcolor;
                btnOverview.BackColor = _color;
                btnOverview.ForeColor = _otherbackcolor;
                btnDetails.BackColor = _color;
                btnDetails.ForeColor = _otherbackcolor;
                btnAssignment.BackColor = _color;
                btnAssignment.ForeColor = _otherbackcolor;
                //btnHistory.BackColor = _color;
                btnAssignmentList.BackColor = _color;
                btnAssignmentList.ForeColor = _otherbackcolor;
                CalenderEvents();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Google Task.');", true);
            }
        }
        protected void linkrequestFeedback_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            string url = "https://meet.google.com/";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(id);
            sb.Append("');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                    "script", sb.ToString());
            //Response.Redirect(""+ id + "");
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }

        protected void linkOpenFeedback_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            DeleteEvent();
            //Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");

        }
        public static CalendarService GetDeleteeventService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { CalendarService.Scope.Calendar };


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
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CalenderAPI",
            });



            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        private void DeleteEvent()
        {
            try
            {
                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                var clientId = Session["ClientID"].ToString();
                DataTable dt = new DataTable();
                dt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (dt.Rows.Count > 0)
                {
                    serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                    privateKey = dt.Rows[0]["PrivateKey"].ToString();
                }

                CalendarService service = GetDeleteeventService(serviceEmail, serviceOnEmailId, privateKey);
                Event bodyfile = new Event();


                string eventId = Session["EventId"].ToString();
                String calendarId = "primary";
                EventsResource.DeleteRequest request = service.Events.Delete(calendarId, eventId);

                request.SendNotifications = true;

                string response = request.Execute();

                if (response == "")
                {
                    string[] authorsList = eventId.Split('_');
                    var addeventResult = eventBLL.DeleteSessionEvent(authorsList[0].ToString());
                    if (addeventResult > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Event Deleted Sucessfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Event Deleted But not added in Database.')", true);
                    }
                    CalenderEvents();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                    CalenderEvents();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

        }
        public static CalendarService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            // string[] scopes = new string[] { CalendarService.Scope.Drive };


            //"SERVICE_ACCOUNT_EMAIL_HERE";
            String serviceAccountEmail = serviceEmail;

            // Scope and user email id which you want to impersonate
            var initializer = new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = Scopes,
                User = serviceOnEmailId
            };

            //get private key, from .JSON file
            var credential = new ServiceAccountCredential(initializer.FromPrivateKey(privateKey));


            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CalenderAPI",
            });



            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        public void CalenderEvents()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable dt = new DataTable();
            dt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (dt.Rows.Count > 0)
            {
                serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                privateKey = dt.Rows[0]["PrivateKey"].ToString();
            }
            //"SERVICE_ACCOUNT_EMAIL_HERE";
            // String serviceAccountEmail = "learningmanagementsystem@bamboo-weft-339613.iam.gserviceaccount.com";
            //
            // // Scope and user email id which you want to impersonate
            // var initializer = new ServiceAccountCredential.Initializer(serviceAccountEmail)
            // {
            //     Scopes = Scopes,
            //     User = "harsh041999mishra@gmail.com"
            // };
            //
            // //get private key, from .JSON file
            // var credential = new ServiceAccountCredential(initializer.FromPrivateKey("-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCpyf64bbzxZ7YX\neNbjm3BB+hjAcZoG7qCPPRQFXOM3yoUwRBsVds7wGRutgVH+ci4XOF92zQ5TVtzS\ny+1y16E8uxhmW5JUYbFoNxx3hdXwPP2ZbKiSQ84OAmFO9mxpuW+ESwbX8Jbu6cFU\n2ImCSwHSF+7NVI23Bav3TP+zvJ3/hw4oitK2uSLUz8KYdFS34NMXy7I2LeX1MSoC\nJnzbNeS9P5AS4I+zyC3khfciozRkimPLvSbbE2mp6LXcMBUHKESh+KYbpsnT1duZ\nK5mI5NsQtfMuy0W2VUbc6Srd2PlQ05KNqqpNsD6lVSGyTI9acPDs1dgf0KCE8EC3\nTEcefpxTAgMBAAECggEAA+2EboYWCe23m9FNof1cXXUIiMpnOX9aYNp8xYKbi5rE\noKyMkfF/eoP3IiO9iV8qQl3sWDNRz4UUI9XF+CuVahChMqJSuSJWwuGR+ikau7OK\nc9xa+ZW3yDVHmg12eJXwwK4NjTzqi51PN74FsRoH3vE2OPAUeduFip4te8W5XEP+\nh7tqod7obje4t8ftcmFFu5AioHrkAQTPL7UOs4T7Plw6SXJsfvRQRzGBNAbfGrQQ\naieZacMAZCWIxe5DgvN4HN6jPBMjul15LEybJo761JcJWMR8tOPDObuosDCwPnSD\nK49KNaO4M8AK0Gk8Dc1ijzPcFSqeOjFsXxkVyI/88QKBgQDoHaOP8YKo77ahnusf\nhS/mZFBrTXABAhTKZv5Se8Z2W//x3Bj1+TRY7LEaz8Ch9MpGsW4RcicTtUyykVJN\nx0BhVuWAObphgPXw+alYUL1voaqGPMtGVIi6/keqmycNkmE6lTKAB7Ne2WAUm2jR\n9HTTHSyjFq595t1T7r35YOTlLQKBgQC7Qo3Vuube22AZUtbydNt0/qb8glYeogUJ\nb1/RkgAlyXcFk27v7wbpVHsjyctidQE3Jl4cwR/BHwM6lxwwHtZv0drkxvjfKyjo\nWIO27n7DtoRN3GHo3FcuS/Kb3ZmUqbf5n/XEi9diDJhsZEf+RcnAsnNf7a02kPI3\nbPvMQ613fwKBgB+n+yikfXdgyf2c2OBBn9jCEZ2wv/fDOuanyUOikdyOi4eGxvi0\n9giyryzC7Lip0/R0OliywtWTQlSQMTNeW09rNH2aYeruVZx50Di1OkDBQapxHCAJ\nY2RtTYTdCCR3tD7zHiIL6tCiwNHOqCsKNeyc6/uKGl4dYE4UH2ClcFI5AoGAO62M\nMi8sYJ2dVLS31/Ex92koopSPCZgs7sLV0J4s+d3o1pgT5NdSZo4L6G3pKWmMh5zs\npVFO42cUyllaHGPXhy9kCUD4E3dXxCRhZa1ALPM/2uh/M4z1I8YEfXPz/BLSlPVL\nh+XhMFg/Q1v6LajkEUtNxaajax5qcwuCe6id4dUCgYBh8Xuai6n6uxYkwetEgs3U\ncdg4to7GFDYfWrsrMBFhhJAZ92ngEMm5dnPy7NmE7TLooM01wN5PAyh+vV/v/IlE\nrAZ8fscxuIhEBs+Hi6FuyGEiAuaWFUgXavhXV0tGy4pP2Pcnu7CJuE3Pf/N5dfo1\nhd8FGWkU2d5dkF3DJNYlYA==\n-----END PRIVATE KEY-----\n"));







            //UserCredential credential;
            //string path = Server.MapPath("../CredentialFIle/CredMain.json");// Path.Combine(System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + "../CredentialFIle/CredMain.json");
            // //string path = HttpContext.Current.Server.MapPath("~/CredentialFIle/CredMain.json");
            //using (var stream =
            //    new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    // The file token.json stores the user's access and refresh tokens, and is created
            //    // automatically when the authorization flow completes for the first time.
            //    string credPath = "token.json";
            //    var token = new TokenResponse { RefreshToken = "" };
            //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.Load(stream).Secrets,
            //        Scopes,
            //        "user",
            //        CancellationToken.None,
            //                               new FileDataStore(credPath, true)
            //        ).Result;
            //    //Console.WriteLine("Credential file saved to: " + credPath);
            //}

            // Create Google Calendar API service.
            //var service = new CalendarService(new BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName,
            //});
            CalendarService service = GetService(serviceEmail, serviceOnEmailId, privateKey);
            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    var calenderEvent = new CalenderEvent();
                    calenderEvent.EventId = eventItem.Id;
                    calenderEvent.Organizer = eventItem.Organizer.Email;
                    calenderEvent.Summary = eventItem.Summary;
                    calenderEvent.Description = eventItem.Description;
                    calenderEvent.StartTime = eventItem.Start.DateTime.ToString();
                    calenderEvent.EndTime = eventItem.End.DateTime.ToString();
                    calenderEvent.MeetLink = eventItem.HangoutLink;
                    GoogleEvents.Add(calenderEvent);

                    //string when = eventItem.Start.DateTime.ToString();
                    //if (String.IsNullOrEmpty(when))
                    //{
                    //    when = eventItem.Start.Date;
                    //}
                    //Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            GrdViewScheduleClass.DataSource = GoogleEvents;
            GrdViewScheduleClass.DataBind();
        }
        protected void btnAssignment_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnAssignment.BackColor = _backcolor;
            btnAssignment.ForeColor = _txtcolor;
            btnOverview.BackColor = _color;
            btnOverview.ForeColor = _otherbackcolor;
            btnDetails.BackColor = _color;
            btnDetails.ForeColor = _otherbackcolor;
            btnScheduleClass.BackColor = _color;
            btnScheduleClass.ForeColor = _otherbackcolor;
            //btnHistory.BackColor = _color;
            btnAssignmentList.BackColor = _color;
            btnAssignmentList.ForeColor = _otherbackcolor;
            bindAssignmentdepartmentddl();
        }
        public void bindAssignmentdepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlAssignmentDepartment.DataSource = dt;
            ddlAssignmentDepartment.DataBind();
            ddlAssignmentDepartment.DataTextField = "DepartmentStandardName";
            ddlAssignmentDepartment.DataValueField = "Id";
            ddlAssignmentDepartment.DataBind();
            ddlAssignmentDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlAssignmentDepartment.SelectedValue));
            ddlAssignmentCourse.DataSource = dt;
            ddlAssignmentCourse.DataBind();
            ddlAssignmentCourse.DataTextField = "CourseSubjectName";
            ddlAssignmentCourse.DataValueField = "Id";
            ddlAssignmentCourse.DataBind();
            ddlAssignmentCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentlessonddl()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddlAssignmentDepartment.SelectedValue), int.Parse(ddlAssignmentCourse.SelectedValue));
            ddlAssignmentLesson.DataSource = dt;
            ddlAssignmentLesson.DataBind();
            ddlAssignmentLesson.DataTextField = "LessonTitle";
            ddlAssignmentLesson.DataValueField = "Id";
            ddlAssignmentLesson.DataBind();
            ddlAssignmentLesson.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnHistory_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            //btnHistory.BackColor = _backcolor;
            //btnHistory.ForeColor = _txtcolor;
            btnOverview.BackColor = _color;
            btnDetails.BackColor = _color;
            btnScheduleClass.BackColor = _color;
            btnAssignment.BackColor = _color;
            btnAssignmentList.BackColor = _color;
        }
        private void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            var fromdate = e.Day.Date.ToShortDateString();
            var newFromDate = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var todate = e.Day.Date.AddDays(1).ToShortDateString();
            var newtodate = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            DataRow[] rows = socialEvents.Select(
                         String.Format(
                            "Date >= #{0}# AND Date < #{1}#",
                           newFromDate,
                           newtodate
                         )
                      );

            foreach (DataRow row in rows)
            {
                System.Web.UI.WebControls.Image image;
                image = new System.Web.UI.WebControls.Image();

                image.ToolTip = row["Description"].ToString();

                e.Cell.BackColor = Color.Wheat;
            }
        }
        private void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            System.Data.DataView view = socialEvents.DefaultView;
            List<DateTime> selectedDate = new List<DateTime>();
            //for (int i = 0; i < Calendar1.SelectedDates.Count; i++)
            //{
            //    selectedDate.Add(Calendar1.SelectedDates[i]);
            //}

            view.RowFilter = String.Format(
                              "Date >= #{0}# AND Date < #{1}#",
                           selectedDate.FirstOrDefault().ToShortDateString(),
                            selectedDate.LastOrDefault().AddDays(1).ToShortDateString()
                           );
            //view.RowFilter = String.Format(
            //                  "Date >= #{0}# AND Date < #{1}#",
            //                  Calendar1.SelectedDate.ToShortDateString(),
            //                  Calendar1.SelectedDate.AddDays(1).ToShortDateString()
            //               );

            if (view.Count > 0)
            {
                GrdViewScheduleClass.Visible = true;
                GrdViewScheduleClass.DataSource = view;
                GrdViewScheduleClass.DataBind();
            }
            else
            {
                GrdViewScheduleClass.Visible = false;
            }
        }

        private DataTable socialEvents;

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
            //this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        [WebMethod]
        public static string SaveData(string empdata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(empdata);
            using (var con = new SqlConnection(Constr))
            {
                foreach (var data in serializeData)
                {
                    using (var cmd = new SqlCommand("INSERT INTO Employee01 VALUES(@Fname, @Lname,@Email,@CreatedDate)"))
                    {

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Fname", data.Option);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return null;
        }

        //protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (DropDownList9.SelectedValue == "0")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Proper Answer Type')", true);
        //    }
        //    else if (DropDownList9.SelectedValue == "1")
        //    {
        //        MultiView2.ActiveViewIndex = 0;
        //    }
        //    else if (DropDownList9.SelectedValue == "2")
        //    {
        //        MultiView2.ActiveViewIndex = 1;
        //    }
        //    else if (DropDownList9.SelectedValue == "3")
        //    {
        //        MultiView2.ActiveViewIndex = 3;
        //    }
        //    else
        //    {
        //        MultiView2.ActiveViewIndex = 2;
        //    }
        //}

        //protected void ddlnumberValidation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlnumberValidation.SelectedValue == "1")
        //    {

        //        ddlrangevalidation.Items.Clear();
        //        ddlrangevalidation.Items.Add(new ListItem("Select Validation", "0"));
        //        ddlrangevalidation.Items.Add(new ListItem("Greater than", "1"));
        //        ddlrangevalidation.Items.Add(new ListItem("Greater than or equal to", "2"));
        //        ddlrangevalidation.Items.Add(new ListItem("Less than", "3"));
        //        ddlrangevalidation.Items.Add(new ListItem("Less than or equal to", "4"));
        //        ddlrangevalidation.Items.Add(new ListItem("Equal to", "5"));
        //        ddlrangevalidation.Items.Add(new ListItem("Not equal to", "6"));
        //        ddlrangevalidation.Items.Add(new ListItem("Between", "7"));
        //        ddlrangevalidation.Items.Add(new ListItem("Not between", "8"));
        //        ddlrangevalidation.Items.Add(new ListItem("Is number", "9"));
        //        ddlrangevalidation.Items.Add(new ListItem("Whole number", "10"));
        //    }
        //    else if (ddlnumberValidation.SelectedValue == "2")
        //    {
        //        ddlrangevalidation.Items.Clear();
        //        ddlrangevalidation.Items.Add(new ListItem("Select Validation", "0"));
        //        ddlrangevalidation.Items.Add(new ListItem("Contains", "1"));
        //        ddlrangevalidation.Items.Add(new ListItem("Doesn't contains", "2"));
        //    }
        //    else if (ddlnumberValidation.SelectedValue == "3")
        //    {
        //        ddlrangevalidation.Items.Clear();
        //        ddlrangevalidation.Items.Add(new ListItem("Select Validation", "0"));
        //        ddlrangevalidation.Items.Add(new ListItem("Maximum character count", "1"));
        //        ddlrangevalidation.Items.Add(new ListItem("Minimum character count", "2"));
        //    }
        //    else
        //    {

        //    }
        //}

        //protected void ddlrangevalidation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlrangevalidation.SelectedItem.Text == "Greater than" || ddlrangevalidation.SelectedItem.Text == "Greater than or equal to" || ddlrangevalidation.SelectedItem.Text == "Less than"
        //        || ddlrangevalidation.SelectedItem.Text == "Less than or equal to" || ddlrangevalidation.SelectedItem.Text == "Equal to" || ddlrangevalidation.SelectedItem.Text == "Not equal to"
        //        || ddlrangevalidation.SelectedItem.Text == "Less than or equal to" || ddlrangevalidation.SelectedItem.Text == "Maximum character count" || ddlrangevalidation.SelectedItem.Text == "Minimum character count")
        //    {
        //        mltvalidation.ActiveViewIndex = 0;
        //    }
        //    else if (ddlrangevalidation.SelectedItem.Text == "Contains" || ddlrangevalidation.SelectedItem.Text == "Doesn't contains")
        //    {
        //        mltvalidation.ActiveViewIndex = 2;
        //    }
        //    else if (ddlrangevalidation.SelectedItem.Text == "Between" || ddlrangevalidation.SelectedItem.Text == "Not between")
        //    {
        //        mltvalidation.ActiveViewIndex = 1;
        //    }
        //}
        // private DataTable videoEvents;
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //  var path = "10secclip.mp4";
                // string link = "test1/10secclip.mp4";//"~/test1/" + path;
                // //Literal1.Text = "<video width=400 controls><source src=test1/10secclip.mp4 type=video/mp4></video>";
                //videoEvents = new DataTable();
                //videoEvents.Columns.Add(new DataColumn("path", typeof(string)));


                //DataRow row;
                //row = videoEvents.NewRow();
                //row["path"] = "<video width=400 controls><source src=test1/10secclip.mp4 type=video/mp4></video>";

                //videoEvents.Rows.Add(row);
                //System.Data.DataView viewpath = socialEvents.DefaultView;
                //List<String> abc = new List<string>();
                //abc.Add("<video width=400 controls><source src=test1/10secclip.mp4 type=video/mp4></video>");
                //DataList1.DataSource = viewpath;
                //DataList1.DataBind();
            }
        }
        protected void GrdViewScheduleClass_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "columnwidth";
                //e.Row.Cells[2].CssClass = "columnwidth";
                //e.Row.Cells[3].CssClass = "columnwidth";
                //e.Row.Cells[4].CssClass = "columnwidth";
                //e.Row.Cells[5].CssClass = "columnwidth";
                //e.Row.Cells[6].CssClass = "columnwidth";
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLessonTitle.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson title cannot be empty')", true);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtLessonDescription.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson description cannot be empty')", true);
                    }
                    else
                    {
                        if (int.Parse(ddllessonDepartment.SelectedValue) != 0)
                        {
                            if (int.Parse(ddllessonCourse.SelectedValue) != 0)
                            {
                                Boolean isPublished = false;
                                if (CheckBox1.Checked == true)
                                {
                                    isPublished = true;
                                }
                                DataTable dtdepartmentstandard = new DataTable();
                                dtdepartmentstandard = bll.GetLessonList("Full");
                                List<string> lessonname = new List<string>();
                                lessonname = dtdepartmentstandard.AsEnumerable()
                               .Select(r => r.Field<string>("LessonTitle"))
                               .ToList();
                                if (!lessonname.Contains(txtLessonTitle.Text))
                                {
                                    var result = bll.AddNewLesson(int.Parse(ddllessonDepartment.SelectedValue), int.Parse(ddllessonCourse.SelectedValue), txtLessonTitle.Text, txtLessonDescription.Text, isPublished);
                                    if (result > 0)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Registered Sucessfully')", true);

                                    }
                                    else
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course / Subject already in available')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Course / Subject')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Course / Subject')", true);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bll = null;
            }
        }
        protected void ddllessonDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewSession.aspx");
        }
        protected void txtFromdate_TextChanged(object sender, EventArgs e)
        {
            FilteredCalenderEvents();
        }
        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            FilteredCalenderEvents();
        }
        public static CalendarService GetFiltereventService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { CalendarService.Scope.Calendar };


            //"SERVICE_ACCOUNT_EMAIL_HERE";
            String serviceAccountEmail = serviceEmail;

            // Scope and user email id which you want to impersonate
            var initializer = new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = Scopes,
                User = serviceOnEmailId
            };

            //get private key, from .JSON file
            var credential = new ServiceAccountCredential(initializer.FromPrivateKey(privateKey));


            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "CalenderAPI",
            });



            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            return service;
        }
        public void FilteredCalenderEvents()
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable dt = new DataTable();
            dt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (dt.Rows.Count > 0)
            {
                serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                privateKey = dt.Rows[0]["PrivateKey"].ToString();
            }

            CalendarService service = GetFiltereventService(serviceEmail, serviceOnEmailId, privateKey);

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");

            if (!string.IsNullOrWhiteSpace(txtFromdate.Text))
            {
                string txtFromDateValue = txtFromdate.Text + "T00:01:00+05:30";
                request.TimeMin = Convert.ToDateTime(txtFromDateValue);
            }
            if (!string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                string txtTillDateValue = TextBox4.Text + "T23:59:00+05:30";
                request.TimeMax = Convert.ToDateTime(txtTillDateValue);
            }
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    var calenderEvent = new CalenderEvent();
                    calenderEvent.EventId = eventItem.Id;
                    calenderEvent.Organizer = eventItem.Organizer.Email;
                    calenderEvent.Summary = eventItem.Summary;
                    calenderEvent.Description = eventItem.Description;
                    calenderEvent.StartTime = eventItem.Start.DateTime.ToString();
                    calenderEvent.EndTime = eventItem.End.DateTime.ToString();
                    calenderEvent.MeetLink = eventItem.HangoutLink;
                    GoogleEvents.Add(calenderEvent);

                    //string when = eventItem.Start.DateTime.ToString();
                    //if (String.IsNullOrEmpty(when))
                    //{
                    //    when = eventItem.Start.Date;
                    //}
                    //Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            GrdViewScheduleClass.DataSource = GoogleEvents;
            GrdViewScheduleClass.DataBind();
        }
        protected void btnVideo_Click(object sender, EventArgs e)
        {
            StudyMaterialView.ActiveViewIndex = 0;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            btnVideo.BackColor = _backcolor;
            btnVideo.ForeColor = _txtcolor;
            btnDocument.BackColor = _color;
            GetListOfYoutubeVideoList();
        }
        protected void btnDocument_Click(object sender, EventArgs e)
        {
            StudyMaterialView.ActiveViewIndex = 1;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            btnDocument.BackColor = _backcolor;
            btnDocument.ForeColor = _txtcolor;
            btnVideo.BackColor = _color;
            GetListOfUploadedFIleList();
        }
        public static DriveService GetListOfUploadedFIleService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public void GetListOfUploadedFIleList()
        {
            try
            {

                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                var clientId = Session["ClientID"].ToString();
                DataTable dt = new DataTable();
                dt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (dt.Rows.Count > 0)
                {
                    serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                    privateKey = dt.Rows[0]["PrivateKey"].ToString();
                }

                DriveService service = GetListOfUploadedFIleService(serviceEmail, serviceOnEmailId, privateKey);

                Google.Apis.Drive.v3.FilesResource.ListRequest FileListRequest = service.Files.List();
                FileListRequest.Fields = "nextPageToken, files(createdTime, id, name, size, version, trashed, parents, webContentLink)";

                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
                List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
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
                GridViewdriveDocument.DataSource = FileList;
                GridViewdriveDocument.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnUploadVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadVideo.aspx");
        }
        protected void btnuploadFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadFile.aspx");
        }
        public static YouTubeService GetListOfYoutubeVideoService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public void GetListOfYoutubeVideoList()
        {
            try
            {
                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                var clientId = Session["ClientID"].ToString();
                DataTable dt = new DataTable();
                dt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (dt.Rows.Count > 0)
                {
                    serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                    privateKey = dt.Rows[0]["PrivateKey"].ToString();
                }

                YouTubeService service = GetListOfYoutubeVideoService(serviceEmail, serviceOnEmailId, privateKey);

                var channelsListRequest = service.Channels.List("contentDetails");
                channelsListRequest.Mine = true;

                // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
                var channelsListResponse = channelsListRequest.Execute();

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
                gridviewyoutubevideo.DataSource = listOfPlayList;
                gridviewyoutubevideo.DataBind();

                //var request = youtubeService.Videos.List("snippet");
                //request.MaxResults = 100;
                //request.PageToken = "";

                //var response = request.Execute();

                //foreach (var playlistItem in response.Items)
                //{
                //    listOfPlayList.Add(new ListOfPlayList { PlayListId = playlistItem.Id, Title = playlistItem.Snippet.Title, Description = playlistItem.Snippet.Description, PublishedAt = playlistItem.Snippet.PublishedAt.ToString() });
                //}

                //gridviewyoutubevideo.DataSource = listOfPlayList;
                //gridviewyoutubevideo.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void linkdeleteyoutubevideo_click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            DeleteYoutubeVideo(id);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        public static YouTubeService GetDeleteYoutubeVideoService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public void DeleteYoutubeVideo(string id)
        {
            var serviceEmail = "";
            var serviceOnEmailId = "";
            var privateKey = "";
            var clientId = Session["ClientID"].ToString();
            DataTable dt = new DataTable();
            dt = serviceBLL.GetServiceAccountDetailById(clientId);
            if (dt.Rows.Count > 0)
            {
                serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                privateKey = dt.Rows[0]["PrivateKey"].ToString();
            }

            YouTubeService service = GetDeleteYoutubeVideoService(serviceEmail, serviceOnEmailId, privateKey);

            var request = service.Videos.Delete(id);

            var response = request.Execute();
            if (response == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Video deleted successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Something went wrong.');", true);
            }
        }
        protected void linkDeleteDriveFile_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            DeleteDriveFIle(id);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        public static DriveService GetDeleteDriveService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public void DeleteDriveFIle(string driveId)
        {
            try
            {
                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                var clientId = Session["ClientID"].ToString();
                DataTable dt = new DataTable();
                dt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (dt.Rows.Count > 0)
                {
                    serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                    privateKey = dt.Rows[0]["PrivateKey"].ToString();
                }

                DriveService service = GetDeleteDriveService(serviceEmail, serviceOnEmailId, privateKey);

                List<string> parentId = new List<string>();
                //parentId.Add("1bNIHobZzUXebhUGrExKoEPkU3ljz8BGQ");
                var file = new Google.Apis.Drive.v3.Data.File();
                // file.Name = TextBox2.Text.Trim();
                file.MimeType = "application/vnd.google-apps.folder";
                var request = service.Files.Delete(driveId);
                request.Fields = "id";
                var value = request.Execute();
                if (value == "")
                {
                    var result = filebll.DeleteDocumentInDrive(driveId);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('File Deleted successfully.');", true);
                        GetListOfUploadedFIleList();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('File deleted but not deleted from database.');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gridviewyoutubevideo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "videocolumnwidth";
                //e.Row.Cells[2].CssClass = "videocolumnwidth";
                //e.Row.Cells[3].CssClass = "videocolumnwidth";
                //e.Row.Cells[4].CssClass = "videocolumnwidth";
            }
        }
        protected void gridViewdriveDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "filescolumnwidth";
                //e.Row.Cells[2].CssClass = "filescolumnwidth";
                //e.Row.Cells[3].CssClass = "filescolumnwidth";
                //e.Row.Cells[4].CssClass = "filescolumnwidth";
                //e.Row.Cells[5].CssClass = "filescolumnwidth";
            }
        }
        protected void linkPermissionDriveFile_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EventId"] = id;
            //DownloadFile(id);

            setPermission(id);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Permission saved successfully.');", true);
        }
        public static DriveService GetDrivePermissionService(string serviceEmail, string serviceOnEmailId, string privateKey)
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
        public void setPermission(string fileId)
        {
            try
            {
                var serviceEmail = "";
                var serviceOnEmailId = "";
                var privateKey = "";
                var clientId = Session["ClientID"].ToString();
                DataTable dt = new DataTable();
                dt = serviceBLL.GetServiceAccountDetailById(clientId);
                if (dt.Rows.Count > 0)
                {
                    serviceEmail = dt.Rows[0]["ServiceAccountEmail"].ToString();
                    serviceOnEmailId = dt.Rows[0]["UserEmail"].ToString();
                    privateKey = dt.Rows[0]["PrivateKey"].ToString();
                }

                DriveService service = GetDrivePermissionService(serviceEmail, serviceOnEmailId, privateKey);
                Permission newPermission = new Permission();
                newPermission.Type = "anyone";
                newPermission.Role = "reader";
                var response = service.Permissions.Create(newPermission, fileId);//.Execute();
                var result = response.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlAssignmentDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentCourseddl();
        }
        protected void ddlAssignmentCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentlessonddl();
        }
        protected void btnAssignmentSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AssignmentModel assignmentModel = new AssignmentModel();
                assignmentModel.DepartmentId = int.Parse(ddlAssignmentDepartment.SelectedValue);
                assignmentModel.CourseId = int.Parse(ddlAssignmentCourse.SelectedValue);
                assignmentModel.LessonId = int.Parse(ddlAssignmentLesson.SelectedValue);
                assignmentModel.Title = txtQuestion.Text;
                assignmentModel.Description = TextBox5.Text;
                assignmentModel.SubmissionDate = DateTime.ParseExact(txtSubmissionDate.Text, "dd/MM/yyyy", null);


                bool hasFile = FileUploadAssignment.HasFile;
                if (hasFile)
                {
                    int filecount = 0;
                    int fileuploadcount = 0;
                    filecount = FileUploadAssignment.PostedFiles.Count();

                    if (filecount <= 5)
                    {
                        List<FileUploadList> optionAnswer = new List<FileUploadList>();
                        int count = 0;
                        foreach (HttpPostedFile postedFile in FileUploadAssignment.PostedFiles)
                        {
                            count += 1;
                            var fileUploadPath = postedFile.FileName;
                            string extension = System.IO.Path.GetExtension(postedFile.FileName);
                            int applicationUserId = int.Parse(Session["applicationUserId"].ToString());
                            var filename = ddlAssignmentDepartment.SelectedValue.ToString() + "_" + ddlAssignmentCourse.SelectedValue.ToString() + "_" + ddlAssignmentLesson.SelectedValue.ToString() + "_" + applicationUserId.ToString() + "_" + TranTrackid + "_" + count.ToString();
                            var departmentName = ddlAssignmentDepartment.SelectedItem.ToString();
                            var courseName = ddlAssignmentCourse.SelectedItem.ToString();
                            var lessonName = ddlAssignmentLesson.SelectedItem.ToString();
                            var newdepartmentName = departmentName.Replace(" ", "");
                            var newcourseName = courseName.Replace(" ", "");
                            var newlessonName = lessonName.Replace(" ", "");
                            string newFolderName = newdepartmentName + newcourseName + newlessonName;
                            string clientFolderPath = Server.MapPath("../LearnerAssignmentFile/" + newFolderName + "/");
                            if (!Directory.Exists(clientFolderPath))
                            {
                                //If Directory (Folder) does not exists. Create it.
                                Directory.CreateDirectory(clientFolderPath);
                            }
                            if (System.IO.File.Exists(Path.Combine(clientFolderPath, filename)))
                            {
                                // If file found, delete it    
                                System.IO.File.Delete(Path.Combine(clientFolderPath, filename));
                            }
                            FileUploadAssignment.SaveAs(clientFolderPath + filename.ToString() + extension);
                            var completeFileName = "/LearnerAssignmentFile/" + newFolderName + "/" + filename.ToString() + extension;
                            optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                            completeFileName = "";
                        }
                        var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                        assignmentModel.FilePath = selectedvalue;
                        var result = assignmentBLL.AddAssignment(assignmentModel);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment added successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can upload maximum 5 file only.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please select file to upload.')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAssignmentList_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnAssignmentList.BackColor = _backcolor;
            btnAssignmentList.ForeColor = _txtcolor;
            btnOverview.BackColor = _color;
            btnOverview.ForeColor = _otherbackcolor;
            btnDetails.BackColor = _color;
            btnDetails.ForeColor = _otherbackcolor;
            btnScheduleClass.BackColor = _color;
            btnScheduleClass.ForeColor = _otherbackcolor;
            btnAssignment.BackColor = _color;
            btnAssignment.ForeColor = _otherbackcolor;
            //btnHistory.BackColor = _color;
            bindAssignmentListdepartmentddl();
        }
        public void bindAssignmentListdepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlassignmentdepartmentList.DataSource = dt;
            ddlassignmentdepartmentList.DataBind();
            ddlassignmentdepartmentList.DataTextField = "DepartmentStandardName";
            ddlassignmentdepartmentList.DataValueField = "Id";
            ddlassignmentdepartmentList.DataBind();
            ddlassignmentdepartmentList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentListCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlassignmentdepartmentList.SelectedValue));
            ddlassignmentCourseList.DataSource = dt;
            ddlassignmentCourseList.DataBind();
            ddlassignmentCourseList.DataTextField = "CourseSubjectName";
            ddlassignmentCourseList.DataValueField = "Id";
            ddlassignmentCourseList.DataBind();
            ddlassignmentCourseList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentListlessonddl()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddlassignmentdepartmentList.SelectedValue), int.Parse(ddlassignmentCourseList.SelectedValue));
            ddlassignmentLessonList.DataSource = dt;
            ddlassignmentLessonList.DataBind();
            ddlassignmentLessonList.DataTextField = "LessonTitle";
            ddlassignmentLessonList.DataValueField = "Id";
            ddlassignmentLessonList.DataBind();
            ddlassignmentLessonList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlassignmentdepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentListCourseddl();
        }
        protected void ddlassignmentCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentListlessonddl();
        }
        protected void linkAssignmentFileView_Click(object sender, EventArgs e)
        {
            DataTable assisnmentFilePath = new DataTable();
            var selectedFIle = "";
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            assisnmentFilePath = assignmentBLL.GetAssignmentList(int.Parse(lblID));
            if (assisnmentFilePath.Rows.Count > 0)
            {
                selectedFIle = assisnmentFilePath.Rows[0]["AssignmentFilePath"].ToString();
            }
            //var selectedFIle = gvrow.Cells[7].Text;
            var updatedData = selectedFIle.Replace("&quot;", '"'.ToString());
            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<FileUploadList>>(updatedData);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("FilePath") });
            //using (var zipStream = new ZipOutputStream(Response.OutputStream))
            //{
            int count = 0;
            foreach (var filePath in correctAnswerSerializeData)
            {
                count += 1;
                string[] authorsList = filePath.FileName.Split('/');
                var finalName = authorsList.LastOrDefault();
                string extension = System.IO.Path.GetExtension(finalName);
                string CompletefilePath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + filePath.FileName.ToString();// ServerMapPath(filePath.FileName.ToString());
                dt.Rows.Add(count, CompletefilePath);
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            ModalPopupExtender1.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void linkAssignmentDelete_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            ViewState["AssignmentId"] = lblID;
            ModalPopupExtender2.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[2].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[3].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[4].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[5].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[6].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[7].CssClass = "assignmentcolumnwidth";
                //e.Row.Cells[8].CssClass = "assignmentcolumnwidth";
            }
        }
        //protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string[] authorsList = e.CommandArgument.ToString().Split('\\');
        //    var finalName = authorsList.LastOrDefault();
        //    Response.Clear();
        //    //Response.ContentType = "application/octet-stream";
        //    string extension = Path.GetExtension(finalName);
        //    string contentType = "";

        //    switch (extension)
        //    {
        //        case ".pdf":
        //            contentType = "application/pdf";
        //            break;
        //        case ".xslx":
        //            contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            break;
        //        case ".docx":
        //            contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //            break;
        //    }
        //    Response.AppendHeader("Content-Disposition", "filename=" + finalName);
        //    Response.TransmitFile("" + e.CommandArgument);
        //    Response.End();
        //}
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(ViewState["AssignmentId"].ToString());
                var result = assignmentBLL.DeleteAssignment(id);

                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Deleted Sucessfully')", true);
                    bindAssignmentList();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bll = null;
            }

        }
        public void bindAssignmentList()
        {
            DataTable dt = new DataTable();
            dt = assignmentBLL.AssignmentList(int.Parse(ddlassignmentdepartmentList.SelectedValue), int.Parse(ddlassignmentCourseList.SelectedValue), int.Parse(ddlassignmentLessonList.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnAssignmentSearch_Click(object sender, EventArgs e)
        {
            bindAssignmentList();
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] authorsList = e.CommandArgument.ToString().Split('\\');
            var finalName = authorsList.LastOrDefault();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            //string extension = Path.GetExtension(finalName);
            //string contentType = "";

            //switch (extension)
            //{
            //    case ".pdf":
            //        contentType = "application/pdf";
            //        break;
            //    case ".xslx":
            //        contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        break;
            //    case ".docx":
            //        contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            //        break;
            //}
            //Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "filename=" + finalName);
            Response.TransmitFile("" + e.CommandArgument);
            Response.End();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[0].CssClass = "assignmentSrNumbercolumnwidth";
                //e.Row.Cells[7].CssClass = "columnwidth";
            }
        }
    }
}