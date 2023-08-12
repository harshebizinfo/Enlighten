using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Assignment : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "5";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Learner/AssignmentList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Learner/UploadAssignmentFile.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}