using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamersParadise.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AgeRating", "Description", "GenreId", "ImageUrl", "Platform", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "A", "Nova igrica", 1, "string", "PC", 50.5, "EA Sports", "NewGame" },
                    { 2, "E", "Description for EA FC 24", 6, "imageUrlForEaFc24", "PC", 60.0, "EA Sports", "EA FC 24" },
                    { 3, "M", "Description for Call of Duty", 1, "imageUrlForCod", "PC", 59.990000000000002, "Activision", "Call of Duty" },
                    { 4, "E", "Description for Minecraft", 2, "imageUrlForMinecraft", "PC", 26.949999999999999, "Mojang", "Minecraft" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
