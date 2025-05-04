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
    public class DUAN_QUANLYDUANConfiguration : IEntityTypeConfiguration<DUAN_QUANLYDUAN>
    {
        public void Configure(EntityTypeBuilder<DUAN_QUANLYDUAN> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.TenDuAn).IsRequired();
            builder.Property(x=>x.MaDuAn).IsRequired();
            builder.HasOne(x=>x.DM_GIAIDOANDUAN).WithMany(x=>x.dUAN_QUANLYDUANs).HasForeignKey(x=>x.GiaiDoanId).OnDelete(DeleteBehavior.Restrict); 
            builder.HasOne(x => x.DM_LOAIDUAN).WithMany(x => x.dUAN_QUANLYDUANs).HasForeignKey(x => x.LoaiDuAn).OnDelete(DeleteBehavior.Restrict); 
            builder.HasOne(x => x.DM_MONHOC).WithMany(x => x.dUAN_QUANLYDUANs).HasForeignKey(x => x.MonHocId);
            builder.HasOne(x=>x.DM_TEAM).WithMany(x=>x.dUAN_QUANLYDUANs).HasForeignKey(x=>x.TeamId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
