using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddConveyanceMonthForStudent
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int StandardId { get; set; }
        public int DivisionId { get; set; }
        public int MonthId { get; set; }
        public Boolean IsActive { get; set; }

    }
}