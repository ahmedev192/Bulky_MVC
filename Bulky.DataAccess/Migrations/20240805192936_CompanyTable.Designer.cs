﻿// <auto-generated />
using System;
using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240805192936_CompanyTable")]
    partial class CompanyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Bulky.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Tech City",
                            Name = "Tech Solution",
                            PhoneNumber = "6669990000",
                            PostalCode = "12121",
                            State = "IL",
                            StreetAddress = "123 Tech St"
                        },
                        new
                        {
                            Id = 2,
                            City = "Vid City",
                            Name = "Vivid Books",
                            PhoneNumber = "7779990000",
                            PostalCode = "66666",
                            State = "IL",
                            StreetAddress = "999 Vid St"
                        },
                        new
                        {
                            Id = 3,
                            City = "Lala land",
                            Name = "Readers Club",
                            PhoneNumber = "1113335555",
                            PostalCode = "99999",
                            State = "NY",
                            StreetAddress = "999 Main St"
                        });
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Harper Lee",
                            CategoryId = 1,
                            Description = "A novel by Harper Lee published in 1960.",
                            ISBN = "9780060935467",
                            ImageUrl = "",
                            ListPrice = 14.99,
                            Price = 12.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 2,
                            Author = "George Orwell",
                            CategoryId = 2,
                            Description = "A dystopian novel by George Orwell published in 1949.",
                            ISBN = "9780451524935",
                            ImageUrl = "",
                            ListPrice = 9.9900000000000002,
                            Price = 8.9900000000000002,
                            Price100 = 6.9900000000000002,
                            Price50 = 7.9900000000000002,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 3,
                            Author = "F. Scott Fitzgerald",
                            CategoryId = 3,
                            Description = "A novel by F. Scott Fitzgerald published in 1925.",
                            ISBN = "9780743273565",
                            ImageUrl = "",
                            ListPrice = 10.99,
                            Price = 9.9900000000000002,
                            Price100 = 7.9900000000000002,
                            Price50 = 8.9900000000000002,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jane Austen",
                            CategoryId = 4,
                            Description = "A novel by Jane Austen published in 1813.",
                            ISBN = "9781503290563",
                            ImageUrl = "",
                            ListPrice = 11.99,
                            Price = 10.99,
                            Price100 = 8.9900000000000002,
                            Price50 = 9.9900000000000002,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 5,
                            Author = "J.D. Salinger",
                            CategoryId = 5,
                            Description = "A novel by J.D. Salinger published in 1951.",
                            ISBN = "9780316769488",
                            ImageUrl = "",
                            ListPrice = 13.99,
                            Price = 12.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 6,
                            Author = "J.R.R. Tolkien",
                            CategoryId = 1,
                            Description = "A fantasy novel by J.R.R. Tolkien published in 1937.",
                            ISBN = "9780547928227",
                            ImageUrl = "",
                            ListPrice = 15.99,
                            Price = 14.99,
                            Price100 = 12.99,
                            Price50 = 13.99,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Ray Bradbury",
                            CategoryId = 2,
                            Description = "A dystopian novel by Ray Bradbury published in 1953.",
                            ISBN = "9781451673319",
                            ImageUrl = "",
                            ListPrice = 12.99,
                            Price = 11.99,
                            Price100 = 9.9900000000000002,
                            Price50 = 10.99,
                            Title = "Fahrenheit 451"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Aldous Huxley",
                            CategoryId = 3,
                            Description = "A dystopian novel by Aldous Huxley published in 1932.",
                            ISBN = "9780060850524",
                            ImageUrl = "",
                            ListPrice = 13.99,
                            Price = 12.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "Brave New World"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Herman Melville",
                            CategoryId = 4,
                            Description = "A novel by Herman Melville published in 1851.",
                            ISBN = "9781503280786",
                            ImageUrl = "",
                            ListPrice = 14.99,
                            Price = 13.99,
                            Price100 = 11.99,
                            Price50 = 12.99,
                            Title = "Moby-Dick"
                        },
                        new
                        {
                            Id = 10,
                            Author = "J.R.R. Tolkien",
                            CategoryId = 5,
                            Description = "A fantasy epic by J.R.R. Tolkien published in 1954.",
                            ISBN = "9780618640157",
                            ImageUrl = "",
                            ListPrice = 24.989999999999998,
                            Price = 22.989999999999998,
                            Price100 = 19.989999999999998,
                            Price50 = 21.989999999999998,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 11,
                            Author = "Paulo Coelho",
                            CategoryId = 1,
                            Description = "A novel by Paulo Coelho published in 1988.",
                            ISBN = "9780062315007",
                            ImageUrl = "",
                            ListPrice = 16.989999999999998,
                            Price = 15.99,
                            Price100 = 13.99,
                            Price50 = 14.99,
                            Title = "The Alchemist"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Dan Brown",
                            CategoryId = 2,
                            Description = "A mystery thriller by Dan Brown published in 2003.",
                            ISBN = "9780307474278",
                            ImageUrl = "",
                            ListPrice = 18.989999999999998,
                            Price = 17.989999999999998,
                            Price100 = 15.99,
                            Price50 = 16.989999999999998,
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            Id = 13,
                            Author = "Margaret Mitchell",
                            CategoryId = 3,
                            Description = "A historical novel by Margaret Mitchell published in 1936.",
                            ISBN = "9780684805270",
                            ImageUrl = "",
                            ListPrice = 22.989999999999998,
                            Price = 20.989999999999998,
                            Price100 = 18.989999999999998,
                            Price50 = 19.989999999999998,
                            Title = "Gone with the Wind"
                        },
                        new
                        {
                            Id = 14,
                            Author = "Joseph Heller",
                            CategoryId = 4,
                            Description = "A satirical novel by Joseph Heller published in 1961.",
                            ISBN = "9781451626650",
                            ImageUrl = "",
                            ListPrice = 15.99,
                            Price = 14.99,
                            Price100 = 12.99,
                            Price50 = 13.99,
                            Title = "Catch-22"
                        },
                        new
                        {
                            Id = 15,
                            Author = "Stephen King",
                            CategoryId = 5,
                            Description = "A horror novel by Stephen King published in 1977.",
                            ISBN = "9780307743657",
                            ImageUrl = "",
                            ListPrice = 17.989999999999998,
                            Price = 16.989999999999998,
                            Price100 = 14.99,
                            Price50 = 15.99,
                            Title = "The Shining"
                        },
                        new
                        {
                            Id = 16,
                            Author = "Stieg Larsson",
                            CategoryId = 1,
                            Description = "A crime novel by Stieg Larsson published in 2005.",
                            ISBN = "9780307454546",
                            ImageUrl = "",
                            ListPrice = 18.989999999999998,
                            Price = 17.989999999999998,
                            Price100 = 15.99,
                            Price50 = 16.989999999999998,
                            Title = "The Girl with the Dragon Tattoo"
                        },
                        new
                        {
                            Id = 17,
                            Author = "J.D. Salinger",
                            CategoryId = 2,
                            Description = "A novel by J.D. Salinger published in 1951.",
                            ISBN = "9780316769488",
                            ImageUrl = "",
                            ListPrice = 13.99,
                            Price = 12.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 18,
                            Author = "J.K. Rowling",
                            CategoryId = 3,
                            Description = "A fantasy novel by J.K. Rowling published in 1997.",
                            ISBN = "9780439708180",
                            ImageUrl = "",
                            ListPrice = 19.989999999999998,
                            Price = 18.989999999999998,
                            Price100 = 16.989999999999998,
                            Price50 = 17.989999999999998,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            Id = 19,
                            Author = "Louisa May Alcott",
                            CategoryId = 4,
                            Description = "A novel by Louisa May Alcott published in 1868.",
                            ISBN = "9780147514010",
                            ImageUrl = "",
                            ListPrice = 11.99,
                            Price = 10.99,
                            Price100 = 8.9900000000000002,
                            Price50 = 9.9900000000000002,
                            Title = "Little Women"
                        },
                        new
                        {
                            Id = 20,
                            Author = "Emily Brontë",
                            CategoryId = 5,
                            Description = "A novel by Emily Brontë published in 1847.",
                            ISBN = "9781505312561",
                            ImageUrl = "",
                            ListPrice = 13.99,
                            Price = 12.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "Wuthering Heights"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Bulky.Models.Product", b =>
                {
                    b.HasOne("Bulky.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bulky.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bulky.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bulky.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bulky.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
