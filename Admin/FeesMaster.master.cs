using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class FeesMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "10";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/FeeGroup.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Admin/FeeNameMasterList.aspx")) || (activepage.Contains("/Admin/AddFeeNameMaster.aspx")) || (activepage.Contains("/Admin/EditFeeNameMaster.aspx")))
            {
                page2.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AddCategoryMaster.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/FeeMonthMaster.aspx"))
            {
                page4.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Admin/FeeType.aspx")) || (activepage.Contains("/Admin/AddFeeType.aspx")) || (activepage.Contains("/Admin/EditFeeType.aspx")))
            {
                page5.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Admin/FeeStructure.aspx")) || (activepage.Contains("/Admin/AddFeeStructure.aspx")))
            {
                page6.Attributes.Add("class", "abc");
            }
        }
    }
}