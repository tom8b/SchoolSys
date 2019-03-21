using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSys.Migrations
{
    public partial class addedemptyadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Person",
                nullable: true);
        }
    }
}
