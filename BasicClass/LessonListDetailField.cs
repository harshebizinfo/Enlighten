using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class LessonListDetailField
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public string LessonTitle { get; set; }
        public Boolean IsActive { get; set; }
    }
}