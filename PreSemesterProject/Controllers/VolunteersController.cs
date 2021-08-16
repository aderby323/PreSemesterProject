using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemesterProject.Controllers
{
    public class VolunteersController : Controller
    {
        public IActionResult Index()
        {
            //return Ok("Volunteers");
            return View("~/Views/Volunteers/Volunteers.cshtml");
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
    }
}
