using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DM_CHUCVU
{
    public Guid Id { get; set; }

    public string MaChucVu { get; set; } = null!;

    public string TenChucVu { get; set; } = null!;
    public Guid PhongBanId { get; set; }
    public DM_PHONGBAN DM_PHONGBAN { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
    public ICollection<TAIKHOAN> Taikhoans { get; set; }
}
