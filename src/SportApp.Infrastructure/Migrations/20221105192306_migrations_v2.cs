using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activity",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd7c3211-3863-4ab5-a2f6-8987ae821a48", "AQAAAAEAACcQAAAAEJU0vm8gSN4ndkGpZRB/53lpmbKLRWoQW1f6cqSL2hZnmu2TR31DbOe4dVFWMvp1cA==", "94c85b0d-7b41-4331-a823-3f87d57ac298" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea082517-5ec3-4ec5-8698-06459f6c7df0", "AQAAAAEAACcQAAAAECYlSJyQbYu+ze37AHK368EXaS7h/WdjSm5A22yIigxx3RkBSoR2oJgFVaUet7a0rg==", "6714d5d5-85d7-45b3-a6e3-24c642162162" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dac47e4-0f6c-44bd-9c39-12f17f8003b7", "AQAAAAEAACcQAAAAEK+QhmbP3u5IMheCx76ibbxOAJ6LddcUiiqEDPuvWIRmfwz8qplXrgiQQ9FXwgk7cQ==", "03cdfd32-a416-4873-bc0b-2c2af22e4324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69d9ae62-3e48-47b1-8d92-ab54ab2c0872", "AQAAAAEAACcQAAAAEKdDQKdm+M0HqzLVB8B04JnhKB/3n1RqO9acMYs34ubjTz/Yd5WXNmSnKNwGbaXoFA==", "1622cb94-2b9c-4350-a22a-238dbee4e4d2" });
        }
    }
}