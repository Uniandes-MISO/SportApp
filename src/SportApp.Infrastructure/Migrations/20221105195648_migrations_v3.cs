using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Training",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a10a49b6-9876-4192-b68a-7f3899c707ee", "AQAAAAEAACcQAAAAEFoexA7CnEGAsPCLHehcdLedRwEOwuhYP9a3qzK7Zs8X9bCy1KysIGNNCzQKQ1JPbw==", "07e37c45-6d5a-4b05-952c-5faa144062e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23484bb5-95f4-4442-9ab0-1dff7233399d", "AQAAAAEAACcQAAAAEL5rp/lFU5qlxx9iPB7bRU4mgV6EHWMygR2UDLDZEdgZgoZp5e32rSQgStHZnzzffQ==", "e3abe394-9c35-4447-b06a-8dc2d677d1e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Training");

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
    }
}