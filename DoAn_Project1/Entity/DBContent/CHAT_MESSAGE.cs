namespace ENTITIES.DBContent
{
    public class CHAT_MESSAGE
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public CHAT_CONVERSATION Conversation { get; set; }
        public Guid NguoiGuiId { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
        public string Content { get; set; }
        public DateTime? NgayTao { get; set; }

        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

    }
}
