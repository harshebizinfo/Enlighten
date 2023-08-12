using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class CourseSubjectList
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public string CourseSubjectName { get; set; }
        public Boolean IsActive { get; set; }
    }
}