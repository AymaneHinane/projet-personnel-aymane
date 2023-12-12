using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class AddSoftDeletedValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "PublishedOn", "SoftDeleted" },
                values: new object[] { new DateTime(2023, 11, 18, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6060), true });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                columns: new[] { "PublishedOn", "SoftDeleted" },
                values: new object[] { new DateTime(2024, 11, 23, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6070), true });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 23, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6070));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Books");

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
    }
}
