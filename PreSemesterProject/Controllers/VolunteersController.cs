using Microsoft.AspNetCore.Mvc;
using PreSemesterProject.Models;
using PreSemesterProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemesterProject.Controllers
{
    public class VolunteersController : Controller
    {
        //private List<Opportunity> _volunteers = new List<Opportunity>();
        private FakeRepository _fakeRepository;

        public VolunteersController(FakeRepository fakeRepository)
        {
            _fakeRepository = fakeRepository;
        }


        public IActionResult Index([FromQuery] string filter, string searchString)
        {
            ViewData["CurrentSearch"] = searchString;
            IEnumerable<Volunteer> volunteers = _fakeRepository.Volunteers;
            //IEnumerable<Volunteer> volunteers = _volunteers;

            if (!string.IsNullOrEmpty(filter)) { filter.ToLower(); }

            if (!string.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(x => x.Username.Contains(searchString) || x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            } // end if

            switch (filter)
            {
                
                case "Approved / Pending Approval":
                    Console.WriteLine("Showing volunteers which are Approved or Pending Approval");
                    volunteers = volunteers.Where(x => x.VolunteerApprovalStatus == ApprovalStatus.Approved || x.VolunteerApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "Approved":
                    Console.WriteLine("Showing volunteers which are Approved");
                    volunteers = volunteers.Where(x => x.VolunteerApprovalStatus == ApprovalStatus.Approved).OrderBy(x => x.Username);
                    break;
                case "Pending":
                    Console.WriteLine("Showing volunteers which are Pending Approval");
                    volunteers = volunteers.Where(x => x.VolunteerApprovalStatus == ApprovalStatus.Pending).OrderBy(x => x.Username);
                    break;
                case "Disapproved":
                    Console.WriteLine("Showing volunteers which are Disapproved");
                    volunteers = volunteers.Where(x => x.VolunteerApprovalStatus == ApprovalStatus.Denied).OrderBy(x => x.Username);
                    break;
                case "Inactive":
                    Console.WriteLine("Showing volunteers which are Inactive");
                    volunteers = volunteers.Where(x => x.Inactive == true).OrderBy(x => x.Username);
                    break;
                
                default:
                    Console.WriteLine("Showing all volunteers");
                    volunteers = volunteers.OrderBy(x => x.VolunteerID);
                    break;
            } // end switch

            return View(volunteers.ToList());
        } // end Index Action

        [HttpGet]
        public IActionResult Edit(string username)
        {
            Volunteer volunteer = _fakeRepository.Volunteers.Where(x => x.VolunteerID == username).FirstOrDefault();

            if (volunteer is null) { return NotFound($"Volunteer with username: {username} not found."); }

            return View(volunteer);
        }

        [HttpPost]
        public IActionResult Edit(Volunteer volunteer)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            return Ok(volunteer);
        }

        [HttpPost]
        public IActionResult Delete(string username)
        {
            return Ok(username);
        }

        
        public IActionResult Create()
        {
            return View("~/Views/Volunteers/Create.cshtml");
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
