using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Product_AND_Category_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Comedy" },
                    { 3, 3, "Drama" },
                    { 4, 4, "Horror" },
                    { 5, 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", 1, "A novel by Harper Lee published in 1960.", "9780060935467", 14.99, 12.99, 10.99, 11.99, "To Kill a Mockingbird" },
                    { 2, "George Orwell", 2, "A dystopian novel by George Orwell published in 1949.", "9780451524935", 9.9900000000000002, 8.9900000000000002, 6.9900000000000002, 7.9900000000000002, "1984" },
                    { 3, "F. Scott Fitzgerald", 3, "A novel by F. Scott Fitzgerald published in 1925.", "9780743273565", 10.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "The Great Gatsby" },
                    { 4, "Jane Austen", 4, "A novel by Jane Austen published in 1813.", "9781503290563", 11.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Pride and Prejudice" },
                    { 5, "J.D. Salinger", 5, "A novel by J.D. Salinger published in 1951.", "9780316769488", 13.99, 12.99, 10.99, 11.99, "The Catcher in the Rye" },
                    { 6, "J.R.R. Tolkien", 1, "A fantasy novel by J.R.R. Tolkien published in 1937.", "9780547928227", 15.99, 14.99, 12.99, 13.99, "The Hobbit" },
                    { 7, "Ray Bradbury", 2, "A dystopian novel by Ray Bradbury published in 1953.", "9781451673319", 12.99, 11.99, 9.9900000000000002, 10.99, "Fahrenheit 451" },
                    { 8, "Aldous Huxley", 3, "A dystopian novel by Aldous Huxley published in 1932.", "9780060850524", 13.99, 12.99, 10.99, 11.99, "Brave New World" },
                    { 9, "Herman Melville", 4, "A novel by Herman Melville published in 1851.", "9781503280786", 14.99, 13.99, 11.99, 12.99, "Moby-Dick" },
                    { 10, "J.R.R. Tolkien", 5, "A fantasy epic by J.R.R. Tolkien published in 1954.", "9780618640157", 24.989999999999998, 22.989999999999998, 19.989999999999998, 21.989999999999998, "The Lord of the Rings" },
                    { 11, "Paulo Coelho", 1, "A novel by Paulo Coelho published in 1988.", "9780062315007", 16.989999999999998, 15.99, 13.99, 14.99, "The Alchemist" },
                    { 12, "Dan Brown", 2, "A mystery thriller by Dan Brown published in 2003.", "9780307474278", 18.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "The Da Vinci Code" },
                    { 13, "Margaret Mitchell", 3, "A historical novel by Margaret Mitchell published in 1936.", "9780684805270", 22.989999999999998, 20.989999999999998, 18.989999999999998, 19.989999999999998, "Gone with the Wind" },
                    { 14, "Joseph Heller", 4, "A satirical novel by Joseph Heller published in 1961.", "9781451626650", 15.99, 14.99, 12.99, 13.99, "Catch-22" },
                    { 15, "Stephen King", 5, "A horror novel by Stephen King published in 1977.", "9780307743657", 17.989999999999998, 16.989999999999998, 14.99, 15.99, "The Shining" },
                    { 16, "Stieg Larsson", 1, "A crime novel by Stieg Larsson published in 2005.", "9780307454546", 18.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "The Girl with the Dragon Tattoo" },
                    { 17, "J.D. Salinger", 2, "A novel by J.D. Salinger published in 1951.", "9780316769488", 13.99, 12.99, 10.99, 11.99, "The Catcher in the Rye" },
                    { 18, "J.K. Rowling", 3, "A fantasy novel by J.K. Rowling published in 1997.", "9780439708180", 19.989999999999998, 18.989999999999998, 16.989999999999998, 17.989999999999998, "Harry Potter and the Sorcerer's Stone" },
                    { 19, "Louisa May Alcott", 4, "A novel by Louisa May Alcott published in 1868.", "9780147514010", 11.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Little Women" },
                    { 20, "Emily Brontë", 5, "A novel by Emily Brontë published in 1847.", "9781505312561", 13.99, 12.99, 10.99, 11.99, "Wuthering Heights" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
