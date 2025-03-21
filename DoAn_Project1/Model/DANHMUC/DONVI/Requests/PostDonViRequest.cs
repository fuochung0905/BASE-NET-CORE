using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.Requests
{
    public class PostDonViRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
        public string? NguoiLienHe { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? DiaChi { get; set; }
    }

}
