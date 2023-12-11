using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class Commande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Order_OrderId",
                table: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthor_OrderId",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BookAuthor");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateOrderedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => new { x.BookId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_LineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 19, 13, 27, 56, 661, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 24, 13, 27, 56, 661, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 24, 13, 27, 56, 661, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "BookAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 18, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 11, 23, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2023, 11, 23, 20, 38, 8, 166, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.InsertData(
                table: "Order",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.UpdateData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "OrderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 },
                column: "OrderId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_OrderId",
                table: "BookAuthor",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Order_OrderId",
                table: "BookAuthor",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
