using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public DbSet<Status> Statuses { get; set; }
        public DbSet<SubComponent> SubComponents { get; set; }
        public DbSet<Component> Component { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured)
            {
                if(_connectionString != null)
                    optionsBuilder.UseSqlServer(_connectionString);
#if DEBUG
                else
                    optionsBuilder.UseSqlServer()/*.UseValidationCheckConstraints()*/;
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

            //modelBuilder.Ignore<Address>(); // == NotMapped (globalny)
        }

        //public DbSet<Person> People { get; set; }

        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries<Entity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList()
                .ForEach(x => x.Updated = DateTime.Now);

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
