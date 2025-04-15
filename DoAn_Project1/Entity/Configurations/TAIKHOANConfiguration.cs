using ENTITIES.DBContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ENTITIES.Configurations
{
    public class TAIKHOANConfiguration : IEntityTypeConfiguration<TAIKHOAN>
    {
        public void Configure(EntityTypeBuilder<TAIKHOAN> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.VAITRO).WithMany(x => x.TAIKHOANs).HasForeignKey(x => x.VaiTroId);
            builder.HasOne(x => x.DM_LOAITAIKHOAN).WithMany(x => x.Taikhoans).HasForeignKey(x => x.LoaiTaiKhoanId);
            builder.HasOne(x => x.DM_DONVI).WithMany(x => x.TAIKHOANs).HasForeignKey(x => x.DonViId);
            builder.HasOne(x => x.CHUCVU).WithMany(x => x.Taikhoans).HasForeignKey(x => x.ChucVuID);
            builder.HasOne(x => x.DM_PHONGBAN).WithMany(x => x.Taikhoans).HasForeignKey(x => x.PhongBanId) ;
            builder.HasOne(x => x.DUAN_QUANLYDUAN).WithMany(x => x.tAIKHOANs).HasForeignKey(x => x.DuAnId);
        }
    }
}
