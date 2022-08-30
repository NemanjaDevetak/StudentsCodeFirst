using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Dtos
{
    public class StudentCourseDto
    {
        public CourseDto CourseDto { get; set; }
        public StudentDto StudentDto { get; set; }
    }
}
