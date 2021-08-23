using PreSemesterProject.Models.DBModels;
using System.Collections.Generic;

namespace PreSemesterProject.Models.ViewModels
{
    public class VolunteerMatchesVM
    {
        public List<Opportunity> Opportunities { get; set; }
        public string VolunteerUsername { get; set; }
    }
}
