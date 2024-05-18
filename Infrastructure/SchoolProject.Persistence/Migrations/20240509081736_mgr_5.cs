using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mgr5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cryptos");

            migrationBuilder.RenameColumn(
                name: "Profit",
                table: "Cryptos",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Cryptos",
                newName: "Profit");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyId",
                table: "Cryptos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CurrentPrice",
                table: "Cryptos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cryptos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
