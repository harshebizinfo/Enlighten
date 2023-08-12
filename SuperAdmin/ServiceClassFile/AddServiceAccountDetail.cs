using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.ServiceClassFile
{
    public class AddServiceAccountDetail
    {
        public int Id { get; set; }
        public string ServiceAccountEmail { get; set; }
        public string UserEmail { get; set; }
        public string PrivateKey { get; set; }
        public int ClientId { get; set; }
        public string FilePath { get; set; }
        public Boolean IsActive { get; set; }
    }
}