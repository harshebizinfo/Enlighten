using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Learner.BasicClass
{
    public class ExamAnswerLog
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int QuestionId { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public int ExamId { get; set; }
        public string Answer { get; set; }
        public int Marks { get; set; }
        public int SequenceNumber { get; set; }
    }
}