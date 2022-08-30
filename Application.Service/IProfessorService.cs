using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IProfessorService
    {
        Task<ResponsePage<GetProfessorDto>> GetProfessors(int page, int pageSize, int? courseId, string? firstName, string? lastName);
        Task<GetProfessorDto> GetProfessor(int id);
        Task<GetProfessorDto> GetProfessor(string firstName);
        Task UpdateProfessor(UpdateProfessorDto professor);
        Task AddProfessor(InsertProfessorDto professor);
        Task DeleteProfessor(int id);
    }
}
