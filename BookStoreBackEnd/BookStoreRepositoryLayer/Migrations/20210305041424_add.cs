using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreRepositoryLayer.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WishlistID",
                table: "WishlistTable",
                newName: "WishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WishId",
                table: "WishlistTable",
                newName: "WishlistID");
        }
    }
}
