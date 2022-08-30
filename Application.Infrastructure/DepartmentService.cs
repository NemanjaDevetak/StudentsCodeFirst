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
    public class DepartmentService : IDepartmentService
    {
        public readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        ApplicationDbContext context;

        public DepartmentService(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task AddDepartment(InsertDepartmentDto insertDepartmentDto)
        {
            await unitOfWork.DepartmentRepository.Insert(mapper.Map<Department>(insertDepartmentDto));
            await unitOfWork.Save();
        }

        public async Task DeleteDepartment(int id)
        {
            await unitOfWork.DepartmentRepository.Delete(id);
            await unitOfWork.Save();
        }

        public async Task<GetDepartmentDto> GetDepartmentById(int id)
        {
            var department = await context.Departments.Where(x => x.Id == id).ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return department;
        }

        public async Task<ResponsePage<GetDepartmentDto>> GetDepartments(int page, int pageSize = 20)
        {
            var pageCount = Math.Ceiling((decimal)context.Departments.Count() / pageSize);

            var departments = await context.Departments.ProjectTo<GetDepartmentDto>(mapper.ConfigurationProvider)
                .Skip((page - 1) * (int)(pageSize))
                .Take((int)pageSize)
                .ToListAsync();

            return new ResponsePage<GetDepartmentDto> { Result = departments, CurrentPage = page, Pages = (int)pageCount };
        }

        public async Task UpdateDepartment(UpdateDepartmentDto department)
        {
            await unitOfWork.DepartmentRepository.Update(mapper.Map<Department>(department));
            await unitOfWork.Save();
        }
    }
}
