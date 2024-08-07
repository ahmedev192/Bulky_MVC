using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatebooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aqidah (Creed)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Hadith");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Fiqh (Jurisprudence)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Tafsir (Quranic Exegesis)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Spirituality");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Nawawi", 2, "A collection of hadith compiled by Imam Nawawi.", "9781591440425", "/images/products/riyad-salehen.jpg", 24.989999999999998, 22.989999999999998, 19.989999999999998, 21.989999999999998, "Riyad as-Salihin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Bukhari", "A book on Islamic manners compiled by Imam Bukhari.", "9781591440715", "/images/products/Al-Adab Al-Mufrad.jpg", 19.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "Al-Adab Al-Mufrad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Al-Ghazali", 5, "A seminal work on Islamic spirituality by Imam Al-Ghazali.", "9781903682417", "/images/products/Ihya Ulum al-Din.jpg", 34.990000000000002, 32.990000000000002, 28.989999999999998, 30.989999999999998, "Ihya Ulum al-Din" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Bukhari", 2, "One of the most authentic collections of hadith in Islam.", "9781591440487", "/images/products/Sahih al-Bukhari.jpg", 29.989999999999998, 27.989999999999998, 23.989999999999998, 25.989999999999998, "Sahih al-Bukhari" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Malik", 3, "A book of hadith and Islamic jurisprudence compiled by Imam Malik.", "9781591440821", "/images/products/Al-Muwatta.jpg", 24.989999999999998, 22.989999999999998, 19.989999999999998, 21.989999999999998, "Al-Muwatta" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Jalal ad-Din al-Mahalli & Jalal ad-Din as-Suyuti", 4, "A classical commentary on the Quran by Jalal ad-Din al-Mahalli and Jalal ad-Din as-Suyuti.", "9781842000871", "/images/products/Tafsir al-Jalalayn.png", 39.990000000000002, 37.990000000000002, 33.990000000000002, 35.990000000000002, "Tafsir al-Jalalayn" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Ibn Hajar al-Asqalani", "A comprehensive commentary on Sahih al-Bukhari by Ibn Hajar al-Asqalani.", "9781591440029", "/images/products/Fath al-Bari.jpg", 49.990000000000002, 47.990000000000002, 43.990000000000002, 45.990000000000002, "Fath al-Bari" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Imam Nawawi", 2, "A collection of forty important hadith compiled by Imam Nawawi.", "9781591440586", "/images/products/The Forty Hadith.jpg", 12.99, 11.99, 9.9900000000000002, 10.99, "The Forty Hadith" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "Title" },
                values: new object[] { "Ibn Rajab al-Hanbali, Ibn al-Qayyim, and Imam al-Ghazali", 5, "A book on Islamic spirituality by Ibn Rajab al-Hanbali, Ibn al-Qayyim, and Imam al-Ghazali.", "9781591440548", "/images/products/The Purification of the Soul.jpg", "The Purification of the Soul" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Muhammad ibn Abd al-Wahhab", 1, "A book on the oneness of God by Muhammad ibn Abd al-Wahhab.", "9789960897313", "/images/products/Kitab al-Tawhid.jpg", 19.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "Kitab al-Tawhid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Comedy");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Drama");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Horror");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Sci-Fi");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Harper Lee", 1, "A novel by Harper Lee published in 1960.", "9780060935467", "", 14.99, 12.99, 10.99, 11.99, "To Kill a Mockingbird" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "George Orwell", "A dystopian novel by George Orwell published in 1949.", "9780451524935", "", 9.9900000000000002, 8.9900000000000002, 6.9900000000000002, 7.9900000000000002, "1984" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "F. Scott Fitzgerald", 3, "A novel by F. Scott Fitzgerald published in 1925.", "9780743273565", "", 10.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "The Great Gatsby" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Jane Austen", 4, "A novel by Jane Austen published in 1813.", "9781503290563", "", 11.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Pride and Prejudice" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "J.D. Salinger", 5, "A novel by J.D. Salinger published in 1951.", "9780316769488", "", 13.99, 12.99, 10.99, 11.99, "The Catcher in the Rye" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "J.R.R. Tolkien", 1, "A fantasy novel by J.R.R. Tolkien published in 1937.", "9780547928227", "", 15.99, 14.99, 12.99, 13.99, "The Hobbit" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Author", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Ray Bradbury", "A dystopian novel by Ray Bradbury published in 1953.", "9781451673319", "", 12.99, 11.99, 9.9900000000000002, 10.99, "Fahrenheit 451" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "Aldous Huxley", 3, "A dystopian novel by Aldous Huxley published in 1932.", "9780060850524", "", 13.99, 12.99, 10.99, 11.99, "Brave New World" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "Title" },
                values: new object[] { "Herman Melville", 4, "A novel by Herman Melville published in 1851.", "9781503280786", "", "Moby-Dick" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { "J.R.R. Tolkien", 5, "A fantasy epic by J.R.R. Tolkien published in 1954.", "9780618640157", "", 24.989999999999998, 22.989999999999998, 19.989999999999998, 21.989999999999998, "The Lord of the Rings" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 11, "Paulo Coelho", 1, "A novel by Paulo Coelho published in 1988.", "9780062315007", "", 16.989999999999998, 15.99, 13.99, 14.99, "The Alchemist" },
                    { 12, "Dan Brown", 2, "A mystery thriller by Dan Brown published in 2003.", "9780307474278", "", 18.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "The Da Vinci Code" },
                    { 13, "Margaret Mitchell", 3, "A historical novel by Margaret Mitchell published in 1936.", "9780684805270", "", 22.989999999999998, 20.989999999999998, 18.989999999999998, 19.989999999999998, "Gone with the Wind" },
                    { 14, "Joseph Heller", 4, "A satirical novel by Joseph Heller published in 1961.", "9781451626650", "", 15.99, 14.99, 12.99, 13.99, "Catch-22" },
                    { 15, "Stephen King", 5, "A horror novel by Stephen King published in 1977.", "9780307743657", "", 17.989999999999998, 16.989999999999998, 14.99, 15.99, "The Shining" },
                    { 16, "Stieg Larsson", 1, "A crime novel by Stieg Larsson published in 2005.", "9780307454546", "", 18.989999999999998, 17.989999999999998, 15.99, 16.989999999999998, "The Girl with the Dragon Tattoo" },
                    { 17, "J.D. Salinger", 2, "A novel by J.D. Salinger published in 1951.", "9780316769488", "", 13.99, 12.99, 10.99, 11.99, "The Catcher in the Rye" },
                    { 18, "J.K. Rowling", 3, "A fantasy novel by J.K. Rowling published in 1997.", "9780439708180", "", 19.989999999999998, 18.989999999999998, 16.989999999999998, 17.989999999999998, "Harry Potter and the Sorcerer's Stone" },
                    { 19, "Louisa May Alcott", 4, "A novel by Louisa May Alcott published in 1868.", "9780147514010", "", 11.99, 10.99, 8.9900000000000002, 9.9900000000000002, "Little Women" },
                    { 20, "Emily Brontë", 5, "A novel by Emily Brontë published in 1847.", "9781505312561", "", 13.99, 12.99, 10.99, 11.99, "Wuthering Heights" }
                });
        }
    }
}
