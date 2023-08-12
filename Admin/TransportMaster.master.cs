using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class TransportMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsFirstScreen"] = "9";
            string activepage = Request.RawUrl;
            if (activepage.Contains("/Admin/VehicleModeList.aspx"))
            {
                page1.Attributes.Add("class", "abc");
            }
            else if ((activepage.Contains("/Admin/VehicleList.aspx"))|| (activepage.Contains("/Admin/AddVehicle.aspx"))|| (activepage.Contains("/Admin/EditVehicle.aspx")))
            {
                page2.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AreaMaster.aspx"))
            {
                page3.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/TransportFee.aspx"))
            {
                page4.Attributes.Add("class", "abc");
            }
            else if (activepage.Contains("/Admin/AllotedVehicleList.aspx"))
            {
                page5.Attributes.Add("class", "abc");
            }
        }
    }
}