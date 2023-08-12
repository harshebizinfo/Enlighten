using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class CategoryMasterList
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Boolean IsActive { get; set; }
    }
}