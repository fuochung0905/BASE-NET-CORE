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
    public class DM_GIAIDOANDUANConfiguration : IEntityTypeConfiguration<DM_GIAIDOANDUAN>
    {
        public void Configure(EntityTypeBuilder<DM_GIAIDOANDUAN> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenGoi).IsRequired();
        }
    }
}
