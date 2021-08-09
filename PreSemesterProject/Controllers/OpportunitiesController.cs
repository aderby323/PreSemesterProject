using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreSemesterProject.Controllers
{
    public class OpportunitiesController : Controller
    {
        
        public IActionResult Index()
        {
            return Ok("OpportunitiesTest");
        }
    }
}
