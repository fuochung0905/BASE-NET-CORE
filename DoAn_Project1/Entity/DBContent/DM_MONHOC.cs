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

        public string TenGoi { get; set; } = null!;

        public int? SoTinChi { get; set; }

        public int? SoLuongMax { get; set; }

        public int? SoLuongThucTe { get; set; }

        public string? PhongHoc { get; set; }

        public DateOnly? NgayBatDau { get; set; }

        public DateOnly NgayKetThuc { get; set; }
        public int ThuTrongTuan { get; set; }
        public TimeOnly GioBatDau { get; set; }
        public TimeOnly GioKetThuc { get; set; }
        public DateTime? NgayTao {  get; set; }

        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<MONHOC_NGUOITHAMGIA> mONHOC_NGUOITHAMGIAs   { get; set; }
    }
}
