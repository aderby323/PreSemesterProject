using System;
using System.Collections.Generic;

namespace PreSemesterProject.Models
{
    public class Volunteer
    {
        public string VolunteerID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        // public string PreferredCenters { get; set; }
        public PreferredCenter PreferredCenters { get; set; }
        public string SkillsAndInterests { get; set; }
        public string Availability { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string EmailAddress { get; set; }
        public string EducationalBackground { get; set; }
        public string CurrentLicenses { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyPhone { get; set; }
        public string EmergencyEmailAddress { get; set; }
        public bool DriversLicenseOnFile { get; set; }
        public bool SSCardOnFile { get; set; }
        public ApprovalStatus VolunteerApprovalStatus { get; set; }
        public bool Inactive { get; set; }

    }
}
