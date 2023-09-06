using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicShop.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentType_User_UserId",
                table: "InstrumentType");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentType_UserId",
                table: "InstrumentType");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InstrumentType");

            migrationBuilder.CreateTable(
                name: "InstrumentTypeUser",
                columns: table => new
                {
                    QualificationsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentTypeUser", x => new { x.QualificationsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_InstrumentTypeUser_InstrumentType_QualificationsId",
                        column: x => x.QualificationsId,
                        principalTable: "InstrumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentTypeUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentTypeUser_UsersId",
                table: "InstrumentTypeUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentTypeUser");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InstrumentType",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentType_UserId",
                table: "InstrumentType",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentType_User_UserId",
                table: "InstrumentType",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
