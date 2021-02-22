﻿// <auto-generated />
using BookStoreRepositoryLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreRepositoryLayer.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStoreModelLayer.BooksModels.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.Property<string>("BookName")
                        .IsRequired();

                    b.Property<string>("BookPrice")
                        .IsRequired();

                    b.Property<int>("PublishedYear");

                    b.Property<string>("PublisherName")
                        .IsRequired();

                    b.HasKey("BookId");

                    b.ToTable("BookTable");
                });

            modelBuilder.Entity("BookStoreModelLayer.BooksModels.CartModel", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("BookPrice");

                    b.Property<int>("UserId");

                    b.HasKey("CartId");

                    b.ToTable("CartTable");
                });

            modelBuilder.Entity("BookStoreModelLayer.BooksModels.OrderModel", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressTypeId");

                    b.Property<int>("BookId");

                    b.Property<int>("CustomerId");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.ToTable("OrderSummaryTable");
                });

            modelBuilder.Entity("BookStoreModelLayer.BooksModels.WishlistModel", b =>
                {
                    b.Property<int>("WishlitID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("UserId");

                    b.HasKey("WishlitID");

                    b.ToTable("WishlistTable");
                });

            modelBuilder.Entity("BookStoreModelLayer.CustomerModels.CustomerModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("AddressTypeId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<long>("PhoneNumber")
                        .HasMaxLength(10);

                    b.HasKey("CustomerId");

                    b.ToTable("CustomerTable");
                });

            modelBuilder.Entity("BookStoreModelLayer.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("UserTabel");
                });

            modelBuilder.Entity("BookStoreModelLayer.UserModels.AddressTypeModel", b =>
                {
                    b.Property<int>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressType")
                        .IsRequired();

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressTypeTable");
                });
#pragma warning restore 612, 618
        }
    }
}
