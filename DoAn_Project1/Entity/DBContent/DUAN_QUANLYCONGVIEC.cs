using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_QUANLYCONGVIEC
{
    public Guid Id { get; set; }

    public string TenCongViec { get; set; } = null!;

    public Guid DuAnId { get; set; }
    public DUAN_QUANLYDUAN DUAN_QUANLYDUAN { get; set; }

    public Guid? GiaiDoanId { get; set; }
    public DM_GIAIDOANDUAN DM_GIAIDOANDUAN { get; set; }

    public Guid? CongViecGiaiDoanId { get; set; }
    
    public Guid? CongViecLienQuanId { get; set; }

    public string? GhiChu { get; set; }

    public Guid? NguoiThucHienId { get; set; }

    public Guid? NguoiKiemTraId { get; set; }

    public Guid? AssignTo { get; set; }

    public int TrangThaiId { get; set; }
    public SYS_TRANGTHAICONGVIEC SYS_TRANGTHAICONGVIEC { get; set; }

    public DateTime? DuKienTuNgay { get; set; }

    public DateTime? DuKienDenNgay { get; set; }

    /// <summary>
    /// Tính theo giờ
    /// </summary>
    public double? GioCongDuKien { get; set; }

    public DateTime? ThucTeTuNgay { get; set; }

    public DateTime? ThucTeDenNgay { get; set; }

    public double? SoGioThucTe { get; set; }

    /// <summary>
    /// Tính theo giờ
    /// </summary>
    public double? ThoiGianTest { get; set; }

    public double? TongThoiGianThucHien { get; set; }

    public double? TienDo { get; set; }

    public string? KetQuaCongViec { get; set; }

    public string? HuongDanSuDungNhanh { get; set; }

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? ParentId { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public double? SoGioCong { get; set; }
    public ICollection<DUAN_LICHSUGIAOVIEC> DUAN_LICHSUGIAOVIECs { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC_CHITIET> DUAN_QUANLYCONGVIEC_CHITIET {  get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC_TEPDINHKEM> dUAN_QUANLYCONGVIEC_TEPDINHKEMs { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC_PHANHOI> dUAN_QUANLYCONGVIEC_PHANHOIs { get; set; }
}
