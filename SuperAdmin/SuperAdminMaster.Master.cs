using LMS.Admin.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class SuperAdminMaster : System.Web.UI.MasterPage
    {
        AdminBLL adminBLL = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DropDownList1.Items.Insert(0, new ListItem("Super Admin", "1"));
                    DropDownList1.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void functionName(object sender, EventArgs e)
        {
            //Response.Write("Hello World!!!");
            Session.Abandon();
            Response.Redirect("../Common/Login.aspx");
        }

    }
}