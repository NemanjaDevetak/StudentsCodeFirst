using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<BaseEntity> BaseRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task Save();
    }
}
