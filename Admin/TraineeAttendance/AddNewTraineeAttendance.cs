using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Admin.TraineeAttendance
{
    public class AddNewTraineeAttendance
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string TraineeName { get; set; }
        public string TraineeEmail { get; set; }
        public string Attandence { get; set; }
    }
}