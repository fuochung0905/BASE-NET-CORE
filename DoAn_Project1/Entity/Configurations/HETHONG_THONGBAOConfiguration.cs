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
    public class HETHONG_THONGBAOConfiguration : IEntityTypeConfiguration<HETHONG_THONGBAO>
    {
        public void Configure(EntityTypeBuilder<HETHONG_THONGBAO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TieuDe).IsRequired();
            builder.Property(x=>x.NoiDung).IsRequired();
        }
    }
}
