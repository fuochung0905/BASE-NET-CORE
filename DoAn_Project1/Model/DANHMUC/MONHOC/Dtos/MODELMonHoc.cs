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
    }
}
