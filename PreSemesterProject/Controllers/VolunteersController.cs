using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using PreSemesterProject.Models.DBModels;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Edit(string username)
        {
            Models.DBModels.Volunteer volunteer = _context.Volunteers.Where(x => x.Username.Equals(username)).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer with username: {username} not found."); }

            return View(volunteer);
        }

        [HttpPost]
        public IActionResult Edit(Models.DBModels.Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            return Ok(volunteer);
        }

        [HttpPost]
        public IActionResult Delete(string username)
        {
            return Ok(username);
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

            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }










        /*
        public IActionResult Index()
        {
            //return Ok("Volunteers");
            return View("~/Views/Volunteers/Index.cshtml");
        }
        

        public IActionResult Filters()
        {
            return View("~/Views/Volunteers/VolunteersFilters.cshtml");
        }

        public IActionResult Edit()
        {
            return View("~/Views/Volunteers/VolunteersEdit.cshtml");
        }

        public IActionResult Add()
        {
            return View("~/Views/Volunteers/VolunteersAdd.cshtml");
        }
        */
    }
}
