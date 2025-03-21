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
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tên chủ đầu tư bắt đầu bắt buộc nhập")]
    public string? ChuDauTu { get; set; }
    public Guid? GiaiDoanId { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Thời gian bắt đầu bắt buộc nhập")]
    public DateTime? ThoiGianBatDau { get; set; }
    public DateTime? ThoiGianKetThuc { get; set; }

    public double TienDo { get; set; }

    public string? GhiChu { get; set; } = string.Empty;
    public int? LoaiDuAn { get; set; }
    public double? ChiPhiHoSo { get; set; }

    public double? ChiPhiTrienKhai { get; set; }

    public double? ChiPhiCode { get; set; }
    public List<Guid>? UserIds { get; set; }

  

    public bool IsCanhBaoHetHan { get; set; }
}