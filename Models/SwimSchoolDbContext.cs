using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Concord_Cougars_Course_Project.Models
{
    public class SwimSchoolDbContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public SwimSchoolDbContext(DbContextOptions
            <SwimSchoolDbContext> options)
            : base(options)
            {}
    }
}
