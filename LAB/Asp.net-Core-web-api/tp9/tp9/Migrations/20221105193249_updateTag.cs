using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class updateTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksTags",
                keyColumns: new[] { "BooksBookId", "TagsId" },
                keyValues: new object[] { 2, "FM" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 8, 19, 32, 49, 608, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 13, 19, 32, 49, 608, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 13, 19, 32, 49, 608, DateTimeKind.Utc).AddTicks(5860));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 8, 18, 51, 45, 823, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 13, 18, 51, 45, 823, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 13, 18, 51, 45, 823, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.InsertData(
                table: "BooksTags",
                columns: new[] { "BooksBookId", "TagsId" },
                values: new object[] { 2, "FM" });
        }
    }
}
