﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Payment : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "6";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Learner/PayExamFee.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
        }
    }
}