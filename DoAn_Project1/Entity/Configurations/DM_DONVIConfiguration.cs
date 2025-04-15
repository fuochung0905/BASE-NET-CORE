using ENTITIES.DBContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Configurations
{
    public class DM_DONVIConfiguration : IEntityTypeConfiguration<DM_DONVI>
    {
        public void Configure(EntityTypeBuilder<DM_DONVI> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenGoi).IsRequired();
        }
    }
}
