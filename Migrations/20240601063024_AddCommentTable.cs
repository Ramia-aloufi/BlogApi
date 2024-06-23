using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "PostId" },
                values: new object[] { 1, "This is a sample comment.", new DateTime(2024, 6, 1, 6, 30, 24, 735, DateTimeKind.Utc).AddTicks(8410), 3 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 18, 0, 40, 8, 671, DateTimeKind.Utc), new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 20, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), new DateTime(2024, 5, 26, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 23, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), new DateTime(2024, 5, 25, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 25, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), new DateTime(2024, 5, 28, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) });
        }
    }
}
