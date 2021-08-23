using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using PreSemesterProject.Models.DBModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PreSemesterProject.Controllers
{
    [Authorize("Admin")]
    public class VolunteersController : Controller
    {
        private readonly VolunteerManagementSystemContext _context;

        public VolunteersController(VolunteerManagementSystemContext context)
        {
            _context = context;
        }


        public IActionResult Index([FromQuery] string filter, string searchString)
        {
            ViewData["CurrentSearch"] = searchString;
            IEnumerable<Models.DBModels.Volunteer> volunteers = _context.Volunteers;

            if (!string.IsNullOrEmpty(filter)) { filter.ToLower(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(x => x.Username.Contains(searchString) || x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            }

            switch (filter)
            {
                
                case "Approved / Pending Approval":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Approved || x.ApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "Approved":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Approved).OrderBy(x => x.Username);
                    break;
                case "Pending":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "Disapproved":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Denied).OrderBy(x => x.Username);
                    break;
                case "Inactive":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Inactive).OrderBy(x => x.Username);
                    break;
                
                default:
                    volunteers = volunteers.OrderBy(x => x.Username);
                    break;
            }

            return View(volunteers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.DBModels.Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return View(); }

            if (_context.Volunteers.Where(x => x.Username.Equals(volunteer.Username, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null) { return BadRequest("Volunteer already exists in the database"); }

            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Models.DBModels.Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer not found."); }

            _context.Volunteers.Remove(volunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.DBModels.Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer not found."); }

            return View(volunteer);
        }

        [HttpPost]
        public IActionResult Edit(Models.DBModels.Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return View(volunteer); }

            Models.DBModels.Volunteer oldVolunteer = _context.Volunteers.Where(x => x.Username == volunteer.Username).FirstOrDefault();

            oldVolunteer = volunteer;

            _context.Update(oldVolunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
