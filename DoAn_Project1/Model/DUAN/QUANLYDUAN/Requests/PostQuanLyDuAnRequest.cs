using System.ComponentModel.DataAnnotations;
using Model.BASE;

namespace MODELS.DUAN.QUANLYDUAN.Requests;
public class PostQuanLyDuAnRequest : BaseRequest
{
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Mã dự án bắt buộc nhập")]
    public string? MaDuAn { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên dự án bắt buộc nhập")]

    public string? TenDuAn { get; set; }
    public Guid? GiaiDoanId { get; set; }
    public Guid? MonHocId { get; set; }
    public Guid? TeamId { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Thời gian bắt đầu bắt buộc nhập")]
    public DateTime? ThoiGianBatDau { get; set; }
    public DateTime? ThoiGianKetThuc { get; set; }
    public double TienDo { get; set; }
    public string? GhiChu { get; set; } = string.Empty;
    public Guid? LoaiDuAn { get; set; }
    public List<Guid>? UserIds { get; set; }
    public bool IsCanhBaoHetHan { get; set; }
}