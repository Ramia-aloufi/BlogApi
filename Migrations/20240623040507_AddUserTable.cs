using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    passwordSalt = table.Column<string>(type: "text", nullable: false),
                    userType = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdDte = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4710), new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720), new DateTime(2024, 6, 21, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 18, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720), new DateTime(2024, 6, 20, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 20, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720), new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4720), new DateTime(2024, 6, 23, 4, 5, 7, 282, DateTimeKind.Utc).AddTicks(4730) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 1, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7840), new DateTime(2024, 5, 31, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 24, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850), new DateTime(2024, 5, 30, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850), new DateTime(2024, 5, 29, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850), new DateTime(2024, 5, 31, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 31, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850), new DateTime(2024, 6, 1, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(7850) });
        }
    }
}
