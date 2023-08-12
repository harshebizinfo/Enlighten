using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "2";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Trainee/StudentList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
        }
    }
}