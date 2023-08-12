using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Common.ClassFile
{
    public class ClientDetail
    {
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string EmailID { get; set; }
        public string CountryCode { get; set; }
        public string ContactNumber { get; set; }
        public string InstituteName { get; set; }
        public string LogoPath { get; set; }
        public string Address { get; set; }
        public string DatabaseName { get; set; }
        public bool DatabaseIsActive { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}