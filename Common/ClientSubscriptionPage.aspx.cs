using LMS.Admin.FeeClassFile;
using LMS.Common.ClassFile;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LMS.Common
{
    public partial class ClientSubscriptionPage : System.Web.UI.Page
    {
        static string q="",mobileAmount = "", amcAmount = "", OnlinePaymentAmount = "", SMSAmount = "", OnlineClassesAmount = "",totalPaymentAmount="";
        static Boolean isMobileIncluded = false, isAMC = false, isOnlinePaymentIncluded = false, isSMSIncluded = false, isOnlineClasses = false;
        string Encryptval;
        string Decryptval;
        DateTime now = DateTime.Now;
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        string ReqHashKey, ResHashKey, ReqAESKey, ResAESKey, MerchantId, pass, Test, prodId, TranType,_key,_secret;
        PCBLL pcBLL = new PCBLL();
        FeeBLL feebll = new FeeBLL();
        ClientBLL clientBLL=new ClientBLL();
        SubscriptionModel bol = new SubscriptionModel();
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        //private const string _key = "rzp_live_oVeNC46p2TbMDq";
        //private const string _secret = "UdY5ilmb3MF67WCjf6RxccNh";
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //payment();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int paymenttypeId=0;
                    q = Request.QueryString["q"].ToString();
                    q = Decryptdata(q);
                    string[] info = q.Split('^');
                    totalPaymentAmount = info[10];
                    string newclientId = info[11];
                    Session["ClientID"] = newclientId;
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
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration is not configured properly')", true);
                    }

                    //q = Request.QueryString["q"].ToString();
                    //q = Decryptdata(q);
                    //string[] info = q.Split('^');
                    //isMobileIncluded = Boolean.Parse(info[0]);
                    //mobileAmount = info[1];
                    //isAMC = Boolean.Parse(info[2]);
                    //amcAmount = info[3];
                    //isOnlinePaymentIncluded = Boolean.Parse(info[4]);
                    //OnlinePaymentAmount = info[5];
                    //isSMSIncluded = Boolean.Parse(info[6]);
                    //SMSAmount = info[7];
                    //isOnlineClasses = Boolean.Parse(info[8]);
                    //OnlineClassesAmount = info[9];
                    //totalPaymentAmount = info[10];
                    //string clientId = info[11];
                    //Session["ClientID"] = clientId;


                    //System.Data.DataTable appliedFfilterListdt = new System.Data.DataTable();
                    //appliedFfilterListdt.Columns.Add("TypeName", typeof(string));
                    //appliedFfilterListdt.Columns.Add("IsIncluded", typeof(string));
                    //appliedFfilterListdt.Columns.Add("Amount", typeof(string));

                    //DataRow paymentModeDataRow = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow["TypeName"] = "Desktop";
                    //paymentModeDataRow["IsIncluded"] = "True";
                    //paymentModeDataRow["Amount"] = "0";
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow);

                    //DataRow paymentModeDataRow1 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow1["TypeName"] = "Mobile";
                    //paymentModeDataRow1["IsIncluded"] = isMobileIncluded.ToString();
                    //paymentModeDataRow1["Amount"] = mobileAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow1);

                    //DataRow paymentModeDataRow2 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow2["TypeName"] = "AMC";
                    //paymentModeDataRow2["IsIncluded"] = isAMC.ToString();
                    //paymentModeDataRow2["Amount"] = amcAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow2);

                    //DataRow paymentModeDataRow3 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow3["TypeName"] = "Online Payment";
                    //paymentModeDataRow3["IsIncluded"] = isOnlinePaymentIncluded.ToString();
                    //paymentModeDataRow3["Amount"] = OnlinePaymentAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow3);

                    //DataRow paymentModeDataRow4 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow4["TypeName"] = "SMS";
                    //paymentModeDataRow4["IsIncluded"] = isSMSIncluded.ToString();
                    //paymentModeDataRow4["Amount"] = SMSAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow4);

                    //DataRow paymentModeDataRow5 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow5["TypeName"] = "Online Classes";
                    //paymentModeDataRow5["IsIncluded"] = isOnlineClasses.ToString();
                    //paymentModeDataRow5["Amount"] = OnlineClassesAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow5);

                    //DataRow paymentModeDataRow6 = appliedFfilterListdt.NewRow();
                    //paymentModeDataRow6["TypeName"] = "Paying Amount";
                    //paymentModeDataRow6["IsIncluded"] = isOnlineClasses.ToString();
                    //paymentModeDataRow6["Amount"] = totalPaymentAmount;
                    //appliedFfilterListdt.Rows.Add(paymentModeDataRow6);

                    //GridView1.DataSource = appliedFfilterListdt;
                    //GridView1.DataBind();
                }
                catch (Exception er)
                {
                    //  Response.Redirect("~/fees_structure/payment.aspx");
                }
            }
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
                Session["ResHashKey"] = ResHashKey;
                Session["ResAESKey"] = ResAESKey;
            }
        }
        public void payment()
        {


            q = Request.QueryString["q"].ToString();
            q = Decryptdata(q);
            string[] info = q.Split('^');
            totalPaymentAmount = info[10];
            string newclientId = info[11];
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
            string ru = prefixPath + "/Common/SubscriptionFundTransferSuccessNew.aspx?s=HA" + ResAESKey + "BREAK" + ResHashKey;
            //string ru = "http://dps.ebizpay.in/fees_structure/FundTransferSuccessNew.aspx?s=HA" + ResAESKey + "BREAK" + ResHashKey;

            string TransactionDateTime = Convert.ToDateTime(now).ToString("dd/MM/yyyy");
            result = InsertTempData();

            if (result > 0 && result != 0)
            {

                try
                {
                    var userName = Session["ClientID"].ToString();
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
                    var applicationUserID = "10101";//Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
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

                    //connection1 = objdal01.Conncetion();
                    //SqlConnection con = new SqlConnection(connection1);
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //SqlCommand cmd = new SqlCommand("insert into tbl_test_temp(ApplicationUserID,value1,value2)values(@applicationUserId,@value1,@value2)", con);
                    //cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(System.Web.HttpContext.Current.Session["ApplicationUserId"].ToString()));
                    //cmd.Parameters.AddWithValue("@value1", r);
                    //cmd.Parameters.AddWithValue("@value2", url);
                    //cmd.ExecuteNonQuery();
                    //if (con.State != ConnectionState.Closed)
                    //{
                    //    con.Close();
                    //}

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

            q = Request.QueryString["q"].ToString();
            q = Decryptdata(q);
            string[] info = q.Split('^');
            isMobileIncluded = Boolean.Parse(info[0]);
            mobileAmount = info[1];
            isAMC = Boolean.Parse(info[2]);
            amcAmount = info[3];
            isOnlinePaymentIncluded = Boolean.Parse(info[4]);
            OnlinePaymentAmount = info[5];
            isSMSIncluded = Boolean.Parse(info[6]);
            SMSAmount = info[7];
            isOnlineClasses = Boolean.Parse(info[8]);
            OnlineClassesAmount = info[9];
            totalPaymentAmount = info[10];
            string clientId = info[11];
            Session["ClientID"] = clientId;

            bol.IsDesktopIncluded = true;
            bol.IsAndroidIncluded = isMobileIncluded;
            bol.IsAMCIncluded = isAMC;
            bol.IsOnlinePaymentIncluded = isOnlinePaymentIncluded;
            bol.IsSMSIncluded = isSMSIncluded;
            bol.IsOnlineClassesIncluded = isOnlineClasses;
            bol.AndroidAmount = double.Parse(mobileAmount);
            bol.AMCAmount = double.Parse(amcAmount);
            bol.OnlinePaymentAmount = double.Parse(OnlinePaymentAmount);
            bol.SMSAmount = double.Parse(SMSAmount);
            bol.OnlineClassesAmount = double.Parse(OnlineClassesAmount);
            bol.TotalPaidAmount = double.Parse(totalPaymentAmount);


            bol.ClientID = Session["ClientID"].ToString();
            bol.ReferenceNumber = TranTrackid;
            bol.TransactionDate = DateTime.Now;
            bol.Verified = false;
            bol.DateOfApproval = DateTime.Now;
            DateTime newDate = DateTime.Now.AddYears(1);
            bol.RenewalDate = newDate;
            result = feebll.InsertTempSubscriptionPaymentDetail(bol);
            return result;
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
            q = Request.QueryString["q"].ToString();
            q = Decryptdata(q);
            string[] info = q.Split('^');
            totalPaymentAmount = info[10];
            string newclientId = info[11];
            DataTable clientdt=new DataTable();
            clientdt = clientBLL.GetClientByClientId(Session["ClientID"].ToString());
           int result = InsertTempData();
            if (result > 0 && result != 0)
            {
                try
                {
                    //if (Convert.ToInt32(Session["StudentId"].ToString()) > 0)
                    //{
                    //int a = (int.Parse(lblgrandtotal.Text) / 100);
                    decimal disc = 0;
                    decimal Amt = Convert.ToDecimal(totalPaymentAmount);

                    //string amount1 = string.Format("{0:0.##}", Amount);
                    //string exitamount1 = string.Format("{0:0.##}", ExitAmount);
                    //string indosAmt = string.Format("{0:0.##}", IndosAmount);
                    //decimal percentageAmount = Convert.ToDecimal(Amount) + Convert.ToDecimal(IndosAmount);
                    //decimal exactPercentageAmount= Convert.ToDecimal((Convert.ToDouble(percentageAmount) * 1) / 100);

                    //decimal totalFinalAmount = (Amount + ExitAmount + IndosAmount+ exactPercentageAmount) *100;
                    //decimal exitFeeAmount = ExitAmount * 100;
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
                        { "name", clientdt.Rows[0]["ClientName"].ToString() },
                        { "email", clientdt.Rows[0]["EmailID"].ToString() },
                        { "mob", clientdt.Rows[0]["ContactNumber"].ToString() },
                        { "sid", result.ToString() },
                        { "totalFinalAmount", string.Format("{0:0.##}", courseAmount) }
                    };
                    getPGDetails();
                    string qry = _key + "^" +  _secret;
                    qry = Encryptdata(qry);
                    string orderId = CreateOrder(amountinSubunits, currency, notes);
                    //Session["storedId"] = id.ToString();
                    notes.Add("orderId", orderId);
                    string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + profileName + "', '" + profileEmail + "', '" + profileMobile + "', '" + JsonConvert.SerializeObject(notes) + "', '"+ courseAmount + "', '"+ qry + "');";
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

                //}
                //else
                //{
                //    ListDictionary trf = new ListDictionary();
                //    trf.Add("amount", exitsAmount);
                //    trf.Add("account", "acc_JmmX8HOUATFMzF");
                //    trf.Add("currency", "INR");

                //    ArrayList lst = new ArrayList();
                //    lst.Add(trf);

                //    Dictionary<string, object> input = new Dictionary<string, object>();
                //    input.Add("amount", amountInSubunits); // this amount should be same as transaction amount
                //    input.Add("currency", "INR");
                //    input.Add("receipt", "12121");
                //    input.Add("payment_capture", 1);

                //    input.Add("transfers", lst);

                //    RazorpayClient client = new RazorpayClient(_key, _secret);
                //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //    Razorpay.Api.Order order = client.Order.Create(input);
                //    var orderId = order["id"].ToString();
                //    return orderId;
                //    // Console.WriteLine("order");
                //}


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}