using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreRepositoryLayer.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "OrderSummaryTable");

            migrationBuilder.RenameColumn(
                name: "WishlitID",
                table: "WishlistTable",
                newName: "WishlistID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderSummaryTable",
                newName: "OrderSummaryID");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CustomerTable",
                newName: "Locality");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "CustomerTable",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "BookPrice",
                table: "CartTable",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CustomerTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PinCode",
                table: "CustomerTable",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "BookPrice",
                table: "BookTable",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "BookCount",
                table: "BookTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookImage",
                table: "BookTable",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "CustomerTable");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "CustomerTable");

            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "BookImage",
                table: "BookTable");

            migrationBuilder.RenameColumn(
                name: "WishlistID",
                table: "WishlistTable",
                newName: "WishlitID");

            migrationBuilder.RenameColumn(
                name: "OrderSummaryID",
                table: "OrderSummaryTable",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Locality",
                table: "CustomerTable",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "CustomerTable",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartTable",
                newName: "BookPrice");

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "OrderSummaryTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "BookPrice",
                table: "BookTable",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
