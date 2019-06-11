using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class datestuffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102c6fde-c4fa-46a0-a70c-fb1d60f20904");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06f7d7c6-954d-4158-a85e-a1eb5e1bcc0b", 0, "02157956-8aec-4056-b0c1-2d00d44edadd", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMHf61xlUGu1F8iwWqtDxveP9OtwdNW2G9B2fFt6FOMxxC4/OmvdutMCyp3Xhk27Vw==", null, false, "cddf423f-8599-4f91-9e9a-6c74680808d0", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06f7d7c6-954d-4158-a85e-a1eb5e1bcc0b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "102c6fde-c4fa-46a0-a70c-fb1d60f20904", 0, "0bf3f7c6-6eae-4d99-a26a-2cc50893fa9e", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPdTHl0kaOodmjq0QKOygzLbxmTa5k36HJ7fSmsr3GdXGT5LcWbEfImj1RCvf0xjiQ==", null, false, "d3e6f283-5ad0-498c-a434-1df1986e3608", false, "admin" });
        }
    }
}
