using Application.Service;
using Application.Service.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models;
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
    public class StudentService : IStudentService
    {
        public readonly IMapper mapper;
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public StudentService(IMapper mapper)
        {
            this.mapper = mapper;
            uof = new UnitOfWork(context);
        }

        public async Task AddStudent(InsertStudentDto student)
        {
            await uof.StudentRepository.Insert(mapper.Map<Student>(student));
            await uof.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await uof.StudentRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetStudentDto> GetStudent(int id)
        {
            var student = await context.Students.Where(x => x.Id == id).ProjectTo<GetStudentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return student;
        }

        public async Task<GetStudentDto> GetStudent(string firstName)
        {
            var student = await context.Students.Where(x => x.FirstName == firstName).ProjectTo<GetStudentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return student;
        }

        public async Task<IEnumerable<GetStudentDto>> GetStudents(int page, int pageSize = 20, int? courseId = null)
        {
            var query = context.Students.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.StudentCourses.Any(y => y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)context.Students.Count() / pageSize);

            IEnumerable<GetStudentDto> students = await query.ProjectTo<GetStudentDto>(mapper.ConfigurationProvider).ToListAsync();

            return students;
        }

        public async Task UpdateStudent(UpdateStudentDto student)
        {
            await uof.StudentRepository.Update(mapper.Map<Student>(student));
            await uof.Save();
        }
    }
}
