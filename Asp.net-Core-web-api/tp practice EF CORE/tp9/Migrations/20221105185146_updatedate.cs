using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class updatedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { 60.00m, new DateTime(2023, 11, 13, 18, 51, 45, 823, DateTimeKind.Utc).AddTicks(3220) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2022, 11, 2, 9, 0, 56, 78, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2022, 11, 7, 9, 0, 56, 78, DateTimeKind.Utc).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                columns: new[] { "Price", "PublishedOn" },
                values: new object[] { null, new DateTime(2022, 11, 7, 9, 0, 56, 78, DateTimeKind.Utc).AddTicks(2270) });
        }
    }
}
