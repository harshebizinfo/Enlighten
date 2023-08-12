using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Admin.ClassFile
{
    public class CalenderEvent
    {
        public string EventId { get; set; }
        public string Summary { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MeetLink { get; set; }
    }
}