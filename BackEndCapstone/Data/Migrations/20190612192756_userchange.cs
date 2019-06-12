using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class userchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae24e023-6eb8-478d-8bec-b715c3ec4e67");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12", 0, "d3e96de6-5a58-49a7-8a2c-7dcba11da44a", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEL+Ddbnbbe85wQsBtmVMOv2o5wxqh1kS74WpUoGiv6LMsQoKXeev7dBo33jcLuhVbA==", null, false, "98acb7d3-66a4-4b5c-b860-d29104b1fe0c", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae24e023-6eb8-478d-8bec-b715c3ec4e67", 0, "cf560501-d2d3-4955-a662-9f6d69fdc491", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAED/sFII5qB3rtb/OpYzrHV4eSQwOHcBkLkf/11qnLnu3fqUSLSVGwWQcuhjy79317g==", null, false, "790d8a93-153d-4825-9e50-ad3028f22bde", false, "admin" });
        }
    }
}
