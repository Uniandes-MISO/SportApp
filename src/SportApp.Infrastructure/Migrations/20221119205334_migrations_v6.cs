using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "059a84d7-8aae-4dc9-ac6c-1ce7383a96b2", "AQAAAAEAACcQAAAAEOhld5dTaaGTWHCnEAJwhzZFx2TPzj0xTbK+Kr3FylCQhBKlPxixiWsgPBM1kDpjWQ==", "fcb0979b-d66d-43a9-9335-6fc23ee8c6e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c020ecac-5c6b-452d-aa08-95396181c1e8", "AQAAAAEAACcQAAAAEDZ04bLPGFw2npuVAChs/5qjT+7NHQWsErE5kfXGi7KgYHVaNz2YCSTf0KFfadWsYw==", "15443f61-9f1d-47c1-b018-cfd884222f0a" });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_AthleteId",
                table: "VirtualSessions",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_CoachId",
                table: "VirtualSessions",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_ScheduleId",
                table: "VirtualSessions",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualSessions_AspNetUsers_AthleteId",
                table: "VirtualSessions",
                column: "AthleteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualSessions_AspNetUsers_CoachId",
                table: "VirtualSessions",
                column: "CoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualSessions_UserSchedule_ScheduleId",
                table: "VirtualSessions",
                column: "ScheduleId",
                principalTable: "UserSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VirtualSessions_AspNetUsers_AthleteId",
                table: "VirtualSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualSessions_AspNetUsers_CoachId",
                table: "VirtualSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualSessions_UserSchedule_ScheduleId",
                table: "VirtualSessions");

            migrationBuilder.DropIndex(
                name: "IX_VirtualSessions_AthleteId",
                table: "VirtualSessions");

            migrationBuilder.DropIndex(
                name: "IX_VirtualSessions_CoachId",
                table: "VirtualSessions");

            migrationBuilder.DropIndex(
                name: "IX_VirtualSessions_ScheduleId",
                table: "VirtualSessions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "342e35db-9e44-48f6-b9f8-0bdc09025223", "AQAAAAEAACcQAAAAEKKH/QOln1dbnLsFWJ4Z5DJ+TW3Ac5UbKwHUMpsxxvZCtu04NgTfNE28H5ARTZTXMQ==", "6f2b6d03-2b8e-4ac5-ba39-2505794cb09c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "158c71ff-9b1f-4723-87f7-2a6182670b9f", "AQAAAAEAACcQAAAAEHphGcqIlxRllA0qUmPqa6/VoI7VGwDYXE2D+Hj4KxoLSjBCd4Qr6AMAxfuz+NXWgQ==", "91f255bd-f3c5-4b5c-b863-7d49b655e652" });
        }
    }
}