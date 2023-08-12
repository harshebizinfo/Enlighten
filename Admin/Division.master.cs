using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Division : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "6";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/AddDivision.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AddLearnerInDepartment.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}