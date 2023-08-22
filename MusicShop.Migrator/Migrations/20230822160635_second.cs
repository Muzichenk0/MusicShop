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
                name: "FK_MusicalInstrument_InstrumentType_Id",
                table: "MusicalInstrument");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_User_Id",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferCategory_Offer_Id",
                table: "OfferCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Offer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategory_OfferId",
                table: "OfferCategory",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_UserId",
                table: "Offer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalInstrument_InstrumentTypeId",
                table: "MusicalInstrument",
                column: "InstrumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalInstrument_InstrumentType_InstrumentTypeId",
                table: "MusicalInstrument",
                column: "InstrumentTypeId",
                principalTable: "InstrumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_User_UserId",
                table: "Offer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCategory_Offer_OfferId",
                table: "OfferCategory",
                column: "OfferId",
                principalTable: "Offer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicalInstrument_InstrumentType_InstrumentTypeId",
                table: "MusicalInstrument");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_User_UserId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferCategory_Offer_OfferId",
                table: "OfferCategory");

            migrationBuilder.DropIndex(
                name: "IX_OfferCategory_OfferId",
                table: "OfferCategory");

            migrationBuilder.DropIndex(
                name: "IX_Offer_UserId",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_MusicalInstrument_InstrumentTypeId",
                table: "MusicalInstrument");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Offer");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalInstrument_InstrumentType_Id",
                table: "MusicalInstrument",
                column: "Id",
                principalTable: "InstrumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_User_Id",
                table: "Offer",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCategory_Offer_Id",
                table: "OfferCategory",
                column: "Id",
                principalTable: "Offer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
