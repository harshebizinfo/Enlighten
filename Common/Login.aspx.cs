using LMS.Common.ClassFile;
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
    public partial class Login : System.Web.UI.Page
    {
        DataTable dt;
        ClientBLL clientBLL = new ClientBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();


            objbll = new BLL();
            try
            {
                dt = new DataTable();
                dt = objbll.UserLogin(txtUserName.Text);

                if (dt.Rows.Count > 0)
                {
                    //if (Session["InstituteName"] != null || Session["LogoPath"] != null || Session["DatabaseName"] != null || Session["ClientID"] != null || Session["EmailID"] != null)
                    //{
                    //    Session.Abandon();
                    //}
                    if (int.Parse(dt.Rows[0]["NumberOfAttempts"].ToString()) < 40)
                    {
                        var password = AesOperation.DecryptString(dt.Rows[0]["PasswordSaltKey"].ToString(), dt.Rows[0]["PasswordHashKey"].ToString());
                        if (txtPassword.Text == password)
                        {
                            DataTable dtValue = new DataTable();
                            dtValue = objbll.GetGroupName(txtUserName.Text);
                            if (dt.Rows.Count > 0)
                            {
                               
                                var role = dtValue.Rows[0]["GroupName"].ToString();
                               //.Select(r => r.Field<string>("GroupName"));
                               if(role== "SuperAdmin")
                                {
                                    Session["ApplicationUserId"] = dt.Rows[0]["ApplicationUserId"].ToString();
                                    Session["FirstAndLastName"] = dt.Rows[0]["FirstName"].ToString() +" "+ dt.Rows[0]["LastName"].ToString();
                                    Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                                    Session["LogedInUserRole"] = role;
                                    Response.Redirect("../SuperAdmin/Dashboard.aspx");
                                }
                                if(role=="Admin")
                                {
                                    DataTable clientdt = new DataTable();
                                    var clientId = dt.Rows[0]["ClientID"].ToString();
                                    clientdt = clientBLL.GetClientByClientId(clientId);
                                    //check subscription status :
                                    string renewaldate;
                                    if (!string.IsNullOrWhiteSpace(clientdt.Rows[0]["RenewalDate"].ToString()))
                                    {
                                        // renewaldate = Convert.ToDateTime(clientdt.Rows[0]["RenewalDate"]).ToString("MM/dd/yyyy HH:mm:ss"); ;
                                        renewaldate = clientdt.Rows[0]["RenewalDate"].ToString();
                                        string dayscount = (Convert.ToDateTime(renewaldate) - DateTime.Today).TotalDays.ToString();
                                        double newdays = double.Parse(dayscount);
                                        if (newdays > 0)
                                        {
                                            adminRedirect(dt, clientdt, role);
                                        }
                                        else
                                        {
                                            clientBLL.EditClientSubscription(clientId);
                                            adminRedirect(dt, clientdt, role);
                                        }
                                    }
                                    else
                                    {
                                        adminRedirect(dt, clientdt, role);
                                    }
 
                                }
                                else if(role == "Teacher")
                                {
                                    DataTable clientdt = new DataTable();
                                    var clientId = dt.Rows[0]["ClientID"].ToString();
                                    clientdt = clientBLL.GetClientByClientId(clientId);
                                    //check subscription status :
                                    DateTime renewaldate;
                                    if (!string.IsNullOrWhiteSpace(clientdt.Rows[0]["RenewalDate"].ToString()))
                                    {
                                        renewaldate = Convert.ToDateTime(clientdt.Rows[0]["RenewalDate"].ToString());
                                        string dayscount = (renewaldate - DateTime.Now).TotalDays.ToString();
                                        double newdayscount = double.Parse(dayscount);
                                        if (newdayscount > 0)
                                        {
                                            teacherRedirect(dt, clientdt, role);
                                        }
                                        else
                                        {
                                            clientBLL.EditClientSubscription(clientId);
                                            teacherRedirect(dt, clientdt, role);
                                        }
                                    }
                                    else
                                    {
                                        teacherRedirect(dt, clientdt, role);
                                    }
                                }
                                else
                                {
                                    DataTable clientdt = new DataTable();
                                    var clientId = dt.Rows[0]["ClientID"].ToString();
                                    clientdt = clientBLL.GetClientByClientId(clientId);
                                    //check subscription status :
                                    DateTime renewaldate;
                                    if (!string.IsNullOrWhiteSpace(clientdt.Rows[0]["RenewalDate"].ToString()))
                                    {
                                        renewaldate = Convert.ToDateTime(clientdt.Rows[0]["RenewalDate"].ToString());
                                        string dayscount = (renewaldate - DateTime.Now).TotalDays.ToString();
                                        double newdayscount = double.Parse(dayscount);
                                        if (newdayscount > 0)
                                        {
                                            studentRedirect(dt, clientdt, role);
                                        }
                                        else
                                        {
                                            clientBLL.EditClientSubscription(clientId);
                                            studentRedirect(dt, clientdt, role);
                                        }
                                    }
                                    else
                                    {
                                        studentRedirect(dt, clientdt, role);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Role has not been assigned')", true);
                            }
                        }
                        else
                        {
                            var NumberOfAttempts = int.Parse(dt.Rows[0]["NumberOfAttempts"].ToString());
                            var newNumberOfAttempts = NumberOfAttempts + 1;
                            
                            var dtnoOfAttempts = objbll.SetNumberOfAttempts(txtUserName.Text, newNumberOfAttempts);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credential')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Account is Deactivated contact administrator to activate')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credential')", true);
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
        public void adminRedirect(DataTable dt, DataTable clientdt,string role)
        {
            Boolean isGoogleSubscription = Boolean.Parse(clientdt.Rows[0]["IsOnlineClassesIncluded"].ToString());
            Session["IsGoogleSubscription"] = isGoogleSubscription;
            Session["InstituteName"] = dt.Rows[0]["InstituteName"].ToString();
            Session["FirstAndLastName"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            Session["LogoPath"] = dt.Rows[0]["LogoPath"].ToString();
            Session["DatabaseName"] = dt.Rows[0]["DatabaseName"].ToString();
            Session["ClientID"] = dt.Rows[0]["ClientID"].ToString();
            Session["ApplicationUserId"] = dt.Rows[0]["ApplicationUserId"].ToString();
            Session["UserName"] = dt.Rows[0]["UserName"].ToString();
            Session["ClientName"] = dt.Rows[0]["ClientName"].ToString();
            Session["LogedInUserRole"] = role;
            Response.Redirect("../Admin/Dashboard.aspx");
        }
        public void teacherRedirect(DataTable dt,DataTable clientdt,string role)
        {
            Boolean isGoogleSubscription = Boolean.Parse(clientdt.Rows[0]["IsOnlineClassesIncluded"].ToString());
            Session["IsGoogleSubscription"] = isGoogleSubscription;
            Session["DatabaseName"] = dt.Rows[0]["DatabaseName"].ToString();
            Session["FirstAndLastName"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            Session["ClientID"] = dt.Rows[0]["ClientID"].ToString();
            Session["ApplicationUserId"] = dt.Rows[0]["ApplicationUserId"].ToString();
            Session["UserName"] = dt.Rows[0]["UserName"].ToString();
            Session["ClientName"] = dt.Rows[0]["ClientName"].ToString();
            Session["LogedInUserRole"] = role;
            Response.Redirect("../Trainee/Dashboard.aspx");
        }
        public void studentRedirect(DataTable dt,DataTable clientdt, string role)
        {
            Boolean isGoogleSubscription = Boolean.Parse(clientdt.Rows[0]["IsOnlineClassesIncluded"].ToString());
            Session["IsGoogleSubscription"] = isGoogleSubscription;
            Session["DatabaseName"] = dt.Rows[0]["DatabaseName"].ToString();
            Session["FirstAndLastName"] = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
            Session["ClientID"] = dt.Rows[0]["ClientID"].ToString();
            Session["ApplicationUserId"] = dt.Rows[0]["ApplicationUserId"].ToString();
            Session["UserName"] = dt.Rows[0]["UserName"].ToString();
            Session["ClientName"] = dt.Rows[0]["ClientName"].ToString();
            Session["LogedInUserRole"] = role;
            Response.Redirect("../Learner/Dashboard.aspx");
        }
    }
}