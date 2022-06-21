using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int CoachId { get; set; }
        public Coach Coach { get; set; }     // Session can have only one Coach
        public string SkillLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DateTime { get; set; }
        public int SessionCapacity {get; set;}
        public Lesson Lesson { get; set; }  //Session can have only one Lesson
        public ICollection<Enrollment> Enrollments { get; set; }  //A Sessionn can have 0 to many enrollments


    }
}
