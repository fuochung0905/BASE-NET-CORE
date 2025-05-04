using Model.BASE;

namespace MODELS.DUAN.QUANLYDUAN.Requests;
public class GetListQuanLyDuAnRequest : GetListPagingRequest
{
    public Guid? GiaiDoanId { get; set; }
    public Guid? LoaiDuAn { get; set; }
}
