using Model.BASE;

namespace MODELS.DUAN.TRANGTHAICONGVIEC.Dtos
{
    public class MODELChuyenTrangThaiCongViec : MODELBase
    {
        public Guid Id { get; set; }

        public int? TrangThaiCongViecNguonId { get; set; }

        public int? TrangThaiCongViecDich { get; set; }

        public string? TenChuyenTrangThai { get; set; }
    }
}
