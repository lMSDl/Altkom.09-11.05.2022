using DAL;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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
                context.Database.EnsureCreated();
            }

            using (var context = new MyContext(@"Server=(localdb)\mssqllocaldb;Database=EFC2"))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

        }
    }
}
