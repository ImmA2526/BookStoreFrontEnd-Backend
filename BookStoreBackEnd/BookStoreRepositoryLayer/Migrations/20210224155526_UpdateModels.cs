using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreRepositoryLayer.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypeTable",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypeTable", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BookTable",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookName = table.Column<string>(nullable: false),
                    BookDescription = table.Column<string>(nullable: false),
                    BookImage = table.Column<string>(nullable: false),
                    BookCount = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    BookPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    BookCount = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTable",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<long>(maxLength: 10, nullable: false),
                    PinCode = table.Column<long>(nullable: false),
                    Locality = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTable", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "OrderSummaryTable",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderSummaryID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSummaryTable", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "UserTabel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTabel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WishlistTable",
                columns: table => new
                {
                    WishlistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistTable", x => x.WishlistID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressTypeTable");

            migrationBuilder.DropTable(
                name: "BookTable");

            migrationBuilder.DropTable(
                name: "CartTable");

            migrationBuilder.DropTable(
                name: "CustomerTable");

            migrationBuilder.DropTable(
                name: "OrderSummaryTable");

            migrationBuilder.DropTable(
                name: "UserTabel");

            migrationBuilder.DropTable(
                name: "WishlistTable");
        }
    }
}
