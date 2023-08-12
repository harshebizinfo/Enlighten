using iTextSharp.text.pdf;
using LMS.Admin.ClassFile;
using LMS.Admin.FeeClassFile;
using LMS.SuperAdmin.ClientClassFile;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfDocument = SelectPdf.PdfDocument;

namespace LMS.Common
{
    public partial class SubscriptionPaymentReceipt : System.Web.UI.Page
    {
        PdfDocument doc = null;
        ClientBLL clientBLL = new ClientBLL();
        //AdminBLL adminBLL = new AdminBLL();
        FeeBLL feeBLL = new FeeBLL();
        TableRow row;
        TableCell cell1, cell2, cell3, cell4, cell5, cell6;
        string reg_no = "", institute = "", coursename = "", payingnow = "", amount = "", time = "", clientid = "", emailid = "harsh@ebizinfo.in", toemail = "", clid, receiptid = "";

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Common/Login.aspx");
        }

        int courseid = 0, pagetype = 0; int setflagforpgimage, academicyearid = 0, monthid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string q = "", r = "", c = "", m = "", t = "", a = "", mon = "";
                try
                {
                    q = Request.QueryString["q"].ToString();
                    q = Decryptdata(q);
                    string[] info = q.Split('^');
                    r = info[0];
                    c = info[1];
                    receiptid = info[2];
                }
                catch (Exception er)
                {
                }
                int tmpid = Convert.ToInt32(r);
                int rect = Convert.ToInt32(receiptid);
                clientid = c;
                DataTable dt2 = new DataTable();
                dt2 = clientBLL.GetClientByClientId(clientid);
                if (dt2.Rows.Count > 0)
                {
                    //h1.InnerText = "";
                    //h2.InnerText = "Email : " + "enlight@ebiz.com";
                    //h3.InnerText = "Contact : " + "9876543212";
                    //Session["DatabaseName"] = dt2.Rows[0]["DatabaseName"].ToString();
                    //h1institute.InnerHtml = "Enlight";
                    //lblInstituteName.Text= dt2.Rows[0]["InstituteName"].ToString();
                    //lblEmail.Text = dt2.Rows[0]["EmailID"].ToString();
                    //lblContact.Text= dt2.Rows[0]["ContactNumber"].ToString();
                    //lblAddress.Text= dt2.Rows[0]["Address"].ToString();
                    //institute = dt2.Rows[0]["InstituteName"].ToString();
                    ////setLogo
                     
                    //     var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                    //img_institute_logo.ImageUrl = "../images/enlight.png";//prefixPath + "//SuperAdmin/ClientLogo/" + dt2.Rows[0]["LogoPath"].ToString();
                }
                // setlogo();
                //assignpersonalvalues(tmpid);
                //assignTotalFeesvalues(rect);
                bind_grid(rect);
                //sendmail();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        public string Decryptdata(string str)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(str);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        public void bind_grid(int ReceiptId)
        {
            string mobileAmount = "", amcAmount = "", OnlinePaymentAmount = "", SMSAmount = "", OnlineClassesAmount = "", totalPaymentAmount = "";
            Boolean isMobileIncluded = false, isAMC = false, isOnlinePaymentIncluded = false, isSMSIncluded = false, isOnlineClasses = false;
            DataTable dtTranFee = new DataTable();
            dtTranFee = feeBLL.GetSubscriptionPaymentById(ReceiptId);
            if (dtTranFee.Rows.Count > 0)
            {
                isMobileIncluded = Boolean.Parse(dtTranFee.Rows[0]["IsAndroidIncluded"].ToString());
                mobileAmount = dtTranFee.Rows[0]["AndroidAmount"].ToString();
                isAMC = Boolean.Parse(dtTranFee.Rows[0]["IsAMCIncluded"].ToString());
                amcAmount = dtTranFee.Rows[0]["AMCAmount"].ToString();
                isOnlinePaymentIncluded = Boolean.Parse(dtTranFee.Rows[0]["IsOnlinePaymentIncluded"].ToString());
                OnlinePaymentAmount = dtTranFee.Rows[0]["OnlinePaymentAmount"].ToString();
                isSMSIncluded = Boolean.Parse(dtTranFee.Rows[0]["IsSMSIncluded"].ToString());
                SMSAmount = dtTranFee.Rows[0]["SMSAmount"].ToString();
                isOnlineClasses = Boolean.Parse(dtTranFee.Rows[0]["IsOnlineClassesIncluded"].ToString());
                OnlineClassesAmount = dtTranFee.Rows[0]["OnlineClassesAmount"].ToString();
                totalPaymentAmount = dtTranFee.Rows[0]["TotalPaidAmount"].ToString();
            }

            System.Data.DataTable appliedFfilterListdt = new System.Data.DataTable();
            appliedFfilterListdt.Columns.Add("TypeName", typeof(string));
            appliedFfilterListdt.Columns.Add("IsIncluded", typeof(string));
            appliedFfilterListdt.Columns.Add("Amount", typeof(string));

            DataRow paymentModeDataRow = appliedFfilterListdt.NewRow();
            paymentModeDataRow["TypeName"] = "Desktop";
            paymentModeDataRow["IsIncluded"] = "True";
            paymentModeDataRow["Amount"] = "0";
            appliedFfilterListdt.Rows.Add(paymentModeDataRow);

            DataRow paymentModeDataRow1 = appliedFfilterListdt.NewRow();
            paymentModeDataRow1["TypeName"] = "Mobile";
            paymentModeDataRow1["IsIncluded"] = isMobileIncluded.ToString();
            paymentModeDataRow1["Amount"] = mobileAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow1);

