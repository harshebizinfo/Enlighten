using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class FeeMonthMasterList
    {
        public int Id { get; set; }
        public string FeeMonth { get; set; }
        public string FeeMonthType { get; set; }
        public int NumberOfMonth { get; set; }
        public Boolean IsActive { get; set; }
    }
}