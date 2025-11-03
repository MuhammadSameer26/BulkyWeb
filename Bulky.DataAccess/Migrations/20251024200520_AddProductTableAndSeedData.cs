using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "James Holden", "A motivational journey through success, failure, and the lessons of time.", "978-1000000001", 899.0, 850.0, 750.0, 800.0, "Fortunes of Times" },
                    { 2, "Amelia Grant", "An emotional story exploring love, loss, and hope beneath dark skies.", "978-1000000002", 799.0, 760.0, 680.0, 720.0, "Dark Skies Leaves and Wonders" },
                    { 3, "William Carter", "A tale of resilience and courage as one stands strong against life's storms.", "978-1000000003", 950.0, 900.0, 800.0, 850.0, "Rock in the Ocean" },
                    { 4, "Sophie Turner", "A lighthearted romantic comedy full of sweetness, laughter, and nostalgia.", "978-1000000004", 699.0, 650.0, 550.0, 600.0, "Cotton Candy" },
                    { 5, "Noah Anderson", "A mysterious thriller about disappearing truths and chasing the impossible.", "978-1000000005", 999.0, 950.0, 850.0, 900.0, "Vanish in the Sunset" },
                    { 6, "Luna Harper", "A futuristic sci-fi story about destiny, hope, and second chances.", "978-1000000006", 899.0, 860.0, 780.0, 820.0, "Whispers of Tomorrow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
