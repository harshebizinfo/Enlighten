using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class NoticeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/NoticeList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
        }
    }
}