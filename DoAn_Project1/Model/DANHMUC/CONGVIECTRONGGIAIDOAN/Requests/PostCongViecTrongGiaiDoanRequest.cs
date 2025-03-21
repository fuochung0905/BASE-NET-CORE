using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.CONGVIECTRONGGIAIDOAN.Requests;
public class PostCongViecTrongGiaiDoanRequest : BaseRequest
{
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã bắt buộc nhập")]
    public string? Ma { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
    public string? TenGoi { get; set; }
    [Required(ErrorMessage = "Giai đoạn bắt buộc chọn")]
    public Guid GiaiDoanId { get; set; }
}


