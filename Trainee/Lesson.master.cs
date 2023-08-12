using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Lesson : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "5";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Trainee/LessonList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Trainee/AddLesson.aspx"))||(activepage.Contains("/Trainee/AddNewSession.aspx"))
                || (activepage.Contains("/Trainee/UploadVideo.aspx")) || (activepage.Contains("/Trainee/UploadFile.aspx")))
            {
                page2.Attributes.Add("class", "abc");
            }
            //else if (activepage.Contains("/Trainee/Session.aspx"))
            //{
            //    page3.Attributes.Add("class", "abc");
            //}
        }
    }
}