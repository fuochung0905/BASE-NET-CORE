using ENTITIES.DBContent;
using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.MONHOC.Dtos
{
    public class MODELMonHoc : MODELBase
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string NienKhoa { get; set; }
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
        public string TenPhongBan { get; set; }
        public string TenNienKhoa { get; set; }
        
        
    }
}
