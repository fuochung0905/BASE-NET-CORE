using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class PhongBan_MonHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PhongBanId",
                table: "DM_MONHOC",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DM_MONHOC_PhongBanId",
                table: "DM_MONHOC",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DM_MONHOC_DM_PHONGBANs_PhongBanId",
                table: "DM_MONHOC",
                column: "PhongBanId",
                principalTable: "DM_PHONGBANs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DM_MONHOC_DM_PHONGBANs_PhongBanId",
                table: "DM_MONHOC");

            migrationBuilder.DropIndex(
                name: "IX_DM_MONHOC_PhongBanId",
                table: "DM_MONHOC");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "DM_MONHOC");
        }
    }
}
