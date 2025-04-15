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
    public class DUAN_QUANLYCONGVIECConfiguration : IEntityTypeConfiguration<DUAN_QUANLYCONGVIEC>
    {
        public void Configure(EntityTypeBuilder<DUAN_QUANLYCONGVIEC> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenCongViec).IsRequired();
            builder.HasOne(x=>x.SYS_TRANGTHAICONGVIEC).WithMany(t=>t.DUAN_QUANLYCONGVIEC).HasForeignKey(x=>x.TrangThaiId);
            builder.HasOne(x=>x.DUAN_QUANLYDUAN).WithMany(d=>d.dUAN_QUANLYCONGVIECs).HasForeignKey(x=>x.DuAnId);
            builder.HasOne(x=>x.DM_GIAIDOANDUAN).WithMany(g=>g.qUANLYCONGVIECs).HasForeignKey(x=>x.GiaiDoanId);
        }
    }
}
