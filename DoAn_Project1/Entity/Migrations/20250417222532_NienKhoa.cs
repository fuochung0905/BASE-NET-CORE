using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class NienKhoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NienKhoaId",
                table: "DM_MONHOC",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DM_NIENKHOA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHienTai = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_DM_NIENKHOA", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DM_MONHOC_NienKhoaId",
                table: "DM_MONHOC",
                column: "NienKhoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DM_MONHOC_DM_NIENKHOA_NienKhoaId",
                table: "DM_MONHOC",
                column: "NienKhoaId",
                principalTable: "DM_NIENKHOA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DM_MONHOC_DM_NIENKHOA_NienKhoaId",
                table: "DM_MONHOC");

            migrationBuilder.DropTable(
                name: "DM_NIENKHOA");

            migrationBuilder.DropIndex(
                name: "IX_DM_MONHOC_NienKhoaId",
                table: "DM_MONHOC");

            migrationBuilder.DropColumn(
                name: "NienKhoaId",
                table: "DM_MONHOC");
        }
    }
}
