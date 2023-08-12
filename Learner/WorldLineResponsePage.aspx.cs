using DotNetIntegrationKit;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.FeeClassFile;
using LMS.BasicClass;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
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

namespace LMS.Learner
{
    public partial class WorldLineResponsePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        DataTable dt1;
        DataSet ds = new DataSet();
        AddPayment bol = new AddPayment();
        ClientBLL clientBLL = new ClientBLL();
        FeeBLL feeBLL = new FeeBLL();
        DeptBLL deptBLL = new DeptBLL();
        PCBLL pcBLL = new PCBLL();
        string clientid,instname = "";
        string ReqHashKey, ResHashKey, ReqAESKey, ResAESKey, MerchantId, pass, Test, prodId, TranType,_key,_secret,_merchantCode,_IsKey,_IsIV;
        /*Variable Declaration*/
        string TranInqResponse, ResPaymentId, ResResult, ResErrorText, ResPosdate, ResTranId, ResAuth, ResAVR, ResAmount, ResErrorNo, ResTrackID, ResRef, okk, Resudf1, Resudf2, Resudf3, Resudf4, Resudf5;
        string postingmmp_txn, postingmer_txn, postinamount, postingprod, postingdate, postingbank_txn, postingf_code, postingbank_name, signature, postingdiscriminator, ipg_txn_id, description, bank_name;
        string strsqlquery = string.Empty;
        int q_id, tmpid;
        int rid;
        string q;
        static int rectNo, cnt;
        static int resultt;
        string receipt = "", receiptDate;
        string regno, sname, mobileno, indosno, coursename, coursecommencedate, postponeamount, regisdate, attempt, sid, status;
        int tempid, results;
        string name, clientcode;
        Double amt;
        string Encryptval;
        string Decryptval;
        #region Variable Declaration

        //		string str = "";
        //		string lskey = null, lsIv = null;
        //		String uuid = null;
        //		String strRequest = "";	
        //				string strPGActualReponse=PGResponse;
        string strHEX, strPGActualReponseWithChecksum, strPGActualReponseEncrypted, strPGActualReponseDecrypted, strPGresponseChecksum, strPGTxnStatusCode;
        //string strPGActualReponse="status=0300|amount=125.00|hash=3243453454353453";
        //string strPGActualReponse=PGResponse,strPGTxnStatusCode;
        string[] strPGChecksum, strPGTxnString;
        bool isDecryptable = false;

        string strPG_TxnStatus = string.Empty,
        strPG_ClintTxnRefNo = string.Empty,
        strPG_TPSLTxnBankCode = string.Empty,
        strPG_TPSLTxnID = string.Empty,
        strPG_TxnAmount = string.Empty,
        strPG_TxnDateTime = string.Empty,
        strPG_TxnDate = string.Empty,
        strPG_TxnTime = string.Empty;
        string strPGResponse;
        string[] strSplitDecryptedResponse;
        string[] strArrPG_TxnDateTime;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                q = Request.QueryString["q"];
                q = Decryptdata(q);
                string[] info = q.Split('^');
                clientid = info[0];
                Session["ClientID"] = clientid;
                getPGDetails();
                strPGResponse = Request["msg"].ToString();  //Reading response of PG

