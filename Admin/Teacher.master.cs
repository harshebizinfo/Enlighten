using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Teacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "2";
            string activepage = Request.RawUrl;
            if ((activepage.Contains("/Admin/TraineeList.aspx"))||(activepage.Contains("/Admin/EditTrainee.aspx")))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AddTrainee1.aspx"))
            {
                page2.Attributes.Add("class", "abc");
            }
        }
    }
}