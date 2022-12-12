using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beercyclopedia.Migrations
{
    /// <inheritdoc />
    public partial class AddIBUAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IBU",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "IBU",
                table: "Beers");
        }
    }
}
