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
    public class ProfessorService : IProfessorService
    {
        public readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        ApplicationDbContext context;

        public ProfessorService(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task AddProfessor(InsertProfessorDto professor)
        {
            await unitOfWork.ProfessorRepository.Insert(mapper.Map<Professor>(professor));
            await unitOfWork.Save();
        }

        public async Task DeleteProfessor(int id)
        {
            await unitOfWork.ProfessorRepository.Delete(id);
            await unitOfWork.Save();
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

        public async Task<ResponsePage<GetProfessorDto>> GetProfessors(int page, int pageSize = 20, int? courseId = null, string? firstName = null, string? lastName = null)
        {
            var query = context.Professors.AsQueryable();

            if (courseId != null)
            {
                query = query.Where(x => x.CourseProfessors.Any(y => y.CourseId == courseId));
            }

            if (firstName != null)
            {
                query = query.Where(x => x.FirstName.Contains(firstName));
            }

            if (lastName != null)
            {
                query = query.Where(x => x.LastName.Contains(lastName));
            }

            var pageCount = Math.Ceiling((decimal)context.Professors.Count() / pageSize);

            var professors = await query.ProjectTo<GetProfessorDto>(mapper.ConfigurationProvider)
                .Skip((page - 1) * (int)(pageSize))
                .Take((int)pageSize)
                .ToListAsync();

            return new ResponsePage<GetProfessorDto> { Result = professors, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task UpdateProfessor(UpdateProfessorDto professorDto)
        {
            Professor professor = await unitOfWork.ProfessorRepository.GetById(professorDto.Id);

            mapper.Map(professorDto, professor);

            unitOfWork.ProfessorRepository.Update(professor);
            await unitOfWork.Save();
        }
    }
}
