using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class addId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7d7c6-954d-4158-a85e-a1eb5e1bcc0b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae24e023-6eb8-478d-8bec-b715c3ec4e67", 0, "cf560501-d2d3-4955-a662-9f6d69fdc491", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAED/sFII5qB3rtb/OpYzrHV4eSQwOHcBkLkf/11qnLnu3fqUSLSVGwWQcuhjy79317g==", null, false, "790d8a93-153d-4825-9e50-ad3028f22bde", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae24e023-6eb8-478d-8bec-b715c3ec4e67");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06f7d7c6-954d-4158-a85e-a1eb5e1bcc0b", 0, "02157956-8aec-4056-b0c1-2d00d44edadd", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMHf61xlUGu1F8iwWqtDxveP9OtwdNW2G9B2fFt6FOMxxC4/OmvdutMCyp3Xhk27Vw==", null, false, "cddf423f-8599-4f91-9e9a-6c74680808d0", false, "admin" });
        }
    }
}
