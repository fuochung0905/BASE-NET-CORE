using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKhoaNgoai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoaiTaiKhoanId",
                table: "TAIKHOANs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOANs_LoaiTaiKhoanId",
                table: "TAIKHOANs",
                column: "LoaiTaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_PHANHOIs_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_PHANHOIs",
                column: "LienKetId");

            migrationBuilder.AddForeignKey(
                name: "FK_DUAN_QUANLYCONGVIEC_PHANHOIs_DUAN_QUANLYCONGVIECs_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_PHANHOIs",
                column: "LienKetId",
                principalTable: "DUAN_QUANLYCONGVIECs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAIKHOANs_DM_LOAITAIKHOANs_LoaiTaiKhoanId",
                table: "TAIKHOANs",
                column: "LoaiTaiKhoanId",
                principalTable: "DM_LOAITAIKHOANs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DUAN_QUANLYCONGVIEC_PHANHOIs_DUAN_QUANLYCONGVIECs_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_PHANHOIs");

            migrationBuilder.DropForeignKey(
                name: "FK_TAIKHOANs_DM_LOAITAIKHOANs_LoaiTaiKhoanId",
                table: "TAIKHOANs");

            migrationBuilder.DropIndex(
                name: "IX_TAIKHOANs_LoaiTaiKhoanId",
                table: "TAIKHOANs");

            migrationBuilder.DropIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_PHANHOIs_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_PHANHOIs");

            migrationBuilder.DropColumn(
                name: "LoaiTaiKhoanId",
                table: "TAIKHOANs");
        }
    }
}
