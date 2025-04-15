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
    public class SYSMENUConfiguration : IEntityTypeConfiguration<SYS_MENU>
    {
        public void Configure(EntityTypeBuilder<SYS_MENU> builder)
        {
            builder.HasKey(x=>x.Id);
           builder.Property(x=>x.ControllerName).IsRequired();
           builder.HasOne(x => x.PHANQUYEN_NHOMQUYEN).WithMany(x => x.Menus).HasForeignKey(x => x.NhomQuyenId);
        }
    }
}
