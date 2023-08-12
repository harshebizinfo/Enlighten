using LMS.Admin.DepartmentClassFile;
using LMS.Admin.FeeClassFile;
using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class EditFeeType : System.Web.UI.Page
    {
        FeeBLL feeBLL = new FeeBLL();
        DeptBLL deptBLL = new DeptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                bindFeeNameddl();
                bindFeeMonthddl();
                int editingId = int.Parse(Session["EditFeeTypeId"].ToString());
                DataTable dt = new DataTable();
                dt = feeBLL.GetFeeTypeMasterById(editingId);
                if (dt.Rows.Count > 0)
                {
                    txtstartDatetime.Text = dt.Rows[0]["DueDate"].ToString();
                    txtLateFee.Text = dt.Rows[0]["LateFee"].ToString();
                    var feeName = dt.Rows[0]["FeeName"].ToString();
                    var standard = dt.Rows[0]["DepartmentStandardName"].ToString();
                    var month = dt.Rows[0]["FeeMonth"].ToString();
                    CheckBox1.Checked = Boolean.Parse(dt.Rows[0]["IsActive"].ToString());
                   
                    ddlStandard.SelectedValue = ddlStandard.Items.FindByText(standard).Value;
                    ddlFeeName.SelectedValue = ddlFeeName.Items.FindByText(feeName).Value;
                    ddlMonth.SelectedValue = ddlMonth.Items.FindByText(month).Value;
                }

               
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptBLL.GetDepartmentStandardList("Active");
            ddlStandard.DataSource = dt;
            ddlStandard.DataBind();
            ddlStandard.DataTextField = "DepartmentStandardName";
            ddlStandard.DataValueField = "Id";
            ddlStandard.DataBind();
            ddlStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindFeeNameddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeNameMasterList("Active");
            ddlFeeName.DataSource = dt;
            ddlFeeName.DataBind();
            ddlFeeName.DataTextField = "FeeName";
            ddlFeeName.DataValueField = "Id";
            ddlFeeName.DataBind();
            ddlFeeName.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindFeeMonthddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeMonthMasterList("Active");
            ddlMonth.DataSource = dt;
            ddlMonth.DataBind();
            ddlMonth.DataTextField = "FeeMonth";
            ddlMonth.DataValueField = "Id";
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int idValue = int.Parse(Session["EditFeeTypeId"].ToString());
            AddFeeTypeMasterList addFeeTypeMaster = new AddFeeTypeMasterList();
            addFeeTypeMaster.Id = idValue;
            addFeeTypeMaster.DepartmentStandardId = int.Parse(ddlStandard.SelectedValue);
            addFeeTypeMaster.DueDate = DateTime.Parse(txtstartDatetime.Text);
            addFeeTypeMaster.FeeNameMasterId = int.Parse(ddlFeeName.SelectedValue);
            addFeeTypeMaster.LateFee = int.Parse(txtLateFee.Text);
            addFeeTypeMaster.FeeMonthId = int.Parse(ddlMonth.SelectedValue);
            bool isChecked = false;
            if (CheckBox1.Checked == true)
            {
                isChecked = true;
            }
            addFeeTypeMaster.IsActive = isChecked;
            var result = feeBLL.UpdateFeeTypeMaster(addFeeTypeMaster);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee type Updated Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }
    }
}