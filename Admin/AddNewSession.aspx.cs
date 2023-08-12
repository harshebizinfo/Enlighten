using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.EventClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using Newtonsoft.Json;
using static Google.Apis.Calendar.v3.Data.Event;

namespace LMS.Admin
{
    public partial class AddNewSession : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        AdminBLL adminbll = new AdminBLL();
        EventBLL eventBLL = new EventBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        public List<CalenderEvent> GoogleEvents = new List<CalenderEvent>();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };

        static string ApplicationName = "Google Calendar API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.Visible = false;
                binddepartmentddl();
            }
        }
        public void bindlearnerddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetLearnerDetailUnderTraineebyDepartmentId(int.Parse(ddlDepartment.SelectedValue));
            List<string> listContents = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listContents.Add(dr["EmailId"].ToString());
                    //ListBox1.Items.Add(dr["EmailId"].ToString());
                }
            }
            CheckBoxList1.DataSource = listContents;
            CheckBoxList1.DataBind();

            //ddlLearner.DataSource = dt;
            //ddlLearner.DataBind();
            //ddlLearner.DataTextField = "EmailId";
            //ddlLearner.DataValueField = "ApplicationUserId";
            //ddlLearner.DataBind();
            //ddlLearner.Items.Insert(0, new ListItem("-- Select --", "0"));
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedValue == "WEEKLY")
            {
                if (!string.IsNullOrWhiteSpace(txtTillDate.Text))
                {
                    CreateEvent();
                    ClearData();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Select till date')", true);
                }
            }
            else
            {
                CreateEvent();
                ClearData();
            }
        }
        private void ClearData()
        {
            //Response.Redirect("AddSession.aspx");
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
            txtStartDate.Text = "";
            //txtEndDate.Text = "";
            //DropDownList1.Items.FindByValue("HH").Selected = true;
            //DropDownList2.Items.FindByValue("MM").Selected = true;
            //DropDownList3.Items.FindByValue("HH").Selected = true;
            //DropDownList4.Items.FindByValue("MM").Selected = true;
            //DropDownList5.Items.FindByValue("0").Selected = true;
            //ddlColors.Items.FindByValue("0").Selected = true;
        }
        public static CalendarService GetService(string serviceEmail, string serviceOnEmailId, string privateKey)
        {
            string[] scopes = new string[] { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };


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
        private void CreateEvent()
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
                CalendarService service = GetService(serviceEmail, serviceOnEmailId, privateKey);

                Event bodyfile = new Event();
                bodyfile.Summary = txtTitle.Text.Trim();
                bodyfile.Location = txtLocation.Text.Trim();
                bodyfile.Description = txtDescription.Text.Trim();
                string txtStartValue = txtStartDate.Text.Trim();
                string starthour = DropDownList1.SelectedValue;
                string startminutes = DropDownList2.SelectedValue;
                string txtStartDateValue = txtStartValue + "T" + starthour + ":" + startminutes + ":00+05:30";

                //string txtEndValue = txtEndDate.Text.Trim();
                string endhour = DropDownList3.SelectedValue;
                string endminutes = DropDownList4.SelectedValue;
                string txtEndDateValue = txtStartValue + "T" + endhour + ":" + endminutes + ":00+05:30";

                EventDateTime start = new EventDateTime();
                start.DateTime = Convert.ToDateTime(txtStartDateValue);//"2022-01-31T12:17:07+05:30"
                start.TimeZone = "Asia/Kolkata";
                EventDateTime end = new EventDateTime();
                end.DateTime = Convert.ToDateTime(txtEndDateValue);
                end.TimeZone = "Asia/Kolkata";
                bodyfile.Start = start;
                bodyfile.End = end;

                List<string> recurrence = new List<string>();
                if (DropDownList5.SelectedValue == "DAILY")
                {
                    string dailyValue = "RRULE:FREQ=DAILY;COUNT=" + txtCount.Text;
                    recurrence.Add(dailyValue);
                }
                else if (DropDownList5.SelectedValue == "WEEKLY")
                {
                    List<string> weekdays = new List<string>();
                    string days = "";
                    if (chkSunday.Checked == true)
                    {
                        weekdays.Add("SU");
                    }
                    if (chkMonday.Checked == true)
                    {
                        weekdays.Add("MO");
                    }
                    if (chkTuesday.Checked == true)
                    {
                        weekdays.Add("TU");
                    }
                    if (chkWednesday.Checked == true)
                    {
                        weekdays.Add("WE");
                    }
                    if (chkThursday.Checked == true)
                    {
                        weekdays.Add("TH");
                    }
                    if (chkFriday.Checked == true)
                    {
                        weekdays.Add("FR");
                    }
                    if (chkSaturday.Checked == true)
                    {
                        weekdays.Add("SA");
                    }
                    string joinedDays = string.Join(",", weekdays);
                    string untilDate = Convert.ToDateTime(txtTillDate.Text).ToString("yyyyMMdd");
                    string completeRecurrence = "RRULE:FREQ=WEEKLY;BYDAY=" + joinedDays + ";UNTIL=" + untilDate + "T170000Z";
                    recurrence.Add(completeRecurrence);
                    //recurrence.Add("RRULE:FREQ=WEEKLY;BYDAY=SU;UNTIL=20220401T170000Z");
                }
                else
                {
                    recurrence.Add("RRULE:FREQ=DAILY;COUNT=1");
                }
                bodyfile.Recurrence = recurrence;

                List<EventAttendee> attendees = new List<EventAttendee>();


                var value = inpHide.Value;
                var serializeData = JsonConvert.DeserializeObject<List<EventObjectValue>>(value);
                int count = 0;
                foreach (var item in serializeData)
                {
                    if (item.Option != "")
                    {
                        attendees.Add(new EventAttendee { Email = item.Option });
                    }
                }
                //attendees.Add(new EventAttendee { Email = "hm911hmishra@gmail.com",Organizer=true });

                DataTable dt = new DataTable();
                dt = adminbll.GetLearnerDetailUnderTraineebyDepartmentId(int.Parse(ddlDepartment.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        attendees.Add(new EventAttendee { Email = dr["EmailId"].ToString() });
                    }
                }
                var loginTrainee=Session["UserName"].ToString();
                attendees.Add(new EventAttendee { Email = loginTrainee });
                bodyfile.Attendees = attendees;

                //var organizerMailId = Session["UserName"].ToString();

                //OrganizerData odata = new OrganizerData();
                //odata.DisplayName = "Harsh Mishra";
                //odata.Email = "hm911hmishra@gmail.com";
                //odata.Self = true;
                //bodyfile.Organizer = odata;
                List<EventReminder> reminderOverrides = new List<EventReminder>();
                if (chkEmail.Checked == true)
                {
                    reminderOverrides.Add(new EventReminder { Method = "email", Minutes = 5 });
                }
                if (chkPopup.Checked == true)
                {
                    reminderOverrides.Add(new EventReminder { Method = "popup", Minutes = 5 });
                }
                reminderOverrides.Add(new EventReminder { Method = "sms", Minutes = 5 });


                Event.RemindersData reminder = new Event.RemindersData();
                reminder.UseDefault = false;
                reminder.Overrides = reminderOverrides;

                bodyfile.Reminders = reminder;

                //set color
                bodyfile.ColorId = ddlColors.SelectedValue;//"10";


                bodyfile.ConferenceData = new ConferenceData
                {
                    CreateRequest = new CreateConferenceRequest
                    {
                        RequestId = "qaw-svno-njb",
                        ConferenceSolutionKey = new ConferenceSolutionKey { Type = "hangoutsMeet" },
                    },
                };

                bodyfile.GuestsCanInviteOthers = false;
                bodyfile.GuestsCanSeeOtherGuests = false;
                bodyfile.GuestsCanModify = false;


                String calendarId = "primary";
                EventsResource.InsertRequest request = service.Events.Insert(bodyfile, calendarId);
                request.ConferenceDataVersion = 1;
                request.SendNotifications = true;

                Event response = request.Execute();

                if (response.Status == "confirmed")
                {
                    var addeventResult = eventBLL.AddSessionEvent(response.Id,int.Parse(ddlDepartment.SelectedValue));
                    if(addeventResult>0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session Created Sucessfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Session Created But not added in Database.')", true);
                    }
                    
                    //Response.Redirect("A.aspx");
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
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedValue == "WEEKLY")
            {
                MultiView1.Visible = true;
                MultiView1.ActiveViewIndex = 0;
            }
            else if (DropDownList5.SelectedValue == "DAILY")
            {
                MultiView1.Visible = true;
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                MultiView1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindlearnerddl();

        }
    }
    public class EventObjectValue
    {
        public string Option { get; set; }

    }
}