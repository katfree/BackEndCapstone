using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class help : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyAttendee_AspNetUsers_UserId1",
                table: "PartyAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchParty_Team_TeamId1",
                table: "WatchParty");

            migrationBuilder.DropIndex(
                name: "IX_WatchParty_TeamId1",
                table: "WatchParty");

            migrationBuilder.DropIndex(
                name: "IX_PartyAttendee_UserId1",
                table: "PartyAttendee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a714a235-598d-4623-b7d9-e4513b2df965");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "WatchParty");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PartyAttendee");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "WatchParty",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PartyAttendee",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e28cbaf-09a4-4d35-b8fd-2e3c19a7ed47", 0, "663250e0-27ac-4447-9bc4-ddf66641bcf8", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDZSp0qeepjRF1JgZoML++R86IpyAHetRjx3uS+lwjgVDGoBWhVTKxLYJ6gErsD5uA==", null, false, "cf765692-bbb4-45ca-a83e-8c4e11c82cff", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchParty_TeamId",
                table: "WatchParty",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendee_UserId",
                table: "PartyAttendee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyAttendee_AspNetUsers_UserId",
                table: "PartyAttendee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchParty_Team_TeamId",
                table: "WatchParty",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyAttendee_AspNetUsers_UserId",
                table: "PartyAttendee");

            migrationBuilder.DropForeignKey(
                name: "FK_WatchParty_Team_TeamId",
                table: "WatchParty");

            migrationBuilder.DropIndex(
                name: "IX_WatchParty_TeamId",
                table: "WatchParty");

            migrationBuilder.DropIndex(
                name: "IX_PartyAttendee_UserId",
                table: "PartyAttendee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e28cbaf-09a4-4d35-b8fd-2e3c19a7ed47");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "WatchParty",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "WatchParty",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PartyAttendee",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PartyAttendee",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a714a235-598d-4623-b7d9-e4513b2df965", 0, "fbf554e5-5243-4e50-b4b3-164819b0a482", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDMwfNSpnhUgXBXmqejMF0lUg+Cu2eNTMCJCFx6b0+tPI7pacnjgkN+jtvhx4yflxw==", null, false, "ff5579ec-4995-40fe-8128-c85e8d579748", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchParty_TeamId1",
                table: "WatchParty",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendee_UserId1",
                table: "PartyAttendee",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyAttendee_AspNetUsers_UserId1",
                table: "PartyAttendee",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WatchParty_Team_TeamId1",
                table: "WatchParty",
                column: "TeamId1",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
