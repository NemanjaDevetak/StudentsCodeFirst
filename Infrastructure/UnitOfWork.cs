using Domain.Infrastructure;
using Domain.Models;
using Domain.Service;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            ApplicationDbContext context,
            IBaseRepository<BaseEntity> baseRepository,
            ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository
            )
        {
            this.context = context;
            this.BaseRepository = baseRepository;
            this.CourseRepository = courseRepository;
            this.DepartmentRepository = departmentRepository;
            this.ProfessorRepository = professorRepository;
            this.StudentRepository = studentRepository;
        }

        public IBaseRepository<BaseEntity> BaseRepository { get;}
        public ICourseRepository CourseRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IProfessorRepository ProfessorRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        private readonly ApplicationDbContext context;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
