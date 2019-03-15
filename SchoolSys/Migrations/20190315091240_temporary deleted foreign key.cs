using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSys.Migrations
{
    public partial class temporarydeletedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_TutorForeignKey",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TutorForeignKey",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Teachers");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TutorForeignKey",
                table: "Classes",
                column: "TutorForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_TutorForeignKey",
                table: "Classes",
                column: "TutorForeignKey",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
