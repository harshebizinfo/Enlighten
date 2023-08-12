using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class NoticeMasterList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoticeDescription { get; set; }
        public Boolean IsActive { get; set; }
    }
}