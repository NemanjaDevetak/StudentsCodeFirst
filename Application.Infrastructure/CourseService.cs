using Application.Service;
using Application.Service.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public readonly IMapper mapper;
        private readonly IUnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public CourseService(IMapper mapper)
        {
            this.mapper = mapper;
            uof = new UnitOfWork(context);
        }
        public async Task AddCourse(InsertCourseDto inserCourseDto)
        {
            await uof.CourseRepository.Insert(mapper.Map<Course>(inserCourseDto));
            await uof.Save();
        }

        public async Task AddProfessor(CourseDto courseDto, ProfessorDto professorDto)
        {
            var course = await uof.CourseRepository.GetById(courseDto.Id);
            var professor = await uof.ProfessorRepository.GetById(professorDto.Id);

            await uof.CourseRepository.AddProfessor(course, professor);
            await uof.Save();
        }

        public async Task AddStudent(CourseDto courseDto, StudentDto studentDto)
        {
            var course = await uof.CourseRepository.GetById(courseDto.Id);
            var student = await uof.StudentRepository.GetById(studentDto.Id);

            await uof.CourseRepository.AddStudent(course, student);
            await uof.Save();
        }

        public async Task DeleteCourse(int id)
        {
            await uof.CourseRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetCourseDto> GetCourseById(int id)
        {
            var course = await context.Courses.Where(x => x.Id == id).ProjectTo<GetCourseDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return course;
        }

        public async Task<IEnumerable<GetCourseDto>> GetCourses(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.Courses.Count() / pageResults);

            var courses = await context.Courses.ProjectTo<GetCourseDto>(mapper.ConfigurationProvider).ToListAsync();

            return courses;
        }

        public async Task UpdateCourse(UpdateCourseDto course)
        {
            await uof.CourseRepository.Update(mapper.Map<Course>(course));
            await uof.Save();
        }
    }
}
