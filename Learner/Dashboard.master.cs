﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "0";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Learner/Dashboard.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
        }
    }
}