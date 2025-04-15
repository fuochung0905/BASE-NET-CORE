using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_QUANLYCONGVIEC_CHITIET
{
    public Guid Id { get; set; }

    public string TenCongViecCon { get; set; } = null!;

    public double? SoGioCong { get; set; }

    public DateTime NgayHoanThanh { get; set; }

    public Guid CongViecId { get; set; }
    public DUAN_QUANLYCONGVIEC DUAN_QUANLYCONGVIEC { get; set; }

    public int TrangThaiId { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool? IsActived { get; set; }

    public bool? IsDeleted { get; set; }
}
