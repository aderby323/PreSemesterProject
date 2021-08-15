using System;

namespace PreSemesterProject.Models
{
    public class Opportunity
    {
        public string OpportunityID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public string Location { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
