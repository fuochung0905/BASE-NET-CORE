using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhongBan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PHONGBAN_NGUOITHAMGIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhongBanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONGBAN_NGUOITHAMGIA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PHONGBAN_NGUOITHAMGIA_DM_PHONGBANs_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "DM_PHONGBANs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PHONGBAN_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHONGBAN_NGUOITHAMGIA_PhongBanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_PHONGBAN_NGUOITHAMGIA_TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                column: "TaiKhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHONGBAN_NGUOITHAMGIA");
        }
    }
}
