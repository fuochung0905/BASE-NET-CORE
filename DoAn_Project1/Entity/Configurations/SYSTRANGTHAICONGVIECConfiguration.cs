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
    public class SYSTRANGTHAICONGVIECConfiguration : IEntityTypeConfiguration<SYS_TRANGTHAICONGVIEC>
    {
        public void Configure(EntityTypeBuilder<SYS_TRANGTHAICONGVIEC> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenGoi).IsRequired();
        }
    }
}
