using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public partial class DM_MONHOC
    {
        public Guid Id { get; set; }
        public string Ma {  get; set; }
        public Guid NienKhoaId { get; set; }
        public DM_NIENKHOA DM_NIENKHOA { get; set; }
        public string TenGoi { get; set; } = null!;

        public int? SoTinChi { get; set; }

        public int? SoLuongMax { get; set; }

        public int? SoLuongThucTe { get; set; }

        public string? PhongHoc { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }
        public int ThuTrongTuan { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public DateTime? NgayTao {  get; set; }

        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<DUAN_QUANLYDUAN> dUAN_QUANLYDUANs { get; set; }
        public ICollection<MONHOC_NGUOITHAMGIA> mONHOC_NGUOITHAMGIAs   { get; set; }
        public ICollection<CHAT_CONVERSATION> cHAT_CONVERSATIONs { get; set; }
        public ICollection<DM_TEAM> dM_TEAMs { get; set; }
        public Guid PhongBanId { get; set; }
        public DM_PHONGBAN DM_PHONGBAN { get; set; }
    }
}
