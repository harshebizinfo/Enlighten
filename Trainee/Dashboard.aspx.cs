using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.ClassFile;
using LMS.Admin.EventClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        public List<CalenderEvent> GoogleEvents = new List<CalenderEvent>();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        EventBLL eventBLL = new EventBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAssignmentList();
                Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
                if (isGoogleSub == true)
                {
                    CalenderEvents();
                    course.Visible = true;
                }
                else
                {
                    course.Visible = false;
                }
            }

        }
        public static CalendarService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { CalendarService.Scope.CalendarReadonly };

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
        public void CalenderEvents()
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
            CalendarService service = GetService(serviceEmail, serviceOnEmailId, privateKey);

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 100;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            List<string> eventInDepartment = new List<string>();
            eventInDepartment = eventBLL.GetEventDetailUnderByTraineeId();
            //Console.WriteLine("Upcoming events:");
            int dataCount = 0;
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string[] authorsList = eventItem.Id.Split('_');
                    if (eventInDepartment.Contains(authorsList[0].ToString()))
                    {
                        dataCount = dataCount + 1;
                        var calenderEvent = new CalenderEvent();
                        calenderEvent.EventId = eventItem.Id;
                        calenderEvent.Organizer = eventItem.Organizer.Email;
                        calenderEvent.Summary = eventItem.Summary;
                        calenderEvent.Description = eventItem.Description;
                        calenderEvent.StartTime = eventItem.Start.DateTime.ToString();
                        calenderEvent.EndTime = eventItem.End.DateTime.ToString();
                        calenderEvent.MeetLink = eventItem.HangoutLink;
                        GoogleEvents.Add(calenderEvent);
                        if (dataCount == 6)
                        {
                            break;
                        }
                    }
                }
            }
            DataList2.DataSource = GoogleEvents;
            DataList2.DataBind();
        }
        public void BindAssignmentList()
        {
            DataTable dt = new DataTable();
            dt = assignmentBLL.GetUploadedAssignmentUnderTrainee("Dashboard");
            DataList1.DataSource = dt;
            DataList1.DataBind();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllAssignmentList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLesson.aspx");
        }
    }
}