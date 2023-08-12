using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddStudentInDepartment
    {
        public int Id { get; set; }
        public int DepartmentStandardId { get; set; }
        public int ApplicationUserId { get; set; }
        public Boolean IsDeleted { get; set; }
        public int DivisionId { get; set; }
        public int CategoryId { get; set; }
        public int AreaId { get; set; }
        public Boolean HasConveyance { get; set; }
        public int ModeId { get; set; }
        public string PickUpVehicleNumber { get; set; }
        public string DropVehicleNumber { get; set; }
        public int PickUpVehicleId { get; set; }
        public int DropVehicleId { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsOneWayTrip { get; set; }
    }
}