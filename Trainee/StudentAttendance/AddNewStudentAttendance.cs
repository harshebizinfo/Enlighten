using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Trainee.StudentAttendance
{
    public class AddNewStudentAttendance
    {
        public int Id { get; set; }
        public int StandardId { get; set; }
        public int DivisionId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public int ApplicationUserId { get; set; }
        public string StudentName { get; set; }
        public string Attandence { get; set; }
    }
}