using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public partial class MONHOC_NGUOITHAMGIA
    {
        public Guid? Id { get; set; }
        public Guid? TaiKhoanId { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
        public Guid? MonHocId { get; set; }
        public DM_MONHOC DM_MONHOC { get; set; }
    }
}