            DataRow paymentModeDataRow2 = appliedFfilterListdt.NewRow();
            paymentModeDataRow2["TypeName"] = "AMC";
            paymentModeDataRow2["IsIncluded"] = isAMC.ToString();
            paymentModeDataRow2["Amount"] = amcAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow2);

            DataRow paymentModeDataRow3 = appliedFfilterListdt.NewRow();
            paymentModeDataRow3["TypeName"] = "Online Payment";
            paymentModeDataRow3["IsIncluded"] = isOnlinePaymentIncluded.ToString();
            paymentModeDataRow3["Amount"] = OnlinePaymentAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow3);

            DataRow paymentModeDataRow4 = appliedFfilterListdt.NewRow();
            paymentModeDataRow4["TypeName"] = "SMS";
            paymentModeDataRow4["IsIncluded"] = isSMSIncluded.ToString();
            paymentModeDataRow4["Amount"] = SMSAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow4);

            DataRow paymentModeDataRow5 = appliedFfilterListdt.NewRow();
            paymentModeDataRow5["TypeName"] = "Online Classes";
            paymentModeDataRow5["IsIncluded"] = isOnlineClasses.ToString();
            paymentModeDataRow5["Amount"] = OnlineClassesAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow5);

            DataRow paymentModeDataRow6 = appliedFfilterListdt.NewRow();
            paymentModeDataRow6["TypeName"] = "Paying Amount";
            paymentModeDataRow6["IsIncluded"] = "";
            paymentModeDataRow6["Amount"] = totalPaymentAmount;
            appliedFfilterListdt.Rows.Add(paymentModeDataRow6);

            GridView1.DataSource = appliedFfilterListdt;
            GridView1.DataBind();

        }
        //public string createemail()
        //{
        //    string text = @"<b>Dear Student,</b><br/><br/>
        //                    Payment Of " + amount + " Rupees is successull for Registration Number: " + reg_no + "" +
        //                    "<br/><br/><b>Institute Name: </b>" + institute + ".<br/>" +
        //                    "<b>Course Name: </b> " + coursename + "<br/>" +
        //                    "<b>Amount Paid:</b> " + amount + " Rupees.<br><br/>" +
        //                    "Please find the attached Receipt.<br/><br/><b>Regards<br/>" + institute + "</b>";

        //    return text;
        //}
        //public void sendmail()
        //{
        //    string message = createemail();
        //    //  string updatedMessage = message.Replace("@email", emailencryptedKey);



        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;

        //    smtp.Credentials = new System.Net.NetworkCredential("Harsh@ebizinfo.in", "HarshMishra@123");
        //    smtp.EnableSsl = true;
        //    MailMessage msg = new MailMessage();
        //    msg.Subject = "Payment Details";
        //    msg.Body = message;
        //    msg.IsBodyHtml = true;
        //    msg.To.Add(toemail);
        //    string fromaddress = "Payment Details <donotreply@oxotel.in>";
        //    msg.From = new MailAddress(fromaddress);
        //    try
        //    {
        //        smtp.Send(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
        //    }
        //}
    }
}