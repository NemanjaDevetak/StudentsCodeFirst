using Domain.Models;
using Domain.Service;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddProfessor(Course course, Professor professor)
        {
            context.CoursesProfessors.AddAsync(new CoursesProfessors { Course = course, Professor = professor });
        }

        public async Task AddStudent(Course course, Student student)
        {
            context.StudentCourses.AddAsync(new StudentCourses { Course = course, Student = student });
        }
    }
}
