using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemesterProject.Models
{
    public class Opportunity
    {

        public int OpportunityID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public string Location { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
