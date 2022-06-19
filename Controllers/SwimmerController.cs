using Concord_Cougars_Course_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Controllers
{
    [Authorize(Roles="Swimmer")]
    public class SwimmerController : Controller
    {
        private readonly SwimSchoolDbContext db;
        public SwimmerController(SwimSchoolDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
