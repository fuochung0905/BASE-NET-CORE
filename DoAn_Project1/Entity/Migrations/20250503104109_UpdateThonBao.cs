using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateThonBao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOs_HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.DropIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.DropColumn(
                name: "HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_ThongBaoId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "ThongBaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOs_ThongBaoId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "ThongBaoId",
                principalTable: "HETHONG_THONGBAOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOs_ThongBaoId",
                table: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.DropIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_ThongBaoId",
                table: "THONGBAO_NGUOIDUNGs");

            migrationBuilder.AddColumn<Guid>(
                name: "HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "HETHONG_THONGBAOId");

            migrationBuilder.AddForeignKey(
                name: "FK_THONGBAO_NGUOIDUNGs_HETHONG_THONGBAOs_HETHONG_THONGBAOId",
                table: "THONGBAO_NGUOIDUNGs",
                column: "HETHONG_THONGBAOId",
                principalTable: "HETHONG_THONGBAOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
