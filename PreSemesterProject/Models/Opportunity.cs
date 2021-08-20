using PreSemesterProject.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace PreSemesterProject.Models
{
    public class Opportunity
    {
        public string OpportunityID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string Description { get; set; }

        [Required]
        [ZipCode]
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
