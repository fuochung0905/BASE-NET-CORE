using System.ComponentModel.DataAnnotations;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using Model.BASE;

namespace MODELS.DUAN.QUANLYCONGVIEC.Requests;
public class PostQuanLyCongViecRequest : BaseRequest
{
	public Guid Id { get; set; }
	[Required(AllowEmptyStrings = false, ErrorMessage = "Tên công việc bắt buộc nhập")]
	public string? TenCongViec { get; set; }
	[Required(ErrorMessage = "Dự án bắt buộc chọn")]
	public Guid? DuAnId { get; set; }
	public Guid? GiaiDoanId { get; set; }
	public Guid? CongViecGiaiDoanId { get; set; }
    public Guid? CongViecLienQuanId { get; set; }
	//[Required(ErrorMessage = "Người thực hiện bắt buộc chọn")]
	public int DoKhoCongViec { get; set; }
    public Guid? NguoiThucHienId { get; set; }
	//[Required(ErrorMessage = "Người kiểm tra bắt buộc chọn")]
	public Guid? NguoiKiemTraId { get; set; }
    public int TrangThaiId { get; set; } = 1;
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
    public double? TienDo { get; set; }
    public Guid? AssignTo { get; set; }
    public string? AssignName { get; set; }
	public string? KetQuaCongViec { get; set; }
	public string? HuongDanSuDungNhanh { get; set; }
    public string? idPopup { get; set; }
    public string? GhiChu { get; set; }

    //TepDinhKem
    public string? FolderTemp { get; set; }
    public string? TepDinhKemIDs { get; set; }
    public List<MODELTepDinhKem>? ListTepDinhKem { get; set; }
    public bool IsTepDinhKem { get; set; } = false;

    public List<PostQuanLiCongViec_ChiTietRequest>? listCongViecChiTiet { get; set; } = new List<PostQuanLiCongViec_ChiTietRequest>();
    public List<PostChiTietCongViecRequest>? listChiTiet { get; set; } = new List<PostChiTietCongViecRequest>();
    //public List<PostSubTaskRequests>? ListSubTask { get; set; } = new List<PostSubTaskRequests>();
    public bool? IsThuyetTrinh { get; set; } = true;
}

