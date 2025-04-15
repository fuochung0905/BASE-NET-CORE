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
    public class DUAN_QUANLYCONGVIEC_PHANHOIConfiguration : IEntityTypeConfiguration<DUAN_QUANLYCONGVIEC_PHANHOI>
    {
        public void Configure(EntityTypeBuilder<DUAN_QUANLYCONGVIEC_PHANHOI> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.DUAN_QUANLYCONGVIEC).WithMany(x=>x.dUAN_QUANLYCONGVIEC_PHANHOIs).HasForeignKey(x=>x.LienKetId);
        }
    }
}
