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
        Task<IEnumerable<GetProfessorDto>> GetProfessors();
        Task<GetProfessorDto> GetProfessorById(int id);
        Task UpdateProfessor(UpdateProfessorDto course);
        Task AddCourse(InsertProfessorDto course);
        Task DeleteCourse(int id);
    }
}
