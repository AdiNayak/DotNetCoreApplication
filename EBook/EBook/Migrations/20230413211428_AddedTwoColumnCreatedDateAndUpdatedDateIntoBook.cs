using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBook.Migrations
{
    public partial class AddedTwoColumnCreatedDateAndUpdatedDateIntoBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Books");
        }
    }
}
