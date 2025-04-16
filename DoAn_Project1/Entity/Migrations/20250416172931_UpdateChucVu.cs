using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChucVu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "DM_TEAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "DM_MONHOC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhongBanId",
                table: "DM_CHUCVUs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DM_CHUCVUs_PhongBanId",
                table: "DM_CHUCVUs",
                column: "PhongBanId");

            migrationBuilder.AddForeignKey(
                name: "FK_DM_CHUCVUs_DM_PHONGBANs_PhongBanId",
                table: "DM_CHUCVUs",
                column: "PhongBanId",
                principalTable: "DM_PHONGBANs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DM_CHUCVUs_DM_PHONGBANs_PhongBanId",
                table: "DM_CHUCVUs");

            migrationBuilder.DropIndex(
                name: "IX_DM_CHUCVUs_PhongBanId",
                table: "DM_CHUCVUs");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "DM_TEAM");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "DM_MONHOC");

            migrationBuilder.DropColumn(
                name: "PhongBanId",
                table: "DM_CHUCVUs");
        }
    }
}
