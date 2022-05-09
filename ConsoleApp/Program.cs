using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var contextOptions = new DbContextOptionsBuilder<MyContext>()
                //połączenie do loclDB (baza danych w pliku)
                //.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFC");
                //połączenie do SQL Server za pomocą Windows Authentication
                .UseSqlServer(@"Server=(local);Database=EFC;Integrated Security=true");
                //połączenie do SQL Server za pomocą loginu i hasła
                //.UseSqlServer(@"Server=(local);Database=EFC;User Id=databaseuser;Password=asdasdasd");

            using (var context = new MyContext(contextOptions.Options))
            {
                context.Database.Migrate();

                //await context.People.ToListAsync();
                await context.Set<Person>().ToListAsync();
            }

            using (var context = new MyContext(@"Server=(localdb)\mssqllocaldb;Database=EFC2"))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

        }
    }
}
