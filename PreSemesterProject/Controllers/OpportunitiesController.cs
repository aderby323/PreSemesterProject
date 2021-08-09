using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemesterProject.Controllers
{
    public class OpportunitiesController : Controller
    {

        private List<Opportunity> _opportunities = new List<Opportunity>();
        
        public IActionResult Index()
        {
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 1,
                Title = "Opportunity 1",
                Description = "This is the first opportunity. There isn't much to do but that's ok! :)",
                Location = "Avenues",
                ModifiedOn = DateTime.UtcNow
            });
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 2,
                Title = "Opportunity 2",
                Description = "This is the second opportunity. Just another plain ol opportunity",
                Location = "UNF",
                ModifiedOn = DateTime.UtcNow.AddDays(3)
            }); ;
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 3,
                Title = "Opportunity 3",
                Description = "This is the third opportunity. Yet another opportunity for a time of thrills and things and such.",
                Location = "Southside",
                ModifiedOn = DateTime.UtcNow.AddHours(5)
            });
            return View(_opportunities);
        }
    }
}
