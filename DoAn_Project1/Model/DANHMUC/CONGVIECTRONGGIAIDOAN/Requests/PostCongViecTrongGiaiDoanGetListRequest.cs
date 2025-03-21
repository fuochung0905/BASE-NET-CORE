using Model.BASE;

namespace MODELS.DANHMUC.CONGVIECTRONGGIAIDOAN.Requests;

public class PostCongViecTrongGiaiDoanGetListRequest : GetListPagingRequest
{
    public Guid? GiaiDoanId { get; set; }
}