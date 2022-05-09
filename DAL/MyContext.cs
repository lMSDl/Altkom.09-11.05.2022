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

            modelBuilder.Entity<Person>();
        }

        //public DbSet<Person> People { get; set; }
    }
}
