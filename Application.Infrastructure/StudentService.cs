using Application.Service;
using Application.Service.Dtos;
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
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public StudentService()
        {
            uof = new UnitOfWork(context);
        }

        public async Task AddStudent(InsertStudentDto student)
        {
            Student newStudent = new Student();
            newStudent.FirstName = student.FirstName;
            newStudent.FirstName = student.LastName;
            newStudent.Address = Address.CreateInstance(student.Address.Country, student.Address.City, student.Address.ZipCode, student.Address.Street);

            await uof.StudentRepository.Insert(newStudent);
            await uof.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await uof.StudentRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetStudentDto> GetStudentById(int id)
        {
            return await context.Students.Select(x => new GetStudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<GetStudentDto>> GetStudents(int page, int pageSize = 20, int? courseId = null)
        {
            var query = context.Students.AsQueryable();

            if (courseId != null) {
                query = query.Where(x => x.StudentCourses.Any(y => y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)context.Students.Count() / pageSize);

            IEnumerable<GetStudentDto> students = await query.Select(x => new GetStudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            })
                .Skip((page - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToListAsync();
            
            return students;
        }

        public async Task UpdateStudent(UpdateStudentDto student)
        {
            Student newStudent = await uof.StudentRepository.GetById(student.Id);
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Address = Address.CreateInstance(student.Address.Country, student.Address.City, student.Address.ZipCode, student.Address.Street);

            await uof.StudentRepository.Update(newStudent);
            await uof.Save();
        }
    }
}
