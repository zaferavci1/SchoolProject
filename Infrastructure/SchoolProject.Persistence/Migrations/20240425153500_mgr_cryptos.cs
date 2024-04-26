using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgrcryptos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Baskets_BasketId",
                table: "Cryptos");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId1",
                table: "Cryptos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_BasketId1",
                table: "Cryptos",
                column: "BasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Baskets_BasketId",
                table: "Cryptos",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Baskets_BasketId1",
                table: "Cryptos",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Baskets_BasketId",
                table: "Cryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Baskets_BasketId1",
                table: "Cryptos");

            migrationBuilder.DropIndex(
                name: "IX_Cryptos_BasketId1",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "BasketId1",
                table: "Cryptos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Baskets_BasketId",
                table: "Cryptos",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
