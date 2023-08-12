using LMS.Admin.ClassFile;
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
    public partial class EditTrainee : System.Web.UI.Page
    {
        AdminBLL adminBLL = new AdminBLL();
        ApplicationUser addNewUser = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var editApplicationUserLearnerId = Session["EditTraineeApplicationUserId"].ToString();
                DataTable dt = new DataTable();
                dt = adminBLL.GetApplicationUserById(int.Parse(editApplicationUserLearnerId));
                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                    txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailId"].ToString();
                    txtContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();
                    txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    txtFatherContactNumber.Text = dt.Rows[0]["FatherContactNumber"].ToString();
                    txtpresentAddress.Text = dt.Rows[0]["PresentAddess"].ToString();
                    txtPresentCity.Text = dt.Rows[0]["PresentCity"].ToString();
                    txtPresentState.Text = dt.Rows[0]["PresentState"].ToString();
                    txtpermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                    txtpermanentCity.Text = dt.Rows[0]["PermanentCity"].ToString();
                    txtPermanentState.Text = dt.Rows[0]["PermanentState"].ToString();

                }
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {

            AdminBLL adminbll = new AdminBLL();
            try
            {
                var editApplicationUserLearnerId = Session["EditTraineeApplicationUserId"].ToString();
                addNewUser.ApplicationUserId = int.Parse(editApplicationUserLearnerId);
                addNewUser.FirstName = txtFirstName.Text;
                addNewUser.LastName = txtLastName.Text;
                addNewUser.EmailId = txtEmail.Text;
                addNewUser.FatherName = txtFatherName.Text;
                addNewUser.FatherContactNumber = txtFatherContactNumber.Text;
                addNewUser.PresentAddess = txtpresentAddress.Text;
                addNewUser.PresentCity = txtPresentCity.Text;
                addNewUser.PresentState = txtPresentState.Text;
                addNewUser.PermanentAddress = txtpermanentAddress.Text;
                addNewUser.PermanentCity = txtpermanentCity.Text;
                addNewUser.PermanentState = txtPermanentState.Text;
                addNewUser.ContactNumber = txtContactNumber.Text;
                var result = adminbll.UpdatedApplicationUserById(addNewUser);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Trainee Updated Sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email is already In use')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}