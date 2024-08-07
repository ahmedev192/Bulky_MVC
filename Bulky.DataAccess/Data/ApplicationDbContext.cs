using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
new Category { Id = 1, Name = "Aqidah (Creed)", DisplayOrder = 1 },
new Category { Id = 2, Name = "Hadith", DisplayOrder = 2 },
new Category { Id = 3, Name = "Fiqh (Jurisprudence)", DisplayOrder = 3 },
new Category { Id = 4, Name = "Tafsir (Quranic Exegesis)", DisplayOrder = 4 },
new Category { Id = 5, Name = "Spirituality", DisplayOrder = 5 }

            );


            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
new Product { Id = 1, Title = "Riyad as-Salihin", Description = "A collection of hadith compiled by Imam Nawawi.", ISBN = "9781591440425", Author = "Imam Nawawi", ListPrice = 24.99, Price = 22.99, Price50 = 21.99, Price100 = 19.99, CategoryId = 2, ImageUrl = "/images/products/riyad-salehen.jpg" },
new Product { Id = 2, Title = "Al-Adab Al-Mufrad", Description = "A book on Islamic manners compiled by Imam Bukhari.", ISBN = "9781591440715", Author = "Imam Bukhari", ListPrice = 19.99, Price = 17.99, Price50 = 16.99, Price100 = 15.99, CategoryId = 2, ImageUrl = "/images/products/Al-Adab Al-Mufrad.jpg" },
new Product { Id = 3, Title = "Ihya Ulum al-Din", Description = "A seminal work on Islamic spirituality by Imam Al-Ghazali.", ISBN = "9781903682417", Author = "Imam Al-Ghazali", ListPrice = 34.99, Price = 32.99, Price50 = 30.99, Price100 = 28.99, CategoryId = 5, ImageUrl = "/images/products/Ihya Ulum al-Din.jpg" },
new Product { Id = 4, Title = "Sahih al-Bukhari", Description = "One of the most authentic collections of hadith in Islam.", ISBN = "9781591440487", Author = "Imam Bukhari", ListPrice = 29.99, Price = 27.99, Price50 = 25.99, Price100 = 23.99, CategoryId = 2, ImageUrl = "/images/products/Sahih al-Bukhari.jpg" },
new Product { Id = 5, Title = "Al-Muwatta", Description = "A book of hadith and Islamic jurisprudence compiled by Imam Malik.", ISBN = "9781591440821", Author = "Imam Malik", ListPrice = 24.99, Price = 22.99, Price50 = 21.99, Price100 = 19.99, CategoryId = 3, ImageUrl = "/images/products/Al-Muwatta.jpg" },
new Product { Id = 6, Title = "Tafsir al-Jalalayn", Description = "A classical commentary on the Quran by Jalal ad-Din al-Mahalli and Jalal ad-Din as-Suyuti.", ISBN = "9781842000871", Author = "Jalal ad-Din al-Mahalli & Jalal ad-Din as-Suyuti", ListPrice = 39.99, Price = 37.99, Price50 = 35.99, Price100 = 33.99, CategoryId = 4, ImageUrl = "/images/products/Tafsir al-Jalalayn.png" },
new Product { Id = 7, Title = "Fath al-Bari", Description = "A comprehensive commentary on Sahih al-Bukhari by Ibn Hajar al-Asqalani.", ISBN = "9781591440029", Author = "Ibn Hajar al-Asqalani", ListPrice = 49.99, Price = 47.99, Price50 = 45.99, Price100 = 43.99, CategoryId = 2, ImageUrl = "/images/products/Fath al-Bari.jpg" },
new Product { Id = 8, Title = "The Forty Hadith", Description = "A collection of forty important hadith compiled by Imam Nawawi.", ISBN = "9781591440586", Author = "Imam Nawawi", ListPrice = 12.99, Price = 11.99, Price50 = 10.99, Price100 = 9.99, CategoryId = 2, ImageUrl = "/images/products/The Forty Hadith.jpg" },
new Product { Id = 9, Title = "The Purification of the Soul", Description = "A book on Islamic spirituality by Ibn Rajab al-Hanbali, Ibn al-Qayyim, and Imam al-Ghazali.", ISBN = "9781591440548", Author = "Ibn Rajab al-Hanbali, Ibn al-Qayyim, and Imam al-Ghazali", ListPrice = 14.99, Price = 13.99, Price50 = 12.99, Price100 = 11.99, CategoryId = 5, ImageUrl = "/images/products/The Purification of the Soul.jpg" },
new Product { Id = 10, Title = "Kitab al-Tawhid", Description = "A book on the oneness of God by Muhammad ibn Abd al-Wahhab.", ISBN = "9789960897313", Author = "Muhammad ibn Abd al-Wahhab", ListPrice = 19.99, Price = 17.99, Price50 = 16.99, Price100 = 15.99, CategoryId = 1, ImageUrl = "/images/products/Kitab al-Tawhid.jpg" }

);






            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Tech Solution",
                   StreetAddress = "123 Tech St",
                   City = "Tech City",
                   PostalCode = "12121",
                   State = "IL",
                   PhoneNumber = "6669990000"
               },
               new Company
               {
                   Id = 2,
                   Name = "Vivid Books",
                   StreetAddress = "999 Vid St",
                   City = "Vid City",
                   PostalCode = "66666",
                   State = "IL",
                   PhoneNumber = "7779990000"
               },
               new Company
               {
                   Id = 3,
                   Name = "Readers Club",
                   StreetAddress = "999 Main St",
                   City = "Lala land",
                   PostalCode = "99999",
                   State = "NY",
                   PhoneNumber = "1113335555"
               }
               );

        }
    }
}
