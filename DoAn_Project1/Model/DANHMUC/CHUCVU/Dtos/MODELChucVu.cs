using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.CHUCVU.Dtos
{
    public class MODELChucVu :MODELBase
    {
        public Guid Id { get; set; }

        public string MaChucVu { get; set; } = null!;

        public string TenChucVu { get; set; } = null!;
        public Guid? PhongBanId { get; set; }
        public string TenPhongBan { get; set; }
    }
}
