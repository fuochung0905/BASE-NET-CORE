using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class updateDUan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MonHocId",
                table: "DUAN_QUANLYDUANs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYDUANs_MonHocId",
                table: "DUAN_QUANLYDUANs",
                column: "MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DUAN_QUANLYDUANs_DM_MONHOC_MonHocId",
                table: "DUAN_QUANLYDUANs",
                column: "MonHocId",
                principalTable: "DM_MONHOC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DUAN_QUANLYDUANs_DM_MONHOC_MonHocId",
                table: "DUAN_QUANLYDUANs");

            migrationBuilder.DropIndex(
                name: "IX_DUAN_QUANLYDUANs_MonHocId",
                table: "DUAN_QUANLYDUANs");

            migrationBuilder.DropColumn(
                name: "MonHocId",
                table: "DUAN_QUANLYDUANs");
        }
    }
}
