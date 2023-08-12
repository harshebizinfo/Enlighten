using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class VerifyClient : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClientDetail objbol = new ClientDetail();
            objbol.ClientID = txtUserName.Text.Trim();
            getClientInfoFromAdminDatabase(objbol);
        }
        public void getClientInfoFromAdminDatabase(ClientDetail objbol)
        {
            BLL objbll = new BLL();


            objbll = new BLL();
            try
            {
                dt = new DataTable();
                dt = objbll.GetClientinfo(objbol);

                if (dt.Rows.Count > 0)
                {
                    if (Session["InstituteName"] != null || Session["LogoPath"] != null || Session["DatabaseName"] != null || Session["ClientID"] != null || Session["EmailID"] != null)
                    {
                        Session.Abandon();
                    }
                    Session["InstituteName"] = dt.Rows[0]["InstituteName"].ToString();
                    Session["LogoPath"] = dt.Rows[0]["LogoPath"].ToString();
                    Session["DatabaseName"] = dt.Rows[0]["DatabaseName"].ToString();
                    Session["ClientID"] = dt.Rows[0]["ClientID"].ToString();
                    Session["EmailID"] = dt.Rows[0]["EmailID"].ToString();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered ClientID is InValid')", true);
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