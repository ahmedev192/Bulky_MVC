using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Sci-Fi", DisplayOrder = 5 }
            );


            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "To Kill a Mockingbird", Description = "A novel by Harper Lee published in 1960.", ISBN = "9780060935467", Author = "Harper Lee", ListPrice = 14.99, Price = 12.99, Price50 = 11.99, Price100 = 10.99,CategoryId=1 , ImageUrl = "" },
                new Product { Id = 2, Title = "1984", Description = "A dystopian novel by George Orwell published in 1949.", ISBN = "9780451524935", Author = "George Orwell", ListPrice = 9.99, Price = 8.99, Price50 = 7.99, Price100 = 6.99, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 3, Title = "The Great Gatsby", Description = "A novel by F. Scott Fitzgerald published in 1925.", ISBN = "9780743273565", Author = "F. Scott Fitzgerald", ListPrice = 10.99, Price = 9.99, Price50 = 8.99, Price100 = 7.99 , CategoryId = 3 , ImageUrl = "" },
                new Product { Id = 4, Title = "Pride and Prejudice", Description = "A novel by Jane Austen published in 1813.", ISBN = "9781503290563", Author = "Jane Austen", ListPrice = 11.99, Price = 10.99, Price50 = 9.99, Price100 = 8.99 , CategoryId = 4 , ImageUrl = "" },
                new Product { Id = 5, Title = "The Catcher in the Rye", Description = "A novel by J.D. Salinger published in 1951.", ISBN = "9780316769488", Author = "J.D. Salinger", ListPrice = 13.99, Price = 12.99, Price50 = 11.99, Price100 = 10.99 , CategoryId =5, ImageUrl = "" },
                new Product { Id = 6, Title = "The Hobbit", Description = "A fantasy novel by J.R.R. Tolkien published in 1937.", ISBN = "9780547928227", Author = "J.R.R. Tolkien", ListPrice = 15.99, Price = 14.99, Price50 = 13.99, Price100 = 12.99 , CategoryId = 1 , ImageUrl = "" },
                new Product { Id = 7, Title = "Fahrenheit 451", Description = "A dystopian novel by Ray Bradbury published in 1953.", ISBN = "9781451673319", Author = "Ray Bradbury", ListPrice = 12.99, Price = 11.99, Price50 = 10.99, Price100 = 9.99 , CategoryId = 2 , ImageUrl = "" },
                new Product { Id = 8, Title = "Brave New World", Description = "A dystopian novel by Aldous Huxley published in 1932.", ISBN = "9780060850524", Author = "Aldous Huxley", ListPrice = 13.99, Price = 12.99, Price50 = 11.99, Price100 = 10.99 , CategoryId = 3, ImageUrl = "" },
                new Product { Id = 9, Title = "Moby-Dick", Description = "A novel by Herman Melville published in 1851.", ISBN = "9781503280786", Author = "Herman Melville", ListPrice = 14.99, Price = 13.99, Price50 = 12.99, Price100 = 11.99 , CategoryId = 4 , ImageUrl = "" },
                new Product { Id = 10, Title = "The Lord of the Rings", Description = "A fantasy epic by J.R.R. Tolkien published in 1954.", ISBN = "9780618640157", Author = "J.R.R. Tolkien", ListPrice = 24.99, Price = 22.99, Price50 = 21.99, Price100 = 19.99 , CategoryId = 5, ImageUrl = "" },
                new Product { Id = 11, Title = "The Alchemist", Description = "A novel by Paulo Coelho published in 1988.", ISBN = "9780062315007", Author = "Paulo Coelho", ListPrice = 16.99, Price = 15.99, Price50 = 14.99, Price100 = 13.99 , CategoryId = 1 , ImageUrl = "" },
                new Product { Id = 12, Title = "The Da Vinci Code", Description = "A mystery thriller by Dan Brown published in 2003.", ISBN = "9780307474278", Author = "Dan Brown", ListPrice = 18.99, Price = 17.99, Price50 = 16.99, Price100 = 15.99 , CategoryId =2, ImageUrl = "" },
                new Product { Id = 13, Title = "Gone with the Wind", Description = "A historical novel by Margaret Mitchell published in 1936.", ISBN = "9780684805270", Author = "Margaret Mitchell", ListPrice = 22.99, Price = 20.99, Price50 = 19.99, Price100 = 18.99 , CategoryId = 3, ImageUrl = "" },
                new Product { Id = 14, Title = "Catch-22", Description = "A satirical novel by Joseph Heller published in 1961.", ISBN = "9781451626650", Author = "Joseph Heller", ListPrice = 15.99, Price = 14.99, Price50 = 13.99, Price100 = 12.99 , CategoryId = 4, ImageUrl = "" },
                new Product { Id = 15, Title = "The Shining", Description = "A horror novel by Stephen King published in 1977.", ISBN = "9780307743657", Author = "Stephen King", ListPrice = 17.99, Price = 16.99, Price50 = 15.99, Price100 = 14.99 , CategoryId = 5, ImageUrl = "" },
                new Product { Id = 16, Title = "The Girl with the Dragon Tattoo", Description = "A crime novel by Stieg Larsson published in 2005.", ISBN = "9780307454546", Author = "Stieg Larsson", ListPrice = 18.99, Price = 17.99, Price50 = 16.99, Price100 = 15.99   , CategoryId = 1, ImageUrl = "" },
                new Product { Id = 17, Title = "The Catcher in the Rye", Description = "A novel by J.D. Salinger published in 1951.", ISBN = "9780316769488", Author = "J.D. Salinger", ListPrice = 13.99, Price = 12.99, Price50 = 11.99, Price100 = 10.99 , CategoryId = 2, ImageUrl = "" },
                new Product { Id = 18, Title = "Harry Potter and the Sorcerer's Stone", Description = "A fantasy novel by J.K. Rowling published in 1997.", ISBN = "9780439708180", Author = "J.K. Rowling", ListPrice = 19.99, Price = 18.99, Price50 = 17.99, Price100 = 16.99 , CategoryId = 3, ImageUrl = "" },
                new Product { Id = 19, Title = "Little Women", Description = "A novel by Louisa May Alcott published in 1868.", ISBN = "9780147514010", Author = "Louisa May Alcott", ListPrice = 11.99, Price = 10.99, Price50 = 9.99, Price100 = 8.99 , CategoryId =4, ImageUrl = "" },
                new Product { Id = 20, Title = "Wuthering Heights", Description = "A novel by Emily Brontë published in 1847.", ISBN = "9781505312561", Author = "Emily Brontë", ListPrice = 13.99, Price = 12.99, Price50 = 11.99, Price100 = 10.99 , CategoryId = 5, ImageUrl = "" }
            );
        }
    }
}
