using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class ClientPaymentConfiguration
    {
        public int Id { get; set; }
        public string PaymentGateWay { get; set; }
        public string ClientId { get; set; }
        public string PaymentPassword { get; set; }
        public string MerchantId { get; set; }
        public Boolean IsActive { get; set; }
        public string RequestHashKey { get; set; }
        public string ResponseHashKey { get; set; }
        public string RequestAESKey { get; set; }
        public string ResponseAESKey { get; set; }
        public string TransactionType { get; set; }
        public string ProductId { get; set; }
        public string RazorKey { get; set; }
        public string RazorSecretKey { get; set; }
        public string MerchantCode { get; set; }
        public string IsKey { get; set; }
        public string IsIv { get; set; }

    }
}