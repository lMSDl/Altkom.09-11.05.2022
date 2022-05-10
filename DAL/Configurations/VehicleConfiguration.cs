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
    public class VehicleConfiguration : EntityCofiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Registration).WithOne(x => x.Vehicle).HasForeignKey<Registration>("VehicleId")/*.IsRequired()*/
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Engine).WithMany(x => x.Vehicles);

            builder.HasMany(x => x.Drivers).WithMany(x => x.Vehicles);
        }
    }
}
