using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class AddService : System.Web.UI.Page
    {
        ClientBLL clientBLL = new ClientBLL();
        ServiceBLL serviceBLL = new ServiceBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            ddlClient.DataTextField = "ClientID";
            ddlClient.DataValueField = "Id";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("ServiceFile/");
            var extension = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (extension == ".json")
            {

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                var clientId = ddlClient.SelectedItem.ToString();
                var newFile = clientId + TranTrackid;
                string clientFolderPath = Server.MapPath("ServiceFile/" + clientId + "/");
                if (!Directory.Exists(clientFolderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(clientFolderPath);
                }

                var completeFileName = clientFolderPath + newFile + extension;
                // var filePath = @"E:\HARSH\GoogleSessionAPI\New folder (3)\Youtube\YoutubeVideoUpload\bin\Debug\abc.mp4";
                FileUpload1.SaveAs(completeFileName);
                AddServiceAccountDetail addServiceAccountFile = new AddServiceAccountDetail();
                addServiceAccountFile.ServiceAccountEmail = txtserviceAccountEmail.Text;
                addServiceAccountFile.UserEmail = txtUserEmail.Text;
                addServiceAccountFile.PrivateKey = txtPrivateKey.Text;
                addServiceAccountFile.ClientId = int.Parse(ddlClient.SelectedValue);
                addServiceAccountFile.IsActive = CheckBox1.Checked == true ? true : false;
                addServiceAccountFile.FilePath = completeFileName;
                var result = serviceBLL.AddServiceAccountDetail(addServiceAccountFile);
                if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Service file added successfully.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Something went wrong..');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Select Only .json extension file.');", true);
            }
        }
    }
}