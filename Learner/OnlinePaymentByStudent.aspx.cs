using DotNetIntegrationKit;
using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.FeeClassFile;
using LMS.BasicClass;
using LMS.Common.ClassFile;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class OnlinePaymentByStudent : System.Web.UI.Page
    {
        AdminBLL adminbll = new AdminBLL();
        FeeBLL feebll = new FeeBLL();
        AddPayment bol = new AddPayment();
        PCBLL pcBLL = new PCBLL();
        DeptBLL deptBLL = new DeptBLL();
        ClientBLL clientBLL=new ClientBLL();
        static string q = "", standard = "", applicationUser = "", s = "", t1 = "", t2 = "", t3 = "", t4 = "", t5 = "", t6 = "", t7 = "", t8 = "", t9 = "", t10 = "",
            t11 = "", t12 = "", t13 = "", t14 = "", t15 = "", t16 = "", t17 = "", t18 = "", t19 = "", t20 = "", t21 = "", t22 = "", t23 = "", t24 = "", t25 = "", IspreviousBalanceFee = "",totalPaymentAmount="";
        string Encryptval;
        string Decryptval;
        DateTime now = DateTime.Now;
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        string ReqHashKey, ResHashKey, ReqAESKey, ResAESKey, MerchantId, pass, Test, prodId, TranType,_key,_secret,_merchantCode,_IsKey,_IsIV;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFeesDetail();
                btnpaynow.Enabled = false;
            }
        }
        public void BindFeesDetail()
        {
            try
            {
                q = Request.QueryString["q"].ToString();
                q = Decryptdata(q);
                string[] info = q.Split('^');
                standard = info[0];
                applicationUser = info[1];
                t1 = info[2];
                t2 = info[3];
                t3 = info[4];
                t4 = info[5];
                t5 = info[6];
                t6 = info[7];
                t7 = info[8];
                t8 = info[9];
                t9 = info[10];
                t10 = info[11];
                t11 = info[12];
                t12 = info[13];
                t13 = info[14];
                t14 = info[15];
                t15 = info[16];
                t16 = info[17];
                t17 = info[18];
                t18 = info[19];
                t19 = info[20];
                t20 = info[21];
                t21 = info[22];
                t22 = info[23];
                t23 = info[24];
                t24 = info[25];
                t25 = info[26];
                IspreviousBalanceFee = info[27];
            }
            catch (Exception er)
            {
                //  Response.Redirect("~/fees_structure/payment.aspx");
            }
            bol.ClientID = Session["ClientID"].ToString();
            bol.StandardId = int.Parse(standard);
            bol.ApplicationUserId = int.Parse(applicationUser);
            bol.T1 = t1; bol.T2 = t2; bol.T3 = t3; bol.T4 = t4; bol.T5 = t5; bol.T6 = t6; bol.T7 = t7; bol.T8 = t8; bol.T9 = t9; bol.T10 = t10; bol.T11 = t11; bol.T12 = t12;
            bol.T13 = t13; bol.T14 = t14; bol.T15 = t15; bol.T16 = t16; bol.T17 = t17; bol.T18 = t18; bol.T19 = t19; bol.T20 = t20; bol.T21 = t21; bol.T22 = t22; bol.T23 = t23; bol.T24 = t24; bol.T25 = t25;
            bol.IspreviousBalanceFee = IspreviousBalanceFee == "" ? false : Boolean.Parse(IspreviousBalanceFee);

            assignpersonalvalues();
            bol.TotalFee = assignfeesvalues1();
            AssignCalculated();

        }
        protected void btnpaynow_Click(object sender, EventArgs e)
        {
            if (validate() == 0)
            {
                q = Request.QueryString["q"].ToString();
                q = Decryptdata(q);
                string[] info = q.Split('^');
                standard = info[0];
                int result = 0;
                int result1 = 0;
                bol.T1 = t1; bol.T2 = t2; bol.T3 = t3; bol.T4 = t4; bol.T5 = t5; bol.T6 = t6; bol.T7 = t7; bol.T8 = t8; bol.T9 = t9; bol.T10 = t10; bol.T11 = t11; bol.T12 = t12;
                bol.T13 = t13; bol.T14 = t14; bol.T15 = t15; bol.T16 = t16; bol.T17 = t17; bol.T18 = t18; bol.T19 = t19; bol.T20 = t20; bol.T21 = t21; bol.T22 = t22; bol.T23 = t23; bol.T24 = t24; bol.T25 = t25;
                bol.IspreviousBalanceFee = IspreviousBalanceFee == "" ? false : Boolean.Parse(IspreviousBalanceFee);
                int appid = int.Parse(Session["ApplicationUserId"].ToString());
                //bol.Stud_name = lblName.Text;
                //bol.father_name = lblFatheName.Text;
                //bol.category = lblCate.Text;
                bol.StandardId = int.Parse(standard);
                bol.ApplicationUserId = appid;
                bol.GrandTotal = Convert.ToDecimal(txtpayingnow.Text);
                bol.TotalFee = Convert.ToDecimal(txttotalfee.Text);
                bol.LateFee = Convert.ToDecimal(txtlatefeecharge.Text);
                bol.GrandTotal = Convert.ToDecimal(txtgrandtotal.Text);
                string newclientId =Session["ClientID"].ToString();
                int paymenttypeId=0;
                DataTable clientdt=new DataTable();
                clientdt = clientBLL.GetClientByClientId(newclientId);
                if (clientdt.Rows.Count > 0)
                {
                    paymenttypeId = clientdt.Rows[0]["PaymentType"].ToString() == "" ? 0 : int.Parse(clientdt.Rows[0]["PaymentType"].ToString());
                }
                if (paymenttypeId > 0)
                {
                    if (paymenttypeId == 1)
                    {
                        payment();
                    }
                    else if (paymenttypeId == 2)
                    {
                        payment_by_Razor();
                    }
                    else if (paymenttypeId == 3)
                    {
                        paymentByWorldLine();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration is not configured properly')", true);
                }
                //payment();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayExamFee.aspx");
        }
        public void assignpersonalvalues()
        {
            DataTable personalDetail = new DataTable();
            var logedInUserId = int.Parse(Session["ApplicationUserId"].ToString());
            personalDetail = adminbll.GetApplicationUserById(logedInUserId);
            lblApplicationNumber.Text = Session["ApplicationUserId"].ToString();
            lblStudentName.Text = personalDetail.Rows[0]["FirstName"].ToString() + " " + personalDetail.Rows[0]["LastName"].ToString();
            lblFatherName.Text = personalDetail.Rows[0]["FatherName"].ToString();
            Session["paymentName"] = personalDetail.Rows[0]["FirstName"].ToString() + " " + personalDetail.Rows[0]["LastName"].ToString();
            Session["paymentEmail"] = personalDetail.Rows[0]["EmailId"].ToString();
            Session["paymentContact"] = personalDetail.Rows[0]["ContactNumber"].ToString();
            DataTable dt = new DataTable();
            // int idValue = int.Parse(Session["EditLearnerInDepartmentId"].ToString());
            dt = deptBLL.GetStudentInformationDetailsByApplicationUserId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //if (Boolean.Parse(dr["IsActive"].ToString()) == true)
                    //{
                    lblClass.Text = dt.Rows[0]["DepartmentStandardName"].ToString();
                    lblCategory.Text = dt.Rows[0]["CategoryName"].ToString();
                    //}
                }

            }
        }
        public Decimal assignfeesvalues1()
        {
            Decimal totalcaluatedfess = 0;
            DataTable dtfees = new DataTable();
            string admissionNo=Session["AdmissionNumber"].ToString();
            int academicYearId= int.Parse(Session["AcademicYearId"].ToString());
            bol.AdmissionNumber = admissionNo;
            bol.AcademicYearId = academicYearId;
            dtfees = feebll.GetFeeDetails(bol);
            if (dtfees.Rows.Count > 0)
            {
                for (int i = 0; i < dtfees.Rows.Count; i++)
                {

                    HtmlTableRow row = new HtmlTableRow();
                    HtmlTableCell cell1 = new HtmlTableCell();
                    HtmlTableCell cell2 = new HtmlTableCell();
                    HtmlTableCell cell3 = new HtmlTableCell();
                    HtmlTableCell cell4 = new HtmlTableCell();
                    cell1.InnerText = dtfees.Rows[i]["FeeMonth"].ToString();
                    cell2.InnerText = dtfees.Rows[i]["FeeName"].ToString();
                    cell3.InnerText = dtfees.Rows[i]["FeeNameAmount"].ToString();
                    cell4.InnerText = dtfees.Rows[i]["FeeType"].ToString();
                    totalcaluatedfess += Convert.ToDecimal(dtfees.Rows[i]["FeeNameAmount"].ToString());
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    tblFee.Rows.Add(row);

                }
            }
            return totalcaluatedfess;
        }
        //public Decimal CalculateLateFee()
        //{
        //    Decimal totalcaluatedLatefess = 0;
        //    DataTable dtLatefees = new DataTable();
        //    dtLatefees = bll.getLatefeesdetails_online(bol);
        //    if (dtLatefees.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtLatefees.Rows.Count; i++)
        //        {
        //            if (dtLatefees.Rows[i]["FineType"].ToString() == "Fixed")
        //            {
        //                totalcaluatedLatefess += Convert.ToDecimal(dtLatefees.Rows[i]["FineAmount"].ToString());
        //            }
        //            else if (dtLatefees.Rows[i]["FineType"].ToString() == "Per Day")
        //            {
        //                decimal fee = 0;
        //                fee = Convert.ToDecimal(dtLatefees.Rows[i]["FineAmount"].ToString()) * Convert.ToInt32(dtLatefees.Rows[i]["dy"].ToString());
        //                totalcaluatedLatefess += fee;
        //            }
        //            else if (dtLatefees.Rows[i]["FineType"].ToString() == "Not Applicable")
        //            {
        //                totalcaluatedLatefess += 0;
        //            }

        //        }
        //    }
        //    return totalcaluatedLatefess;
        //}
        public void getPGDetails()
        {

            DataTable dt = new DataTable();
            var clientid = Session["ClientID"].ToString();

            dt = pcBLL.GetClientsPaymentConfigurationByClientId(clientid);
            if (dt.Rows.Count > 0)
            {
                ResAESKey = dt.Rows[0]["ResponseAESKey"].ToString();
                ReqAESKey = dt.Rows[0]["RequestAESKey"].ToString();
                MerchantId = dt.Rows[0]["MerchantId"].ToString();
                pass = dt.Rows[0]["PaymentPassword"].ToString();
                ResHashKey = dt.Rows[0]["ResponseHashKey"].ToString();
                ReqHashKey = dt.Rows[0]["RequestHashKey"].ToString();
                Test = dt.Rows[0]["IsActive"].ToString();
                TranType = dt.Rows[0]["TransactionType"].ToString();
                prodId = dt.Rows[0]["ProductId"].ToString();
                _key = dt.Rows[0]["RazorKey"].ToString();
                _secret = dt.Rows[0]["RazorSecretKey"].ToString();
                _merchantCode = dt.Rows[0]["MerchantCode"].ToString();
                _IsKey = dt.Rows[0]["IsKey"].ToString();
                _IsIV = dt.Rows[0]["IsIv"].ToString();
                Session["ResHashKey"] = ResHashKey;
                Session["ResAESKey"] = ResAESKey;
            }
        }
        public void AssignCalculated()
        {

            txttotalfee.Text = bol.TotalFee.ToString();
            bol.GrandTotal = bol.TotalFee; //+ bol.Latefee;
            txtlatefeecharge.Text = "0.00";//bol.Latefee.ToString();
            txtgrandtotal.Text = bol.GrandTotal.ToString();
            txtpayingnow.Text = bol.GrandTotal.ToString();
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
        public void payment()
        {
            getPGDetails();

            int result = 0;
            string strURL, strClientCode, strClientCodeEncoded;
            byte[] b;
            string strResponse = "";

            string MerchantLogin = MerchantId;
            string MerchantPass = pass;
            string TransactionType = TranType;
            string ProductID = prodId;
            string TransactionID = TranTrackid;

            //string MerchantLogin = "9132";
            //string MerchantPass = "Test@123";
            //string TransactionType = "NBFundtransfer";
            //string ProductID = "NSE";
            //string TransactionID = TranTrackid;
            string TransactionAmount = "1";
            //string TransactionAmount = txtgrandtotal.Text;
            string TransactionCurrency = "INR";
            string BankID = "2001";
            var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
            string ru = prefixPath+"/Learner/FundTransferSuccessNew.aspx?s=HA" + ResAESKey + "BREAK" + ResHashKey;
            //string ru = "http://dps.ebizpay.in/fees_structure/FundTransferSuccessNew.aspx?s=HA" + ResAESKey + "BREAK" + ResHashKey;

            string TransactionDateTime = Convert.ToDateTime(now).ToString("dd/MM/yyyy");
            result = InsertTempData();

            if (result > 0 && result != 0)
            {

                try
                {
                    var userName = Session["UserName"].ToString();
                    b = Encoding.UTF8.GetBytes(userName);
                    strClientCode = Convert.ToBase64String(b);
                    strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);
                    strURL = "" + ConfigurationManager.AppSettings["TransferURL"].ToString();
                    strURL = strURL.Replace("[MerchantLogin]", MerchantLogin + "&");
                    strURL = strURL.Replace("[MerchantPass]", MerchantPass + "&");
                    strURL = strURL.Replace("[TransactionType]", TransactionType + "&");
                    strURL = strURL.Replace("[ProductID]", ProductID + "&");
                    strURL = strURL.Replace("[TransactionAmount]", TransactionAmount + "&");
                    strURL = strURL.Replace("[TransactionCurrency]", TransactionCurrency + "&");
                    strURL = strURL.Replace("[TransactionServiceCharge]", "0" + "&");
                    strURL = strURL.Replace("[ClientCode]", strClientCodeEncoded + "&");
                    strURL = strURL.Replace("[TransactionID]", TransactionID + "&");
                    strURL = strURL.Replace("[TransactionDateTime]", TransactionDateTime + "&");
                    strURL = strURL.Replace("[CustomerAccountNo]", "100000036600" + "&");
                    strURL = strURL.Replace("[MerchantDiscretionaryData]", "cc" + "&");
                    strURL = strURL.Replace("[BankID]", BankID + "&");
                    strURL = strURL.Replace("[ru]", ru + "&");// Remove on Production
                    strURL = strURL.Replace("[refudf1]", result.ToString() + "&");
                    var applicationUserID = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                    strURL = strURL.Replace("[refudf2]", applicationUserID + "&");
                    var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
                    strURL = strURL.Replace("[refudf3]", clientId + "&");


                    string reqHashKey = ReqHashKey;
                    //string reqHashKey = "KEY123657234";
                    string signature = "";
                    string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
                    byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
                    byte[] bt = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                    // byte[] b = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(prodid));
                    signature = byteToHexString(bt).ToLower();
                    strURL = strURL.Replace("[signature]", signature);
                    Application["temp"] = strURL;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers
                    var r = strURL.Substring(strURL.IndexOf(@"?") + 1);
                    encdec(r);
                    string url = "https://paynetzuat.atomtech.in/paynetz/epi/fts?login=" + MerchantLogin + "&encdata=" + Encryptval;

                    connection1 = objdal01.Conncetion();
                    SqlConnection con = new SqlConnection(connection1);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("insert into tbl_test_temp(ApplicationUserID,value1,value2)values(@applicationUserId,@value1,@value2)", con);
                    cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(System.Web.HttpContext.Current.Session["ApplicationUserId"].ToString()));
                    cmd.Parameters.AddWithValue("@value1", r);
                    cmd.Parameters.AddWithValue("@value2", url);
                    cmd.ExecuteNonQuery();
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }

                    HttpContext.Current.Response.Redirect(url, false);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public int InsertTempData()
        {
            int result = 0;
            bol.ClientID = Session["ClientID"].ToString();
            bol.ReferenceNumber = TranTrackid;
            bol.TransactionDate = DateTime.Now;
            bol.Verified = false;
            result = feebll.InsertTempPaymentDetail(bol);
            return result;


        }
        public int validate()
        {
            int validation = 0;
            if (txtpayingnow.Text.Trim() == "")
            {
                validation = validation + 1;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Amount paying is Blank.');", true);
            }
            else if (Convert.ToDecimal(txtpayingnow.Text.Trim()) == 0)
            {
                validation = validation + 1;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Amount paying should be nonzero.');", true);
            }


            return validation;
        }
        public static string byteToHexString(byte[] byData)
        {
            StringBuilder sb = new StringBuilder((byData.Length * 2));
            for (int i = 0; (i < byData.Length); i++)
            {
                int v = (byData[i] & 255);
                if ((v < 16))
                {
                    sb.Append('0');
                }

                sb.Append(v.ToString("X"));

            }

            return sb.ToString();
        }
        public void encdec(string txt)
        {
            //string passphrase = "A4476C2062FFA58980DC8F79EB6A799E";
            //string salt = "A4476C2062FFA58980DC8F79EB6A799E";
            string passphrase = ReqAESKey;
            string salt = ReqAESKey;
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int iterations = 65536;
            int keysize = 256;
            string plaintext = txt;
            string hashAlgorithm = "SHA1";
            Encryptval = Encrypt(plaintext, passphrase, salt, iv, iterations);

            Decryptval = decrypt(Encryptval, passphrase, salt, iv, iterations);
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                btnpaynow.Enabled = true;
            }
            else
            {
                btnpaynow.Enabled = false;
            }
            BindFeesDetail();
        }
        public String Encrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            string data = ByteArrayToHexString(Encrypt(plainBytes, GetSymmetricAlgorithm(passphrase, salt, iv, iterations))).ToUpper();


            return data;
        }
        public String decrypt(String plainText, String passphrase, String salt, Byte[] iv, int iterations)
        {
            byte[] str = HexStringToByte(plainText);

            string data1 = Encoding.UTF8.GetString(decrypt(str, GetSymmetricAlgorithm(passphrase, salt, iv, iterations)));
            return data1;
        }
        public byte[] Encrypt(byte[] plainBytes, SymmetricAlgorithm sa)
        {
            return sa.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        }
        public byte[] decrypt(byte[] plainBytes, SymmetricAlgorithm sa)
        {
            return sa.CreateDecryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }
        public SymmetricAlgorithm GetSymmetricAlgorithm(String passphrase, String salt, Byte[] iv, int iterations)
        {
            var saltBytes = new byte[16];
            var ivBytes = new byte[16];
            Rfc2898DeriveBytes rfcdb = new System.Security.Cryptography.Rfc2898DeriveBytes(passphrase, Encoding.UTF8.GetBytes(salt), iterations);
            saltBytes = rfcdb.GetBytes(32);
            var tempBytes = iv;
            Array.Copy(tempBytes, ivBytes, Math.Min(ivBytes.Length, tempBytes.Length));
            var rij = new RijndaelManaged(); //SymmetricAlgorithm.Create();
            rij.Mode = CipherMode.CBC;
            rij.Padding = PaddingMode.PKCS7;
            rij.FeedbackSize = 128;
            rij.KeySize = 128;

            rij.BlockSize = 128;
            rij.Key = saltBytes;
            rij.IV = ivBytes;
            return rij;
        }
        protected static byte[] HexStringToByte(string hexString)
        {
            try
            {
                int bytesCount = (hexString.Length) / 2;
                byte[] bytes = new byte[bytesCount];
                for (int x = 0; x < bytesCount; ++x)
                {
                    bytes[x] = Convert.ToByte(hexString.Substring(x * 2, 2), 16);
                }
                return bytes;
            }
            catch
            {
                throw;
            }
        }
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        protected void payment_by_Razor()
        {
            getPGDetails();
            string q = _key + "^" +  _secret;
            q = Encryptdata(q);
            totalPaymentAmount = txtgrandtotal.Text;
            DataTable clientdt=new DataTable();
            clientdt = clientBLL.GetClientByClientId(Session["ClientID"].ToString());
            int result = InsertTempData();
            if (result > 0 && result != 0)
            {
                try
                {
                    decimal disc = 0;
                    decimal Amt = Convert.ToDecimal(totalPaymentAmount);

                    decimal courseAmount = Amt *100;

                    decimal amountinSubunits = courseAmount;
                    string currency = "INR";
                    string name = clientdt.Rows[0]["ClientName"].ToString();
                    string description = "Razorpay Payment Gateway Demo";
                    string imageLogo = "";
                    string profileName = clientdt.Rows[0]["ClientName"].ToString();
                    string profileMobile = clientdt.Rows[0]["ContactNumber"].ToString();
                    string profileEmail = clientdt.Rows[0]["EmailID"].ToString();
                    Dictionary<string, string> notes = new Dictionary<string, string>()
                    {
                        { "TranTrackid", TranTrackid },
                        { "name", Session["paymentName"].ToString() },
                        { "email", Session["paymentEmail"].ToString() },
                        { "mob", Session["paymentContact"].ToString() },
                        { "sid", result.ToString() },
                        { "totalFinalAmount", string.Format("{0:0.##}", courseAmount) },
                        { "clientId", Session["ClientID"].ToString() }
                    };

                    string orderId = CreateOrder(amountinSubunits, currency, notes);
                    //Session["storedId"] = id.ToString();
                    notes.Add("orderId", orderId);
                    string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "', '" + JsonConvert.SerializeObject(notes) + "', '"+ courseAmount + "', '"+ q + "');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);


                    //amount1 = string.Format("{0:0.##}", amtt);
                    // Response.Redirect("CoursePaymentByAtom.aspx?sid=" + q_id + "&TranTrackid=" + TranTrackid + "&amt=" + amount1 + "&name=" + txtname.Text + "&exitAmount=" + exitamount1 + "&indosAmount=" + indosAmt + "&email=" + txtemailid.Text + "&mob=" + txtmobileno.Text);

                }
                catch (Exception ex)
                {

                }
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
        private string CreateOrder(decimal amountInSubunits, string currency, Dictionary<string, string> notes)
        {
            try
            {
                int paymentCapture = 1;
                //exitsAmount
                //if (0 == 0)
                //{
                getPGDetails();
                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", amountInSubunits);
                options.Add("currency", currency);
                options.Add("payment_capture", paymentCapture);
                options.Add("notes", notes);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.Expect100Continue = false;

                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void paymentByWorldLine()
        {
            getPGDetails();
           
            totalPaymentAmount = txtgrandtotal.Text;
            DataTable clientdt=new DataTable();
            clientdt = clientBLL.GetClientByClientId(Session["ClientID"].ToString());
            int result = InsertTempData();
            string q =Session["ClientID"].ToString()+ "^"+result.ToString();
            q = Encryptdata(q);
            if (result > 0 && result != 0)
            {
                try
                {
                    var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                    string message = prefixPath+"/Learner/WorldLineResponsePage.aspx?q="+q;
                    string[] totalpayingAmount=totalPaymentAmount.Split('.');
                    string newvalue="10";//totalpayingAmount[0].ToString();
                    RequestURL objRequestURL = new RequestURL();
                    String response = objRequestURL.SendRequest
                                       (
                                       "T"                                     //TXT_requesttype.Text
                                      , _merchantCode       //dynamic              //, TXT_merchantcode.Text
                                      , TranTrackid      //dynamic             //, TXT_MerchantTxnRefNo.Text
                                      , Session["ClientID"].ToString(), newvalue                     //additionalField     //, TXT_ITC.Text, TXT_Amount.Text
                                      , "INR"                                  //, TXT_Currencycode.Text
                                      , TranTrackid       //customerid               //, TXT_uniqueCustomerID.Text
                                      , message       //, TXT_returnURL.Text
                                      , ""                                   //, TXT_StoSreturnURL.Text
                                      , ""                                   //, TXT_TPSLTXNID.Text
                                      , "first_"+newvalue.ToString()+".0_0.0"                       //, TXT_Shoppingcartdetails.Text
                                      , DateTime.Now.ToString("dd-MM-yyyy")   //, TXT_TxnDate.Text
                                      , result.ToString()   //Email                         //, TXT_Email.Text
                                      , ""    //mobile                       //, TXT_mobileNo.Text
                                      , "470"    //bank code                    //, TXT_Bankcode.Text  hardcoded
                                      , lblStudentName.Text                    //, TXT_customerName.Text
                                      , ""                                   //, TXT_CardID.Text
                                      , ""                                   //, TXT_AccountNo.Text
                                      , _IsKey  //dynamic          //, TXT_IsKey.Text
                                      , _IsIV  //dynamic          //, TXT_IsIv.Text
                                       );
                    //https://payments.paynimo.com/PaynimoProxy/services/TransactionUATDetails
                    //https://www.tpsl-india.in/PaymentGateway/services/TransactionDetailsNew
                    //https://payments.paynimo.com/PaynimoProxy/services/TransactionLiveDetails
                    String strResponse = response.ToUpper();

                    if (strResponse.StartsWith("ERROR"))
                    {
                        lblError.Text = response;
                    }
                    else
                    {
                        if ("T" == "T")
                        {
                            Response.Write("<form name='s1_2' id='s1_2' action='" + response + "' method='post'> ");
                            Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");
                            Response.Write("</script>");
                            Response.Write("<script language='javascript' >");
                            Response.Write("</script>");
                            Response.Write("</form> ");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}