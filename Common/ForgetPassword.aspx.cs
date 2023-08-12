using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private static Random random = new Random();
        //DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();


            objbll = new BLL();
            try
            {

                DataTable dtcheckUserExisting = new DataTable();
                dtcheckUserExisting = objbll.UserLogin(txtUserName.Text);
                if (dtcheckUserExisting.Rows.Count > 0)
                {
                    var emailencryptedKey = AesOperation.EncryptString("pAudS4S3KD0idn#@!Qh5kSje35*kE4AS", txtUserName.Text);
                    var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                    string message = prefixPath + "/Common/SetPassword.aspx?e=@email";
                    string updatedMessage = message.Replace("@email", emailencryptedKey);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("Harsh@ebizinfo.in", "HarshMishra@123");
                    smtp.EnableSsl = true;
                    MailMessage msg = new MailMessage();
                    msg.Subject = "User Added Successfully";
                    msg.Body = updatedMessage;
                    msg.IsBodyHtml = true;
                    msg.To.Add(txtUserName.Text.Trim());
                    string fromaddress = "PG <donotreply@oxotel.in>";
                    msg.From = new MailAddress(fromaddress);
                    try
                    {
                        smtp.Send(msg);
                    }
                    catch
                    {
                        throw;
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Mail Sent on registered EmailId')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Provide registered Mail Id')", true);
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