using Model.BASE;

namespace MODELS.DUAN.QUANLYDUAN.Dtos;
public class MODELQuanLyDuAn : MODELBase
{
    public Guid Id { get; set; }
    public string? MaDuAn { get; set; }
    public string? TenDuAn { get; set; }
    public string? ChuDauTu { get; set; }
    public Guid GiaiDoanId { get; set; }
    public string? GiaiDoan { get; set; }
    public DateTime ThoiGianBatDau { get; set; }
    public DateTime ThoiGianKetThuc { get; set; }
    public double TienDo { get; set; }
    public string GhiChu { get; set; } = string.Empty;
    public int? LoaiDuAn { get; set; }
    public double? ChiPhiHoSo { get; set; }
    public double? ChiPhiTrienKhai { get; set; }
    public double? ChiPhiCode { get; set; }
   

    public bool IsCanhBaoHetHan { get; set; }
}