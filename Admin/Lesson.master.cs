using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Lesson : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "8";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/LessonList1.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Admin/AddNewLesson.aspx")) || (activepage.Contains("/Admin/AddNewSession.aspx"))
                || (activepage.Contains("/Admin/UploadVideo.aspx")) || (activepage.Contains("/Admin/UploadFile.aspx")))
            {
                page2.Attributes.Add("class", "abc");
            }
            //if (activepage.Contains("/Admin/AssignmentList.aspx"))
            //{
            //    page1.Attributes.Add("class", "abc");
            //}
        }
    }
}