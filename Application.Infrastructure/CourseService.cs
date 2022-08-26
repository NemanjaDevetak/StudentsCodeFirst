using Application.Service;
using Application.Service.Dtos;
using Domain.Models;
using Domain.Service;
using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class CourseService : ICourseService
    {
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public CourseService()
        {
            uof = new UnitOfWork(context);
        }
        public async Task AddCourse(InsertCourseDto dto)
        {
            Course newCourse = new Course();
            newCourse.Code = dto.Code;
            newCourse.CourseName = dto.CourseName;

            await uof.CourseRepository.Insert(newCourse);
            await uof.Save();
        }

        public async Task AddProfessor(CourseDto courseDto, ProfessorDto professorDto)
        {
            Course newCourse = await context.Courses.Select(x => new Course
            {
                Id = x.Id,
                Code = x.Code,
                CourseName = x.CourseName
            }).FirstOrDefaultAsync(x => x.Id == courseDto.Id);

            Professor newProfessor = await context.Professors.Select(x => new Professor
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = Address.CreateInstance(x.Address.Country, x.Address.City, x.Address.ZipCode, x.Address.Street)
            }).FirstOrDefaultAsync(x => x.Id == professorDto.Id);

            await uof.CourseRepository.AddProfessor(newCourse, newProfessor);
            await uof.Save();
        }

        public async Task AddStudent(Course course, Student student)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCourse(int id)
        {
            await uof.CourseRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetCourseDto> GetCourseById(int id)
        {
            return await context.Courses.Select(x => new GetCourseDto
            {
                Id = x.Id,
                Code = x.Code,
                CourseName = x.CourseName
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<GetCourseDto>> GetCourses()
        {
            return await context.Courses.Select(x => new GetCourseDto
            {
                Id = x.Id,
                Code = x.Code,
                CourseName = x.CourseName
            }).ToListAsync();
        }

        public async Task UpdateCourse(UpdateCourseDto course)
        {
            Course newCourse = new Course();
            newCourse.Code = course.Code;
            newCourse.CourseName = course.CourseName;

            await uof.CourseRepository.Update(newCourse);
            await uof.Save();
        }
    }
}
