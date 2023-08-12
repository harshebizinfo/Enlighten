using LMS.Admin.FeeClassFile;
using LMS.Common.ClassFile;
using LMS.SuperAdmin.ClientClassFile;
using Newtonsoft.Json.Linq;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Common
{
    public partial class RazorSubscriptionFundTransferSuccessNew : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        DataTable dt1;
        DataSet ds = new DataSet();
        SubscriptionModel bol = new SubscriptionModel();
        ClientBLL clientBLL = new ClientBLL();
        FeeBLL feeBLL = new FeeBLL();
        /*Variable Declaration*/
        string TranInqResponse, ResPaymentId, ResResult, ResErrorText, ResPosdate, ResTranId, ResAuth, ResAVR, ResAmount, ResErrorNo, ResTrackID, ResRef, okk, Resudf1, Resudf2, Resudf3, Resudf4, Resudf5;
        string postingmmp_txn, postingmer_txn, postinamount, postingprod, postingdate, postingbank_txn, postingf_code, postingbank_name, signature, postingdiscriminator, ipg_txn_id, description, bank_name;
        string strsqlquery = string.Empty;
        int q_id, tmpid;
        int rid;
        string q;
        static int resultt;
        string receipt = "", receiptDate;
        string regno, sname, mobileno, indosno, coursename, coursecommencedate, postponeamount, regisdate, attempt, sid, status;
        int tempid, results;
        string name, clientcode;
        Double amt;
        string Encryptval;
        string Decryptval;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    dt = new DataTable();
                    postinamount = "0";
                    postingmmp_txn = Request.QueryString["orderId"];
                    postingmer_txn = Request.QueryString["paymentId"];
                    signature = Request.QueryString["signature"];
                    string qry = Request.QueryString["qry"];
                    qry = Decryptdata(qry);
                    string[] info = qry.Split('^');
                    string _key = info[0];
                    string _secret = info[1];

                    Dictionary<string, string> attributes = new Dictionary<string, string>();

                    attributes.Add("razorpay_payment_id", postingmer_txn);
                    attributes.Add("razorpay_order_id", postingmmp_txn);
                    attributes.Add("razorpay_signature", signature);
                    description = signature;
                    try
                    {
                        Utils.verifyPaymentSignature(attributes);

                        RazorpayClient client = new RazorpayClient(_key, _secret);
                        Payment payment = client.Payment.Fetch(postingmer_txn);
                        var value = payment.Attributes.ToString();
                        JObject jObject = JObject.Parse(value);

                        var amount = (string)jObject["amount"];
                        postinamount = (decimal.Parse(amount) / 100).ToString();
                        var status2 = (string)jObject["status"];
                        var method = (string)jObject["method"];

                        postingdiscriminator = method;
                        JToken jUser = jObject["notes"];
                        name = (string)jUser["name"];
                        clientcode = name;
                        string transactionTrackId = (string)jUser["TranTrackid"];
                        var emailId = (string)jUser["email"];
                        var mobile = (string)jUser["mob"];
                        var sid = (string)jUser["sid"];
                        var totalfinalamount = (decimal)jUser["totalFinalAmount"];

                        //postingmmp_txn = betweenStrings(Decryptval, "mmp_txn=", "&");
                        //postingmer_txn = betweenStrings(Decryptval, "mer_txn=", "&");
                        ipg_txn_id = transactionTrackId;
                        // rid = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        if (status2 == "captured")
                        {
                            status = status2;
                            Resudf1 = sid;
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
                            bol.ServiceCharge = 0;// int.Parse(serviceChargevalue.ToString());
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
                            lblStatus.Text = "transaction failed or cancelled...";
                        }
                    }
                    catch (Exception exp)
                    {
                        //return exp;
                    }
                }
            }

            catch (Exception ex)
            {

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
        public string Encryptdata(string str)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
    }
}