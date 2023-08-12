using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class TransportFeeList
    {
        public int Id { get; set; }
        public int AreaMasterId { get; set; }
        public int VehicleModeId { get; set; }
        public int TransportAmount { get; set; }
        public Boolean IsActive { get; set; }
    }
}