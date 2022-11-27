using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EatingRoutine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatingRoutine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EatingRoutineBusiness",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EatingRoutineId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatingRoutineBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EatingRoutineBusiness_EatingRoutine_EatingRoutineId",
                        column: x => x.EatingRoutineId,
                        principalTable: "EatingRoutine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EatingRoutineBusiness_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4ca735e-b6fc-4a46-a5e2-638d80f9f498", "AQAAAAEAACcQAAAAELmlt5S662VvsWVgfAQuOGpWwjf39CY5lD/8vqb3nMGiEPDKDpAgqRzDdi2vY3D9Ew==", "370b1c09-2e38-499e-a63d-64f9ad11c6b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97f7cdd9-08ef-40ff-a392-105e5cc85991", "AQAAAAEAACcQAAAAECd3Xvh0IAt23yqb5GGeVQLVdMsN2L39zvZjWzEOGGEiVU/O+we0NHM8CcIdcmH8wg==", "a41922cb-cae1-49e5-877e-661effe54c87" });

            migrationBuilder.CreateIndex(
                name: "IX_EatingRoutineBusiness_EatingRoutineId",
                table: "EatingRoutineBusiness",
                column: "EatingRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_EatingRoutineBusiness_ServiceId",
                table: "EatingRoutineBusiness",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EatingRoutineBusiness");

            migrationBuilder.DropTable(
                name: "EatingRoutine");

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
        }
    }
}