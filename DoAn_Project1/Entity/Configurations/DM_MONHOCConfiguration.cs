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
    public class DM_MONHOCConfiguration : IEntityTypeConfiguration<DM_MONHOC>
    {
        public void Configure(EntityTypeBuilder<DM_MONHOC> builder)
        {
           builder.HasKey(x=>x.Id);
            builder.Property(x => x.Ma).IsRequired();
            builder.Property(X=>X.TenGoi).IsRequired();
        }
    }
}
