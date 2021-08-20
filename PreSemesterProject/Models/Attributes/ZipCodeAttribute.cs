using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PreSemesterProject.Models.Attributes
{
    public class ZipCodeAttribute : ValidationAttribute
    {
        public ZipCodeAttribute() { }

        Regex Regex = new Regex("^(?!0{3})[0-9]{3,5}$");

        public string NewErrorMessage(string zip) =>
            $"{zip} is not a valid United States zip code";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Opportunity opportunity = (Opportunity)validationContext.ObjectInstance;

            if (opportunity is null || opportunity.Location is null) { return new ValidationResult("Zip code is required."); }

            if (Regex.IsMatch(opportunity.Location) && opportunity.Location.Length == 5)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(NewErrorMessage(opportunity.Location));
        }
    }
}
