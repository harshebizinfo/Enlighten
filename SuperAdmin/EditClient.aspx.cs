﻿using LMS.SuperAdmin.ClientClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class EditClient : System.Web.UI.Page
    {
        ClientBLL ClientBLL = new ClientBLL();

        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPaymentModeddl();
                string newClientId = Session["NewClientId"].ToString();
                DataTable dt = new DataTable();
                dt = ClientBLL.GetClientByClientId(newClientId);
                if (dt.Rows.Count > 0)
                {
                    txtClientName.Text = dt.Rows[0]["ClientName"].ToString();
                    txtClientEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    txtContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();
                    txtInstituteName.Text = dt.Rows[0]["InstituteName"].ToString();
                    txtpermanentAddress.Text = dt.Rows[0]["Address"].ToString();
                    CheckBox1.Checked = Boolean.Parse(dt.Rows[0]["IsGoogleSubscription"].ToString());
                    Image1.ImageUrl = "../SuperAdmin/ClientLogo/" + dt.Rows[0]["LogoPath"].ToString();
                    string myValue=dt.Rows[0]["PaymentType"].ToString();
                    ddlClient.SelectedValue = myValue==""?"0":myValue.ToString();
                }
                
            }
        }
        public void bindPaymentModeddl()
        {
            DataTable dt = new DataTable();
            dt = ClientBLL.GetPaymentMethod();
            ddlClient.DataSource = dt;
            ddlClient.DataBind();
            ddlClient.DataTextField = "PaymentType";
            ddlClient.DataValueField = "Id";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public int uploadfile()
        {
            int upload = 0;
            string filename = FileUpload1.FileName;
            string extension = System.IO.Path.GetExtension(filename);
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
            {
                filename = filename.Substring(0, 8);
                filename = string.Concat(filename.Split(' '));
                string n = string.Format("{0:yyyy-MM-dd_hh-mm-ss}_{1}", DateTime.Now, filename) + extension;
                string fname = Server.MapPath("~/SuperAdmin/ClientLogo/" + n);
                FileUpload1.SaveAs(fname);
                Session["logopathvalue"] = n;
                upload = 1;
            }
            return upload;
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles == true)
            {
                if (uploadfile() != 0)
                {
                    AddNewClientDetail addClient = new AddNewClientDetail();
                    string newClientId = Session["NewClientId"].ToString();
                    addClient.ClientId = newClientId;
                    addClient.ClientName = txtClientName.Text;
                    addClient.ContactNumber = txtContactNumber.Text;
                    addClient.EmailId = txtClientEmail.Text;
                    addClient.InstituteName = txtInstituteName.Text;
                    addClient.Address = txtpermanentAddress.Text;
                    addClient.PaymentTypeId = int.Parse(ddlClient.SelectedValue.ToString());
                    addClient.IsGoogleSubscription = CheckBox1.Checked == true ? true : false;


                    addClient.LogoPath = Session["logopathvalue"].ToString();//"ClientLogo/" + txtClientName.Text + "/" + TranTrackid + extension+"";
                    var result = ClientBLL.EditNewClient(addClient);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Client edf Successfully.');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Something went wrong.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please choose image with correct format.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please choose proper image.');", true);
            }
        }
        protected void Button10_Click(object sender, EventArgs e)
        {

        }
    }
}