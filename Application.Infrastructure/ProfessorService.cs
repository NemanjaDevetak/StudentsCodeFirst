using Application.Service;
using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class ProfessorService : IProfessorService
    {
        public Task AddCourse(InsertProfessorDto course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetProfessorDto> GetProfessorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProfessorDto>> GetProfessors()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfessor(UpdateProfessorDto course)
        {
            throw new NotImplementedException();
        }
    }
}
