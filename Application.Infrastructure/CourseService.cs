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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Infrastructure
{
    public class CourseService : ICourseService
    {
        public readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        ApplicationDbContext context;

        public CourseService(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task AddCourse(InsertCourseDto inserCourseDto)
        {
            await unitOfWork.CourseRepository.Insert(mapper.Map<Course>(inserCourseDto));
            await unitOfWork.Save();
        }

        public async Task AddProfessor(CourseDto courseDto, ProfessorDto professorDto)
        {
            var course = await unitOfWork.CourseRepository.GetById(courseDto.Id);
            var professor = await unitOfWork.ProfessorRepository.GetById(professorDto.Id);

            await unitOfWork.CourseRepository.AddProfessor(course, professor);
            await unitOfWork.Save();
        }

        public async Task AddStudent(CourseDto courseDto, StudentDto studentDto)
        {
            var course = await unitOfWork.CourseRepository.GetById(courseDto.Id);
            var student = await unitOfWork.StudentRepository.GetById(studentDto.Id);

            await unitOfWork.CourseRepository.AddStudent(course, student);
            await unitOfWork.Save();
        }

        public async Task DeleteCourse(int id)
        {
            await unitOfWork.CourseRepository.Delete(id);
            await unitOfWork.Save();
        }

        public async Task<GetCourseDto> GetCourseById(int id)
        {
            var course = await context.Courses.Where(x => x.Id == id).ProjectTo<GetCourseDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return course;
        }

        public async Task<ResponsePage<GetCourseDto>> GetCourses(int page, int pageSize = 20, string? courseName = null)
        {
            var query = context.Courses.AsQueryable();

            if (String.IsNullOrWhiteSpace(courseName) == false)
            {
                query = query.Where(x => x.CourseName.Contains(courseName));
            }
            var pageCount = Math.Ceiling((decimal)context.Courses.Count() / pageSize);

            var courses = await query.ProjectTo<GetCourseDto>(mapper.ConfigurationProvider)
                .Skip((page - 1) * (int)(pageSize))
                .Take((int)pageSize)
                .ToListAsync();

            return new ResponsePage<GetCourseDto> { Result = courses, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task UpdateCourse(UpdateCourseDto course)
        {
            await unitOfWork.CourseRepository.Update(mapper.Map<Course>(course));
            await unitOfWork.Save();
        }
    }
}
