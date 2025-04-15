using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_QUANLYDUAN
{
    public Guid Id { get; set; }

    public string? MaDuAn { get; set; }

    public string TenDuAn { get; set; } = null!;


    public Guid? GiaiDoanId { get; set; }
    public DM_GIAIDOANDUAN DM_GIAIDOANDUAN {  get; set; }

    public DateTime? ThoiGianBatDau { get; set; }

    public DateTime? ThoiGianKetThuc { get; set; }

    public double? TienDo { get; set; }

    public string? GhiChu { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? LoaiDuAn { get; set; }
    public DM_LOAIDUAN DM_LOAIDUAN { get; set; }

    public bool? IsCanhBaoHetHan { get; set; }
    public ICollection<DUAN_DANHSACHNGUOITHUCHIEN> DUAN_DANHSACHNGUOITHUCHIENs { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC> dUAN_QUANLYCONGVIECs { get; set; }
    public ICollection<QUANLYDUAN_NGUOIDUNG> QUANLYDUAN_NGUOIDUNGs { get; set; }
    public ICollection<TAIKHOAN> tAIKHOANs { get; set; }

}
