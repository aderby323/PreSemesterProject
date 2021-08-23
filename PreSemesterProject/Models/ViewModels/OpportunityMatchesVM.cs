using System.Collections.Generic;
using PreSemesterProject.Models.DBModels;

namespace PreSemesterProject.Models.ViewModels
{
    public class OpportunityMatchesVM
    {
        public List<Volunteer> Volunteers { get; set; }
        public string OpportunityTitle { get; set; }
    }
}
