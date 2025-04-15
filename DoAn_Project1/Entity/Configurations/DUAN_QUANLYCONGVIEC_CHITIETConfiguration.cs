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
    public class DUAN_QUANLYCONGVIEC_CHITIETConfiguration : IEntityTypeConfiguration<DUAN_QUANLYCONGVIEC_CHITIET>
    {
        public void Configure(EntityTypeBuilder<DUAN_QUANLYCONGVIEC_CHITIET> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenCongViecCon).IsRequired();
            builder.HasOne(x=>x.DUAN_QUANLYCONGVIEC).WithMany(x=>x.DUAN_QUANLYCONGVIEC_CHITIET).HasForeignKey(x=>x.CongViecId);
        }
    }
}
