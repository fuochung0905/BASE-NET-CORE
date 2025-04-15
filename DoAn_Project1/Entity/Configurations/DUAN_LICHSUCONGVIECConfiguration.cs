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
    public class DUAN_LICHSUCONGVIECConfiguration : IEntityTypeConfiguration<DUAN_LICHSUGIAOVIEC>
    {
        public void Configure(EntityTypeBuilder<DUAN_LICHSUGIAOVIEC> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.DUAN_QUANLYCONGVIEC).WithMany(v=>v.DUAN_LICHSUGIAOVIECs).HasForeignKey(x=>x.CongViecId);
          
        }
    }
}
