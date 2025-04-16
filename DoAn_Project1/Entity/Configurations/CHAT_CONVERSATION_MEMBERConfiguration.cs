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
    public class CHAT_CONVERSATION_MEMBERConfiguration : IEntityTypeConfiguration<CHAT_CONVERSATIONMEMBER>
    {
        public void Configure(EntityTypeBuilder<CHAT_CONVERSATIONMEMBER> builder)
        {
           builder.HasKey(x=>x.Id);
            builder.HasOne(x=>x.CHAT_CONVERSATION).WithMany(x=>x.CHAT_CONVERSATIONMEMBERs).HasForeignKey(x=>x.ConversationId); 
            builder.HasOne(x=>x.TAIKHOAN).WithMany(x=>x.CHAT_CONVERSATIONMEMBERs).HasForeignKey(x=>x.TaiKhoanId);
        }
    }
}
