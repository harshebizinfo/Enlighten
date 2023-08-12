using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Common.ClassFile
{
    public class AddUser: ClientDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHashKey { get; set; }
        public string PasswordSaltKay { get; set; }
        public string MobileNumber { get; set; }
    }
}