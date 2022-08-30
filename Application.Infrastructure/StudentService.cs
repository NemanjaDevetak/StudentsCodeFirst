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
    public class StudentService : IStudentService
    {
        public readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        ApplicationDbContext context;

        public StudentService(ApplicationDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddStudent(InsertStudentDto student)
        {
            await unitOfWork.StudentRepository.Insert(mapper.Map<Student>(student));
            await unitOfWork.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await unitOfWork.StudentRepository.Delete(id);
            await unitOfWork.Save();
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

        public async Task<ResponsePage<GetStudentDto>> GetStudents(int page, int pageSize = 20, int? courseId = null, string? firstName = null, string? lastName = null)
        {
            var query = context.Students.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.StudentCourses.Any(y => y.CourseId == courseId));
            }

            if (String.IsNullOrWhiteSpace(firstName) == false)
            {
                query = query.Where(x => x.FirstName.Contains(firstName));
            }

            if (String.IsNullOrWhiteSpace(lastName) == false)
            {
                query = query.Where(x => x.LastName.Contains(lastName));
            }

            var pageCount = Math.Ceiling((decimal)context.Students.Count() / pageSize);

            var students = await query.ProjectTo<GetStudentDto>(mapper.ConfigurationProvider)
                .Skip((page - 1) * (int)(pageSize))
                .Take((int)pageSize)
                .ToListAsync();

            return new ResponsePage<GetStudentDto> { Result = students, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task UpdateStudent(UpdateStudentDto studentDto)
        {
            Student student = await unitOfWork.StudentRepository.GetById(studentDto.Id);

            mapper.Map(studentDto, student);

            unitOfWork.StudentRepository.Update(student);
            await unitOfWork.Save();
        }
    }
}
