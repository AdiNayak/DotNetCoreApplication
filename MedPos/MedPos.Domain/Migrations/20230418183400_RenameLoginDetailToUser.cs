using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPos.Domain.Migrations
{
    public partial class RenameLoginDetailToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails");

            migrationBuilder.RenameTable(
                name: "LoginDetails",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "LoginDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginDetails",
                table: "LoginDetails",
                column: "UserId");
        }
    }
}
