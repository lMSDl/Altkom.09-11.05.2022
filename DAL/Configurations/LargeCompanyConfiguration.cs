﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class LargeCompanyConfiguration : EntityCofiguration<LargeCompany>
    {
        public override void Configure(EntityTypeBuilder<LargeCompany> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(LargeCompany));
        }
    }
}
