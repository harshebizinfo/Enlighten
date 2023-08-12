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
    public partial class EditFeeNameMaster : System.Web.UI.Page
    {
        FeeBLL feeBLL = new FeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFeeGroupddl();
                int editingId = int.Parse(Session["EditFeeNameMasterDetailId"].ToString());
                DataTable dt = new DataTable();
                dt = feeBLL.GetFeeNameMasterListById(editingId);
                if (dt.Rows.Count > 0)
                {
                    txtFeeName.Text = dt.Rows[0]["FeeName"].ToString();
                    chkRefundable.Checked = Boolean.Parse(dt.Rows[0]["RefundableFee"].ToString());
                    chkoptional.Checked = Boolean.Parse(dt.Rows[0]["OptionalFee"].ToString());
                    chkdiscount.Checked = Boolean.Parse(dt.Rows[0]["DiscountOn"].ToString());
                    chkConveyance.Checked = Boolean.Parse(dt.Rows[0]["Conveyance"].ToString());
                    chkFeeDisplay.Checked = Boolean.Parse(dt.Rows[0]["FeeDisplay"].ToString());
                    chkTransferhead.Checked = Boolean.Parse(dt.Rows[0]["TransferHead"].ToString());
                    CheckBox1.Checked = Boolean.Parse(dt.Rows[0]["IsActive"].ToString());
                    int feeGroupId = int.Parse(dt.Rows[0]["FeeGroupId"].ToString());
                    DataTable feeGroupDataTable = new DataTable();
                    feeGroupDataTable = feeBLL.GetFeeGroupList("Active");
                    var feeGroupName = "";
                    foreach(DataRow dr in feeGroupDataTable.Rows)
                    {
                        if(feeGroupId==int.Parse(dr["Id"].ToString()))
                        {
                            feeGroupName = dr["FeeGroupName"].ToString();
                        }
                    }
                    ddlFeeGroup.SelectedValue = ddlFeeGroup.Items.FindByText(feeGroupName).Value;
                }
            }
        }
        public void bindFeeGroupddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeGroupList("Active");
            ddlFeeGroup.DataSource = dt;
            ddlFeeGroup.DataBind();
            ddlFeeGroup.DataTextField = "FeeGroupName";
            ddlFeeGroup.DataValueField = "Id";
            ddlFeeGroup.DataBind();
            ddlFeeGroup.Items.Insert(0, new ListItem("-- Select Fee Name --", "0"));
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Boolean checkedValue = false;
            Boolean checkedrefundableValue = false;
            Boolean checkedoptionalValue = false;
            Boolean checkedDiscountValue = false;
            Boolean checkedConveyanceValue = false;
            Boolean checkedfeeDisplayValue = false;
            Boolean checkedtransferHeadValue = false;
            if (CheckBox1.Checked == true)
            {
                checkedValue = true;
            }
            if (chkRefundable.Checked == true)
            {
                checkedrefundableValue = true;
            }
            if (chkoptional.Checked == true)
            {
                checkedoptionalValue = true;
            }
            if (chkdiscount.Checked == true)
            {
                checkedDiscountValue = true;
            }
            if (chkConveyance.Checked == true)
            {
                checkedConveyanceValue = true;
            }
            if (chkFeeDisplay.Checked == true)
            {
                checkedfeeDisplayValue = true;
            }
            if (chkTransferhead.Checked == true)
            {
                checkedtransferHeadValue = true;
            }
            int editFeeNameMasterId = int.Parse(Session["EditFeeNameMasterDetailId"].ToString());
            AddFeeNameMasterList feeNameList = new AddFeeNameMasterList();
            feeNameList.Id = editFeeNameMasterId;
            feeNameList.FeeName = txtFeeName.Text;
            feeNameList.RefundableFee = checkedrefundableValue;
            feeNameList.OptionalFee = checkedoptionalValue;
            feeNameList.DiscountOn = checkedDiscountValue;
            feeNameList.Conveyance = checkedConveyanceValue;
            feeNameList.FeeDisplay = checkedfeeDisplayValue;
            feeNameList.TransferHead = checkedtransferHeadValue;
            feeNameList.FeeGroupId = int.Parse(ddlFeeGroup.SelectedValue);
            feeNameList.IsActive = checkedValue;
            var result = feeBLL.UpdateFeeNameMaster(feeNameList);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Name Master updated Sucessfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }
    }
}