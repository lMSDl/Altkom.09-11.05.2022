using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class PersonCofiguration : PersonBaseCofiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable("People", "efc");
        }
    }

    public abstract class PersonBaseCofiguration<T> : EntityCofiguration<T> where T : Person
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            //builder.HasKey(x => x.Guid);
            builder.Property(x => x.FirstName).HasColumnName("Name").HasMaxLength(15);
            builder.Property(x => x.PESEL).HasPrecision(11, 0);//.HasColumnType("decimal(11,0)");
            builder.Property(x => x.LastName).IsRequired().HasDefaultValue("Kowalski");
            //builder.Ignore(x => x.Address); // == NotMapped
            builder.Property(x => x.FullName).HasComputedColumnSql("[Name] + ' ' + [LastName]", stored: true);

            builder.HasAlternateKey(x => x.PESEL);

            //builder.HasDiscriminator<string>("type")
            builder.HasDiscriminator(x => x.Type)
                .HasValue<Person>(nameof(Person))
                .HasValue<Student>(nameof(Student))
                .HasValue<Educator>(nameof(Educator));
            //builder.HasDiscriminator<int>("type")
            //    .HasValue<Person>(1)
            //    .HasValue<Student>(2)
            //    .HasValue<Educator>(3);
        }
    }
}
