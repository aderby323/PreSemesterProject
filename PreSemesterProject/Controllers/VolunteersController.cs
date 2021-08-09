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
            return View("~/Views/Volunteers.cshtml");
        }

    }
}