                if (strPGResponse != "" || strPGResponse != null)
                {
                    LBL_DisplayResult.Text = "Response :: " + strPGResponse;

                    RequestURL objRequestURL = new RequestURL();    //Creating Object of Class DotNetIntegration_1_1.RequestURL
                    string strDecryptedVal = null;                  //Decrypting the PG response

                    if (!String.IsNullOrEmpty(Convert.ToString(Session["PropertyFile"])))
                    {
                        string strFilePath = ConfigurationSettings.AppSettings["FilePath"];
                        string[] FilePath = strFilePath.Split('\\');
                        string MerchantCode = Convert.ToString(_merchantCode);
                        //strFilePath = FilePath[0] + "\\" + FilePath[2] + "\\" + MerchantCode + "\\" + FilePath[4];

                        strDecryptedVal = objRequestURL.VerifyPGResponse(strPGResponse, strFilePath);
                    }
                    else
                    {
                        string strIsKey = Convert.ToString(_IsKey);
                        string strIsIv = Convert.ToString(_IsIV);

                        strDecryptedVal = objRequestURL.VerifyPGResponse(strPGResponse, strIsKey, strIsIv);
                    }
                    lblResponseDecrypted.Text = strDecryptedVal;

                    if (strDecryptedVal.StartsWith("ERROR"))
                    {
                        lblValidate.Text = strDecryptedVal;
                    }
                    else
                    {
                        strSplitDecryptedResponse = strDecryptedVal.Split('|');
                        GetPGRespnseData(strSplitDecryptedResponse);

                        if (strPG_TxnStatus == "0300")
                        {
                            lblValidate.Text = "Transaction Success " + strPGTxnStatusCode;
                            storePaymentDetail();
                        }
                        else if (strPG_TxnStatus == "0200")
                        {
                            lblValidate.Text = "Transaction Success " + strPGTxnStatusCode;
                            storePaymentDetail();
                        }
                        else
                        {
                            strPGTxnString = strSplitDecryptedResponse[2].Split('=');
                            lblValidate.Text = "Transaction Fail " + "ERROR:" + strPGTxnString[1];
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
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
                _merchantCode = dt.Rows[0]["MerchantCode"].ToString();
                _IsKey = dt.Rows[0]["IsKey"].ToString();
                _IsIV = dt.Rows[0]["IsIv"].ToString();
                Session["ResHashKey"] = ResHashKey;
                Session["ResAESKey"] = ResAESKey;
            }
        }
        public void storePaymentDetail()
        {
            q = Request.QueryString["q"];
            q = Decryptdata(q);
            string[] info = q.Split('^');
            clientid = info[0];
            string resultId=info[1].ToString();
            status = lblValidate.Text;
            Resudf1 = resultId;
            tempid = Convert.ToInt32(Resudf1);
            Session["ClientID"] = clientid;
            getPGDetails();
            DataTable dt2 = new DataTable();
            //clientid = Resudf3;
            dt2 = clientBLL.GetClientByClientId(clientid);
            if (dt2.Rows.Count > 0)
            {
                if (Session["DatabaseName"] == null)
                {
                    Session["DatabaseName"] = dt2.Rows[0]["DatabaseName"].ToString();
                }
            }
            instname = dt2.Rows[0]["InstituteName"].ToString();
            int tempId = Convert.ToInt32(tempid);
            bol.TransactionId = strPG_TPSLTxnID;
            bol.ReferenceNumber = strPG_ClintTxnRefNo;
            dt1 = new DataTable();
            dt1 = feeBLL.GetTempPaymentDetailById(tempid);
            if (dt1.Rows.Count > 0)
            {

                bol.ApplicationUserId = int.Parse(dt1.Rows[0]["ApplicationUserId"].ToString());
                bol.StandardId = int.Parse(dt1.Rows[0]["StandardId"].ToString());
                bol.CategoryId = int.Parse(dt1.Rows[0]["CategoryId"].ToString());
                bol.TotalFee = Convert.ToDecimal(dt1.Rows[0]["TotalFee"].ToString());
                bol.LateFee = Convert.ToDecimal(dt1.Rows[0]["LateFee"].ToString());
                bol.GrandTotal = Convert.ToDecimal(dt1.Rows[0]["GrandTotal"].ToString());
                bol.T1 = dt1.Rows[0]["F1"].ToString();
                bol.T2 = dt1.Rows[0]["F2"].ToString();
                bol.T3 = dt1.Rows[0]["F3"].ToString();
                bol.T4 = dt1.Rows[0]["F4"].ToString();
                bol.T5 = dt1.Rows[0]["F5"].ToString();
                bol.T6 = dt1.Rows[0]["F6"].ToString();
                bol.T7 = dt1.Rows[0]["F7"].ToString();
                bol.T8 = dt1.Rows[0]["F8"].ToString();
                bol.T9 = dt1.Rows[0]["F9"].ToString();
                bol.T10 = dt1.Rows[0]["F10"].ToString();
                bol.T11 = dt1.Rows[0]["F11"].ToString();
                bol.T12 = dt1.Rows[0]["F12"].ToString();
                bol.T13 = dt1.Rows[0]["F13"].ToString();
                bol.T14 = dt1.Rows[0]["F14"].ToString();
                bol.T15 = dt1.Rows[0]["F15"].ToString();
                bol.T16 = dt1.Rows[0]["F16"].ToString();
                bol.T17 = dt1.Rows[0]["F17"].ToString();
                bol.T18 = dt1.Rows[0]["F18"].ToString();
                bol.T19 = dt1.Rows[0]["F19"].ToString();
                bol.T20 = dt1.Rows[0]["F20"].ToString();
                bol.T21 = dt1.Rows[0]["F21"].ToString();
                bol.T22 = dt1.Rows[0]["F22"].ToString();
                bol.T23 = dt1.Rows[0]["F23"].ToString();
                bol.T24 = dt1.Rows[0]["F24"].ToString();
                bol.T25 = dt1.Rows[0]["F25"].ToString();
            }
            //addfield_bll bll2 = new addfield_bll();
            //bol.startdate1 = DateTime.Now;
            int receiptId = getReceiptNumber(bol.ApplicationUserId);
            if (receiptId > 0)
            {
                resultt = 0;
                cnt = 0;

                int data = Convert.ToInt32(bol.GrandTotal);
                var amountInwords = "Rupees " + ConvertNumbertoWords(Convert.ToInt32(data)) + " Only.";
                AddFeeTransaction addFeeTransaction = new AddFeeTransaction();
                addFeeTransaction.ApplicationUserId = bol.ApplicationUserId;
                Session["ApplicationUserId"] = bol.ApplicationUserId;
                addFeeTransaction.DepartmentId = bol.StandardId;
                addFeeTransaction.TotalFeeAmount = bol.TotalFee;
                addFeeTransaction.FeeReceiptId = receiptId;
                addFeeTransaction.TotalDiscountAmount = 0;
                addFeeTransaction.TotalReceivedAmount = bol.GrandTotal;
                addFeeTransaction.ServiceTax = Convert.ToDecimal(0);
                addFeeTransaction.TransactionId = strPG_TPSLTxnID;
                addFeeTransaction.TransactionDate = DateTime.Now.ToString();
                addFeeTransaction.ReferenceNumber = strPG_ClintTxnRefNo;
                addFeeTransaction.DepartmentId = bol.StandardId;
                addFeeTransaction.AmountInWords = amountInwords;

                resultt = feeBLL.InsertFeeTransactionOnline(addFeeTransaction);
                if (resultt > 0)
                {
                    DataTable departmentId = new DataTable();
                    departmentId = deptBLL.GetStudentInformationListByApplicationUserId();
                    int classId = 0;
                    int academicYearId = 0;
                    string admissionNumber = "";
                    if (departmentId.Rows.Count > 0)
                    {
                        classId = int.Parse(departmentId.Rows[0]["ClassId"].ToString());
                        academicYearId = int.Parse(departmentId.Rows[0]["AcademicYearId"].ToString());
                        admissionNumber = departmentId.Rows[0]["AdmissionNumber"].ToString();
                    }
                    bol.AdmissionNumber = admissionNumber;
                    bol.AcademicYearId = academicYearId;

                    dt2 = new DataTable();
                    dt2 = feeBLL.GetFeeDetails(bol);
                    results = dt2.Rows.Count;
                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            FeeTransactionDetail feeTransactionDetail = new FeeTransactionDetail();
                            feeTransactionDetail.FeeReceiptId = receiptId;
                            feeTransactionDetail.DepartmentId = bol.StandardId;
                            feeTransactionDetail.FeeMonth = dt2.Rows[i]["FeeMonth"].ToString();
                            feeTransactionDetail.FeeName = dt2.Rows[i]["FeeName"].ToString();
                            feeTransactionDetail.FeeAmount = Convert.ToDecimal(dt2.Rows[i]["FeeNameAmount"].ToString());
                            feeTransactionDetail.FeeStructureId = int.Parse(dt2.Rows[i]["FeeStructureId"].ToString());
                            int resul = feeBLL.InsertFeeTransactionDetail(feeTransactionDetail);
                            if (resul > 0)
                            {
                                cnt++;
                            }

                        }
                    }
                    if (cnt == results)
                    {
                        q = Resudf1 + "^" + clientid + "^" + receiptId.ToString();
                        q = Encryptdata(q);
                        Response.Redirect("OnlinePaymentReceipt.aspx?q=" + q, false);
                        // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Dumped.');", true);
                    }
                }

            }
        }
        public void GetPGRespnseData(string[] parameters)
        {

            string[] strGetMerchantParamForCompare;

            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_REF")
                {
                    strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_BANK_CD")
                {
                    strPG_TPSLTxnBankCode = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_ID")
                {
                    strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMT")
                {
                    strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_TIME")
                {
                    strPG_TxnDateTime = Convert.ToString(strGetMerchantParamForCompare[1]);
                    strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                    strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                    strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
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