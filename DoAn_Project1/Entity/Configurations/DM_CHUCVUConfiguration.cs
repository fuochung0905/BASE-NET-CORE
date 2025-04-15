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
    public class DM_CHUCVUConfiguration : IEntityTypeConfiguration<DM_CHUCVU>
    {
        public void Configure(EntityTypeBuilder<DM_CHUCVU> builder)
        {
            builder.HasKey(pc=> pc.Id);
            builder.Property(x => x.TenChucVu).IsRequired();
        }
    }
}
