using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IDepartmentService
    {
        Task<ResponsePage<GetDepartmentDto>> GetDepartments(int page, int pageSize);
        Task<GetDepartmentDto> GetDepartmentById(int id);
        Task UpdateDepartment(UpdateDepartmentDto course);
        Task AddDepartment(InsertDepartmentDto course);
        Task DeleteDepartment(int id);
    }
}
