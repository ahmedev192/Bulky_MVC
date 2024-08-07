using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tempdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "/images/products/riyad-salehen.jpg", 1 },
                    { 2, "/images/products/Al-Adab Al-Mufrad.jpg", 2 },
                    { 3, "/images/products/Ihya Ulum al-Din.jpg", 3 },
                    { 4, "/images/products/Sahih al-Bukhari.jpg", 4 },
                    { 5, "/images/products/Al-Muwatta.jpg", 5 },
                    { 6, "/images/products/Tafsir al-Jalalayn.png", 6 },
                    { 7, "/images/products/Fath al-Bari.jpg", 7 },
                    { 8, "/images/products/The Forty Hadith.jpg", 8 },
                    { 9, "/images/products/The Purification of the Soul.jpg", 9 },
                    { 10, "/images/products/Kitab al-Tawhid.jpg", 10 },
                    { 11, "/images/products/riyad-salehen.jpg", 1 },
                    { 12, "/images/products/Al-Adab Al-Mufrad.jpg", 2 },
                    { 13, "/images/products/Ihya Ulum al-Din.jpg", 3 },
                    { 14, "/images/products/Sahih al-Bukhari.jpg", 4 },
                    { 15, "/images/products/Al-Muwatta.jpg", 5 },
                    { 16, "/images/products/Tafsir al-Jalalayn.png", 6 },
                    { 17, "/images/products/Fath al-Bari.jpg", 7 },
                    { 18, "/images/products/The Forty Hadith.jpg", 8 },
                    { 19, "/images/products/The Purification of the Soul.jpg", 9 },
                    { 20, "/images/products/Kitab al-Tawhid.jpg", 10 },
                    { 21, "/images/products/riyad-salehen.jpg", 1 },
                    { 22, "/images/products/Al-Adab Al-Mufrad.jpg", 2 },
                    { 23, "/images/products/Ihya Ulum al-Din.jpg", 3 },
                    { 24, "/images/products/Sahih al-Bukhari.jpg", 4 },
                    { 25, "/images/products/Al-Muwatta.jpg", 5 },
                    { 26, "/images/products/Tafsir al-Jalalayn.png", 6 },
                    { 27, "/images/products/Fath al-Bari.jpg", 7 },
                    { 28, "/images/products/The Forty Hadith.jpg", 8 },
                    { 29, "/images/products/The Purification of the Soul.jpg", 9 },
                    { 30, "/images/products/Kitab al-Tawhid.jpg", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
