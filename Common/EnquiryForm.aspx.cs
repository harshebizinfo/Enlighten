using LMS.Common.EnquiryClassFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class EnquiryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EnquiryBLL objbll = new EnquiryBLL();


            objbll = new EnquiryBLL();
            try
            {

                    var result = objbll.RequestEnquiry(txtFirstName.Text,txtLastName.Text,txtEmailid.Text,txtContactNumber.Text,txtAddress.Text);
                    if (result > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data saved Sucessfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                    }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objbll = null;
            }
        }
    }
}