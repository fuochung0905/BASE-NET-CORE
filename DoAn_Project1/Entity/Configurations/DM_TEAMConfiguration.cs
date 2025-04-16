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
    public class DM_TEAMConfiguration : IEntityTypeConfiguration<DM_TEAM>
    {
        public void Configure(EntityTypeBuilder<DM_TEAM> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenGoi).IsRequired();
            builder.Property(x=>x.Ma).IsRequired();
            builder.HasOne(x => x.DM_MONHOC).WithMany(x => x.dM_TEAMs).HasForeignKey(x => x.MonHocId);
        }
    }
}
