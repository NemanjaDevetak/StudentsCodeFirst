using Application.Service.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface ICourseService
    {
        Task<ResponsePage<GetCourseDto>> GetCourses(int page, int pageSize, string? courseName);
        Task<GetCourseDto> GetCourseById(int id);
        Task UpdateCourse(UpdateCourseDto course);
        Task AddCourse(InsertCourseDto course);
        Task DeleteCourse(int id);
        Task AddProfessor(CourseDto course, ProfessorDto professor);
        Task AddStudent(CourseDto course, StudentDto student);
    }
}
