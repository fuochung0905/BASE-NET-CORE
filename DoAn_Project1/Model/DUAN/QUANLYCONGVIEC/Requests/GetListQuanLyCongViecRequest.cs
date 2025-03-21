using Model.BASE;

namespace MODELS.DUAN.QUANLYCONGVIEC.Requests;
public class GetListQuanLyCongViecRequest : GetListPagingRequest
{
	public Guid? DuAnId { get; set; }
	public Guid? GiaiDoanId { get; set; }
	public Guid? CongViecTrongGiaiDoanId { get; set; }
	public int TrangThaiId { get; set; }
	public Guid? NguoiThucHienId { get; set; }
	public Guid? NguoiKiemTraId { get; set; }
	public Guid? AssignTo { get; set; }
}
