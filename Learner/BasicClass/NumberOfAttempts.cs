using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Learner.BasicClass
{
    public class NumberOfAttempts
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public int ExamId { get; set; }
        public int NumberOfAttempt { get; set; }
        public string CreatedOn { get; set; }
        public string NoOfAttempts { get; set; }
    }
}