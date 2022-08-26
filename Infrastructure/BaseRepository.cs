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

        public async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            this.dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task <T> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            this.dbSet.Update(entity);
        }
    }
}
