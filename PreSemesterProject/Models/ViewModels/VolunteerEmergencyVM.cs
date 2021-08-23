using PreSemesterProject.Models.DBModels;

namespace PreSemesterProject.Models.ViewModels
{
    public class VolunteerEmergencyVM
    {
        public int VolunteerID { get; set; }

        public VolunteerEmergencyContact Contact { get; set; }
    }
}
