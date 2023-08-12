using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class ClientMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string activepage = Request.RawUrl;
            if (activepage.Contains("/SuperAdmin/ClientList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/SuperAdmin/AddClient.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}