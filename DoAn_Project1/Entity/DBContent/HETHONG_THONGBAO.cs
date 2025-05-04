using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class HETHONG_THONGBAO
{
    public Guid Id { get; set; }

    public string TieuDe { get; set; } = null!;

    public string? NoiDung { get; set; }

    public int? Type { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
    public ICollection<HETHONG_THONGBAO_TEPDINHKEM> HETHONG_THONGBAO_TEPDINHKEMs { get; set; }
    public ICollection<THONGBAO_NGUOIDUNG> tHONGBAO_NGUOIDUNGs { get; set; }
}
