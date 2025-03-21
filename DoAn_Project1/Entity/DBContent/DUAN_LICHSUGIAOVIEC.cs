using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_LICHSUGIAOVIEC
{
    public Guid Id { get; set; }

    public Guid CongViecId { get; set; }

    public Guid? NguoiDangThucHien { get; set; }

    public int TrangThaiId { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
