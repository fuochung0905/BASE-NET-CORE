namespace MODELS.DUAN.QUANLYCONGVIEC.Dtos;
public class MODELQuanLyCongViec_PhanHoi
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public Guid LienKetId { get; set; }
    public Guid NguoiGuiId { get; set; }
    public string? NguoiGui { get; set; }
    public DateTime NgayGui { get; set; }
    public string NoiDungHtml { get; set; } = string.Empty;
    public string? PhanHoiByUsername { get; set; }
}
