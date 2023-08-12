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
    public partial class EditPaymentConfiguration : System.Web.UI.Page
    {
        PCBLL pCBLL = new PCBLL();
        ClientBLL clientBLL = new ClientBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClientddl();
                DataTable dt = new DataTable();
                int paymentConfigurationId = int.Parse(Session["ClientPaymentConfigurationId"].ToString());
                dt = pCBLL.GetClientsPaymentConfigurationById(paymentConfigurationId);
                if(dt.Rows.Count>0)
                {
                    txtTransactionType.Text = dt.Rows[0]["TransactionType"].ToString();
                    txtmerchantid.Text = dt.Rows[0]["MerchantId"].ToString();
                    txtpassword.Text = dt.Rows[0]["PaymentPassword"].ToString();
                    txtPaymentGateway.Text = dt.Rows[0]["PaymentGateWay"].ToString();
                    txtRequestHashKey.Text = dt.Rows[0]["RequestHashKey"].ToString();
                    txtResponseHashKey.Text = dt.Rows[0]["ResponseHashKey"].ToString();
                    txtRequestAESKey.Text = dt.Rows[0]["RequestAESKey"].ToString();
                    txtResponseAESKey.Text = dt.Rows[0]["ResponseAESKey"].ToString();
                    txtProductId.Text = dt.Rows[0]["ProductId"].ToString();
                    txtRazorKey.Text = dt.Rows[0]["RazorKey"].ToString();
                    txtRazorSecretKey.Text = dt.Rows[0]["RazorSecretKey"].ToString();
                    txtMerchantCode.Text = dt.Rows[0]["MerchantCode"].ToString();
                    txtKey.Text = dt.Rows[0]["IsKey"].ToString();
                    txtIsIv.Text = dt.Rows[0]["IsIv"].ToString();
                    CheckBox1.Checked = Boolean.Parse(dt.Rows[0]["IsActive"].ToString());
                    string clientId = dt.Rows[0]["ClientId"].ToString();
                    DataTable clientdt = new DataTable();
                    clientdt = clientBLL.GetAllClient();
                    var instituteName = "";
                    int paymentType=0;
                    foreach (DataRow dr in clientdt.Rows)
                    {
                        if(clientId==dr["ClientID"].ToString())
                        {
                            instituteName = dr["InstituteName"].ToString();
                            paymentType = dr["PaymentType"].ToString()==""?0: int.Parse(dr["PaymentType"].ToString());
                        }
                    }

                    ddlClient.SelectedValue = ddlClient.Items.FindByText(instituteName).Value;

                    DataTable newdt=new DataTable();
                    newdt = clientBLL.GetPaymentMethod();
                    if (newdt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in newdt.Rows)
                        {
                            if (int.Parse(dr["Id"].ToString()) == paymentType)
                            {
                                txtPaymentGateway.Text = dr["PaymentType"].ToString();
                            }
                        }
                    }
                }
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
            int paymentConfigurationId = int.Parse(Session["ClientPaymentConfigurationId"].ToString());
            ClientPaymentConfiguration parameter = new ClientPaymentConfiguration();
            parameter.Id = paymentConfigurationId;
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
            var result = pCBLL.UpdateClientsPaymentConfiguration(parameter);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration updated Successfully')", true);
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
    }
}