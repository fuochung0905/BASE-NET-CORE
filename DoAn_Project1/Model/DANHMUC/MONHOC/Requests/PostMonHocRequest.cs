using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.MONHOC.Requests
{
    public class PostMonHocRequest : BaseRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã môn học không được để trống")]
        public string Ma { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên môn học không được để trống")]
        public string TenGoi { get; set; } = null!;

        public int? SoTinChi { get; set; }

        public int? SoLuongMax { get; set; }

        public int? SoLuongThucTe { get; set; }

        public string? PhongHoc { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }
        public int ThuTrongTuan { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }
        public Guid? PhongBanId { get; set; }
    }
}
