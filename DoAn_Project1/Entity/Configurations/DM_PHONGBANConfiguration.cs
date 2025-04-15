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
    public class DM_PHONGBANConfiguration : IEntityTypeConfiguration<DM_PHONGBAN>
    {
        public void Configure(EntityTypeBuilder<DM_PHONGBAN> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenGoi).IsRequired();
            builder.HasOne(x=>x.DM_DONVI).WithMany(x=>x.DM_PHONGBANs).HasForeignKey(x=>x.DonViId);
        }
    }
}
