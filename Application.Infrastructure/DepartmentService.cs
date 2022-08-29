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
    public class DepartmentService : IDepartmantService
    {
        public readonly IMapper mapper;
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public DepartmentService(IMapper mapper)
        {
            this.mapper = mapper;
            uof = new UnitOfWork(context);
        }
        public async Task AddDepartment(InsertDepartmentDto insertDepartmentDto)
        {
            await uof.DepartmentRepository.Insert((mapper.Map<Department>(insertDepartmentDto)));
            await uof.Save();
        }

        public async Task DeleteDepartment(int id)
        {
            await uof.DepartmentRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetDepartmentDto> GetDepartmentById(int id)
        {
            var department = await context.Departments.Where(x => x.Id == id).ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetDepartments(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.Courses.Count() / pageResults);

            var departments = await context.Departments.ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).ToListAsync();

            return departments;
        }

        public async Task UpdateDepartment(UpdateDepartmentDto department)
        {
            await uof.DepartmentRepository.Update(mapper.Map<Department>(department));
            await uof.Save();
        }
    }
}
