using Application.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IStudentService
    {
        Task<ResponsePage<GetStudentDto>> GetStudents(int page, int pageSize, int? courseId, string? firstName, string? lastName);
        Task<GetStudentDto> GetStudent(int id);
        Task<GetStudentDto> GetStudent(string firstName);
        Task UpdateStudent(UpdateStudentDto student);
        Task AddStudent(InsertStudentDto student);
        Task DeleteStudent(int id);
    }
}
