
using System.ComponentModel.DataAnnotations;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class PostChangePasswordRequest
    {
        public Guid? Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu cũ bắt buộc nhập")]
        public string? MatKhauCu { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu mới bắt buộc nhập")]
        public string? MatKhauMoi { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nhắc lại mật khẩu bắt buộc nhập")]
        public string? XacNhanMatKhauMoi { get; set; } = string.Empty;
    }


}
