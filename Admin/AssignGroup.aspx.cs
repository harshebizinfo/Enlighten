using LMS.Admin.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AssignGroup : System.Web.UI.Page
    {
        AdminBLL adminBLL = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindUserddl();
                bindGroupddl();
               btnSetIsPrimary.Visible = false;
            }
        }
        public void bindUserddl()
        {
            DataTable dt = new DataTable();
            dt = adminBLL.GetAllUserUnderClient();
            ddlapplicationUser.DataSource = dt;
            ddlapplicationUser.DataBind();
            ddlapplicationUser.DataTextField = "EmailId";
            ddlapplicationUser.DataValueField = "ApplicationUserId";
            ddlapplicationUser.DataBind();
            ddlapplicationUser.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblIsDatabaseActive = (Label)e.Row.FindControl("lblIsPrimary");
                if (lblIsDatabaseActive.Text == "✓")
                {
                    lblIsDatabaseActive.ForeColor = Color.Green;
                }
                else
                {
                    lblIsDatabaseActive.ForeColor = Color.Red;
                }
                  
            }
        }
        public void bindGroupddl()
        {
            DataTable dt = new DataTable();
            dt = adminBLL.GetAllGroupUnderClient();
            ddlGroupList.DataSource = dt;
            ddlGroupList.DataBind();
            ddlGroupList.DataTextField = "GroupName";
            ddlGroupList.DataValueField = "TenantGroupId";
            ddlGroupList.DataBind();
            ddlGroupList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void linkDeletePlayListItem_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            lblId.Text = id;
            ModalPopupExtender2.Show();
            // DeletePlayList(id);
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
                int id = int.Parse(lblId.Text);
                var result = adminBLL.DeleteGroupAssignToUser(id);

                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Group Name Deleted Sucessfully')", true);
                bindGroupAssignedToUser();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }

        }
        public void bindGroupAssignedToUser()
        {
            DataTable dt = new DataTable();
            dt = adminBLL.GetAllGroupAssignToUser(int.Parse(ddlapplicationUser.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ddlapplicationUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGroupAssignedToUser();
            btnSetIsPrimary.Visible = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            var result = adminBLL.AddGroupAssignTenantGroupToUser(int.Parse(ddlGroupList.SelectedValue), int.Parse(ddlapplicationUser.SelectedValue));
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Group assigned to user Sucessfully')", true);
                bindGroupAssignedToUser();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }

        protected void btnSetIsPrimary_Click(object sender, EventArgs e)
        {
            int tenantGroupId = 0;
            List<int> deleteingId = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Boolean isActive = false;
                Label labelid = row.FindControl("lblid") as Label;
                int id = Convert.ToInt32(labelid.Text);
                CheckBox checkIsActive = (row.FindControl("chkPrimary") as CheckBox);

                if (checkIsActive.Checked == true)
                {
                    deleteingId.Add(id);
                    tenantGroupId = id;
                }
            }
            if (deleteingId.Count == 1)
            {
                var result = adminBLL.UpdateGroupAssignTenantSetPrimary(tenantGroupId,int.Parse(ddlapplicationUser.SelectedValue));
                if(result>0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Group to Set defailt')", true);
                    bindGroupAssignedToUser();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select only one group to set primary')", true);
            }
        }
    }
}