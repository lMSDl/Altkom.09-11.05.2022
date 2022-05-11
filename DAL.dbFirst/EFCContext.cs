using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.dbFirst
{
    public partial class EFCContext : DbContext
    {
        public EFCContext()
        {
        }

        public EFCContext(DbContextOptions<EFCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverVehicle> DriverVehicles { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<LargeCompany> LargeCompanies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<SmallCompany> SmallCompanies { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<SubComponent> SubComponents { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=EFC;Integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasIndex(e => new { e.Street, e.City }, "IX_Address_Street_City")
                    .IsUnique();

                entity.HasIndex(e => e.ZipCode, "Index_Address_Zip");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Component");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");
            });

            modelBuilder.Entity<DriverVehicle>(entity =>
            {
                entity.HasKey(e => new { e.DriversId, e.VehiclesId });

                entity.ToTable("DriverVehicle");

                entity.HasIndex(e => e.VehiclesId, "IX_DriverVehicle_VehiclesId");

                entity.HasOne(d => d.Drivers)
                    .WithMany(p => p.DriverVehicles)
                    .HasForeignKey(d => d.DriversId);

                entity.HasOne(d => d.Vehicles)
                    .WithMany(p => p.DriverVehicles)
                    .HasForeignKey(d => d.VehiclesId);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.ToTable("Engine");
            });

            modelBuilder.Entity<LargeCompany>(entity =>
            {
                entity.ToTable("LargeCompany");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LargeCompany)
                    .HasForeignKey<LargeCompany>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People", "efc");

                entity.HasIndex(e => e.Pesel, "AK_People_PESEL")
                    .IsUnique();

                entity.HasIndex(e => e.AddressId, "IX_People_AddressId");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullName).HasComputedColumnSql("(([Name]+' ')+[LastName])", true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasDefaultValueSql("(N'Kowalski')");

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.Property(e => e.Pesel)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("PESEL");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Updated).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.HasIndex(e => e.VehicleId, "IX_Registration_VehicleId")
                    .IsUnique()
                    .HasFilter("([VehicleId] IS NOT NULL)");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Vehicle)
                    .WithOne(p => p.Registration)
                    .HasForeignKey<Registration>(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<SmallCompany>(entity =>
            {
                entity.ToTable("SmallCompany");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SubComponent>(entity =>
            {
                entity.HasIndex(e => e.ComponentId, "IX_SubComponents_ComponentId");

                entity.HasIndex(e => e.StatusId, "IX_SubComponents_StatusId");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.SubComponents)
                    .HasForeignKey(d => d.ComponentId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.SubComponents)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.EngineId, "IX_Vehicle_EngineId");

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.EngineId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
