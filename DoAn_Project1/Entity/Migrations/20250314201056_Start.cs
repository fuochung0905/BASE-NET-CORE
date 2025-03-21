using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DM_CHUCVU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_CHUCVU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_DONVI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Website = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_DONVI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_GIAIDOANDUAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsThuyetTrinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_GIAIDOANDUAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_LOAIDUAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsThuyetTrinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_LOAIDUAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_PHONGBAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false, defaultValueSql: "(((((0)-(0))-(0))-(0))-(0.0))"),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONGBAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_DANHSACHNGUOITHUCHIEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiThucHienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DUAN_LICHSUGIAOVIEC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CongViecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDangThucHien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_LICHSUGIAOVIEC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCongViec = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CongViecGiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CongViecLienQuanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiThucHienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiKiemTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    DuKienTuNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    DuKienDenNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    GioCongDuKien = table.Column<double>(type: "float", nullable: true, comment: "Tính theo giờ"),
                    ThucTeTuNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThucTeDenNgay = table.Column<DateTime>(type: "datetime", nullable: true),
                    SoGioThucTe = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTest = table.Column<double>(type: "float", nullable: true, comment: "Tính theo giờ"),
                    TongThoiGianThucHien = table.Column<double>(type: "float", nullable: true),
                    TienDo = table.Column<double>(type: "float", nullable: true),
                    KetQuaCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuongDanSuDungNhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoGioCong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenMoRong = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUANLYCONGVIEC_LOI_TEPDINHkEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_PHANHOI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiGuiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime", nullable: false),
                    NoiDungHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_PHANHOI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_TEPDINHKEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenMoRong = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_TEPDINHKEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYDUAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDuAn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDuAn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ChuDauTu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    TienDo = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoaiDuAn = table.Column<int>(type: "int", nullable: true),
                    ChiPhiHoSo = table.Column<double>(type: "float", nullable: true),
                    ChiPhiTrienKhai = table.Column<double>(type: "float", nullable: true),
                    ChiPhiCode = table.Column<double>(type: "float", nullable: true),
                    IsCanhBaoHetHan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYDUAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HETHONG_THONGBAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HETHONG_THONGBAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HETHONG_THONGBAO_TEPDINHKEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BieuMauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TenMoRong = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HETHONG_THONGBAO_TEPDINHKEM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControllerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsXem = table.Column<bool>(type: "bit", nullable: false),
                    IsThem = table.Column<bool>(type: "bit", nullable: false),
                    IsCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    IsXoa = table.Column<bool>(type: "bit", nullable: false),
                    IsDuyet = table.Column<bool>(type: "bit", nullable: false),
                    IsThongKe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN_NHOMQUYEN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN_NHOMQUYEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QUANLYDUAN_NGUOIDUNG",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUANLYDUAN_NGUOIDUNG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_MENU",
                columns: table => new
                {
                    ControllerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Controller = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NhomQuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    CoXem = table.Column<bool>(type: "bit", nullable: false),
                    CoThem = table.Column<bool>(type: "bit", nullable: false),
                    CoCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    CoXoa = table.Column<bool>(type: "bit", nullable: false),
                    CoDuyet = table.Column<bool>(type: "bit", nullable: false),
                    CoThongKe = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsShowMenu = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN_QUYEN", x => x.ControllerName);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TRANGTHAICONGVIECs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TRANGTHAICONGVIECs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    TinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    XaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiQuanLyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoaiTaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoDienThoai = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    HoLot = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false, comment: "0: nam, 1: nữ"),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MatKhauSalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CountLoginFail = table.Column<int>(type: "int", nullable: false, comment: "Số lần đăng nhập sai"),
                    TimeLoginFail = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Thời gian đăng nhập sai gần nhất"),
                    TimeChangePassword = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Thời gian đổi mật khẩu gần nhất"),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: true, defaultValue: false, comment: "Là đăng nhập lần đầu"),
                    ChucVuID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "THONGBAO_NGUOIDUNG",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongBaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Is_Read = table.Column<bool>(type: "bit", nullable: true),
                    Read_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Delivered_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THONGBAO_NGUOIDUNG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiSua = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiXoa = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO_1", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DM_CHUCVU");

            migrationBuilder.DropTable(
                name: "DM_DONVI");

            migrationBuilder.DropTable(
                name: "DM_GIAIDOANDUAN");

            migrationBuilder.DropTable(
                name: "DM_LOAIDUAN");

            migrationBuilder.DropTable(
                name: "DM_PHONGBAN");

            migrationBuilder.DropTable(
                name: "DUAN_DANHSACHNGUOITHUCHIEN");

            migrationBuilder.DropTable(
                name: "DUAN_LICHSUGIAOVIEC");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEM");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_PHANHOI");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_TEPDINHKEM");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYDUAN");

            migrationBuilder.DropTable(
                name: "HETHONG_THONGBAO");

            migrationBuilder.DropTable(
                name: "HETHONG_THONGBAO_TEPDINHKEM");

            migrationBuilder.DropTable(
                name: "PHANQUYEN");

            migrationBuilder.DropTable(
                name: "PHANQUYEN_NHOMQUYEN");

            migrationBuilder.DropTable(
                name: "QUANLYDUAN_NGUOIDUNG");

            migrationBuilder.DropTable(
                name: "SYS_MENU");

            migrationBuilder.DropTable(
                name: "SYS_TRANGTHAICONGVIECs");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");

            migrationBuilder.DropTable(
                name: "THONGBAO_NGUOIDUNG");

            migrationBuilder.DropTable(
                name: "VAITRO");
        }
    }
}
