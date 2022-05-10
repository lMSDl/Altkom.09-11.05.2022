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
    public class AddressConfiguration : EntityCofiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            //builder.HasKey(x => x.Ident);

            builder.HasIndex(x => x.ZipCode).HasDatabaseName("Index_Address_Zip");
            builder.HasIndex(x => new { x.Street, x.City }).IsUnique().HasFilter(null);

            builder.HasCheckConstraint("CK_ZipCode", "LEN([ZipCode]) = 6 AND CHARINDEX('-', [ZipCode]) = 3");
        }
    }
}
