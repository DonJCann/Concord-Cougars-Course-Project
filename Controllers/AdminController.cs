using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Concord_Cougars_Course_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// This class handles actions for the Admin


namespace Concord_Cougars_Course_Project.Controllers
{
    public class AdminController : Controller
    {

        SwimSchoolDbContext db;
        public AdminController(SwimSchoolDbContext db)
        {
            this.db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllLesson()
        {
            var lesson = await db.Lessons.ToListAsync();
            return View(lesson);
        }
        public IActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddLesson(Lesson lesson)
        {
            db.Add(lesson);
            await db.SaveChangesAsync();
            return RedirectToAction("AllLesson");
        }
    }
}
