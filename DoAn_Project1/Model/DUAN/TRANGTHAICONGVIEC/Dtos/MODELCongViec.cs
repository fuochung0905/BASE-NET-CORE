using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.TRANGTHAICONGVIEC.Dtos
{
    public class MODELCongViec : MODELBase
    {
        public Guid Id { get; set; }
        public string? TenCongViec { get; set; } = string.Empty;
        public int SoNgayConLai { get; set; }
        public Guid? DuAnId { get; set; }
        public string? TenDuAn { get; set; } = string.Empty;
        public Guid? GiaiDoanId { get; set; }
        public Guid? CongViecGiaiDoanId { get; set; }
        public Guid? NguoiThucHienId { get; set; }
        public double? ThoiGianTest { get; set; }
        public string? NguoiThucHien { get; set; } = string.Empty;
        public string? AnhDaiDienNguoiThucHien { get; set; }
        public Guid? NguoiKiemTraId { get; set; }

		public string? AnhDaiDienNguoiKiemTra { get; set; }
		public string? NguoiKiemTra { get; set; } = string.Empty;
        public double? GioCongDuKien { get; set; }
        public int? TrangThaiId { get; set; }
        public Guid? AssignTo { get; set; }
        public string? NguoiAssignTo { get; set; } = string.Empty;
        public string? AnhDaiDienNguoiAssignTo { get; set; }
        public bool IsQuanTri { get; set; } = true;
        public int SoLuongTepDinhKem { get; set; }
        public int SoLuongPhanHoi { get; set; }
        public bool? IsThuyetTrinh { get; set; }
        public DateTime? DuKienTuNgay { get; set; }
        public DateTime? DuKienDenNgay { get; set; }
    }
}
