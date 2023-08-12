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

namespace LMS.Learner
{
    public partial class Event1 : System.Web.UI.Page
    {
        public List<CalenderEvent> GoogleEvents = new List<CalenderEvent>();
        EventBLL eventBLL = new EventBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
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
                Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
                if (isGoogleSub == true)
                {
                    CalenderEvents(deptId);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Google Task.');", true);
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
        public void CalenderEvents(int departmentId)
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
            DataTable eventdt = new DataTable();
            eventdt = eventBLL.GetSessionEventByDepartmentId(departmentId);
            if (eventdt.Rows.Count > 0)
            {
                foreach (DataRow item in eventdt.Rows)
                {
                    eventInDepartment.Add(item["EventId"].ToString());
                }
            }
            //Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string[] authorsList = eventItem.Id.Split('_');
                    if (eventInDepartment.Contains(authorsList[0].ToString()))
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
                    }
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
            //else
            //{
            //    Console.WriteLine("No upcoming events found.");
            //}
            //Console.Read(); 
        }
        protected void txtFromdate_TextChanged(object sender, EventArgs e)
        {
            DataTable departmentId = new DataTable();
            departmentId = assignmentBLL.GetLearnerDepartmentId();
            int deptId = 0;
            if (departmentId.Rows.Count > 0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }
            FilteredCalenderEvents(deptId);
        }
        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable departmentId = new DataTable();
            departmentId = assignmentBLL.GetLearnerDepartmentId();
            int deptId = 0;
            if (departmentId.Rows.Count > 0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }
            FilteredCalenderEvents(deptId);
        }
        public void FilteredCalenderEvents(int departmentId)
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
            request.MaxResults = 100;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            List<string> eventInDepartment = new List<string>();
            DataTable eventdt = new DataTable();
            eventdt = eventBLL.GetSessionEventByDepartmentId(departmentId);
            if (eventdt.Rows.Count > 0)
            {
                foreach (DataRow item in eventdt.Rows)
                {
                    eventInDepartment.Add(item["EventId"].ToString());
                }
            }

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string[] authorsList = eventItem.Id.Split('_');
                    if (eventInDepartment.Contains(authorsList[0].ToString()))
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
                    }

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
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
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
    }
}