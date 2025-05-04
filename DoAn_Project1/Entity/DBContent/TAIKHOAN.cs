using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class TAIKHOAN
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public Guid VaiTroId { get; set; }
    public VAITRO VAITRO { get; set; }
    public Guid? LoaiTaiKhoanId { get; set; }
    public DM_LOAITAIKHOAN DM_LOAITAIKHOAN { get; set; }
    public Guid? DonViId { get; set; }
    public DM_DONVI DM_DONVI { get; set; }

    public Guid? PhongBanId { get; set; }
    public DM_PHONGBAN DM_PHONGBAN { get; set; }
    public Guid? NguoiQuanLyId { get; set; }
    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? HoLot { get; set; }

    public string Ten { get; set; } = null!;

    public DateTime? NgaySinh { get; set; }

    public int GioiTinh { get; set; }

    public string? AnhDaiDien { get; set; }

    public string MatKhau { get; set; } = null!;

    public string MatKhauSalt { get; set; } = null!;

    public DateTime NgayTao { get; set; }

    public string NguoiTao { get; set; } = null!;

    public DateTime? NgaySua { get; set; }

    public string? NguoiSua { get; set; }

    public DateTime? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }

    public int CountLoginFail { get; set; }

    public DateTime? TimeLoginFail { get; set; }

    public DateTime? TimeChangePassword { get; set; }

    public bool? IsFirstLogin { get; set; }

    public Guid? ChucVuID { get; set; }
    public DM_CHUCVU CHUCVU { get; set; }
    public Guid? DuAnId { get; set; }
    public DUAN_QUANLYDUAN DUAN_QUANLYDUAN {get ; set; }
    public ICollection<THONGBAO_NGUOIDUNG> tHONGBAO_NGUOIDUNGs { get; set; }
    public ICollection<DUAN_DANHSACHNGUOITHUCHIEN> DUAN_DANHSACHNGUOITHUCHIENs { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC> DUAN_QUANLYCONGVIECs { get; set; }
    public ICollection<QUANLYDUAN_NGUOIDUNG> QUANLYDUAN_NGUOIDUNGs { get; set; }
    public ICollection<MONHOC_NGUOITHAMGIA> mONHOC_NGUOITHAMGIAs { get; set; }
    public ICollection<TEAM_NGUOITHAMGIA> tEAM_NGUOITHAMGIAs{ get; set; }
    public ICollection<CHAT_MESSAGE> cHAT_MESSAGEs { get; set; }
    public ICollection<CHAT_CONVERSATIONMEMBER> CHAT_CONVERSATIONMEMBERs { get; set; }
    public ICollection<PHONGBAN_NGUOITHAMGIA> pHONGBAN_NGUOITHAMGIAs { get; set; }  

}
