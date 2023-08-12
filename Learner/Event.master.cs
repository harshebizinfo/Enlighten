using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Event : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "3";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Learner/Event.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
        }
    }
}