using System;
using System.Collections.Generic;

#nullable disable

namespace PreSemesterProject.Models.DBModels
{
    public partial class Opportunity
    {
        public int OpportunityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
