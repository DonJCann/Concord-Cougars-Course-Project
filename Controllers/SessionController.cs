using Concord_Cougars_Course_Project.Models;
using Concord_Cougars_Course_Project.ViewModels;
//using Concord_Cougars_Course_Project.Views.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Controllers
{
    public class SessionController : Controller
    {
        SwimSchoolDbContext db;
        public SessionController(SwimSchoolDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> AllSession()
        {
            var session = await db.Sessions
                .Include(c => c.Coach).ToListAsync();
            return View(session);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddSession(int id)
        {
            var lesson = await db.Lessons.
                SingleOrDefaultAsync(l => l.LessonId == id);
            SessionAddSessionViewModel vm = new SessionAddSessionViewModel();
            ViewBag.Lesson = lesson;
            TempData["lessonId"] = lesson.LessonId;
            TempData["skillLvl"] = lesson.SkillLevel;
            return View(vm);
        }
       [HttpPost]
        public async Task<IActionResult> AddSession(SessionAddSessionViewModel vm)
        {
            var currentId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var coachId = db.Coachs.FirstOrDefault
                 (c => c.UserId == currentId).CoachId;
            var lessonId = TempData["lessonId"];
            var skillLvl = TempData["skillLvl"];
            vm.Session.CoachId = coachId;
            vm.Session.LessonId = (int)lessonId;
            vm.Session.SkillLevel = (string)skillLvl;
            db.Add(vm.Session);
            await db.SaveChangesAsync();
            return RedirectToAction("AllLesson", "Coach");
        }
        /*           var CoachDisplay = await db.Coachs.Select(x => new
                    {
                        Id =
                        x.CoachId,
                        value = x.CoachName
                    }).ToListAsync();
                    SessionAddSessionViewModel vm = new SessionAddSessionViewModel();
                    vm.CoachList = new SelectList(CoachDisplay, "Id", "Value");
                    return View(vm);
                }
         /*       [HttpPost]
                public async Task<IActionResult> AddSession(SessionAddSessionViewModel vm)
                {
                    var coach = await db.Coachs.SingleOrDefault(i =>
                    i.CoachId == vm.Coach.CoachId);
                    vm.Session.CoachId = coach;
                    db.Add(vm.Session);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AllSessions");
                }
        */
    }
}
