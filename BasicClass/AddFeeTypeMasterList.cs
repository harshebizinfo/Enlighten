using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddFeeTypeMasterList
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public DateTime DueDate { get; set; }
        public int FeeNameMasterId { get; set; }
        public int LateFee { get; set; }
        public int FeeMonthId { get; set; }
        public Boolean IsActive { get; set; }
    }
}