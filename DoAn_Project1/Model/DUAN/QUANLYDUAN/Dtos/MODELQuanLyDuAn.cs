using Model.BASE;

namespace MODELS.DUAN.QUANLYDUAN.Dtos;
public class MODELQuanLyDuAn : MODELBase
{
    public Guid Id { get; set; }
    public string? MaDuAn { get; set; }
    public string? TenDuAn { get; set; }
    public Guid GiaiDoanId { get; set; }
    public string? GiaiDoan { get; set; }
    public DateTime ThoiGianBatDau { get; set; }
    public DateTime ThoiGianKetThuc { get; set; }
    public string GhiChu { get; set; } = string.Empty;
    public Guid? LoaiDuAn { get; set; }
    public string? TenLoaiDuAn { get; set; }
    public bool IsCanhBaoHetHan { get; set; }
}