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
        public ICollection<Session> Sessions { get; set; }  //A Coach can teash 0 to many Sessions
    }
}
