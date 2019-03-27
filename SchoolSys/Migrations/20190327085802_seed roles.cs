using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSys.Migrations
{
    public partial class seedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9a0-ad65-4ff8-ac17-11bd9344e575",
                column: "ConcurrencyStamp",
                value: "4da7f362-fd8d-4f18-a56e-6104ef1fb978");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "c01b892c-d713-4ab6-a9cd-bef50d4305d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ade9a1-4565-4aac-ac17-11bd9344e575",
                column: "ConcurrencyStamp",
                value: "b35d9f26-9b57-4f02-ade7-2f5e9971921b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "422348c9-096e-45be-8349-71350d274965", "AQAAAAEAACcQAAAAEJOKFKtaYEMtDd63gFUXxkV6+8/vqSy7D7Sqq3vuMFtZuGGRxEPKGTJ2npTDpuuzeA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9a0-ad65-4ff8-ac17-11bd9344e575",
                column: "ConcurrencyStamp",
                value: "87065fee-05b2-41aa-b153-000a9f705ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                column: "ConcurrencyStamp",
                value: "71a304b2-a157-4e3a-ab50-31ab802259bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1ade9a1-4565-4aac-ac17-11bd9344e575",
                column: "ConcurrencyStamp",
                value: "501f84f3-c343-4945-972d-647db28e8da5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "031ab9b2-acff-42cd-b30d-b7a1c410a25f", "AQAAAAEAACcQAAAAEGws9bOpjPEQ+8bQQN5M3YWvPxoOkYOIC1Zy+VhYrx3OUHiewQF4Ccu8O+r/Sv5l4g==" });
        }
    }
}
