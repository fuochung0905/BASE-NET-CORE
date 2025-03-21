
using Model.BASE;
using MODELS.DANHMUC.Requests;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.GIAIDOANDUAN.Requests;
public class PostGiaiDoanDuAnRequest : BaseRequest
{
	public Guid Id { get; set; }
	public string? Ma { get; set; }
	[Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
	public string? TenGoi { get; set; }
}
