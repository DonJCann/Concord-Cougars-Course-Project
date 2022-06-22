using Concord_Cougars_Course_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.ViewModels
{
    public class SessionAddSessionViewModel
    {
        public Lesson Lesson { get; set; }
        public Session Session { get; set; }
        public Coach Coach { get; set; }
        // public SelectList CoachList { get; set; }
    }
}
