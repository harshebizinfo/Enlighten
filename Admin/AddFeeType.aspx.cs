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
    public partial class AddFeeType : System.Web.UI.Page
    {
        FeeBLL feeBLL = new FeeBLL();
        DeptBLL deptBLL = new DeptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddepartmentddl();
                bindFeeNameddl();
                bindFeeMonthddl();
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
            AddFeeTypeMasterList addFeeTypeMaster = new AddFeeTypeMasterList();
            addFeeTypeMaster.DepartmentStandardId = int.Parse(ddlStandard.SelectedValue);
            addFeeTypeMaster.DueDate = DateTime.Parse(txtstartDatetime.Text);
            addFeeTypeMaster.FeeNameMasterId = int.Parse(ddlFeeName.SelectedValue);
            addFeeTypeMaster.LateFee = int.Parse(txtLateFee.Text);
            addFeeTypeMaster.FeeMonthId = int.Parse(ddlMonth.SelectedValue);
            bool isChecked = false;
            if(CheckBox1.Checked==true)
            {
                isChecked = true;
            }
            addFeeTypeMaster.IsActive = isChecked;
            var result = feeBLL.AddFeeTypeMasterMaster(addFeeTypeMaster);
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee type added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtLateFee.Text = "";
            txtstartDatetime.Text = "";
        }
    }
}