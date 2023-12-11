using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class addquantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookAuthor",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BooksTags",
                keyColumns: new[] { "BooksBookId", "TagsId" },
                keyValues: new object[] { 1, "HW" });

            migrationBuilder.DeleteData(
                table: "BooksTags",
                keyColumns: new[] { "BooksBookId", "TagsId" },
                keyValues: new object[] { 3, "HA" });

            migrationBuilder.DeleteData(
                table: "BooksTags",
                keyColumns: new[] { "BooksBookId", "TagsId" },
                keyValues: new object[] { 3, "HD" });

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOffersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOffersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PriceOffers",
                keyColumn: "PriceOffersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagsId",
                keyValue: "FM");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagsId",
                keyValue: "HA");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagsId",
                keyValue: "HD");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagsId",
                keyValue: "HW");

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "LineItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "LineItem");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name", "WebUrl" },
                values: new object[,]
                {
                    { 1, "joseph", "http//helloworld.org" },
                    { 2, "bahari", "http//bahari.com" },
                    { 3, "noha", "http//bahari.com" },
                    { 4, "berdi", "http//bahari.com" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Description", "Price", "PublishedOn", "Publisher", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "basic of coding", 50.00m, new DateTime(2023, 12, 11, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5640), "Wakanim", true, "Hello wolrd" },
                    { 2, "basic of footbal coathing", 70.00m, new DateTime(2024, 12, 16, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5650), "Shona", true, "foot mangering" },
                    { 3, "basic of hardwar tools", 60.00m, new DateTime(2023, 12, 16, 10, 48, 52, 106, DateTimeKind.Utc).AddTicks(5650), "ward", false, "hardwar" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                column: "TagsId",
                values: new object[]
                {
                    "FM",
                    "HA",
                    "HD",
                    "HW"
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "BooksTags",
                columns: new[] { "BooksBookId", "TagsId" },
                values: new object[,]
                {
                    { 1, "HW" },
                    { 3, "HA" },
                    { 3, "HD" }
                });

            migrationBuilder.InsertData(
                table: "PriceOffers",
                columns: new[] { "PriceOffersId", "BookId", "NewPrice", "PromotionalText" },
                values: new object[,]
                {
                    { 1, 1, 30.00m, "Save 1$ if you ordered 40 unit" },
                    { 2, 2, 20.00m, "Save 2$ if you ordered 20 unit" },
                    { 3, 3, 200.00m, "Save 2$ if you ordered 20 unit" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BookId", "Comment", "NumStars", "VoterName" },
                values: new object[,]
                {
                    { 1, 1, "I Love this book a lot", 5.0, "anayelle" },
                    { 2, 2, "I hate this book", 3.0, "joelle" },
                    { 3, 3, "I hate this book", 1.0, "alie" },
                    { 4, 3, "I love this book", 4.0, "noor" }
                });
        }
    }
}
