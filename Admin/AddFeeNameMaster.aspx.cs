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
    public partial class AddFeeNameMaster : System.Web.UI.Page
    {
        FeeBLL feeBLL = new FeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFeeGroupddl();
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
            AddFeeNameMasterList feeNameList = new AddFeeNameMasterList();
            feeNameList.FeeName = txtFeeName.Text;
            feeNameList.RefundableFee = checkedrefundableValue;
            feeNameList.OptionalFee = checkedoptionalValue;
            feeNameList.DiscountOn = checkedDiscountValue;
            feeNameList.Conveyance = checkedConveyanceValue;
            feeNameList.FeeDisplay = checkedfeeDisplayValue;
            feeNameList.TransferHead = checkedtransferHeadValue;
            feeNameList.FeeGroupId = int.Parse(ddlFeeGroup.SelectedValue);
            feeNameList.IsActive = checkedValue;
            var result = feeBLL.AddFeeNameMaster(feeNameList);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Name Master added Sucessfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            txtFeeName.Text = "";
            CheckBox1.Checked = false;
            chkRefundable.Checked = false;
            chkoptional.Checked = false;
            chkdiscount.Checked = false;
            chkConveyance.Checked = false;
            chkFeeDisplay.Checked = false;
            chkTransferhead.Checked = false;
        }
    }
}