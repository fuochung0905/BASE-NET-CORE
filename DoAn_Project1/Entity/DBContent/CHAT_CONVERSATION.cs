using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public class CHAT_CONVERSATION
    {
        public Guid Id { get; set; }
        public bool IsGroup { get; set; }
        public Guid TeamId { get; set; } 
        public Guid MonHocId { get; set; }
        public DM_MONHOC DM_MONHOC { get; set; }
        public DateTime? NgayTao { get; set; }

        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<CHAT_MESSAGE> ChatMessages { get; set; }
        public ICollection<CHAT_CONVERSATIONMEMBER> CHAT_CONVERSATIONMEMBERs { get; set; }
    }
}
