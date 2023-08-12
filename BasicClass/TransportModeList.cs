using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class TransportModeList
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string VehicleName { get; set; }
        public Boolean IsActive { get; set; }
    }
}