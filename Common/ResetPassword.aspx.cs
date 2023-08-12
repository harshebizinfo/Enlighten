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
    public partial class ResetPassword : System.Web.UI.Page
    {
        private static Random random = new Random();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();


            objbll = new BLL();
            try
            {
                dt = new DataTable();
                dt = objbll.UserLogin("Harsh9920mishra@gmail.com");//Session["UserName"].Tostring()

                if (dt.Rows.Count > 0)
                {
                    var oldPassword = AesOperation.DecryptString(dt.Rows[0]["PasswordSaltKey"].ToString(), dt.Rows[0]["PasswordHashKey"].ToString());
                    if (txtOldPassword.Text.Trim() == oldPassword)
                    {
                        if (oldPassword != txtNewPassword.Text)
                        {
                            if (txtNewPassword.Text == txtConNewPassword.Text)
                            {
                               // var encryptedKey = "";
                                dt = new DataTable();
                                // dt = objbll.GetClientinfo(encryptedKey);
                                var encryptedSaltKey = genrate_random_no();
                                var encryptedString = AesOperation.EncryptString(encryptedSaltKey, txtNewPassword.Text);
                                // var password = AesOperation.DecryptString(encryptedSaltKey, encryptedString);
                                var result = objbll.SetUserPassword("Harsh@ebizinfo.in", encryptedSaltKey, encryptedString);
                                if (result > 0)
                                {
                                    Response.Redirect("Login.aspx");
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password Set Sucessfully')", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('new password and confirm new password is not similar')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('old and new password should not similar')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Old Password is Invalid')", true);
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
        public string genrate_random_no()
        {
            BLL objbll = new BLL();
            objbll = new BLL();
            bool condition;
            var c = "";

            c = RandomString();
            var tendantno = c.ToString();
            condition = objbll.VerifySaltKey(tendantno);

            while (condition == true)
            {
                c = RandomString();
                var newTendantno = c.ToString();
                var values = objbll.VerifySaltKey(newTendantno);
                if (!values)
                {
                    break;
                }
            }
            return (c).ToString();
        }
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789&%*^$!";
            return new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}