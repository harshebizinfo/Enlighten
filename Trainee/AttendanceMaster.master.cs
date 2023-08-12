using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class AttendanceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Trainee/ViewStudentAttendance.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Trainee/TakeStudentAttendance.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Trainee/UpdateStudentAttendance.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
        }
    }
}