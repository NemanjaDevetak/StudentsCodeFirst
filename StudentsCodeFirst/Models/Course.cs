using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class Course : BaseEntity
    {
        public Course()
        {
            CourseProfessor = new HashSet<CoursesProfessors>();
            StudentCourses = new HashSet<StudentCourses>();
        }
        public string Code { get; set; }
        public string? CourseName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<CoursesProfessors> CourseProfessor { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
