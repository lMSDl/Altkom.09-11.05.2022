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
    public class PeopleService : IPeopleService
    {
        private DbContext _context;

        public PeopleService(DbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Person entity)
        {
            //using var _context = new MyContext("connectionString");
            await _context.Set<Person>().AddAsync(entity);
            if(entity.Address.Id != 0)
            {
                _context.Entry(entity.Address).State = EntityState.Unchanged;
            } 
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Person>().FindAsync(id);
            if (entity == null)
                return;
            _context.Set<Person>().Remove(entity);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<IEnumerable<Person>> ReadAsync()
        {
            return await _context.Set<Person>().AsNoTracking().ToListAsync();
        }

        public async Task<Person> ReadAsync(int id)
        {
            return await _context.Set<Person>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, Person entity)
        {
            entity.Id = id;
            _context.Set<Person>().Update(entity);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
