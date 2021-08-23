using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using PreSemesterProject.Models.DBModels;
using PreSemesterProject.Models.ViewModels;
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
            IEnumerable<Volunteer> volunteers = _context.Volunteers;

            if (!string.IsNullOrEmpty(filter)) { filter = filter.ToLower(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                volunteers = volunteers.Where(x => x.Username.ToLower().Contains(searchString) || x.FirstName.ToLower().Contains(searchString) || x.LastName.ToLower().Contains(searchString));
            }

            switch (filter)
            {
                
                case "approvedpending":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Approved || x.ApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "approved":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Approved).OrderBy(x => x.Username);
                    break;
                case "pending":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "denied":
                    volunteers = volunteers.Where(x => x.ApprovalStatus == ApprovalStatus.Denied).OrderBy(x => x.Username);
                    break;
                case "inactive":
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
        public IActionResult Create(Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return View(); }

            Volunteer existing = _context.Volunteers.Where(x => x.Username.Equals(volunteer.Username)).FirstOrDefault();

            if (existing != null) { return BadRequest("Volunteer already exists in the database"); }

            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer not found."); }

            _context.Volunteers.Remove(volunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer not found."); }

            return View(volunteer);
        }

        [HttpPost]
        public IActionResult Edit(Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return View(volunteer); }

            Volunteer oldVolunteer = _context.Volunteers.Where(x => x.VolunteerId == volunteer.VolunteerId).FirstOrDefault();

            oldVolunteer.Username = volunteer.Username;
            oldVolunteer.FirstName = volunteer.FirstName;
            oldVolunteer.LastName = volunteer.LastName;
            oldVolunteer.SkillsAndInterests = volunteer.SkillsAndInterests;
            oldVolunteer.Availability = volunteer.Availability;
            oldVolunteer.HomePhone = volunteer.HomePhone;
            oldVolunteer.WorkPhone = volunteer.WorkPhone;
            oldVolunteer.CellPhone = volunteer.CellPhone;
            oldVolunteer.EducationBackground = volunteer.EducationBackground;
            oldVolunteer.CurrentLicenses = volunteer.CurrentLicenses;
            oldVolunteer.DlonFile = volunteer.DlonFile;
            oldVolunteer.SsonFile = volunteer.SsonFile;
            oldVolunteer.PreferredCenter = volunteer.PreferredCenter;
            oldVolunteer.ApprovalStatus = volunteer.ApprovalStatus;

            _context.Update(oldVolunteer);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult GetMatches(int id)
        {
            Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return View(); }

            VolunteerMatchesVM matches = new VolunteerMatchesVM()
            {
                VolunteerUsername = volunteer.Username,
                Opportunities = _context.Opportunities.Where(x => x.Location == volunteer.PreferredCenter).OrderBy(x => x.Title).ToList()
            };

            return View(matches);
        }

        [HttpGet]
        public IActionResult AddEmergencyInfo(int id)
        {
            Volunteer volunteer = _context.Volunteers.Where(x => x.VolunteerId == id).FirstOrDefault();

            if (volunteer is null) { return View(); }

            return View(new VolunteerEmergencyVM() { VolunteerID = id } );
        }

        [HttpPost]
        public IActionResult AddEmergencyInfo(VolunteerEmergencyVM info)
        {
            if (!ModelState.IsValid) { return View(); }

            info.Contact.VolunteerId = info.VolunteerID;

            _context.Add(info.Contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
