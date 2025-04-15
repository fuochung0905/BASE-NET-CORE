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
    public class MONHOC_NGUOITHAMGIAConfiguration : IEntityTypeConfiguration<MONHOC_NGUOITHAMGIA>
    {
        public void Configure(EntityTypeBuilder<MONHOC_NGUOITHAMGIA> builder)
        {
           builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.TAIKHOAN).WithMany(x=>x.mONHOC_NGUOITHAMGIAs).HasForeignKey(x=>x.TaiKhoanId);
            builder.HasOne(x=>x.DM_MONHOC).WithMany(x=>x.mONHOC_NGUOITHAMGIAs).HasForeignKey(x=>x.MonHocId);
        }
    }
}
