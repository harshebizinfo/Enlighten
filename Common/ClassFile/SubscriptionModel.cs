using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Common.ClassFile
{
    public class SubscriptionModel
    {
        public string ClientID { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string AmountInWords { get; set; }
        public Boolean Verified { get; set; }
        public Boolean IsDesktopIncluded { get; set; }
        public Boolean IsAndroidIncluded { get; set; }
        public Boolean IsAMCIncluded { get; set; }
        public Boolean IsOnlinePaymentIncluded { get; set; }
        public Boolean IsSMSIncluded { get; set; }
        public Boolean IsOnlineClassesIncluded { get; set; }
        public double AndroidAmount { get; set; }
        public double AMCAmount { get; set; }
        public double OnlinePaymentAmount { get; set; }
        public double SMSAmount { get; set; }
        public double OnlineClassesAmount { get; set; }
        public double TotalPaidAmount { get; set; }
        public DateTime DateOfApproval { get; set; }
        public DateTime RenewalDate { get; set; }
        public int ServiceCharge { get; set; }
    }
}