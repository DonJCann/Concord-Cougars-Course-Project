using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Concord_Cougars_Course_Project.Models
{
    public enum ProgressReport
    {
        Pass, Fail // Can adjust if necessary later based off the user story for a coach writing progress reports
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int SwimmerId { get; set; }
        public int SessionId { get; set; }
        public Swimmer Swimmer { get; set; }
        public Session Seission { get; set; }
        [DisplayFormat(NullDisplayText = "No Progres Report")]
        public ProgressReport? ProgressReport { get; set; }
    }
}
