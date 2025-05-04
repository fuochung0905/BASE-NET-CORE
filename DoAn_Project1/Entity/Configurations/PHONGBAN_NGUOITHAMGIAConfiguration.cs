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
    public class PHONGBAN_NGUOITHAMGIAConfiguration : IEntityTypeConfiguration<PHONGBAN_NGUOITHAMGIA>
    {
        public void Configure(EntityTypeBuilder<PHONGBAN_NGUOITHAMGIA> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TAIKHOAN).WithMany(x => x.pHONGBAN_NGUOITHAMGIAs).HasForeignKey(x => x.TaiKhoanId);
            builder.HasOne(x => x.DM_PHONGBAN).WithMany(x => x.dM_PHONGBAN_NHGIA).HasForeignKey(x => x.PhongBanId);
        }
    }
}
