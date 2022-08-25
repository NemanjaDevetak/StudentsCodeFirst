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
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private IBaseRepository<BaseEntity> baseRepository;
        private ICourseRepository courseRepository;
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

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
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
