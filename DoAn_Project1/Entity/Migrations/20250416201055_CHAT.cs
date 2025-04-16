using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class CHAT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHAT_CONVERSATION",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_CHAT_CONVERSATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHAT_CONVERSATION_DM_MONHOC_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "DM_MONHOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHAT_CONVERSATIONMEMBER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayThamGia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAT_CONVERSATIONMEMBER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHAT_CONVERSATIONMEMBER_CHAT_CONVERSATION_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "CHAT_CONVERSATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHAT_CONVERSATIONMEMBER_TAIKHOANs_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHAT_MESSAGE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiGuiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_CHAT_MESSAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHAT_MESSAGE_CHAT_CONVERSATION_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "CHAT_CONVERSATION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CHAT_MESSAGE_TAIKHOANs_NguoiGuiId",
                        column: x => x.NguoiGuiId,
                        principalTable: "TAIKHOANs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_CONVERSATION_MonHocId",
                table: "CHAT_CONVERSATION",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_CONVERSATIONMEMBER_ConversationId",
                table: "CHAT_CONVERSATIONMEMBER",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_CONVERSATIONMEMBER_TaiKhoanId",
                table: "CHAT_CONVERSATIONMEMBER",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_MESSAGE_ConversationId",
                table: "CHAT_MESSAGE",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_MESSAGE_NguoiGuiId",
                table: "CHAT_MESSAGE",
                column: "NguoiGuiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHAT_CONVERSATIONMEMBER");

            migrationBuilder.DropTable(
                name: "CHAT_MESSAGE");

            migrationBuilder.DropTable(
                name: "CHAT_CONVERSATION");
        }
    }
}
