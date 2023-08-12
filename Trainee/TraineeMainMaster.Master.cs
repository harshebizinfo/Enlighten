using LMS.Admin.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class TraineeMainMaster : System.Web.UI.MasterPage
    {
        AdminBLL adminBLL = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var userName = Session["FirstAndLastName"].ToString();
                    var clientId = Session["ClientID"].ToString();
                    var applicationUserId = Session["ApplicationUserId"].ToString();
                    var role = Session["LogedInUserRole"].ToString();
                    DataTable dtrole = new DataTable();
                    dtrole = adminBLL.GetLogedInUserRole(clientId, int.Parse(applicationUserId));
                    DropDownList1.DataSource = dtrole;
                    DropDownList1.DataBind();
                    DropDownList1.DataTextField = "GroupName";
                    DropDownList1.DataValueField = "TenantGroupId";
                    DropDownList1.DataBind();

                    ListItem selectedListItem = DropDownList1.Items.FindByText(role);

                    if (selectedListItem != null)
                    {
                        selectedListItem.Selected = true;
                    }
                    Label1.Text = userName;
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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRoleName = DropDownList1.SelectedItem.ToString();
            if (selectedRoleName == "SuperAdmin")
            {
                Session["LogedInUserRole"] = "SuperAdmin";
                Response.Redirect("../SuperAdmin/Dashboard.aspx");
            }
            if (selectedRoleName == "Admin")
            {
                Session["LogedInUserRole"] = "Admin";
                Response.Redirect("../Admin/Dashboard.aspx");
            }
            else if (selectedRoleName == "Teacher")
            {
                Session["LogedInUserRole"] = "Teacher";
                Response.Redirect("../Trainee/Dashboard.aspx");
            }
            else if (selectedRoleName == "Learner")
            {
                Session["LogedInUserRole"] = "Learner";
                Response.Redirect("../Learner/Exam.aspx");
            }
        }
    }
}