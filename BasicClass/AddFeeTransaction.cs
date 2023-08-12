using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddFeeTransaction
    {
        public int Id { get; set; }
        public int FeeReceiptId { get; set; }
        public int ApplicationUserId { get; set; }
        public Decimal TotalFeeAmount { get; set; }
        public Decimal FineAmount { get; set; }
        public Decimal TotalDiscountAmount { get; set; }
        public Decimal TotalReceivedAmount { get; set; }
        public Decimal ServiceTax { get; set; }
        public string TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public string ReferenceNumber { get; set; }
        public int DepartmentId { get; set; }
        public string AmountInWords { get; set; }
    }
}