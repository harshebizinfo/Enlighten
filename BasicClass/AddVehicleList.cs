using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class AddVehicleList
    {
        public int Id { get; set; }
        public int VehicleModeId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleDescription { get; set; }
        public string PickUpDriverName { get; set; }
        public string PickUpDriverAddress { get; set; }
        public string PickUpDriverContactNumber { get; set; }
        public string PickUpDriverAdhaarNumber { get; set; }
        public string DropDriverName { get; set; }
        public string DropDriverAddress { get; set; }
        public string DropDriverContactNumber { get; set; }
        public string DropDriverAdhaarNumber { get; set; }
        public Boolean IsActive { get; set; }
    }
}