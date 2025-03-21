using Model.BASE;

namespace MODELS.DANHMUC.GIAIDOANDUAN.Dtos;

public class MODELGiaiDoanDuAn : MODELBase
{
	public Guid Id { get; set; }
	public string? Ma { get; set; }
	public string? TenGoi { get; set; }
}