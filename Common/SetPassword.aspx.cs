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
    public partial class SetPassword : System.Web.UI.Page
    {
        private static Random random = new Random();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtConNewPassword.Text)
            {
                var encryptedemail = Request.QueryString["e"].Trim();
                var encode = encryptedemail.Replace(" ", "+");
                var email = AesOperation.DecryptString("pAudS4S3KD0idn#@!Qh5kSje35*kE4AS", encode);
                BLL objbll = new BLL();


                objbll = new BLL();
                try
                {
                    DataTable dtcheckUserExisting = new DataTable();
                    dtcheckUserExisting = objbll.UserLogin(email);
                    if (dtcheckUserExisting.Rows.Count > 0)
                    {
                       // var encryptedKey = "";
                        dt = new DataTable();
                        // dt = objbll.GetClientinfo(encryptedKey);
                        var encryptedSaltKey = genrate_random_no();
                        var encryptedString = AesOperation.EncryptString(encryptedSaltKey, txtNewPassword.Text);
                        // var password = AesOperation.DecryptString(encryptedSaltKey, encryptedString);
                        var result = objbll.SetUserPassword(email, encryptedSaltKey, encryptedString);
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
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry you have not registered')", true);
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
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password and confirm password is not similar')", true);
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