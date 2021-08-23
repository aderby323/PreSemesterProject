using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class VolunteerEmergencyContact
    {
        public int VolunteerEmergencyId { get; set; }
        public int VolunteerId { get; set; }

        [Required(ErrorMessage = "You must provide a full name")]
        public string Ecname { get; set; }

        // Emergency contact needs at least one valid phone number to contact
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string EchomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string EcworkPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string EccellPhone { get; set; }

        // Not required, what if they don't have an email?
        [DataType(DataType.EmailAddress)]
        public string EcemailAddress { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}
