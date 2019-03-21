using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSys.Migrations
{
    public partial class identityupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "Person");
        }
    }
}
