using Concord_Cougars_Course_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Concord_Cougars_Course_Project.Controllers
{
    [Authorize(Roles ="Coach")]
    public class CoachController : Controller
    {

        private readonly SwimSchoolDbContext db;
        public CoachController(SwimSchoolDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }       
        public IActionResult AddCoach()  // Adds the Coach profile
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            Coach coach = new Coach();
            if(db.Coachs.Any(i => i.UserId == currentUserId))
            {
                coach = db.Coachs.FirstOrDefault
                    (i => i.UserId == currentUserId);
            }
            else
            {
                coach.UserId = currentUserId;
            }
            return View(coach);
        }
        [HttpPost]
        public async Task<IActionResult> AddCoach   // Post action for adding Coach profile
            (Coach coach)
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            if (db.Coachs.Any
                (i => i.UserId == currentUserId))
            {
                var coachToUpdate = db.Coachs.FirstOrDefault
                    (i => i.UserId == currentUserId);
                coachToUpdate.CoachName = coach.CoachName;
                db.Update(coachToUpdate);
                
            }
            else
            {
                db.Add(coach);
            }
            await db.SaveChangesAsync();
            return View("Index");
        }
       // public IActionResult AddSession()    // This is in the Session Controller
       // {
       //     Session session = new Session();
       //     var currentUserId = this.User.FindFirst
       //         (ClaimTypes.NameIdentifier).Value;
       //     session.CoachId = db.Coachs.
       //         SingleOrDefault(i => i.UserId ==
       //             currentUserId).CoachId;
       //     return View(session);
       // }
       // [HttpPost]
      //  public async Task<IActionResult> AddSession(Session session)
      //  {
      //      db.Add(session);
      //      await db.SaveChangesAsync();
      //      return RedirectToAction("Index", "Coach");
      //  }
        public async Task<IActionResult> SessionbyCoach()
        {
            var currentUserId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            var CoachId = db.Coachs.SingleOrDefault
                (i => i.UserId == currentUserId).CoachId;
            var session = await db.Sessions.Where(i =>
            i.CoachId == CoachId).ToListAsync();
            return View(session);
        }
        public async Task<IActionResult> AllLesson() // Generate a list of lessons for sessions to be added to
        {
            var currentId = this.User.FindFirst
                (ClaimTypes.NameIdentifier).Value;
            if (db.Coachs.Any(c => c.UserId == currentId))
            {
                var coachToTest = db.Coachs.FirstOrDefault
                    (t => t.UserId == currentId);
                if (coachToTest.CoachName == null)
                {
                    ViewBag.profileExist = false;
                }
                else
                {
                    ViewBag.profileExist = true;
                }
            }
            else
            {
                ViewBag.profileExist = false;
            }

            // ViewBag.coachName = db.Coachs.FirstOrDefault
            //    (c => c.UserId == currentId).CoachName;
            var lessons = await db.Lessons.ToListAsync();
            return View(lessons);
        }
        public async Task<IActionResult>PostProgressReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var allSwimmers = await db.Enrollments.Include(c => c.Session).Where(c => c.SessionId == id).ToListAsync();
            if (allSwimmers == null)
            {
                return NotFound();
            }
            return View(allSwimmers);
        }
        [HttpPost]
        public IActionResult PostProgressReport(List<Enrollment> enrollments)
        {
            foreach (var enrollment in enrollments)
            {
                var er = db.Enrollments.Find(enrollment.EnrollmentId);
                er.ProgressReport = enrollment.ProgressReport;
            }
            db.SaveChanges();
            return RedirectToAction("SessionByCoach");
        }
    }
}
