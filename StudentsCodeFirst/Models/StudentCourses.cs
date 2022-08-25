using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum Grade { 
        Six = 6,
        Seven = 7, 
        Eight = 8,
        Nine = 9,
        Ten = 10
    }
    public partial class StudentCourses : BaseEntity
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public Grade Grade { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
