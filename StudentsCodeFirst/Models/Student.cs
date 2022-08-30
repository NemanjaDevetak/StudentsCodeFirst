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
    public partial class Student : Person
    {
        public string StudentIndex { get; set; }
        public Student()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
