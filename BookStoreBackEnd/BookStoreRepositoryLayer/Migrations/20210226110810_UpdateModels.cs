using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreRepositoryLayer.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserTabel");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserTabel",
                newName: "FullName");

            migrationBuilder.AddColumn<long>(
                name: "Mobile",
                table: "UserTabel",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "UserTabel");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserTabel",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserTabel",
                nullable: false,
                defaultValue: "");
        }
    }
}
