using System;
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
                name: "FK_InstrumentType_InstrumentType_InstrumentTypeId",
                table: "InstrumentType");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentType_InstrumentTypeId",
                table: "InstrumentType");

            migrationBuilder.DropColumn(
                name: "InstrumentTypeId",
                table: "InstrumentType");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentType_ParentId",
                table: "InstrumentType",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentType_InstrumentType_ParentId",
                table: "InstrumentType",
                column: "ParentId",
                principalTable: "InstrumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentType_InstrumentType_ParentId",
                table: "InstrumentType");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentType_ParentId",
                table: "InstrumentType");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrumentTypeId",
                table: "InstrumentType",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentType_InstrumentTypeId",
                table: "InstrumentType",
                column: "InstrumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentType_InstrumentType_InstrumentTypeId",
                table: "InstrumentType",
                column: "InstrumentTypeId",
                principalTable: "InstrumentType",
                principalColumn: "Id");
        }
    }
}
