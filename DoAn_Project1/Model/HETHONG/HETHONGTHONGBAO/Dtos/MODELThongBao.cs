using Model.BASE;

namespace MODELS.HETHONG.HETHONGTHONGBAO.Dtos
{
    public class MODELThongBao : MODELBase
    {
        public Guid Id { get; set; }

        public string TieuDe { get; set; } 

        public string? NoiDung { get; set; }

        public int? Type { get; set; }
        public List<string>? UserId { get; set; }
    }
}
