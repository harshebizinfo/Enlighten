using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Group : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "1";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/GroupList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            if (activepage.Contains("/Admin/AssignGroup.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}