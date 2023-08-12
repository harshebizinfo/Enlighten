using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class ComplaintListModel
    {
        public int Id { get; set; }
        public int StreamId { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
        public string AdmissionNumber { get; set; }
        public string Complaint { get; set; }
        public string StepTaken { get; set; }
    }
}