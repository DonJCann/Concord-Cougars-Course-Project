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
        public string SkillLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayTime { get; set; }
        public int SessionCapacity {get; set;}
       
    }
}
