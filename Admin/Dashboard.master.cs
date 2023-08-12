using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "0";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/Dashboard.aspx"))
            {
                page1.Attributes.Add("class", "abc");
                page2.Attributes.Add("class", "defaultbgColor");
                page3.Attributes.Add("class", "defaultbgColor");
                page4.Attributes.Add("class", "defaultbgColor");
                page5.Attributes.Add("class", "defaultbgColor");
                page6.Attributes.Add("class", "defaultbgColor");
                page7.Attributes.Add("class", "defaultbgColor");
            }
        }
    }
}