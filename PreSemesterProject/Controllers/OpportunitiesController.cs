using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using PreSemesterProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PreSemesterProject.Controllers
{
    [Authorize("Admin")]
    public class OpportunitiesController : Controller
    {

        //private List<Opportunity> _opportunities = new List<Opportunity>();
        private FakeRepository _fakeRepository;

        public OpportunitiesController(FakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }
        
        public IActionResult Index([FromQuery] string filter, string searchString)
        {
            ViewData["CurrentSearch"] = searchString;
            IEnumerable<Opportunity> opportunities = _fakeRepository.Opportunities;

            if (!string.IsNullOrEmpty(filter)) { filter.ToLower(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                opportunities = opportunities.Where(x => x.Title.Contains(searchString));
            }

            switch (filter)
            {
                case "recent":
                    Console.WriteLine("Showing recent opportunities");
                    opportunities = opportunities.Where(x => x.ModifiedOn > DateTime.UtcNow.AddDays(-60)).OrderBy(x => x.ModifiedOn);
                    break;
                case "location":
                    Console.WriteLine("Showing opportunities by location");
                    opportunities = opportunities.OrderBy(x => x.Location);
                    break;
                default:
                    Console.WriteLine("Showing opportunities");
                    opportunities = opportunities.OrderBy(x => x.OpportunityID);
                    break;
            }

            return View(opportunities.ToList());
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Opportunity opportunity = _fakeRepository.Opportunities.Where(x => x.OpportunityID == id).FirstOrDefault();

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
        public IActionResult Delete(string id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Add()
        {
            _fakeRepository.Opportunities.Add(new Opportunity
            {
                OpportunityID = Guid.NewGuid().ToString(),
                Title = "Test Opportunity",
                Description = "random word here",
                Location = "32256",
                ModifiedOn = DateTime.UtcNow
            });
            return RedirectToAction("Index");
        }
    }

}
