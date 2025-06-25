using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class addNullDanhGiaCongViec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HuongDanSuDungNhanh",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropColumn(
                name: "NgayHoanThanh",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropColumn(
                name: "SoGioCong",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropColumn(
                name: "ThoiGianTest",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropColumn(
                name: "TongThoiGianThucHien",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.DropColumn(
                name: "levelTask",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.AddColumn<int>(
                name: "DanhGiaCongViec",
                table: "DUAN_QUANLYCONGVIECs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DanhGiaCongViec",
                table: "DUAN_QUANLYCONGVIECs");

            migrationBuilder.AddColumn<string>(
                name: "HuongDanSuDungNhanh",
                table: "DUAN_QUANLYCONGVIECs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayHoanThanh",
                table: "DUAN_QUANLYCONGVIECs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SoGioCong",
                table: "DUAN_QUANLYCONGVIECs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ThoiGianTest",
                table: "DUAN_QUANLYCONGVIECs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TongThoiGianThucHien",
                table: "DUAN_QUANLYCONGVIECs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "levelTask",
                table: "DUAN_QUANLYCONGVIECs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
