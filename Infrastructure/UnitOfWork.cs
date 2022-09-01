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
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private IBaseRepository<BaseEntity> baseRepository;
        private ICourseRepository courseRepository;
        private IDepartmentRepository departmentRepository;
        private IProfessorRepository professorRepository;
        private IStudentRepository studentRepository;
        public IBaseRepository<BaseEntity> BaseRepository
        {
            get
            {

                if (this.baseRepository == null)
                {
                    this.baseRepository = new BaseRepository<BaseEntity>(context);
                }
                return baseRepository;
            }
        }
        public ICourseRepository CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(context);
                }
                return courseRepository;
            }
        }
        public IDepartmentRepository DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return departmentRepository;
            }
        }
        public IProfessorRepository ProfessorRepository
        {
            get
            {

                if (this.professorRepository == null)
                {
                    this.professorRepository = new ProfessorRepository(context);
                }
                return professorRepository;
            }
        }
        public IStudentRepository StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }

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
