using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using LMS.Admin;
using LMS.Admin.ClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class AddSession : System.Web.UI.Page
    {
        public List<CalenderEvent> GoogleEvents = new List<CalenderEvent>();
        ServiceBLL serviceBLL = new ServiceBLL();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };

        static string ApplicationName = "Google Calendar API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.Visible = false;
            }
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
            Response.Redirect("AddSession.aspx");
            //txtTitle.Text = "";
            //txtDescription.Text = "";
            //txtLocation.Text = "";
            //txtStartDate.Text = "";
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

                //        DateTime startDateTime = new DateTime("2015-05-28T09:00:00-07:00");
                //        EventDateTime start = new EventDateTime()
                //            .setDateTime(startDateTime)
                //            .setTimeZone("America/Los_Angeles");
                //        event.setStart(start);

                //DateTime endDateTime = new DateTime("2015-05-28T17:00:00-07:00");
                //        EventDateTime end = new EventDateTime()
                //            .setDateTime(endDateTime)
                //            .setTimeZone("America/Los_Angeles");
                //        event.setEnd(end);

                string txtStartValue = txtStartDate.Text.Trim();
                string starthour = DropDownList1.SelectedValue;
                string startminutes = DropDownList2.SelectedValue;
                string txtStartDateValue = txtStartValue + "T" + starthour + ":" + startminutes + ":00+05:30";

                string txtEndValue = txtEndDate.Text.Trim();
                string endhour = DropDownList3.SelectedValue;
                string endminutes = DropDownList4.SelectedValue;
                string txtEndDateValue = txtEndValue + "T" + endhour + ":" + endminutes + ":00+05:30";

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
                    recurrence.Add("RRULE:FREQ=DAILY;COUNT=1");
                }
                if (DropDownList5.SelectedValue == "WEEKLY")
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
                bodyfile.Recurrence = recurrence;

                List<EventAttendee> attendees = new List<EventAttendee>();

                //attendees.Add(new EventAttendee { Email = "Sumit@ebizinfo.in" });
                //attendees.Add(new EventAttendee { Email = "harsh9920mishra@gmail.com" });
                //attendees.Add(new EventAttendee { Email = "harsh041999mishra@gmail.com" });

                var value = inpHide.Value;
                var serializeData = JsonConvert.DeserializeObject<List<EventObjectValue>>(value);
                int count = 0;
                foreach (var item in serializeData)
                {
                    attendees.Add(new EventAttendee { Email = item.Option });
                }

                bodyfile.Attendees = attendees;

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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Event Created Sucessfully')", true);
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
            else
            {
                MultiView1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}