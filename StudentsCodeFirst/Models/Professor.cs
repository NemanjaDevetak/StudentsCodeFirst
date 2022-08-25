using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Professor : Person
    {
        public Professor()
        {
            CourseProfessors = new HashSet<CoursesProfessors>();
        }
        public virtual ICollection<CoursesProfessors> CourseProfessors { get; set; }
    }
}
