using iTextSharp.text.pdf;
using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
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

namespace LMS.Learner
{
    public partial class OnlinePaymentReceipt : System.Web.UI.Page
    {
        PdfDocument doc = null;
        ClientBLL clientBLL = new ClientBLL();
        AdminBLL adminBLL = new AdminBLL();
        FeeBLL feeBLL = new FeeBLL();
        DeptBLL deptBLL = new DeptBLL();
        TableRow row;
        TableCell cell1, cell2, cell3, cell4, cell5, cell6;
        string reg_no = "", institute = "", coursename = "", payingnow = "", amount = "", time = "", clientid = "", emailid = "harsh@ebizinfo.in",toemail="", clid, receiptid = "";

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
                    h1.InnerText = dt2.Rows[0]["Address"].ToString();
                    h2.InnerText = "Email : " + dt2.Rows[0]["EmailID"].ToString();
                    h3.InnerText = "Contact : " + dt2.Rows[0]["ContactNumber"].ToString();
                    Session["DatabaseName"] = dt2.Rows[0]["DatabaseName"].ToString();
                    h1institute.InnerHtml = dt2.Rows[0]["InstituteName"].ToString();
                    institute= dt2.Rows[0]["InstituteName"].ToString();
                    //setLogo
                    var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                    img_institute_logo.ImageUrl = prefixPath+"//SuperAdmin/ClientLogo/" + dt2.Rows[0]["LogoPath"].ToString();
                }
               // setlogo();
                assignpersonalvalues(tmpid);
                assignTotalFeesvalues(rect);
                bind_grid(rect);
                sendmail();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        //public void setlogo()
        //{
        //    DataTable dt = new DataTable();
        //    bol1.clientid_to_get_PG_details = clientid;
        //    dt = bll1.get_client_details(bol1);
        //    h1institute.InnerHtml = dt.Rows[0]["institutename"].ToString();
        //    img_institute_logo.ImageUrl = "http://ebizpay.in//logo/" + dt.Rows[0]["imagename"].ToString();


        //}
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
        public void assignpersonalvalues(int tmpid)
        {
            reg_no = Session["ApplicationUserId"].ToString();
            DataTable personalDetail = new DataTable();
            var logedInUserId = int.Parse(Session["ApplicationUserId"].ToString());
            personalDetail = adminBLL.GetApplicationUserById(logedInUserId);
            lbladdno.Text = Session["ApplicationUserId"].ToString();
            lblfirstname.Text = personalDetail.Rows[0]["FirstName"].ToString() + " " + personalDetail.Rows[0]["LastName"].ToString();
            lblFatherName.Text = personalDetail.Rows[0]["FatherName"].ToString();
            toemail = personalDetail.Rows[0]["EmailId"].ToString();
            DataTable dt = new DataTable();
            // int idValue = int.Parse(Session["EditLearnerInDepartmentId"].ToString());
            dt = deptBLL.GetStudentInformationDetailsByApplicationUserId();
            if (dt.Rows.Count > 0)
            {
                //foreach (DataRow dr in dt.Rows)
                //{
                //    if (Boolean.Parse(dr["IsActive"].ToString()) == true)
                //    {
                        lblcourse.Text = dt.Rows[0]["DepartmentStandardName"].ToString();
                        coursename = lblcourse.Text;
                        lblcatg.Text = dt.Rows[0]["CategoryName"].ToString();
                //    }
                //}
            }
        }
        public void assignTotalFeesvalues(int ReceiptId)
        {
            DataTable dtTotFee = new DataTable();
            dtTotFee = feeBLL.GetFeeTransactionByReceiptNumber(ReceiptId);
            if (dtTotFee.Rows.Count > 0)
            {
                for (int i = 0; i < dtTotFee.Rows.Count; i++)
                {
                    lblreceiptno.Text = dtTotFee.Rows[0]["FeeReceiptId"].ToString();
                    lblreceiptdate.Text = dtTotFee.Rows[0]["CreatedOn"].ToString();
                    lblfeesamount.Text = dtTotFee.Rows[0]["TotalFeeAmount"].ToString();
                    lblDiscount.Text = dtTotFee.Rows[0]["TotalDiscountAmount"].ToString();
                    lbltotallatefee.Text = dtTotFee.Rows[0]["FineAmount"].ToString();
                    lbltotalfees.Text = dtTotFee.Rows[0]["TotalReceivedAmount"].ToString();
                    lblnowpaid.Text = dtTotFee.Rows[0]["TotalReceivedAmount"].ToString();
                    lblamount_word.Text = dtTotFee.Rows[0]["AmountInWords"].ToString();
                    //lblusername.Text = dtTotFee.Rows[0]["UserId"].ToString();
                    amount = lblnowpaid.Text;
                }
            }
        }
        public void bind_grid(int ReceiptId)
        {
            DataTable dtTranFee = new DataTable();
            dtTranFee = feeBLL.GetFeeTransactionDetailByReceiptNumber(ReceiptId);
            GridView1.DataSource = dtTranFee;
            GridView1.DataBind();
        }
        public string createemail()
        {
            string text = @"<b>Dear Student,</b><br/><br/>
                            Payment Of " + amount + " Rupees is successull for Registration Number: " + reg_no + "" +
                            "<br/><br/><b>Institute Name: </b>" + institute + ".<br/>" +
                            "<b>Course Name: </b> " + coursename + "<br/>" +
                            "<b>Amount Paid:</b> " + amount + " Rupees.<br><br/>" +
                            "Please find the attached Receipt.<br/><br/><b>Regards<br/>" + institute + "</b>";

            return text;
        }
        public void sendmail()
        {
            string message = createemail();
          //  string updatedMessage = message.Replace("@email", emailencryptedKey);



            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            smtp.Credentials = new System.Net.NetworkCredential("Harsh@ebizinfo.in", "HarshMishra@123");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Payment Details";
            msg.Body = message;
            msg.IsBodyHtml = true;
            msg.To.Add(toemail);
            string fromaddress = "Payment Details <donotreply@oxotel.in>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }
            //emailandsms_bll bll_email = new emailandsms_bll();

            //string emailtext = "";
            //emailtext = createemail();
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter w = new HtmlTextWriter(sw);
            //divreceipt.RenderControl(w);
            //string htmlstring = sw.GetStringBuilder().ToString();
            //DateTime date = System.DateTime.Now;
            //string filename = clientid + reg_no + date.ToString("dd_mm_yy_hh_MM_ss") + ".pdf";
            //createpdf(htmlstring, filename);
            // //bll_email.sendEmail(emailtext, "Payment Details", emailid, filename, clientid);
            //if (File.Exists(Server.MapPath("~/fees_structure/receipt_pdf_files/" + filename)))
            //{
            //    try
            //    {
            //        File.Delete(Server.MapPath("~/fees_structure/receipt_pdf_files/" + filename));
            //    }
            //    catch (Exception er)
            //    {
            //    }
            //    finally
            //    {
            //        Session.Remove("db_name");
            //    }
            //}
        }

        public void createpdf(string htmlstring, string filename)
        {
            string baseUrl = "";
            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            int webPageWidth = 1024;
            int webPageHeight = 0;
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.MinPageLoadTime = 2;
            converter.Options.MaxPageLoadTime = 30;
            doc = new PdfDocument();
            try
            {
                doc = converter.ConvertHtmlString(htmlstring, baseUrl);
                doc.Save(Server.MapPath("~/fees_structure/receipt_pdf_files/" + filename));
                doc.Close();
            }
            catch (Exception er)
            {
            }
            finally { }
        }
    }
}