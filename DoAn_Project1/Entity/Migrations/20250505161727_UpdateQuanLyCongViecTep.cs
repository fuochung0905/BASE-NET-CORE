using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuanLyCongViecTep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LienKetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenMoRong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoLon = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM_DUAN_QUANLYCONGVIECs_LienKetId",
                        column: x => x.LienKetId,
                        principalTable: "DUAN_QUANLYCONGVIECs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM_LienKetId",
                table: "DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM",
                column: "LienKetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM");
        }
    }
}
