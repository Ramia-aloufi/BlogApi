using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultDataToPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_post",
                table: "post");

            migrationBuilder.RenameTable(
                name: "post",
                newName: "posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Content", "CreatedAt", "ImageUrl", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core is a free and open-source web framework developed by Microsoft.", new DateTime(2024, 5, 18, 0, 40, 8, 671, DateTimeKind.Utc), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB8vWxHzX5mIpJz5aVrqHrDRRfvrb69esckGkGlm6HPw&s", "Introduction to ASP.NET Core", new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc) },
                    { 2, "Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.", new DateTime(2024, 5, 20, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), "https://media.licdn.com/dms/image/D4D12AQEKTlrp8y_g0A/article-cover_image-shrink_720_1280/0/1683976532326?e=2147483647&v=beta&t=41WsN7UYuouE7WcA_pmij4yF__uReRR5qm8rdtngHOM", "Getting Started with Entity Framework Core", new DateTime(2024, 5, 26, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) },
                    { 3, "Middleware is software that's assembled into an application pipeline to handle requests and responses.", new DateTime(2024, 5, 23, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSv3lYL2b29XYVOoFeRIBDWQ9Sb9NL7MS1eBeApMQ8GOw&s", "Understanding Middleware in ASP.NET Core", new DateTime(2024, 5, 25, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) },
                    { 4, "Razor Pages is a page-based programming model that makes building web UI easier and more productive.", new DateTime(2024, 5, 25, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), "https://www.examturf.com/eqtkhtabd/wp-content/uploads/2021/02/ASP.NET-Framework.jpg", "Exploring Razor Pages in ASP.NET Core", new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) },
                    { 5, "Blazor is a framework for building interactive web applications with .NET and C#.", new DateTime(2024, 5, 27, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10), "https://positiwise.com/blog/wp-content/uploads/2023/01/common-architectures-in-asp-.net-core.jpg", "Introduction to Blazor", new DateTime(2024, 5, 28, 0, 40, 8, 671, DateTimeKind.Utc).AddTicks(10) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "post");

            migrationBuilder.AddPrimaryKey(
                name: "PK_post",
                table: "post",
                column: "Id");
        }
    }
}
