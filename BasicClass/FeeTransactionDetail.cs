using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class FeeTransactionDetail
    {
        public int Id { get; set; }
        public int FeeReceiptId { get; set; }
        public int DepartmentId { get; set; }
        public string FeeMonth { get; set; }
        public string FeeName { get; set; }
        public int FeeStructureId { get; set; }
        public Decimal FeeAmount { get; set; }
        public int CreatedBy { get; set; }
    }
}