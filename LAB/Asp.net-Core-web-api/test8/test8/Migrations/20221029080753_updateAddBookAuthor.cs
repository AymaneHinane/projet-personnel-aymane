using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test8.Migrations
{
    public partial class updateAddBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "shippingAdresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(6870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(4620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "productPropertyValues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(6360),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "productProperties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductCategoryProperty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(2810),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(3730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(4160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(3380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(1790),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(1240),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.CreateTable(
                name: "Author2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(2330)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author2",
                columns: new[] { "Id", "Name", "WebUrl" },
                values: new object[,]
                {
                    { 1, "joseph", "http//helloworld.org" },
                    { 2, "bahari", "http//bahari.com" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "PublishedOn", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, "basic of coding", new DateTime(2022, 11, 1, 8, 7, 53, 293, DateTimeKind.Utc).AddTicks(660), "Hello wolrd", null },
                    { 2, 2, "basic of footbal coathing", new DateTime(2022, 11, 6, 8, 7, 53, 293, DateTimeKind.Utc).AddTicks(680), "foot mangering", null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 291, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 291, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 291, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 29, 9, 7, 53, 290, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author2");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "shippingAdresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(4620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "productPropertyValues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "productProperties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5460),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductCategoryProperty",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(5200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4100),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(4350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 25, 19, 43, 45, 834, DateTimeKind.Local).AddTicks(3060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 29, 9, 7, 53, 292, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 25, 19, 43, 45, 833, DateTimeKind.Local).AddTicks(5310));
        }
    }
}
