using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class KhoaNgoai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DM_CHUCVUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_CHUCVUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_DONVIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_DONVIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_GIAIDOANDUANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsThuyetTrinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_GIAIDOANDUANs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_LOAIDUANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsThuyetTrinh = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_LOAIDUANs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_LOAITAIKHOANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_LOAITAIKHOANs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenMoRong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_PHANHOIs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiGuiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungHtml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_PHANHOIs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HETHONG_THONGBAOs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HETHONG_THONGBAOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN_NHOMQUYENs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN_NHOMQUYENs", x => x.Id);
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
                name: "VAITROs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITROs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_PHONGBANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_PHONGBANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DM_PHONGBANs_DM_DONVIs_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DM_DONVIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYDUANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TienDo = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LoaiDuAn = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsCanhBaoHetHan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYDUANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYDUANs_DM_GIAIDOANDUANs_GiaiDoanId",
                        column: x => x.GiaiDoanId,
                        principalTable: "DM_GIAIDOANDUANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYDUANs_DM_LOAIDUANs_LoaiDuAn",
                        column: x => x.LoaiDuAn,
                        principalTable: "DM_LOAIDUANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HETHONG_THONGBAO_TEPDINHKEMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BieuMauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenMoRong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HETHONG_THONGBAO_TEPDINHKEMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HETHONG_THONGBAO_TEPDINHKEMs_HETHONG_THONGBAOs_LienKetId",
                        column: x => x.LienKetId,
                        principalTable: "HETHONG_THONGBAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYS_MENUs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhomQuyenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    CoXem = table.Column<bool>(type: "bit", nullable: false),
                    CoThem = table.Column<bool>(type: "bit", nullable: false),
                    CoCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    CoXoa = table.Column<bool>(type: "bit", nullable: false),
                    CoDuyet = table.Column<bool>(type: "bit", nullable: false),
                    CoThongKe = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsShowMenu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_MENUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SYS_MENUs_PHANQUYEN_NHOMQUYENs_NhomQuyenId",
                        column: x => x.NhomQuyenId,
                        principalTable: "PHANQUYEN_NHOMQUYENs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYENs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsXem = table.Column<bool>(type: "bit", nullable: false),
                    IsThem = table.Column<bool>(type: "bit", nullable: false),
                    IsCapNhat = table.Column<bool>(type: "bit", nullable: false),
                    IsXoa = table.Column<bool>(type: "bit", nullable: false),
                    IsDuyet = table.Column<bool>(type: "bit", nullable: false),
                    IsThongKe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYENs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PHANQUYENs_VAITROs_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VAITROs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOANs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiQuanLyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoLot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhauSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CountLoginFail = table.Column<int>(type: "int", nullable: false),
                    TimeLoginFail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeChangePassword = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: true),
                    ChucVuID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TAIKHOANs_DM_CHUCVUs_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "DM_CHUCVUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TAIKHOANs_DM_DONVIs_DonViId",
                        column: x => x.DonViId,
                        principalTable: "DM_DONVIs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TAIKHOANs_DM_PHONGBANs_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "DM_PHONGBANs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TAIKHOANs_DUAN_QUANLYDUANs_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DUAN_QUANLYDUANs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TAIKHOANs_VAITROs_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VAITROs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_DANHSACHNGUOITHUCHIENs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiThucHienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TAIKHOANId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_DANHSACHNGUOITHUCHIENs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_DANHSACHNGUOITHUCHIENs_DUAN_QUANLYDUANs_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DUAN_QUANLYDUANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DUAN_DANHSACHNGUOITHUCHIENs_TAIKHOANs_TAIKHOANId",
                        column: x => x.TAIKHOANId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIECs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCongViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CongViecGiaiDoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CongViecLienQuanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiThucHienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NguoiKiemTraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    DuKienTuNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuKienDenNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioCongDuKien = table.Column<double>(type: "float", nullable: true),
                    ThucTeTuNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThucTeDenNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoGioThucTe = table.Column<double>(type: "float", nullable: true),
                    ThoiGianTest = table.Column<double>(type: "float", nullable: true),
                    TongThoiGianThucHien = table.Column<double>(type: "float", nullable: true),
                    TienDo = table.Column<double>(type: "float", nullable: true),
                    KetQuaCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuongDanSuDungNhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoGioCong = table.Column<double>(type: "float", nullable: true),
                    TAIKHOANId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIECs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIECs_DM_GIAIDOANDUANs_GiaiDoanId",
                        column: x => x.GiaiDoanId,
                        principalTable: "DM_GIAIDOANDUANs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIECs_DUAN_QUANLYDUANs_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DUAN_QUANLYDUANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIECs_SYS_TRANGTHAICONGVIECs_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "SYS_TRANGTHAICONGVIECs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIECs_TAIKHOANs_TAIKHOANId",
                        column: x => x.TAIKHOANId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QUANLYDUAN_NGUOIDUNGs",
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
                    table.PrimaryKey("PK_QUANLYDUAN_NGUOIDUNGs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUANLYDUAN_NGUOIDUNGs_DUAN_QUANLYDUANs_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DUAN_QUANLYDUANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QUANLYDUAN_NGUOIDUNGs_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "THONGBAO_NGUOIDUNGs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThongBaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HETHONG_THONGBAOId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Is_Read = table.Column<bool>(type: "bit", nullable: true),
                    Read_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delivered_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THONGBAO_NGUOIDUNGs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOs_HETHONG_THONGBAOId",
                        column: x => x.HETHONG_THONGBAOId,
                        principalTable: "HETHONG_THONGBAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_THONGBAO_NGUOIDUNGs_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DUAN_LICHSUGIAOVIECs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CongViecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiDangThucHien = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SYS_TRANGTHAICONGVIECId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_LICHSUGIAOVIECs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_LICHSUGIAOVIECs_DUAN_QUANLYCONGVIECs_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "DUAN_QUANLYCONGVIECs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DUAN_LICHSUGIAOVIECs_SYS_TRANGTHAICONGVIECs_SYS_TRANGTHAICONGVIECId",
                        column: x => x.SYS_TRANGTHAICONGVIECId,
                        principalTable: "SYS_TRANGTHAICONGVIECs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_CHITIET",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenCongViecCon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoGioCong = table.Column<double>(type: "float", nullable: true),
                    NgayHoanThanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CongViecId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActived = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    SYS_TRANGTHAICONGVIECId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_CHITIET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIEC_CHITIET_DUAN_QUANLYCONGVIECs_CongViecId",
                        column: x => x.CongViecId,
                        principalTable: "DUAN_QUANLYCONGVIECs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIEC_CHITIET_SYS_TRANGTHAICONGVIECs_SYS_TRANGTHAICONGVIECId",
                        column: x => x.SYS_TRANGTHAICONGVIECId,
                        principalTable: "SYS_TRANGTHAICONGVIECs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_TEPDINHKEMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenMoRong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_TEPDINHKEMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIEC_TEPDINHKEMs_DUAN_QUANLYCONGVIECs_LienKetId",
                        column: x => x.LienKetId,
                        principalTable: "DUAN_QUANLYCONGVIECs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DM_PHONGBANs_DonViId",
                table: "DM_PHONGBANs",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_DANHSACHNGUOITHUCHIENs_DuAnId",
                table: "DUAN_DANHSACHNGUOITHUCHIENs",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_DANHSACHNGUOITHUCHIENs_TAIKHOANId",
                table: "DUAN_DANHSACHNGUOITHUCHIENs",
                column: "TAIKHOANId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_LICHSUGIAOVIECs_CongViecId",
                table: "DUAN_LICHSUGIAOVIECs",
                column: "CongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_LICHSUGIAOVIECs_SYS_TRANGTHAICONGVIECId",
                table: "DUAN_LICHSUGIAOVIECs",
                column: "SYS_TRANGTHAICONGVIECId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_CHITIET_CongViecId",
                table: "DUAN_QUANLYCONGVIEC_CHITIET",
                column: "CongViecId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_CHITIET_SYS_TRANGTHAICONGVIECId",
                table: "DUAN_QUANLYCONGVIEC_CHITIET",
                column: "SYS_TRANGTHAICONGVIECId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_TEPDINHKEMs_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_TEPDINHKEMs",
                column: "LienKetId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIECs_DuAnId",
                table: "DUAN_QUANLYCONGVIECs",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIECs_GiaiDoanId",
                table: "DUAN_QUANLYCONGVIECs",
                column: "GiaiDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIECs_TAIKHOANId",
                table: "DUAN_QUANLYCONGVIECs",
                column: "TAIKHOANId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIECs_TrangThaiId",
                table: "DUAN_QUANLYCONGVIECs",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYDUANs_GiaiDoanId",
                table: "DUAN_QUANLYDUANs",
                column: "GiaiDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYDUANs_LoaiDuAn",
                table: "DUAN_QUANLYDUANs",
                column: "LoaiDuAn");

            migrationBuilder.CreateIndex(
                name: "IX_HETHONG_THONGBAO_TEPDINHKEMs_LienKetId",
                table: "HETHONG_THONGBAO_TEPDINHKEMs",
                column: "LienKetId");

            migrationBuilder.CreateIndex(
                name: "IX_PHANQUYENs_VaiTroId",
                table: "PHANQUYENs",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_QUANLYDUAN_NGUOIDUNGs_DuAnId",
                table: "QUANLYDUAN_NGUOIDUNGs",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_QUANLYDUAN_NGUOIDUNGs_TaiKhoanId",
                table: "QUANLYDUAN_NGUOIDUNGs",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_MENUs_NhomQuyenId",
                table: "SYS_MENUs",
                column: "NhomQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_ChucVuID",
                table: "TAIKHOANs",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_DonViId",
                table: "TAIKHOANs",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_DuAnId",
                table: "TAIKHOANs",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_PhongBanId",
                table: "TAIKHOANs",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_VaiTroId",
                table: "TAIKHOANs",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "HETHONG_THONGBAOId");

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_TaiKhoanId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "TaiKhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DM_LOAITAIKHOANs");

            migrationBuilder.DropTable(
                name: "DUAN_DANHSACHNGUOITHUCHIENs");

            migrationBuilder.DropTable(
                name: "DUAN_LICHSUGIAOVIECs");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_CHITIET");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEMs");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_PHANHOIs");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_TEPDINHKEMs");

            migrationBuilder.DropTable(
                name: "HETHONG_THONGBAO_TEPDINHKEMs");

            migrationBuilder.DropTable(
                name: "PHANQUYENs");

            migrationBuilder.DropTable(
                name: "QUANLYDUAN_NGUOIDUNGs");

            migrationBuilder.DropTable(
                name: "SYS_MENUs");

            migrationBuilder.DropTable(
                name: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropTable(
                name: "PHANQUYEN_NHOMQUYENs");

            migrationBuilder.DropTable(
                name: "HETHONG_THONGBAOs");

            migrationBuilder.DropTable(
                name: "SYS_TRANGTHAICONGVIECs");

            migrationBuilder.DropTable(
                name: "TAIKHOANs");

            migrationBuilder.DropTable(
                name: "DM_CHUCVUs");

            migrationBuilder.DropTable(
                name: "DM_PHONGBANs");

            migrationBuilder.DropTable(
                name: "DUAN_QUANLYDUANs");

            migrationBuilder.DropTable(
                name: "VAITROs");

            migrationBuilder.DropTable(
                name: "DM_DONVIs");

            migrationBuilder.DropTable(
                name: "DM_GIAIDOANDUANs");

            migrationBuilder.DropTable(
                name: "DM_LOAIDUANs");
        }
    }
}
