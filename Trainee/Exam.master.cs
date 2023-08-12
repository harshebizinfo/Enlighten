using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Exam : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "6";
            string activepage = Request.RawUrl; 
            if (activepage.Contains("/Trainee/ExamList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Trainee/ExamSettings.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Trainee/CreateQuestionPaper.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Trainee/CheckQuestionPaper.aspx"))|| (activepage.Contains("/Trainee/CheckExamQuestionPaper.aspx")))
            {
                page4.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Trainee/DeleteQuestionLog.aspx"))
            {
                page5.Attributes.Add("class", "abc");
            }
        }
    }
}