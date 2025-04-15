using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public partial class TEAM_NGUOITHAMGIA
    {
        public Guid? Id { get; set; }
        public Guid? TaiKhoanId { get; set; }
        public TAIKHOAN TAIKHOAN { get; set; }
        public Guid? TeamId { get; set; }
        public DM_TEAM DM_TEAM { get; set; }
        public bool IsLeader { get; set; }
    }
}
