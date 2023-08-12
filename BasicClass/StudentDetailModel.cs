using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.BasicClass
{
    public class StudentDetailModel
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
        public string Language { get; set; }
        public string Nationality { get; set; }
        public int TehseelId { get; set; }
        public int CityId { get; set; }
        public string PrevSchoolName { get; set; }
        public int PrevStreamId { get; set; }
        public int PrevClassId { get; set; }
        public int PrevMediumId { get; set; }
        public double PrevMarks { get; set; }
        public double PrevTotalMarks { get; set; }
        public string PrevAddress { get; set; }
        public string FatherPhone { get; set; }
        public int FatherEducationId { get; set; }
        public int FatherOccupationId { get; set; }
        public string FatherAddress { get; set; }
        public string MotherName { get; set; }
        public string MotherPhone { get; set; }
        public int MotherEducationId { get; set; }
        public int MotherOccupationId { get; set; }
        public string MotherAddress { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianRelationShip { get; set; }
        public string GuardianAddress { get; set; }
        public int DocumentsId { get; set; }
        public Boolean IsPreviousSchoolIncluded { get; set; }
        public Boolean IsSibilingsIncluded { get; set; }
        public string AdmissionNumber { get; set; }
    }
}