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
    public class PHANQUYENConfiguration : IEntityTypeConfiguration<PHANQUYEN>
    {
        public void Configure(EntityTypeBuilder<PHANQUYEN> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ControllerName).IsRequired();
            builder.HasOne(x => x.VAITRO).WithMany(x => x.PHANQUYENs).HasForeignKey(x => x.VaiTroId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
