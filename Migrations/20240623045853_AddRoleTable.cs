using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    iActive = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdDte = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 23, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 13, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8370), new DateTime(2024, 6, 22, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 15, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8380), new DateTime(2024, 6, 21, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 18, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390), new DateTime(2024, 6, 20, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 20, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390), new DateTime(2024, 6, 22, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 22, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390), new DateTime(2024, 6, 23, 4, 58, 53, 43, DateTimeKind.Utc).AddTicks(8390) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

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
    }
}
