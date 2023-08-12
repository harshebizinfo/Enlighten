using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AttendanceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "4";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/ViewTraineeAttendance.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Admin/TakeTraineeAttendance.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Admin/UpdateTraineeAttendance.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Admin/ViewStudentAttendanceByAdmin.aspx"))
            {
                page4.Attributes.Add("class", "abc");
            }
        }
    }
}