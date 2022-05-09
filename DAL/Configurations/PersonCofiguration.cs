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
    public class PersonCofiguration : EntityCofiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.ToTable("People", "efc");
            builder.Property(x => x.FirstName).HasColumnName("Name").HasMaxLength(15);
            builder.Property(x => x.PESEL).HasPrecision(11, 0);//.HasColumnType("decimal(11,0)");
            builder.Property(x => x.LastName).IsRequired().HasDefaultValue("Kowalski");
            //builder.Ignore(x => x.Address); // == NotMapped
            builder.Property(x => x.FullName).HasComputedColumnSql("[Name] + ' ' + [LastName]", stored: true);

        }
    }
}
