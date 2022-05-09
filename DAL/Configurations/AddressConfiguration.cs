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
        }
    }
}
