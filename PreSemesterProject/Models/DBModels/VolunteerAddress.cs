using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class VolunteerAddress
    {
        public int VolunteerAddressId { get; set; }
        public int VolunteerId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
