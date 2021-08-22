using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class VolunteerEmergencyContact
    {
        public int VolunteerEmergencyId { get; set; }
        public int VolunteerId { get; set; }
        public string Ecname { get; set; }
        public string EchomePhone { get; set; }
        public string EcworkPhone { get; set; }
        public string EccellPhone { get; set; }
        public string EcemailAddress { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
