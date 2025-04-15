using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMONHOC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DM_MONHOC",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: true),
                    SoLuongMax = table.Column<int>(type: "int", nullable: true),
                    SoLuongThucTe = table.Column<int>(type: "int", nullable: true),
                    PhongHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: false),
                    ThuTrongTuan = table.Column<int>(type: "int", nullable: false),
                    GioBatDau = table.Column<TimeOnly>(type: "time", nullable: false),
                    GioKetThuc = table.Column<TimeOnly>(type: "time", nullable: false),
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
                    table.PrimaryKey("PK_DM_MONHOC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_TEAM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_DM_TEAM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MONHOC_NGUOITHAMGIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONHOC_NGUOITHAMGIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MONHOC_NGUOITHAMGIA_DM_MONHOC_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "DM_MONHOC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MONHOC_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TEAM_NGUOITHAMGIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEAM_NGUOITHAMGIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEAM_NGUOITHAMGIA_DM_TEAM_TeamId",
                        column: x => x.TeamId,
                        principalTable: "DM_TEAM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TEAM_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MONHOC_NGUOITHAMGIA_MonHocId",
                table: "MONHOC_NGUOITHAMGIA",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_MONHOC_NGUOITHAMGIA_TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TEAM_NGUOITHAMGIA_TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TEAM_NGUOITHAMGIA_TeamId",
                table: "TEAM_NGUOITHAMGIA",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MONHOC_NGUOITHAMGIA");

            migrationBuilder.DropTable(
                name: "TEAM_NGUOITHAMGIA");

            migrationBuilder.DropTable(
                name: "DM_MONHOC");

            migrationBuilder.DropTable(
                name: "DM_TEAM");
        }
    }
}
