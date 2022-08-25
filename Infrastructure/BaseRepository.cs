using Domain.Models;
using Domain.Service;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            this.dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            this.dbSet.Update(entity);
        }
    }
}
