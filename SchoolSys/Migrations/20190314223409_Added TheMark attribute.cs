using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSys.Migrations
{
    public partial class AddedTheMarkattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TheMark",
                table: "Marks",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheMark",
                table: "Marks");
        }
    }
}
