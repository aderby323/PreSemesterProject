using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            VolunteerAddresses = new HashSet<VolunteerAddress>();
            VolunteerEmergencyContacts = new HashSet<VolunteerEmergencyContact>();
        }

        public int VolunteerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PreferredCenter PreferredCenter { get; set; }
        public string SkillsAndInterests { get; set; }
        public string Availability { get; set; }
        public string EducationBackground { get; set; }
        public string CurrentLicenses { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public bool DlonFile { get; set; }
        public bool SsonFile { get; set; }
        public string ApprovalStatus { get; set; }

        public virtual ICollection<VolunteerAddress> VolunteerAddresses { get; set; }
        public virtual ICollection<VolunteerEmergencyContact> VolunteerEmergencyContacts { get; set; }
    }
}
