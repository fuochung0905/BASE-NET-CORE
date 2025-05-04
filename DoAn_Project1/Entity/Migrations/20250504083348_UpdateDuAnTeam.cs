using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDuAnTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MONHOC_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_PHONGBAN_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TEAM_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "DUAN_QUANLYDUANs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYDUANs_TeamId",
                table: "DUAN_QUANLYDUANs",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_DUAN_QUANLYDUANs_DM_TEAM_TeamId",
                table: "DUAN_QUANLYDUANs",
                column: "TeamId",
                principalTable: "DM_TEAM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MONHOC_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHONGBAN_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TEAM_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DUAN_QUANLYDUANs_DM_TEAM_TeamId",
                table: "DUAN_QUANLYDUANs");

            migrationBuilder.DropForeignKey(
                name: "FK_MONHOC_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_PHONGBAN_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TEAM_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA");

            migrationBuilder.DropIndex(
                name: "IX_DUAN_QUANLYDUANs_TeamId",
                table: "DUAN_QUANLYDUANs");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "DUAN_QUANLYDUANs");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_MONHOC_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "MONHOC_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PHONGBAN_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "PHONGBAN_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TEAM_NGUOITHAMGIA_TAIKHOANs_TaiKhoanId",
                table: "TEAM_NGUOITHAMGIA",
                column: "TaiKhoanId",
                principalTable: "TAIKHOANs",
                principalColumn: "Id");
        }
    }
}
