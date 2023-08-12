using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Learner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "3";
            string activepage = Request.RawUrl;
            if ((activepage.Contains("/Admin/LearnerList.aspx"))||(activepage.Contains("/Admin/EditLearner.aspx")))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AddLearner1.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/UploadStudent.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            //else if (activepage.Contains("/Admin/StudentAdmissionReport.aspx"))
            //{
            //    page4.Attributes.Add("class", "abc");
            //}
        }
    }
}