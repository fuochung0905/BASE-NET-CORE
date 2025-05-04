using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DM_PHONGBAN
{
    public Guid Id { get; set; }
    
    public Guid DonViId { get; set; }
    public DM_DONVI DM_DONVI { get; set; }
    public string? Ma { get; set; }

    public string TenGoi { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
    public ICollection<TAIKHOAN> Taikhoans { get; set; }
    public ICollection<DM_CHUCVU> dM_CHUCVUs { get; set; }
    public ICollection<DM_MONHOC> dM_MONHOCs { get; set; }
    public ICollection<PHONGBAN_NGUOITHAMGIA> dM_PHONGBAN_NHGIA { get; set; }
}
