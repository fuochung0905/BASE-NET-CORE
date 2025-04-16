using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MonHocId",
                table: "DM_TEAM",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DM_TEAM_MonHocId",
                table: "DM_TEAM",
                column: "MonHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DM_TEAM_DM_MONHOC_MonHocId",
                table: "DM_TEAM",
                column: "MonHocId",
                principalTable: "DM_MONHOC",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DM_TEAM_DM_MONHOC_MonHocId",
                table: "DM_TEAM");

            migrationBuilder.DropIndex(
                name: "IX_DM_TEAM_MonHocId",
                table: "DM_TEAM");

            migrationBuilder.DropColumn(
                name: "MonHocId",
                table: "DM_TEAM");
        }
    }
}
