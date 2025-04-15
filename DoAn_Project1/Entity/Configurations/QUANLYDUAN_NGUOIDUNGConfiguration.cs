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
    public class QUANLYDUAN_NGUOIDUNGConfiguration : IEntityTypeConfiguration<QUANLYDUAN_NGUOIDUNG>
    {
        public void Configure(EntityTypeBuilder<QUANLYDUAN_NGUOIDUNG> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.TAIKHOAN).WithMany(x=>x.QUANLYDUAN_NGUOIDUNGs).HasForeignKey(x=>x.TaiKhoanId);
            builder.HasOne(x => x.DUAN_QUANLYDUAN).WithMany(x => x.QUANLYDUAN_NGUOIDUNGs).HasForeignKey(x => x.DuAnId);
        }
    }
}
