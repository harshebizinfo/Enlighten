using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.ClientClassFile
{
    public class AddNewClientDetail
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string CountryCode { get; set; }
        public string ContactNumber { get; set; }
        public string InstituteName { get; set; }
        public string LogoPath { get; set; }
        public string Address { get; set; }
        public int ApplicationUserId { get; set; }
        public int PaymentTypeId { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsGoogleSubscription { get; set; }
    }
}