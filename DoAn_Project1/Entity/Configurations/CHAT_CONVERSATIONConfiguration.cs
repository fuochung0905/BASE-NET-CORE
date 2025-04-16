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
    public class CHAT_CONVERSATIONConfiguration : IEntityTypeConfiguration<CHAT_CONVERSATION>
    {
        public void Configure(EntityTypeBuilder<CHAT_CONVERSATION> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.DM_MONHOC).WithMany(x=>x.cHAT_CONVERSATIONs).HasForeignKey(x=>x.MonHocId);
        }
    }
}
