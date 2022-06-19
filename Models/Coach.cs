using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Concord_Cougars_Course_Project.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<Lesson> Lessons { get; set; }  //Updated removed LessionId and added Lessons as the collection
//        public ICollection<Lesson> SkillLevel {get; set;}
    }
}
