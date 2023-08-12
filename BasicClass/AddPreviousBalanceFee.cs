using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddPreviousBalanceFee
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int DepartmentStandardId { get; set; }
        public int DivisionId { get; set; }
        public double PreviousBalanceAmount { get; set; }
        public Boolean IsPaid { get; set; }
        public int CreatedBy { get; set; }
    }
}