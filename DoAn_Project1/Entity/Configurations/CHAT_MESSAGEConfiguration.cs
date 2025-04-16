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
    public class CHAT_MESSAGEConfiguration : IEntityTypeConfiguration<CHAT_MESSAGE>
    {
        public void Configure(EntityTypeBuilder<CHAT_MESSAGE> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.TAIKHOAN).WithMany(x=>x.cHAT_MESSAGEs).HasForeignKey(x=>x.NguoiGuiId);
            builder.HasOne(x=>x.Conversation).WithMany(x=>x.ChatMessages).HasForeignKey(x=>x.ConversationId);
        }
    }
}
