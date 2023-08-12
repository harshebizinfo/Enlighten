using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Trainee.BasicClass
{
    public class Question
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public int CourseSubjectId { get; set; }
        public int ExamId { get; set; }
        public string QuestionToAsk { get; set; }
        public string QuestionOptionMetadata { get; set; }
        public string CorrectOption { get; set; }
        public int QuestionAnswerTypeId { get; set; }
        public int Marks { get; set; }
        public Boolean IsRequired { get; set; }
        public int ValidationAnswerTypeId { get; set; }
        public int ValidationAnswerId { get; set; }
        public string ValueToCompare { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string ErrorMessage { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
    }
}