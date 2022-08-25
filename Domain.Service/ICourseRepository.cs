using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        void AddProfessor(Course course, Professor professor);
        void AddStudent(Course course, Student student);
    }
}
