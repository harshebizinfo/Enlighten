using LMS.SuperAdmin.ClientClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        private static Random random = new Random();
        DataTable dt;
        ClientBLL ClientBLL = new ClientBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        //AddUser addNewUser = new AddUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int uploadfile()
        {
            int upload = 0;
            string filename = FileUpload1.FileName;
            string extension = System.IO.Path.GetExtension(filename);
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
            {
                //filename = filename.Substring(0, 8);
                filename = string.Concat(filename.Split(' '));
                string n = string.Format("{0:yyyy-MM-dd_hh-mm-ss}_{1}", DateTime.Now,"") + extension;
                string fname = Server.MapPath("~/SuperAdmin/ClientLogo/" + n);
                FileUpload1.SaveAs(fname);
                Session["logopathvalue"] = n;
                upload = 1;
            }
            return upload;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles == true)
            {
                if (uploadfile() != 0)
                {
                    AddNewClientDetail addClient = new AddNewClientDetail();
                    addClient.ClientName = txtFirstName.Text;
                    addClient.ContactNumber = txtContactNumber.Text;
                    addClient.EmailId = txtEmailid.Text;
                    addClient.InstituteName = txtLastName.Text;
                    addClient.Address = txtpermanentAddress.Text;

                    addClient.LogoPath = Session["logopathvalue"].ToString();//"ClientLogo/" + txtClientName.Text + "/" + TranTrackid + extension+"";
                    var result = ClientBLL.AddNewClient(addClient);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Client added Successfully.');", true);
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
    }
}