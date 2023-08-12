using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Learner.BasicClass
{
    public class TempPaymentDetailField
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public int ExamId { get; set; }
        public int ApplicationUserId { get; set; }
        public int PaymentNumberOfTimes { get; set; }
        public string ReferenceNumber { get; set; }
        public string ClientId { get; set; }
        public DateTime TransactionDate { get; set; }
        public Boolean Verified { get; set; }
    }
}