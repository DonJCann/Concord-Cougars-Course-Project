using Concord_Cougars_Course_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Concord_Cougars_Course_Project.Views.Shared
{
    public class SessionAddSessionViewModel
    {
        public Session Session { get; set; }
        public Coach Coach { get; set; }
        public SelectList CoachList { get; set; }
    }
}
