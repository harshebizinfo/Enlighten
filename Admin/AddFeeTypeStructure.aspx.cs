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
    public partial class AddFeeTypeStructure : System.Web.UI.Page
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
                bindCategoryddl();
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

            //foreach (DataRow dr in dt.Rows)
            //{
            //    CheckBoxList1.Items.Add(new ListItem { Text = dr["FeeMonth"].ToString(), Value = dr["Id"].ToString() });
            //}
        }
        public void bindCategoryddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetCategoryMasterList("Active");
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //if (CheckBoxList1.SelectedValue != null && CheckBoxList1.SelectedValue != "")
            //{

            //    foreach (ListItem item in CheckBoxList1.Items)
            //    {
            //if (item.Selected)
            //{
            //checkedCount += 1;
            AddFeeTypeStructureList addFeeTypeMaster = new AddFeeTypeStructureList();
            addFeeTypeMaster.DepartmentStandardId = int.Parse(ddlStandard.SelectedValue);
            addFeeTypeMaster.FeeNameAmount = int.Parse(txtFeeAmount.Text);
            addFeeTypeMaster.FeeNameMasterId = int.Parse(ddlFeeName.SelectedValue);
            addFeeTypeMaster.CategoryMasterId = int.Parse(ddlCategory.SelectedValue);
            addFeeTypeMaster.FeeMonthId = int.Parse(ddlMonth.SelectedValue);
            addFeeTypeMaster.DueDate = DateTime.ParseExact(txtstartDatetime.Text, "dd/MM/yyyy", null);
            addFeeTypeMaster.LateFee = int.Parse(txtLateFee.Text);
            bool isChecked = false;
            //if (CheckBox1.Checked == true)
            //{
            //    isChecked = true;
            //}
            addFeeTypeMaster.IsActive = CheckBox1.Checked == true ? true : false;
            var result = feeBLL.AddFeeTypeMasterAndFeeStructure(addFeeTypeMaster);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Type and Structure added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
            //}
            //    }

            //    if (resultCount == checkedCount)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Type and Structure added Successfully')", true);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select month to create Fee Type and Structure')", true);
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtFeeAmount.Text = "";
            txtLateFee.Text = "";
            txtstartDatetime.Text = "";
        }
    }
}