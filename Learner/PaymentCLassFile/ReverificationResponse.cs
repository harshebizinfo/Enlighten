using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Learner.PaymentCLassFile
{
    public class ReverificationResponse
    {
        public string MerchantID { get; set; }
        public string MerchantTxnID { get; set; }
        public string Amt { get; set; }
        public string Verified { get; set; }
        public string StatusCode { get; set; }
        public string Desc { get; set; }
        public string Bid { get; set; }
        public string BankName { get; set; }
        public string AtomTxnId { get; set; }
        public string Discriminator { get; set; }
        public string Surcharge { get; set; }
        public string CardNumber { get; set; }
        public string TxnDate { get; set; }
        public string Udf9 { get; set; }
        public string ReconStatus { get; set; }
        public string Sdt { get; set; }
    }
}