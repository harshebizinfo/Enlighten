using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Learner.BasicClass;
using LMS.Learner.PaymentCLassFile;
using LMS.SuperAdmin.ClientClassFile;
using LMS.Trainee.ExamClessFile;
using LMS.Trainee.QuestionClassFile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class PayExamFee : System.Web.UI.Page
    {
        ClientBLL clientBLL = new ClientBLL();
        TempPaymentDetailField tpdf = new TempPaymentDetailField();
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        ExamBLL exambll = new ExamBLL();
        QuestionBLL questionbll = new QuestionBLL();
        PaymentBLL paymentbll = new PaymentBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        static string feetypes = "'',";
        string t1 = "", t2 = "", t3 = "", t4 = "", t5 = "", t6 = "", t7 = "", t8 = "", t9 = "", t10 = "", t11 = "", t12 = "", t13 = "", t14 = "",
            t15 = "", t16 = "", t17 = "", t18 = "", t19 = "", t20 = "", t21 = "", t22 = "", t23 = "", t24 = "", t25 = "";
        string IspreviousBalanceFee="";
        DateTime now = DateTime.Now;
        public static string optionValue = "";
        string Encryptval;
        string Decryptval;
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable clientdt = new DataTable();
                var clientId = Session["ClientID"].ToString();
                clientdt = clientBLL.GetClientByClientId(clientId);
                Boolean isPaymentSubscription = Boolean.Parse(clientdt.Rows[0]["IsOnlinePaymentIncluded"].ToString());
                ViewState["IsGoogleSubscription"] = isPaymentSubscription;
                if (isPaymentSubscription == true)
                {
                    DataTable departmentId = new DataTable();
                    departmentId = deptbll.GetStudentInformationListByApplicationUserId();
                    int classId = 0;
                    int academicYearId = 0;
                    string admissionNumber = "";
                    if (departmentId.Rows.Count > 0)
                    {
                        classId = int.Parse(departmentId.Rows[0]["ClassId"].ToString());
                        academicYearId = int.Parse(departmentId.Rows[0]["AcademicYearId"].ToString());
                        admissionNumber = departmentId.Rows[0]["AdmissionNumber"].ToString();
                    }
                    ViewState["StudentDepartmentId"] = classId;
                    Session["AdmissionNumber"] = admissionNumber;
                    Session["AcademicYearId"] = academicYearId;
                    DataTable feeMonthdt = new DataTable();
                    feeMonthdt = paymentbll.GetPaymentData(classId, academicYearId, admissionNumber);
                    GridView1.DataSource = feeMonthdt;
                    GridView1.DataBind();

                    DataTable previousdt = new DataTable();
                    if (previousdt.Columns.Count == 0)
                    {
                        previousdt.Columns.Add("id", typeof(int));
                        previousdt.Columns.Add("FeeType", typeof(string));
                        previousdt.Columns.Add("status", typeof(string));
                    }
                    DataTable previousBalance = new DataTable();
                    previousBalance = paymentbll.CheckPreviousBalanceExists();
                    if (previousBalance.Rows.Count > 0)
                    {
                        DataRow dr = previousdt.NewRow();
                        dr["id"] = 10101;
                        dr["FeeType"] = "Previous Balance Fee";
                        dr["status"] = "Not Deposited";
                        previousdt.Rows.Add(dr);
                        GridView2.DataSource = previousdt;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView2.Visible = false;
                    }
                }
                else
                {
                    btngo.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Subscribe for Online Payment.');", true);
                }
                //bindCourseddl();
                //bindExamddl();
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            int count = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox checkfield = (CheckBox)row.FindControl("checkfield2");
                if (checkfield.Checked == true)
                {
                    count = count + 1;
                    Label txt = (Label)row.FindControl("lblcontrolname1");
                    if (row.RowIndex == 0) { t1 = txt.Text; }
                    else if (row.RowIndex == 1) { t2 = txt.Text; }
                    else if (row.RowIndex == 2) { t3 = txt.Text; }
                    else if (row.RowIndex == 3) { t4 = txt.Text; }
                    else if (row.RowIndex == 4) { t5 = txt.Text; }
                    else if (row.RowIndex == 5) { t6 = txt.Text; }
                    else if (row.RowIndex == 6) { t7 = txt.Text; }
                    else if (row.RowIndex == 7) { t8 = txt.Text; }
                    else if (row.RowIndex == 8) { t9 = txt.Text; }
                    else if (row.RowIndex == 9) { t10 = txt.Text; }
                    else if (row.RowIndex == 10) { t11 = txt.Text; }
                    else if (row.RowIndex == 11) { t12 = txt.Text; }
                    else if (row.RowIndex == 12) { t13 = txt.Text; }
                    else if (row.RowIndex == 13) { t14 = txt.Text; }
                    else if (row.RowIndex == 14) { t15 = txt.Text; }
                    else if (row.RowIndex == 15) { t16 = txt.Text; }
                    else if (row.RowIndex == 16) { t17 = txt.Text; }
                    else if (row.RowIndex == 17) { t18 = txt.Text; }
                    else if (row.RowIndex == 18) { t19 = txt.Text; }
                    else if (row.RowIndex == 19) { t20 = txt.Text; }
                    else if (row.RowIndex == 20) { t21 = txt.Text; }
                    else if (row.RowIndex == 21) { t22 = txt.Text; }
                    else if (row.RowIndex == 22) { t23 = txt.Text; }
                    else if (row.RowIndex == 23) { t24 = txt.Text; }
                    else if (row.RowIndex == 24) { t25 = txt.Text; }

                }
            }
            foreach (GridViewRow row in GridView2.Rows)
            {
                CheckBox checkfield = (CheckBox)row.FindControl("checkfield2");
                if (checkfield.Checked == true)
                {
                    Label txt = (Label)row.FindControl("lblcontrolname1");
                    if (row.RowIndex == 0) { IspreviousBalanceFee = "true"; }
                }
                else
                {
                    Label txt = (Label)row.FindControl("lblcontrolname1");
                    if (row.RowIndex == 0) { IspreviousBalanceFee = "false"; }
                }
            }
            if (count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('please select at least one month to pay fee.');", true);

            }
            else
            {
                string fee_type = feetypes.Remove(feetypes.Length - 1, 1);
                int deptId = int.Parse(ViewState["StudentDepartmentId"].ToString());
                int applicationUserId = int.Parse(Session["ApplicationUserId"].ToString());
                string q = deptId.ToString().Trim() + "^" + applicationUserId.ToString() + "^" + t1 + "^" + t2 + "^" + t3 + "^" + t4 + "^" + t5 + "^" + t6 + "^" + t7 + 
                    "^" + t8 + "^" + t9 + "^" + t10 + "^" + t11 + "^" + t12 + "^" + t13 + "^" + t14 + "^" + t15 + "^" + t16 + "^" + t17 + "^" + t18 + "^" + t19 + "^" +
                    t20 + "^" + t21 + "^" + t22 + "^" + t23 + "^" + t24 + "^" + t25 + "^"+ IspreviousBalanceFee.ToString();
                q = Encryptdata(q);
                Response.Redirect("OnlinePaymentByStudent.aspx?q=" + q, false);
            }
        }
        public string Encryptdata(string str)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        //public void bindCourseddl()
        //{
        //    DataTable dt = new DataTable();
        //    dt = coursebll.GetCourseSubjectListOfLearner();
        //    ddlSubjectCourse.DataSource = dt;
        //    ddlSubjectCourse.DataBind();
        //    ddlSubjectCourse.DataTextField = "CourseSubjectName";
        //    ddlSubjectCourse.DataValueField = "Id";
        //    ddlSubjectCourse.DataBind();
        //    ddlSubjectCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        //    ViewState["departmentStandardId"] = int.Parse(dt.Rows[0]["DepartmentStandardID"].ToString());
        //}
        //public void bindExamddl()
        //{
        //    DataTable dt = new DataTable();
        //    dt = exambll.GetExamList("Active");
        //    ddlExam.DataSource = dt;
        //    ddlExam.DataBind();
        //    ddlExam.DataTextField = "ExamName";
        //    ddlExam.DataValueField = "Id";
        //    ddlExam.DataBind();
        //    ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}

        //protected void btnStartExam_Click(object sender, EventArgs e)
        //{
        //    payment();
        //}
        //public int InsertTempData()
        //{
        //    int numberOfCount = 1;
        //    DataTable getPaymentDetail = new DataTable();
        //    getPaymentDetail = paymentbll.GetPaymentDetail(int.Parse(ViewState["departmentStandardId"].ToString()), int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
        //    if (getPaymentDetail.Rows.Count > 0)
        //    {
        //        numberOfCount += getPaymentDetail.Rows.Count;
        //    }
        //    int result = 0;
        //    tpdf.ReferenceNumber = TranTrackid;
        //    tpdf.DepartmentStandardId = int.Parse(ViewState["departmentStandardId"].ToString());
        //    tpdf.CourseSubjectId = int.Parse(ddlSubjectCourse.SelectedValue.ToString());
        //    tpdf.ExamId = int.Parse(ddlExam.SelectedValue.ToString());
        //    tpdf.PaymentNumberOfTimes = numberOfCount;
        //    tpdf.TransactionDate = DateTime.Now;
        //    tpdf.Verified = false;
        //    result = paymentbll.AddNewTempPaymentDetail(tpdf);
        //    return result;



        //}
        //public void payment()
        //{
        //    int result = 0;
        //    string strURL, strClientCode, strClientCodeEncoded;
        //    byte[] b;
        //    string strResponse = "";
        //    string MerchantLogin = "9132";
        //    string MerchantPass = "Test@123";
        //    string TransactionType = "NBFundtransfer";
        //    string ProductID = "NSE";
        //    string TransactionID = TranTrackid;
        //    string TransactionAmount = "1";
        //    //string TransactionAmount = txtgrandtotal.Text;
        //    string TransactionCurrency = "INR";
        //    string BankID = "2001";
        //    string ru = "https://localhost:44391/Learner/FundTransferSuccessNew.aspx";
        //    //string ru = "http://dps.ebizpay.in/fees_structure/FundTransferSuccessNew.aspx";

        //    string TransactionDateTime = Convert.ToDateTime(now).ToString("dd/MM/yyyy");
        //    result = InsertTempData();

        //    if (result > 0 && result != 0)
        //    {

        //        try
        //        {
        //            var userName = Session["UserName"].ToString();
        //            b = Encoding.UTF8.GetBytes(userName);
        //            strClientCode = Convert.ToBase64String(b);
        //            strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);
        //            strURL = "" + ConfigurationManager.AppSettings["TransferURL"].ToString();
        //            strURL = strURL.Replace("[MerchantLogin]", MerchantLogin + "&");
        //            strURL = strURL.Replace("[MerchantPass]", MerchantPass + "&");
        //            strURL = strURL.Replace("[TransactionType]", TransactionType + "&");
        //            strURL = strURL.Replace("[ProductID]", ProductID + "&");
        //            strURL = strURL.Replace("[TransactionAmount]", TransactionAmount + "&");
        //            strURL = strURL.Replace("[TransactionCurrency]", TransactionCurrency + "&");
        //            strURL = strURL.Replace("[TransactionServiceCharge]", "0" + "&");
        //            strURL = strURL.Replace("[ClientCode]", strClientCodeEncoded + "&");
        //            strURL = strURL.Replace("[TransactionID]", TransactionID + "&");
        //            strURL = strURL.Replace("[TransactionDateTime]", TransactionDateTime + "&");
        //            strURL = strURL.Replace("[CustomerAccountNo]", "100000036600" + "&");
        //            strURL = strURL.Replace("[MerchantDiscretionaryData]", "cc" + "&");
        //            strURL = strURL.Replace("[BankID]", BankID + "&");
        //            strURL = strURL.Replace("[ru]", ru + "&");// Remove on Production
        //            strURL = strURL.Replace("[refudf1]", result.ToString() + "&");
        //            var applicationUserID = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
        //            strURL = strURL.Replace("[refudf2]", applicationUserID + "&");
        //            var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
        //            strURL = strURL.Replace("[refudf3]", clientId + "&");






        //            //  string reqHashKey = requestkey;
        //            string reqHashKey = "KEY123657234";
        //            string signature = "";
        //            string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
        //            byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
        //            byte[] bt = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
        //            // byte[] b = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(prodid));
        //            signature = byteToHexString(bt).ToLower();
        //            strURL = strURL.Replace("[signature]", signature);
        //            Application["temp"] = strURL;
        //            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers
        //            var r = strURL.Substring(strURL.IndexOf(@"?") + 1);
        //            encdec(r);
        //            string url = "https://paynetzuat.atomtech.in/paynetz/epi/fts?login=9132&encdata=" + Encryptval;

        //            HttpContext.Current.Response.Redirect(url, false);

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //    }
        //}
        //public static string byteToHexString(byte[] byData)
        //{
        //    StringBuilder sb = new StringBuilder((byData.Length * 2));
        //    for (int i = 0; (i < byData.Length); i++)
        //    {
        //        int v = (byData[i] & 255);
        //        if ((v < 16))
        //        {
        //            sb.Append('0');
        //        }

        //        sb.Append(v.ToString("X"));

        //    }

        //    return sb.ToString();
        //}

        //public void encdec(string txt)
        //{
        //    string passphrase = "A4476C2062FFA58980DC8F79EB6A799E";
        //    string salt = "A4476C2062FFA58980DC8F79EB6A799E";
        //    byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        //    int iterations = 65536;
        //    int keysize = 256;
        //    string plaintext = txt;
        //    string hashAlgorithm = "SHA1";
        //    Encryptval = Encrypt(plaintext, passphrase, salt, iv, iterations);

        //    Decryptval = decrypt(Encryptval, passphrase, salt, iv, iterations);
        //}

        //public String Encrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
        //{
        //    var plainBytes = Encoding.UTF8.GetBytes(plainText);
        //    string data = ByteArrayToHexString(Encrypt(plainBytes, GetSymmetricAlgorithm(passphrase, salt, iv, iterations))).ToUpper();


        //    return data;
        //}
        //public String decrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
        //{
        //    byte[] str = HexStringToByte(plainText);

        //    string data1 = Encoding.UTF8.GetString(decrypt(str, GetSymmetricAlgorithm(passphrase, salt, iv, iterations)));
        //    return data1;
        //}
        //public byte[] Encrypt(byte[] plainBytes, SymmetricAlgorithm sa)
        //{
        //    return sa.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        //}
        //public byte[] decrypt(byte[] plainBytes, SymmetricAlgorithm sa)
        //{
        //    return sa.CreateDecryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        //}
        //public SymmetricAlgorithm GetSymmetricAlgorithm(String passphrase, String salt, Byte[] iv, int iterations)
        //{
        //    var saltBytes = new byte[16];
        //    var ivBytes = new byte[16];
        //    Rfc2898DeriveBytes rfcdb = new System.Security.Cryptography.Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes(salt), iterations);
        //    saltBytes = rfcdb.GetBytes(32);
        //    var tempBytes = iv;
        //    Array.Copy(tempBytes, ivBytes, Math.Min(ivBytes.Length, tempBytes.Length));
        //    var rij = new RijndaelManaged(); //SymmetricAlgorithm.Create();
        //    rij.Mode = CipherMode.CBC;
        //    rij.Padding = PaddingMode.PKCS7;
        //    rij.FeedbackSize = 128;
        //    rij.KeySize = 128;

        //    rij.BlockSize = 128;
        //    rij.Key = saltBytes;
        //    rij.IV = ivBytes;
        //    return rij;
        //}
        //protected static byte[] HexStringToByte(string hexString)
        //{
        //    try
        //    {
        //        int bytesCount = (hexString.Length) / 2;
        //        byte[] bytes = new byte[bytesCount];
        //        for (int x = 0; x < bytesCount; ++x)
        //        {
        //            bytes[x] = Convert.ToByte(hexString.Substring(x * 2, 2), 16);
        //        }
        //        return bytes;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //public static string ByteArrayToHexString(byte[] ba)
        //{
        //    StringBuilder hex = new StringBuilder(ba.Length * 2);
        //    foreach (byte b in ba)
        //        hex.AppendFormat("{0:x2}", b);
        //    return hex.ToString();
        //}
    }
}