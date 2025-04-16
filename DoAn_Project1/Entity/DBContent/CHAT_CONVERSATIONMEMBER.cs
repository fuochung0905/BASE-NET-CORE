using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public class CHAT_CONVERSATIONMEMBER
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public CHAT_CONVERSATION CHAT_CONVERSATION { get; set; }
        public Guid TaiKhoanId { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
        public DateTime NgayThamGia { get; set; }
    }
}
