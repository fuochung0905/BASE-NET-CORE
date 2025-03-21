using Model.BASE;

namespace MODELS.HETHONG.VAITRO.Dtos
{
    public class MODELNhomQuyen : MODELBase
    {
        public Guid Id { get; set; }
        public string TenGoi { get; set; }
        public string Icon { get; set; }
        public int? Sort { get; set; }
        public Guid? ParentId { get; set; }
        public string? Parent { get; set; }
    }
}
