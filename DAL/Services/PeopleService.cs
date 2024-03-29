﻿using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PeopleService : EntityService<Person>, IPeopleService
    {
        public PeopleService(DbContext context) : base(context)
        {
        }

        public override async Task<int> CreateAsync(Person entity)
        {
            //using var _context = new MyContext("connectionString");
            await Context.Set<Person>().AddAsync(entity);
            if(entity.Address.Id != 0)
            {
                Context.Entry(entity.Address).State = EntityState.Unchanged;
            } 
            await Context.SaveChangesAsync();
            Context.ChangeTracker.Clear();
            return entity.Id;
        }

        public async Task<IEnumerable<Person>> ReadAsync(string firstName, string lastName)
        {
            var result = await Context.Set<Person>().Where(x => x.FirstName == firstName).Where(x => x.LastName == lastName)
                .ToListAsync();
            return result;
        }

        public override async Task DeleteAsync(int id)
        {
            //await Context.Database.ExecuteSqlRawAsync("DELETE FROM efc.People WHERE Id = {0}", id);
            await Context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM efc.People WHERE Id = {id}");
        }

        public async Task<Person> ReadAsync(ulong pesel)
        {
            var result = await Context.Set<Person>().FromSqlInterpolated($"EXEC efc.GetPersonByPESEL {pesel}").ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
