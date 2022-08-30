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
    public class ProfessorService : IProfessorService
    {
        public readonly IMapper mapper;
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public ProfessorService(IMapper mapper)
        {
            this.mapper = mapper;
            uof = new UnitOfWork(context);
        }
        public async Task AddProfessor(InsertProfessorDto professor)
        {
            await uof.ProfessorRepository.Insert(mapper.Map<Professor>(professor));
            await uof.Save();
        }

        public async Task DeleteProfessor(int id)
        {
            await uof.ProfessorRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetProfessorDto> GetProfessor(int id)
        {
            var professor = await context.Professors.Where(x => x.Id == id).ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return professor;
        }

        public async Task<GetProfessorDto> GetProfessor(string firstName)
        {
            var professor = await context.Professors.Where(x => x.FirstName == firstName).ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return professor;
        }

        public async Task<IEnumerable<GetProfessorDto>> GetProfessors(int page, int pageSize = 20, int? courseId = null)
        {
            var query = context.Professors.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.CourseProfessors.Any(y => y.CourseId == courseId));
            }

            var pageCount = Math.Ceiling((decimal)context.Professors.Count() / pageSize);

            IEnumerable<GetProfessorDto> professors = await query.ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider).ToListAsync();

            return professors;
        }

        public async Task UpdateProfessor(UpdateProfessorDto professor)
        {
            await uof.ProfessorRepository.Update(mapper.Map<Professor>(professor));
            await uof.Save();
        }
    }
}
