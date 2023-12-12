using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class RemovePriceListOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "LineItem");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 11, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 16, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 12, 16, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5650));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "LineItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 19, 13, 30, 27, 146, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 24, 13, 30, 27, 146, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 24, 13, 30, 27, 146, DateTimeKind.Utc).AddTicks(7400));
        }
    }
}
