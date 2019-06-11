using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndCapstone.Data.Migrations
{
    public partial class secondtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    SportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    SportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchParty",
                columns: table => new
                {
                    WatchPartyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 55, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Limit = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    TeamId = table.Column<string>(nullable: false),
                    TeamId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchParty", x => x.WatchPartyId);
                    table.ForeignKey(
                        name: "FK_WatchParty_Team_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WatchParty_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyAttendee",
                columns: table => new
                {
                    PartyAttendeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    WatchPartyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyAttendee", x => x.PartyAttendeeId);
                    table.ForeignKey(
                        name: "FK_PartyAttendee_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartyAttendee_WatchParty_WatchPartyId",
                        column: x => x.WatchPartyId,
                        principalTable: "WatchParty",
                        principalColumn: "WatchPartyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a714a235-598d-4623-b7d9-e4513b2df965", 0, "fbf554e5-5243-4e50-b4b3-164819b0a482", "admin@admin.com", true, "Admina", null, "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDMwfNSpnhUgXBXmqejMF0lUg+Cu2eNTMCJCFx6b0+tPI7pacnjgkN+jtvhx4yflxw==", null, false, "ff5579ec-4995-40fe-8128-c85e8d579748", false, "admin" });

            migrationBuilder.InsertData(
                table: "Sport",
                columns: new[] { "SportId", "Name" },
                values: new object[,]
                {
                    { 1, "Hockey" },
                    { 2, "Soccer" },
                    { 3, "Football" },
                    { 4, "Baseball" },
                    { 5, "Basketball" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "Name", "SportId" },
                values: new object[,]
                {
                    { 1, "Nashville Predators", 1 },
                    { 4, "Nashville Soccer Club", 2 },
                    { 3, "Tennessee Titans", 3 },
                    { 2, "Nashville Sounds", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendee_UserId1",
                table: "PartyAttendee",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PartyAttendee_WatchPartyId",
                table: "PartyAttendee",
                column: "WatchPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SportId",
                table: "Team",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchParty_TeamId1",
                table: "WatchParty",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_WatchParty_UserId",
                table: "WatchParty",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartyAttendee");

            migrationBuilder.DropTable(
                name: "WatchParty");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a714a235-598d-4623-b7d9-e4513b2df965");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
