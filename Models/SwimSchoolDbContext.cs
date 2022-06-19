// Added Identity to SwimSchoolDbContext
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Models
{
    public class SwimSchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public SwimSchoolDbContext(DbContextOptions
            <SwimSchoolDbContext> options)
            : base(options)
            {}
    }
}
