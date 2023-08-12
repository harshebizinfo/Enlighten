using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class CourseSubject : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "7";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/SubjectList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/CourseORSubjectList.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}