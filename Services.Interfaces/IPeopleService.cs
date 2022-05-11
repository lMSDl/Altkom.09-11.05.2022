using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPeopleService : IEntityService<Person>
    {
        Task<IEnumerable<Person>> ReadAsync(string firstName, string lastName);
        Task<Person> ReadAsync(ulong pesel);
    }
}
