using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SportApp.Infrastructure.Migrations
{
    public partial class migrations_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportType",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: false),
                    TrainingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTraining",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrainingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTraining_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTraining_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Activity_TrainingId",
                table: "Activity",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraining_TrainingId",
                table: "UserTraining",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTraining_UserId",
                table: "UserTraining",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "UserTraining");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropColumn(
                name: "SportType",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a079d055-d181-4692-9146-fed8c18a989d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e36152-2b34-412e-b4f7-1b366b1c1e79", "AQAAAAEAACcQAAAAEGzoMIwJzMFOthAxoC0thEX9oCLqv0d8dtW+MQFNBjpoh8pdQTyrH0sPBPjweP9pJw==", "a78da486-4793-411e-abee-fe8230612a72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a275e39-b2a3-42e2-b019-4f543b82bfd1", "AQAAAAEAACcQAAAAECeQs1pLyJjN2BOMujRFpZt3UDjlw6BlapBt4xAefc01IcKml+d9wWCAdg7CT+lejw==", "dd62d87f-8719-4bd0-bf0a-d69fdf3daacb" });
        }
    }
}