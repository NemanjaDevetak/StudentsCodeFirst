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
    public class DepartmentService : IDepartmantService
    {
        private readonly UnitOfWork uof;
        ApplicationDbContext context = new ApplicationDbContext();

        public DepartmentService()
        {
            uof = new UnitOfWork(context);
        }
        public async Task AddDepartment(InsertDepartmentDto dto)
        {
            Department newDepartment = new Department();
            newDepartment.DeptartmentName = dto.DepartmentName;

            await uof.DepartmentRepository.Insert(newDepartment);
            await uof.Save();
        }

        public async Task DeleteDepartment(int id)
        {
            await uof.DepartmentRepository.Delete(id);
            await uof.Save();
        }

        public async Task<GetDepartmentDto> GetDepartmentById(int id)
        {
            return await context.Departments.Select(x => new GetDepartmentDto
            {
                Id = x.Id,
                DepartmentName = x.DeptartmentName
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetDepartments()
        {
            return await context.Departments.Select(x => new GetDepartmentDto
            {
                Id = x.Id,
                DepartmentName = x.DeptartmentName
            }).ToListAsync();
        }

        public async Task UpdateDepartment(UpdateDepartmentDto course)
        {
            Department newDepartment = new Department();
            newDepartment.DeptartmentName = course.DepartmentName;

            await uof.DepartmentRepository.Update(newDepartment);
        }
    }
}
