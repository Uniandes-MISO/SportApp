using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "VirtualSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSchedule_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSchedule_UserId",
                table: "UserSchedule",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSchedule");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "VirtualSessions");

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
    }
}