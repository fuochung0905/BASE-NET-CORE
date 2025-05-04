using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public class PHONGBAN_NGUOITHAMGIA
    {
        public Guid? Id { get; set; }
        public Guid TaiKhoanId { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
        public Guid? PhongBanId { get; set; }
        public DM_PHONGBAN DM_PHONGBAN { get; set; }
    }
}
