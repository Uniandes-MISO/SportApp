using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c881ff26-3e55-456b-a883-4e5b2412640f", "AQAAAAEAACcQAAAAECrLQzJg95PxrjwoaML0u3+Iz4RyL2jqxc58QjyAkI93rOIpXIUI2QJNLWmoo7DVyg==", "2478101e-ab53-45f8-9911-ed6612957500" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96392949-8728-416c-8fcf-467a85c7bab4", "AQAAAAEAACcQAAAAEKzMPpfyhBWlki0r+tzDqw/nlkBe+YpgHgXxqU5As11tvTMKVa9MItfKYeW8ICN5hA==", "e8b3c919-629a-4ed0-bb30-90a27177988d" });
        }
    }
}