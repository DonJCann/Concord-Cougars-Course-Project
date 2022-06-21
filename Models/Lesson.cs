using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string SkillLevel { get; set; }
        public decimal tuition { get; set; }
        public ICollection<Session> Sessions { get; set; }  // A Lesson can have 0 to many Sessions
    }
}
