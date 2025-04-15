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
    public class HETHONG_THONGBAO_TEPDINHKEMConfiguration : IEntityTypeConfiguration<HETHONG_THONGBAO_TEPDINHKEM>
    {
        public void Configure(EntityTypeBuilder<HETHONG_THONGBAO_TEPDINHKEM> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.HETHONG_THONGBAO).WithMany(x => x.HETHONG_THONGBAO_TEPDINHKEMs).HasForeignKey(X => X.LienKetId);
        }
    }
}
