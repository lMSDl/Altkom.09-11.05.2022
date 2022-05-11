using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected DbContext Context { get; }

        public EntityService(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            //using var _context = new MyContext("connectionString");
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            Context.ChangeTracker.Clear();
            return entity.Id;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Context.Set<Person>().FindAsync(id);
            if (entity == null)
                return;
            Context.Set<Person>().Remove(entity);
            await Context.SaveChangesAsync();
            Context.ChangeTracker.Clear();
        }

        public virtual async Task<IEnumerable<T>> ReadAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> ReadAsync(int id)
        {
            return await Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task UpdateAsync(int id, T entity)
        {
            entity.Id = id;
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
            Context.ChangeTracker.Clear();
        }
    }
}
