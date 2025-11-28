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
    public class DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEMConfiguration : IEntityTypeConfiguration<DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM>
    {
        public void Configure(EntityTypeBuilder<DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.DUAN_QUANLYCONGVIEC).WithMany(x => x.dUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEMs).HasForeignKey(x => x.LienKetId);
        }
    }
}
