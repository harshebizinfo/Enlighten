using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class Payment : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string activepage = Request.RawUrl;
            if ((activepage.Contains("/SuperAdmin/PaymentConfiguration.aspx"))||(activepage.Contains("/SuperAdmin/EditPaymentConfiguration.aspx")))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/SuperAdmin/AddPaymentConfiguration.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/SuperAdmin/reverification.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/SuperAdmin/PaidPaymentList.aspx"))
            {
                page4.Attributes.Add("class", "abc");
            }
        }
    }
}