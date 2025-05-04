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
    public class THONGBAO_NGUOIDUNGConfiguration : IEntityTypeConfiguration<THONGBAO_NGUOIDUNG>
    {
        public void Configure(EntityTypeBuilder<THONGBAO_NGUOIDUNG> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TAIKHOAN).WithMany(x => x.tHONGBAO_NGUOIDUNGs).HasForeignKey(x => x.TaiKhoanId);
            builder.HasOne(x => x.HETHONG_THONGBAO).WithMany(x => x.tHONGBAO_NGUOIDUNGs).HasForeignKey(x => x.ThongBaoId);
        }
    }
}
