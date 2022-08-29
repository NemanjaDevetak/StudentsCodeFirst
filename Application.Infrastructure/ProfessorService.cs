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
    public class ProfessorService : IProfessorService
    {
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public ProfessorService()
        {
            uof = new UnitOfWork(context);
        }
        public async Task AddProfessor(InsertProfessorDto professor)
        {
            Professor newProfessor = new Professor();
            newProfessor.FirstName = professor.FirstName;
            newProfessor.FirstName = professor.LastName;
            newProfessor.Address = Address.CreateInstance(professor.Address.Country, professor.Address.City, professor.Address.ZipCode, professor.Address.Street);

            await uof.ProfessorRepository.Insert(newProfessor);
            await uof.Save();
        }

        public async Task DeleteProfessor(int id)
        {
            await uof.ProfessorRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetProfessorDto> GetProfessor(int id)
        {
            return await context.Professors.Select(x => new GetProfessorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetProfessorDto> GetProfessor(string firstName)
        {
            return await context.Professors.Select(x => new GetProfessorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).FirstOrDefaultAsync(x => x.FirstName == firstName);
        }

        public async Task<IEnumerable<GetProfessorDto>> GetProfessors(int page, int pageSize = 20, int? courseId = null)
        {
            var query = context.Professors.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.CourseProfessors.Any(y => y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)context.Professors.Count() / pageSize);

            IEnumerable<GetProfessorDto> professors = await query.Select(x => new GetProfessorDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            })
                .Skip((page - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToListAsync();

            return professors;
        }

        public async Task UpdateProfessor(UpdateProfessorDto professor)
        {
            Professor newProfessor = await uof.ProfessorRepository.GetById(professor.Id);
            newProfessor.FirstName = professor.FirstName;
            newProfessor.LastName = professor.LastName;
            newProfessor.Address = Address.CreateInstance(professor.Address.Country, professor.Address.City, professor.Address.ZipCode, professor.Address.Street);

            await uof.ProfessorRepository.Update(newProfessor);
            await uof.Save();
        }
    }
}
