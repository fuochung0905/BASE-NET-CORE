using Model.BASE;

namespace MODELS.DANHMUC.CONGVIECTRONGGIAIDOAN.Dtos;

public class MODELCongViecTrongGiaiDoan : MODELBase
{
    public Guid Id { get; set; }
    public string? Ma { get; set; }
    public string TenGoi { get; set; } = null!;
    public Guid GiaiDoanId { get; set; }
    public string? GiaiDoan { get; set; } = string.Empty;
}