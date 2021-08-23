using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models.DBModels;
using PreSemesterProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using PreSemesterProject.Models;

namespace PreSemesterProject.Controllers
{
    [Authorize("Admin")]
    public class OpportunitiesController : Controller
    {

        private readonly VolunteerManagementSystemContext _context;

        public OpportunitiesController(VolunteerManagementSystemContext context)
        {
            _context = context;
        }
        
        public IActionResult Index([FromQuery] string filter, string searchString)
        {
            ViewData["CurrentSearch"] = searchString;
            IEnumerable<Opportunity> opportunities = _context.Opportunities;

            if (!string.IsNullOrEmpty(filter)) { filter.ToLower(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                opportunities = opportunities.Where(x => x.Title.ToLower().Contains(searchString.ToLower()));
            }

            switch (filter)
            {
                case "recent":
                    Console.WriteLine("Showing recent opportunities");
                    opportunities = opportunities.Where(x => x.Date > DateTime.UtcNow.AddDays(-60)).OrderBy(x => x.Date);
                    break;
                case "location":
                    Console.WriteLine("Showing opportunities by location");
                    opportunities = opportunities.OrderBy(x => x.Location);
                    break;
                default:
                    Console.WriteLine("Showing opportunities");
                    opportunities = opportunities.OrderBy(x => x.OpportunityId);
                    break;
            }

            return View(opportunities.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Opportunity opportunity = _context.Opportunities.Where(x => x.OpportunityId == id).FirstOrDefault();

            if (opportunity is null) { return NotFound($"Opportunity with ID: {id} not found."); }

            return View(opportunity);
        }

        [HttpPost]
        public IActionResult Edit(Opportunity opportunity)
        {
            if (!ModelState.IsValid) { return View(opportunity); }

            Opportunity oldOpportunity = _context.Opportunities.Where(x => x.OpportunityId == opportunity.OpportunityId).FirstOrDefault();

            oldOpportunity.Title = opportunity.Title;
            oldOpportunity.Description = opportunity.Description;
            oldOpportunity.Date = opportunity.Date;
            oldOpportunity.Location = opportunity.Location;

            _context.Update(oldOpportunity);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Opportunity opportunity = _context.Opportunities.Where(x => x.OpportunityId == id).FirstOrDefault();

            if (opportunity is null) { return NotFound($"Opportunity with ID: {id} not found."); }

            _context.Opportunities.Remove(opportunity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Opportunity opportunity)
        {
            if (!ModelState.IsValid) { return View(); }

            _context.Opportunities.Add(opportunity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetMatches(int id)
        {
            Opportunity opportunity = _context.Opportunities.Where(x => x.OpportunityId == id).FirstOrDefault();

            if (opportunity is null) { return View(); }

            OpportunityMatchesVM matches = new OpportunityMatchesVM()
            {
                OpportunityTitle = opportunity.Title,
                Volunteers = _context.Volunteers
                .Where(x => x.PreferredCenter == opportunity.Location && (x.ApprovalStatus == ApprovalStatus.Approved || x.ApprovalStatus == ApprovalStatus.Pending))
                .OrderBy(x => x.ApprovalStatus).ToList()
            };

            return View(matches);
        }

    }
}
