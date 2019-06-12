using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class datestuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e28cbaf-09a4-4d35-b8fd-2e3c19a7ed47");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "102c6fde-c4fa-46a0-a70c-fb1d60f20904", 0, "0bf3f7c6-6eae-4d99-a26a-2cc50893fa9e", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPdTHl0kaOodmjq0QKOygzLbxmTa5k36HJ7fSmsr3GdXGT5LcWbEfImj1RCvf0xjiQ==", null, false, "d3e6f283-5ad0-498c-a434-1df1986e3608", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102c6fde-c4fa-46a0-a70c-fb1d60f20904");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e28cbaf-09a4-4d35-b8fd-2e3c19a7ed47", 0, "663250e0-27ac-4447-9bc4-ddf66641bcf8", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDZSp0qeepjRF1JgZoML++R86IpyAHetRjx3uS+lwjgVDGoBWhVTKxLYJ6gErsD5uA==", null, false, "cf765692-bbb4-45ca-a83e-8c4e11c82cff", false, "admin" });
        }
    }
}
