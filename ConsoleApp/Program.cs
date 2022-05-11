using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                context.Database.EnsureDeleted();
                context.Database.Migrate();

                var person = new Person { FirstName = "Ada", LastName = "Ewowska", BithDate = DateTime.Now.AddYears(-23), PESEL = 12312312332 };
                var address = new Address { City = "Warszawa", Street = " Krakowska", ZipCode = "11-111" };
                person.Address = address;

                var person2 = new Person { FirstName = "Ewa", LastName = "Ewowska", BithDate = DateTime.Now.AddYears(-23), PESEL = 32132132132 };
                person2.Address = address;

                // context.Set<Person>().Attach(person);
                context.Entry(person).State = EntityState.Unchanged;

                //Jeśli klucz jest generowany przez bazę, to metoda Update działa jak AddOrUpdate w zależności czy wartość klucza jest == 0 lub != 0
                //context.Set<Person>().Update(person);
                //context.Set<Person>().Update(person2);
                await context.Set<Person>().AddAsync(person);
                await context.Set<Person>().AddAsync(person2);

                Console.WriteLine(context.ChangeTracker.ToDebugString(Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTrackerDebugStringOptions.IncludeProperties));

                await context.SaveChangesAsync();

                person2.BithDate = DateTime.Now.AddYears(-32);
                context.Set<Person>().Update(person2);
                //mówimy dbContex, żeby nie aktualizował zmiany daty urodzenia
                //context.Entry(person2).Property(x => x.BithDate).IsModified = false;

                Console.WriteLine(context.ChangeTracker.ToDebugString(Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTrackerDebugStringOptions.IncludeProperties));

                await context.SaveChangesAsync();

                //context.Set<Person>().Remove(person2);
                //czyścimy dbContext ponieważ chcemy załączyć obiekt o id, który jest już załączony
                context.ChangeTracker.Clear();
                context.Set<Person>().Remove(new Person { Id = 2 });

                await context.SaveChangesAsync();

            }

            //using (var context = new MyContext(@"Server=(localdb)\mssqllocaldb;Database=EFC2"))
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //}

        }

        private static async Task WorkingWithComponents(DbContextOptionsBuilder<MyContext> contextOptions)
        {
            var component = new Component();
            component.SubComponents = new List<SubComponent>() { new SubComponent{ Status = new Status { Id = "A" } },
            new SubComponent{ Status = new Status { Id = "A" } }, new SubComponent{ Status = new Status { Id = "B" }} };

            using (var context = new MyContext(contextOptions.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();

                await context.Statuses.AddAsync(new Status { Id = "A" });
                await context.Statuses.AddAsync(new Status { Id = "B" });
                await context.Statuses.AddAsync(new Status { Id = "C" });
                await context.Statuses.AddAsync(new Status { Id = "D" });
                await context.SaveChangesAsync();
                context.ChangeTracker.Clear();

                //var statuses = component.SubComponents.Select(x => x.Status).GroupBy(x => x.Id).Select(x => x.First());
                //foreach (var subComponent in component.SubComponents)
                //{
                //    subComponent.Status = statuses.Single(x => x.Id == subComponent.Status.Id);
                //}

                //await context.Component.AddAsync(component);
                //foreach (var item in context.Statuses.Local)
                //{
                //    context.Entry(item).State = EntityState.Unchanged;
                //}

                //await context.SaveChangesAsync();

                var dbComponent = new Component();
                await context.Component.AddAsync(dbComponent);
                await context.SaveChangesAsync();
                context.ChangeTracker.Clear();

                foreach (var subcomponent in component.SubComponents)
                {
                    subcomponent.Component = new Component { Id = dbComponent.Id };
                    await context.SubComponents.AddAsync(subcomponent);
                    context.Entry(subcomponent.Component).State = EntityState.Unchanged;
                    context.Entry(subcomponent.Status).State = EntityState.Unchanged;
                    await context.SaveChangesAsync();
                    context.ChangeTracker.Clear();
                }


            }
        }
    }
}
