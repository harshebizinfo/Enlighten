using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Admin.ClassFile
{
    public class ListOfPlayList
    {
        public string PlayListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PublishedAt { get; set; }
        public long? Position { get; set; }
    }
}