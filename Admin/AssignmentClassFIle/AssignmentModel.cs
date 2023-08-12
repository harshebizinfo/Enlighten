using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Admin.AssignmentClassFIle
{
    public class AssignmentModel
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string FilePath { get; set; }
    }
}