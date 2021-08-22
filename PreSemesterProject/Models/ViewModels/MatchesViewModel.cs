using System.Collections.Generic;
using PreSemesterProject.Models.DBModels;

namespace PreSemesterProject.Models.ViewModels
{
    public class MatchesViewModel
    {
        public List<DBModels.Volunteer> Volunteers { get; set; }
        public string OpportunityTitle { get; set; }
    }
}
