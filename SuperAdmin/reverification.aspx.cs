using LMS.Admin.DepartmentClassFile;
using LMS.Admin.FeeClassFile;
using LMS.BasicClass;
using LMS.Learner.PaymentCLassFile;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class reverification : System.Web.UI.Page
    {
        ClientBLL clientBll = new ClientBLL();
        PaymentBLL paymentBLL = new PaymentBLL();
        PCBLL pcBLL = new PCBLL();
        DeptBLL deptBLL = new DeptBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        string ReqHashKey, ResHashKey, ReqAESKey, ResAESKey, MerchantId, pass, Test, prodId, TranType,_key,_secret;
        string postingmmp_txn, postingmer_txn, postinamount, postingprod, postingdate, postingbank_txn, postingf_code, postingbank_name, signature, postingdiscriminator, ipg_txn_id, description, Resudf1, Resudf2, Resudf3, Resudf4, Resudf5, status;
        static decimal serviceCharge1;
        string Encryptval;
        string Decryptval;
        static int resultt, cnt, rectNo, results;
        static DataTable dt1, dt2;
        AddPayment bol = new AddPayment();
        FeeBLL feeBLL = new FeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindClient();
                Button9.Visible = false;
            }
            Button9.Visible = false;
        }
        public void bindClient()
        {
            DataTable dt = new DataTable();
            dt = clientBll.GetAllClient();
            ddlClient.DataSource = dt;
            ddlClient.DataBind();
            ddlClient.DataTextField = "ClientName";
            ddlClient.DataValueField = "DatabaseName";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["DatabaseName"] = ddlClient.SelectedValue.ToString();
            BindReverificationGrid();
            Button9.Visible = true;
        }
        public void BindReverificationGrid()
        {
            DataTable dt = new DataTable();
            dt = paymentBLL.GetAllTempPaymentDetail();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindReverificationGrid();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
            }
        }
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = paymentBLL.GetAllTempPaymentDetail();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "ApplicationUserId LIKE '%" + search + "%' OR ReferenceNumber LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%'  OR GrandTotal LIKE '%" + search + "%' OR FullName LIKE '%" + search + "%' OR TransactionDate LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    string search = txtSearch.Text;
        //    DataTable dt = new DataTable();
        //    dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartmentStandard.SelectedValue));
        //    DataView DataView = dt.DefaultView;
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
        //        DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'"; ;
        //    }
        //    GridView1.DataSource = DataView;
        //    GridView1.DataBind();
        //}

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=NotVerifiedPaymentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='7' align='center'><font size='7'>" + ddlClient.SelectedItem.ToString() + " Reverification List</font></td></tr>                                        <tr><td colspan='7'></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(sw.ToString());
            string footerTable = @"<Table><tr><td colspan='7'></td></tr><tr><td colspan='3' align='left'><b>Report By :</b>" + userName + "</td><td></td><td colspan='3' align='right'><b>Date :</b>" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr></Table>";
            Response.Write(footerTable);
            Response.End();
        }
        private void PrepareGridViewForExport(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string newclientId =ddlClient.SelectedValue.ToString();
            int paymenttypeId=0;
            DataTable clientdt=new DataTable();
            clientdt = clientBll.GetClientByClientId(newclientId);
            if (clientdt.Rows.Count > 0)
            {
                paymenttypeId = clientdt.Rows[0]["PaymentType"].ToString() == "" ? 0 : int.Parse(clientdt.Rows[0]["PaymentType"].ToString());
            }
            if (paymenttypeId > 0)
            {
                if (paymenttypeId == 1)
                {
                    verifyreferencenumber();
                }
                else if (paymenttypeId == 2)
                {
                    verifyReferenceNumberRazor();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration is not configured properly')", true);
            }
        }
        public void verifyReferenceNumberRazor()
        {

        }
        public void getPGDetails()
        {

            DataTable dt = new DataTable();
            Session["ClientID"] = ddlClient.SelectedValue.ToString();
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
        public void verifyreferencenumber()
        {
            getPGDetails();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label lblreference = (Label)row.FindControl("lblreferencenumber");
                Label lblamount = (Label)row.FindControl("lbltotalfeeofcourse");
                Label lbltransactiondate = (Label)row.FindControl("lbltransactiondate");
                Label lblid = (Label)row.FindControl("lblid");
                try
                {
                    var login = MerchantId;
                    var merchantId = MerchantId;
                    var merchantTxnID = lblreference.Text;

                    var AMT = lblamount.Text;
                    var transactionDate = DateTime.Parse(lbltransactiondate.Text).ToString("yyyy-MM-dd");//().DateTime.Parse(lbltransactiondate.Text).Date;
                    string str = "merchantid=" + merchantId + "&merchanttxnid=" + merchantTxnID + "&amt=" + AMT + "&tdate=" + transactionDate + "";
                    string enc = null;
                    // encdec(str);
                    //string url = "https://paynet.atomtech.in/paynetz/vftsv2?login=9132&encdata=" + Encryptval;
                    string url = "https://payment.atomtech.in/paynetz/vfts?" + str;
                    var responseString = callurl(url);
                    var newstring = responseString.ToString();
                    responseString = responseString.Remove(0, 40);

                    ReverificationResponse reverificationResponse = new ReverificationResponse();
                    reverificationResponse.MerchantID = betweenStrings(responseString, "MerchantID=\"", "\" MerchantTxnID");
                    reverificationResponse.MerchantTxnID = betweenStrings(responseString, "MerchantTxnID=\"", "\" AMT");
                    reverificationResponse.Amt = betweenStrings(responseString, "AMT=\"", "\" VERIFIED").ToString();
                    reverificationResponse.Verified = betweenStrings(responseString, "VERIFIED=\"", "\" BID");
                    reverificationResponse.StatusCode = "";
                    reverificationResponse.Desc = "";
                    reverificationResponse.Bid = betweenStrings(responseString, "BID=\"", "\" bankname");
                    reverificationResponse.BankName = betweenStrings(responseString, "bankname=\"", "\" atomtxnId");
                    reverificationResponse.AtomTxnId = betweenStrings(responseString, "atomtxnId=\"", "\" discriminator");
                    reverificationResponse.Discriminator = betweenStrings(responseString, "discriminator=\"", "\" surcharge");
                    reverificationResponse.Surcharge = betweenStrings(responseString, "surcharge=\"", "\" CardNumber");
                    reverificationResponse.CardNumber = betweenStrings(responseString, "CardNumber=\"", "\" TxnDate");
                    reverificationResponse.TxnDate = betweenStrings(responseString, "TxnDate=\"", "\" UDF9");
                    reverificationResponse.Udf9 = betweenStrings(responseString, "UDF9=\"", "\" reconstatus");
                    reverificationResponse.ReconStatus = betweenStrings(responseString, "reconstatus=\"", "\" sdt");
                    reverificationResponse.Sdt = betweenStrings(responseString, "=\"", "\" sdt");

                    //encdec1(responseString);
                    if (responseString != null)//Decryptval
                    {
                        //var myDetails = JsonConvert.DeserializeObject<ResponseJsonValue>(jsonText);//Decryptval
                        var databaseName = "";
                        databaseName = ddlClient.SelectedItem.ToString();
                        bol.ReferenceNumber = reverificationResponse.MerchantTxnID;
                        paymentBLL.updatePaymentTempverifiedstatus(bol.ReferenceNumber);
                        if (reverificationResponse.Verified == "SUCCESS")
                        {
                            if (reverificationResponse.MerchantTxnID != null)
                            {
                                if (paymentBLL.get_if_paymentreferenceid_exist(bol.ReferenceNumber) == 0)
                                {
                                    var tempid = int.Parse(lblid.Text);
                                    int result = insertintoPaymentTables(tempid,
                                        databaseName,
                                        reverificationResponse.MerchantID,
                                        reverificationResponse.MerchantTxnID,
                                        reverificationResponse.BankName,
                                        reverificationResponse.Discriminator,
                                        reverificationResponse.TxnDate,
                                        reverificationResponse.Surcharge);
                                    if (result > 0)
                                    {
                                        Label lblstatus = (Label)row.FindControl("lblstatus");
                                        lblstatus.Text = "Successfully Verified and inserted in database.";
                                    }
                                    else
                                    {
                                        Label lblstatus = (Label)row.FindControl("lblstatus");
                                        lblstatus.Text = "Database Insert Failure.";
                                    }
                                }
                                else
                                {
                                    Label lblstatus = (Label)row.FindControl("lblstatus");
                                    lblstatus.Text = "Already exists in database." + reverificationResponse.MerchantTxnID;
                                }
                            }
                            else
                            {
                                Label lblstatus = (Label)row.FindControl("lblstatus");
                                lblstatus.Text = reverificationResponse.Verified;
                            }
                        }
                        else if (reverificationResponse.Verified != "SUCCESS")
                        {
                            Label lblstatus = (Label)row.FindControl("lblstatus");
                            lblstatus.Text = reverificationResponse.Verified;
                        }
                        //       checkandinsertdata(row);
                        System.Threading.Thread.Sleep(300);
                    }
                    else
                    {
                        Label lblstatus = (Label)row.FindControl("lblstatus");
                        lblstatus.Text = "Invalid Reference ID." + bol.TransactionId;
                    }
                }
                catch (Exception ex)
                {
                    //ClsLogging.writefileE("Error:" + ex.Message, ClsLogging.LogType.Worldline);
                    //ClsLogging.writefileE("Trace:" + ex.StackTrace, ClsLogging.LogType.Worldline);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
                    //lblmessage.ForeColor = System.Drawing.Color.Red;
                    //lblmessage.Text = "There Was Some Error Processing.....Please Check The Data you have Entered";
                }
            }
        }
        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
        public string callurl(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers
            var client = new WebClient();
            var content = client.DownloadString(url);
            return content;
        }
        public void encdec1(string txt)
        {
            string passphrase = Session["ResAESKey"].ToString();//"75AEF0FA1B94B3C10D4F5B268F757F11";
            string salt = Session["ResAESKey"].ToString();//"75AEF0FA1B94B3C10D4F5B268F757F11";
            //string passphrase = "A804011E3A690585E57C81B0D0004B31";
            //string salt = "A804011E3A690585E57C81B0D0004B31";
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int iterations = 65536;
            int keysize = 256;
            string plaintext = txt;
            string hashAlgorithm = "SHA1";
            // Encryptval = Encrypt(plaintext, passphrase, salt, iv, iterations);

            Decryptval = decrypt(plaintext, passphrase, salt, iv, iterations);
        }
        public async Task<string> paymentAPI(string url)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res != null) { }
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                    return EmpResponse;
                }
                //returning the employee list to view
                // return View(EmpInfo);
            }
            return "";
        }
        public int insertintoPaymentTables(int tempid, string databaseName, string referncenumber, string transaction, string bankName, string discriminator, string transactionDate,string surplusCharge)
        {
            dt1 = new DataTable();
            bol.tempid = tempid;
            bol.TransactionId = transaction;
            bol.ReferenceNumber = referncenumber;
            bol.BankName = bankName;
            bol.Discriminator = discriminator;
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
            // addfield_bll bll2 = new addfield_bll();
            bol.startdate1 = DateTime.Now;
            bol.receiptid = getReceiptNumber(bol.ApplicationUserId);
            if (bol.receiptid > 0)
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
                addFeeTransaction.FeeReceiptId = bol.receiptid;
                addFeeTransaction.TotalDiscountAmount = 0;
                addFeeTransaction.TotalReceivedAmount = bol.GrandTotal;
                addFeeTransaction.ServiceTax = Convert.ToDecimal(surplusCharge);
                addFeeTransaction.TransactionId = bol.TransactionId;
                addFeeTransaction.TransactionDate = transactionDate;
                addFeeTransaction.ReferenceNumber = bol.ReferenceNumber;
                addFeeTransaction.DepartmentId = bol.StandardId;
                addFeeTransaction.AmountInWords = amountInwords;

                bol.AmtInWord = amountInwords;
                // bol.receiptid = receiptId;
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
                            feeTransactionDetail.FeeReceiptId = bol.receiptid;
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
                        return 1;
                    }
                }

            }
            return 0;
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
        public void encdec(string txt)
        {
            string passphrase = ReqAESKey;// "A4476C2062FFA58980DC8F79EB6A799E";
            string salt = ReqAESKey;// "A4476C2062FFA58980DC8F79EB6A799E";
            byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int iterations = 65536;
            int keysize = 256;
            string plaintext = txt;
            string hashAlgorithm = "SHA1";
            Encryptval = Encrypt(plaintext, passphrase, salt, iv, iterations);

            Decryptval = decrypt(Encryptval, passphrase, salt, iv, iterations);
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
    }
}