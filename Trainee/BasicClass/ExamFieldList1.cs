using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Trainee.BasicClass
{
    public class ExamFieldList1
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public string ExamName { get; set; }
        public Boolean IsActive { get; set; }
    }
}