using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
        {

        }

        public MyContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        private readonly string _connectionString;
        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                if(_connectionString != null)
                    optionsBuilder.UseSqlServer(_connectionString);
#if DEBUG
                else
                    optionsBuilder.UseSqlServer();
#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Person>();

            //modelBuilder.Entity<Person>().ToTable("People");
            //modelBuilder.Entity<Person>()
            //    .Property(x => x.FirstName).HasColumnName("Name").HasMaxLength(15);
            //modelBuilder.Entity<Person>()
            //    .Property(x => x.PESEL).HasColumnType("decimal(11,0)");
            //modelBuilder.Entity<Person>()
            //    .Property(x => x.LastName).IsRequired();
            //modelBuilder.Entity<Person>().Ignore(x => x.Address); // == NotMapped

            //modelBuilder.ApplyConfiguration(new PersonCofiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonCofiguration).Assembly);

            modelBuilder.Ignore<Address>(); // == NotMapped (globalny)
        }

        //public DbSet<Person> People { get; set; }
    }
}
