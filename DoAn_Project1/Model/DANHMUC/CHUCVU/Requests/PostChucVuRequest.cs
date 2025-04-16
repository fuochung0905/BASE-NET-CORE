using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.CHUCVU.Requests
{
    public class PostChucVuRequest :BaseRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã chức vụ không được rỗng")]
        public string MaChucVu { get; set; } = null!;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên chức vụ không được rỗng")]
        public string TenChucVu { get; set; } = null!;
        public Guid? PhongBanId { get; set; }
    }
   
}
