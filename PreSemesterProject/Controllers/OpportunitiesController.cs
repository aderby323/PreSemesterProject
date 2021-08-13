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

        public OpportunitiesController()
        {
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 1,
                Title = "Opportunity 1",
                Description = "This is the first opportunity. There isn't much to do but that's ok! :)",
                Location = "Avenues",
                ModifiedOn = new DateTime(2021,8,2)
            });
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 2,
                Title = "Opportunity 2",
                Description = "This is the second opportunity. Just another plain ol opportunity",
                Location = "UNF",
                ModifiedOn = new DateTime(2021, 6, 9)
            });
            _opportunities.Add(new Opportunity()
            {
                OpportunityID = 3,
                Title = "Opportunity 3",
                Description = "This is the third opportunity. Yet another opportunity for a time of thrills and things and such.",
                Location = "Southside",
                ModifiedOn = new DateTime(2020,1,4)
            });
        }
        
        public IActionResult Index()
        {
            return View(_opportunities);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Opportunity opportunity = _opportunities.Where(x => x.OpportunityID == id).FirstOrDefault();

            if(opportunity is null) { return NotFound($"Opportunity with ID: {id} not found."); }

            return View(opportunity);
        }

        [HttpPost]
        public IActionResult Edit(Opportunity opportunity)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            return Ok(opportunity);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }
    }

}
