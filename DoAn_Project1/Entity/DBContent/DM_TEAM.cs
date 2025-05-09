﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public partial class DM_TEAM
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenGoi { get; set; } = null!;
        public Guid MonHocId { get; set; }
        public DM_MONHOC DM_MONHOC { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<TEAM_NGUOITHAMGIA> tEAM_NGUOITHAMGIAs { get; set; }
        public ICollection<DUAN_QUANLYDUAN> dUAN_QUANLYDUANs { get; set; }
    }
}
