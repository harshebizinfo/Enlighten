using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string FatherName { get; set; }
        public string FatherContactNumber { get; set; }
        public string PresentAddess { get; set; }
        public string PresentCity { get; set; }
        public string PresentState { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string Gender { get; set; }
        public string AdhaarCardNumber { get; set; }
        public string PANCardNumber { get; set; }
        public string PasswordHashKey { get; set; }
        public string PasswordSaltKey { get; set; }
        public int NumberOfAttempts { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedOn { get; set; }
        public Boolean IsDeleted { get; set; }
        public string ClientId { get; set; }
    }
}