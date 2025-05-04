using Model.BASE;
using MODELS.BASE;

namespace MODELS.DUAN.QUANLYCONGVIEC.Dtos;
public class MODELQuanLyCongViec : MODELBase
{
	public Guid Id { get; set; }
	public string? TenCongViec { get; set; } = string.Empty;
    public int? TongSoDongThang { get; set; } = 0;
    public Guid? DuAnId { get; set; }
	public string? DuAn { get; set; } = string.Empty;
	public Guid? GiaiDoanId { get; set; }
	public string? GiaiDoan { get; set; } = string.Empty;
	public Guid? CongViecGiaiDoanId { get; set; }
    public int DoKhoCongViec { get; set; }
    public string? CongViecGiaiDoan { get; set; } = string.Empty;
    public Guid? CongViecLienQuanId { get; set; }
    public Guid? NguoiThucHienId { get; set; }
	public string? NguoiThucHien { get; set; } = string.Empty;
	public Guid? NguoiKiemTraId { get; set; }
	public string? NguoiKiemTra { get; set; } = string.Empty;
	public int TrangThaiId { get; set; }
	public string? TrangThai { get; set; } = string.Empty;
	public DateTime? DuKienTuNgay { get; set; }
	public DateTime? DuKienDenNgay { get; set; }
	/// <summary>
	/// Tính theo giờ
	/// </summary>
	public double? GioCongDuKien { get; set; }
	public DateTime? ThucTeTuNgay { get; set; }
	public DateTime? ThucTeDenNgay { get; set; }
	public double? SoGioThucTe { get; set; }
	/// <summary>
	/// Tính theo giờ
	/// </summary>
	public double? ThoiGianTest { get; set; }
	public double? TongThoiGianThucHien { get; set; }
    public double TienDo { get; set; }
	public int SoLoiDaFix { get; set; }
	public double? TongSoGioTestChiTiet { get; set; }
	public int TongSoLoi { get; set; }
    public Guid? AssignTo { get; set; }
	public HashSet<string> listAssignName { get; set; }
	public string? AssignName { get; set; }
	public string? KetQuaCongViec { get; set; }
	public string? HuongDanSuDungNhanh { get; set; }
    public string? GhiChu { get; set; }
	public bool? IsThuyetTrinh { get; set; } 

    public List<MODELQuanLyCongViec_PhanHoi>? DanhSachPhanHoi { get; set; }

    //TepDinhKem
    public string? FolderTemp { get; set; }
    public string? TepDinhKemIDs { get; set; }
    public List<MODELTepDinhKem>? ListTepDinhKem { get; set; }
}
public class MODELQuanLyCongViecTK : MODELBase
{
    public int? Tong { get; set; } = 0;
    public int? TongSoDongThang { get; set; } = 0;
    
}
