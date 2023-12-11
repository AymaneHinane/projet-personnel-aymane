using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class AddFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 18, 20, 36, 3, 73, DateTimeKind.Utc).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 23, 20, 36, 3, 73, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 23, 20, 36, 3, 73, DateTimeKind.Utc).AddTicks(9850));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 9, 8, 50, 44, 853, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 14, 8, 50, 44, 853, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 14, 8, 50, 44, 853, DateTimeKind.Utc).AddTicks(6740));
        }
    }
}
