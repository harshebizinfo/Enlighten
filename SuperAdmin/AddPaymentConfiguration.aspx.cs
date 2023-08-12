using LMS.BasicClass;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class AddPaymentConfiguration : System.Web.UI.Page
    {
        PCBLL pCBLL = new PCBLL();
        ClientBLL clientBLL = new ClientBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindClientddl();
            }
        }
        public void bindClientddl()
        {
            DataTable dt = new DataTable();
            dt = clientBLL.GetAllClient();
            ddlClient.DataSource = dt;
            ddlClient.DataBind();
            ddlClient.DataTextField = "InstituteName";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ClientPaymentConfiguration parameter = new ClientPaymentConfiguration();
            parameter.TransactionType = txtTransactionType.Text;
            parameter.MerchantId = txtmerchantid.Text;
            parameter.PaymentPassword = txtpassword.Text;
            parameter.ClientId = ddlClient.SelectedValue.ToString();
            parameter.PaymentGateWay = txtPaymentGateway.Text;
            parameter.RequestHashKey = txtRequestHashKey.Text;
            parameter.ResponseHashKey = txtResponseHashKey.Text;
            parameter.RequestAESKey = txtRequestAESKey.Text;
            parameter.ResponseAESKey = txtResponseAESKey.Text;
            parameter.ProductId = txtProductId.Text;
            parameter.RazorKey = txtRazorKey.Text;
            parameter.RazorSecretKey = txtRazorSecretKey.Text;
            parameter.MerchantCode = txtMerchantCode.Text;
            parameter.IsKey = txtKey.Text;
            parameter.IsIv = txtIsIv.Text;
            parameter.IsActive = CheckBox1.Checked == true ? true : false;
            var result = pCBLL.AddNewClientsPaymentConfiguration(parameter);
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CancelClick();
        }
        public void CancelClick()
        {
            txtProductId.Text = "";
            txtTransactionType.Text = "";
            txtmerchantid.Text = "";
            txtpassword.Text = "";
            txtRequestHashKey.Text = "";
            txtResponseAESKey.Text = "";
            txtResponseHashKey.Text = "";
            txtRequestAESKey.Text = "";
            
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int paymentType=0;
            DataTable dt=new DataTable();
            dt = clientBLL.GetClientByClientId(ddlClient.SelectedValue.ToString());
            if(dt.Rows.Count>0)
            {
                paymentType = dt.Rows[0]["PaymentType"].ToString()==""?0:int.Parse(dt.Rows[0]["PaymentType"].ToString());
            }
            //txtPaymentGateway
            DataTable newdt=new DataTable();
            newdt = clientBLL.GetPaymentMethod();
            if(newdt.Rows.Count>0)
            {
                foreach(DataRow dr in newdt.Rows)
                {
                    if(int.Parse(dr["Id"].ToString())==paymentType)
                    {
                        txtPaymentGateway.Text = dr["PaymentType"].ToString();
                    }
                }
            }
        }
    }
}