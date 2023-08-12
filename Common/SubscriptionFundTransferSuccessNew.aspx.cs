using LMS.Admin.ClassFile;
using LMS.Admin.FeeClassFile;
using LMS.BasicClass;
using LMS.Common.ClassFile;
using LMS.SuperAdmin.ClientClassFile;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class SubscriptionFundTransferSuccessNew : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection1"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        static DataSet ds;
        static DataTable dt1, dt2;
        SqlDataReader dr;
        DateTime now = DateTime.Now;

        string Decryptval;
        string postingmmp_txn, postingmer_txn, postinamount, postingprod, postingdate, postingbank_txn, postingf_code, postingbank_name, signature, postingdiscriminator, ipg_txn_id, description, Resudf1, Resudf2, Resudf3, Resudf4, Resudf5, status;
        string strsqlquery = string.Empty;
        int q_id, tmpid;
        int rid;
        static int rectNo, cnt;
        string emailid = "", contact = "", name = "", instname = "", monthid = "";
        int tempid, results;
        string clientid;
        decimal amt;
        static decimal serviceCharge1;
        SubscriptionModel bol = new SubscriptionModel();
        ClientBLL clientBLL = new ClientBLL();
        FeeBLL feeBLL = new FeeBLL();
        static int resultt;
        string q;
        string ReqHashKey, ResHashKey, ReqAESKey, ResAESKey, MerchantId, pass, encryptedStringAES, encryptedStringHash;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    NameValueCollection nvc = Request.Form;
                    var substringvalue = Request.QueryString["s"].ToString();

                    //encryptedStringHash = Request.QueryString["hashkeys"].ToString();
                    ResAESKey = betweenStrings(substringvalue, "HA", "BREAK");
                    ResHashKey = betweenStrings(substringvalue, "BREAK", "");

                    var s = Request.Params["encdata"].ToString();

                    encdec(s);
                    if (Decryptval != null)
                    {

                        postingmmp_txn = betweenStrings(Decryptval, "mmp_txn=", "&");
                        postingmer_txn = betweenStrings(Decryptval, "mer_txn=", "&");
                        ipg_txn_id = betweenStrings(Decryptval, "ipg_txn_id=", "&");
                        postinamount = betweenStrings(Decryptval, "amt=", "&");
                        postingprod = betweenStrings(Decryptval, "prod=", "&");
                        postingdate = betweenStrings(Decryptval, "date=", "&");
                        postingbank_txn = betweenStrings(Decryptval, "bank_txn=", "&");
                        postingf_code = betweenStrings(Decryptval, "f_code=", "&");
                        postingbank_name = betweenStrings(Decryptval, "mmp_txn=", "&");
                        signature = betweenStrings(Decryptval, "signature=", "&");
                        postingdiscriminator = betweenStrings(Decryptval, "discriminator=", "&");
                       double serviceChargevalue = Convert.ToDouble(betweenStrings(Decryptval, "surcharge=", "&"));

                        Resudf1 = betweenStrings(Decryptval, "udf9=", "&");
                        Resudf2 = betweenStrings(Decryptval, "udf10=", "&");
                        Resudf3 = betweenStrings(Decryptval, "udf11=", "&");
                        //Resudf4 = betweenStrings(Decryptval, "udf12=", "&");
                        //Resudf5 = betweenStrings(Decryptval, "udf13=", "&");
                        string clientcode = betweenStrings(Decryptval, "clientcode=", "&");
                        //string respHashKey = "0d31d14960a3495cbf";
                        //  string respHashKey = "KEYRESP123657234";
                        string respHashKey = ResHashKey;
                        string ressignature = "";
                        string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
                        //string strsignature = postingmmp_txn + postingmer_txn1 + postingf_code + postingprod + discriminator + postinamount + postingbank_txn;
                        byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
                        byte[] b = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                        ressignature = byteToHexString(b).ToLower();
                        Random rm = new Random();
                        rid = rm.Next(10000000, 99999999);
                        if (postingf_code == "Ok") { status = "Success"; }
                        else if (postingf_code == "F") { status = "fail"; }
                        else { status = "cancel"; }
                        if (postingf_code == "Ok")
                        {
                            if (signature == ressignature)
                            {

                                tempid = Convert.ToInt32(Resudf1);

                                //DataTable dt2 = new DataTable();
                                //clientid = Resudf3;
                                //dt2 = clientBLL.GetClientByClientId(clientid);
                                //if (dt2.Rows.Count > 0)
                                //{
                                //    if (Session["DatabaseName"] == null)
                                //    {
                                //        Session["DatabaseName"] = dt2.Rows[0]["DatabaseName"].ToString();
                                //    }
                                //}
                                //instname = dt2.Rows[0]["InstituteName"].ToString();
                                int tempId = Convert.ToInt32(tempid);
                                bol.TransactionId = postingmmp_txn;
                                bol.ReferenceNumber = postingmer_txn;
                                dt1 = new DataTable();
                                dt1 = feeBLL.GetTempSubscriptionPaymentById(tempid);
                                if (dt1.Rows.Count > 0)
                                {

                                    bol.ReferenceNumber = dt1.Rows[0]["ReferenceNumber"].ToString();
                                    bol.TransactionDate = DateTime.Parse(dt1.Rows[0]["TransactionDate"].ToString());
                                    bol.Verified = Boolean.Parse(dt1.Rows[0]["Verified"].ToString());
                                    bol.ClientID = dt1.Rows[0]["ClientId"].ToString();
                                    bol.IsDesktopIncluded = Boolean.Parse(dt1.Rows[0]["IsDesktopIncluded"].ToString());
                                    bol.IsAndroidIncluded = Boolean.Parse(dt1.Rows[0]["IsAndroidIncluded"].ToString());
                                    bol.IsAMCIncluded = Boolean.Parse(dt1.Rows[0]["IsAMCIncluded"].ToString());
                                    bol.IsOnlinePaymentIncluded = Boolean.Parse(dt1.Rows[0]["IsOnlinePaymentIncluded"].ToString());
                                    bol.IsSMSIncluded = Boolean.Parse(dt1.Rows[0]["IsSMSIncluded"].ToString());
                                    bol.IsOnlineClassesIncluded = Boolean.Parse(dt1.Rows[0]["IsOnlineClassesIncluded"].ToString());

                                    bol.AndroidAmount = double.Parse(dt1.Rows[0]["AndroidAmount"].ToString());
                                    bol.AMCAmount = double.Parse(dt1.Rows[0]["AMCAmount"].ToString());
                                    bol.OnlinePaymentAmount = double.Parse(dt1.Rows[0]["OnlinePaymentAmount"].ToString());
                                    bol.SMSAmount = double.Parse(dt1.Rows[0]["SMSAmount"].ToString());
                                    bol.OnlineClassesAmount = double.Parse(dt1.Rows[0]["OnlineClassesAmount"].ToString());
                                    bol.TotalPaidAmount = double.Parse(dt1.Rows[0]["TotalPaidAmount"].ToString());
                                    bol.DateOfApproval = DateTime.Parse(dt1.Rows[0]["DateOfApproval"].ToString());
                                    bol.RenewalDate = DateTime.Parse(dt1.Rows[0]["RenewalDate"].ToString());
                                }
                                //addfield_bll bll2 = new addfield_bll();
                                //bol.startdate1 = DateTime.Now;

                                resultt = 0;

                                var amountInwords = "Rupees " + ConvertNumbertoWords(Convert.ToInt32(bol.TotalPaidAmount)) + " Only.";

                                bol.AmountInWords = amountInwords;
                                bol.ServiceCharge = (int)serviceChargevalue;
                                //bol.TransactionId=
                                resultt = feeBLL.InsertSubscriptionPaymentDetail(bol);
                                if (resultt > 0)
                                {
                                    int resultValue = feeBLL.UpdateClientSubscription(bol);
                                    if (resultValue > 0)
                                    {
                                        q = Resudf1 + "^" + Resudf3 + "^" + resultt.ToString();
                                        q = Encryptdata(q);
                                        Response.Redirect("SubscriptionPaymentReceipt.aspx?q=" + q, false);
                                    }
                                }
                            }
                            else
                            {
                                lblStatus.Text = "Signature Mismatched...";
                            }
                        }
                        else { lblStatus.Text = "transaction failed or cancelled..."; }
                    }
                }
            }

            catch (Exception ex)
            {

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
            //string passphrase = "75AEF0FA1B94B3C10D4F5B268F757F11";
            //string salt = "75AEF0FA1B94B3C10D4F5B268F757F11";
            string passphrase = ResAESKey;
            string salt = ResAESKey;
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int iterations = 65536;
            int keysize = 256;
            string plaintext = txt;
            string hashAlgorithm = "SHA1";
            // Encryptval = Encrypt(plaintext, passphrase, salt, iv, iterations);

            Decryptval = decrypt(plaintext, passphrase, salt, iv, iterations);
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
        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }

        public int getReceiptNumber(int applicationUserId)
        {
            rectNo = 0;
            DateTime currentDateTime = DateTime.Now;
            rectNo = feeBLL.GenerateReceiptNumber(currentDateTime, applicationUserId);
            return rectNo;

        }
        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}