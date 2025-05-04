using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.PHONGBAN.Requests
{
    public class PostPhongBanRequest : BaseRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Đơn vị bắt buộc nhập")]
        public Guid? DonViId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã bắt bắt buộc nhập")]
        public string? Ma { get; set; }
        public string? TenDonVi { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }
        public bool IsKhoa { get; set; }
        public List<Guid> taiKhoanIds { get; set; }
    }

}
