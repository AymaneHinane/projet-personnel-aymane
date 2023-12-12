using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test8.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(7520)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    _NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8980)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(890)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(1810)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8030)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeleveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(9380)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("CK_OrderDate", "[DeleveryDate] > [OrderDate]");
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    productCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(370)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_AvailableQuantity", "[AvailableQuantity] >= 0");
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_productCategoryId",
                        column: x => x.productCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryProperty",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductPropertyId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(1330)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryProperty", x => new { x.ProductCategoryId, x.ProductPropertyId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryProperty_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryProperty_productProperties_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "productProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Article = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(8490)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shippingAdresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Maroc"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(2710)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippingAdresses", x => x.Id);
                    table.CheckConstraint("CheckZipCode", "[ZipCode] between 100 and 9999");
                    table.ForeignKey(
                        name: "FK_shippingAdresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 301, DateTimeKind.Local).AddTicks(9860)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.CheckConstraint("CheckQuantityNotEqualZero", "[OrderQuantity] >= 0");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productPropertyValues",
                columns: table => new
                {
                    ProductPropertyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 10, 24, 22, 55, 31, 302, DateTimeKind.Local).AddTicks(2240)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productPropertyValues", x => new { x.ProductId, x.ProductPropertyId });
                    table.ForeignKey(
                        name: "FK_productPropertyValues_productProperties_ProductPropertyId",
                        column: x => x.ProductPropertyId,
                        principalTable: "productProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productPropertyValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreateDate", "FirstName", "LastName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(370), "yan", "Maxim", null },
                    { 2, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(470), "han", "axim", null },
                    { 3, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(470), "jan", "amine", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "UpdateDate", "_NumberPhone" },
                values: new object[,]
                {
                    { 1, "naie", "nina", null, "06611112577" },
                    { 2, "noa", "nella", null, "06611112588" },
                    { 3, "joelle", "tisa", null, "06611112599" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "book", null },
                    { 2, "phone", null },
                    { 3, "laptop", null }
                });

            migrationBuilder.InsertData(
                table: "productProperties",
                columns: new[] { "Id", "PropertyName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "screen_size", null },
                    { 2, "cpu_version", null },
                    { 3, "cpu_type", null },
                    { 4, "gpu_type", null },
                    { 5, "gpu_version", null },
                    { 6, "storage_type", null },
                    { 7, "storage", null },
                    { 9, "ram_storage", null },
                    { 10, "author", null },
                    { 11, "book_category", null },
                    { 12, "mark", null },
                    { 13, "arm_type", null },
                    { 14, "arm_version", null }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorId", "CreateDate", "Name", "UpdateDate", "categorie" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1530), "hello world", null, "science" },
                    { 2, 1, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1540), "life is good", null, "romance" },
                    { 3, 2, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1540), "wolf", null, "horour" },
                    { 4, 2, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1550), "docker", null, "science" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeleveryDate", "OrderDate", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, null, null, null },
                    { 2, 1, null, null, null },
                    { 3, 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategoryProperty",
                columns: new[] { "ProductCategoryId", "ProductPropertyId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 10, null },
                    { 1, 11, null },
                    { 1, 12, null },
                    { 2, 1, null },
                    { 2, 7, null },
                    { 2, 9, null },
                    { 2, 12, null },
                    { 2, 13, null },
                    { 2, 14, null },
                    { 3, 1, null },
                    { 3, 2, null },
                    { 3, 3, null },
                    { 3, 4, null },
                    { 3, 5, null },
                    { 3, 6, null },
                    { 3, 7, null },
                    { 3, 9, null },
                    { 3, 12, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Name", "UpdateDate", "productCategoryId" },
                values: new object[,]
                {
                    { 1, 22, "hp omen 15", null, 3 },
                    { 2, 11, "asus 15", null, 3 },
                    { 3, 46, "s22", null, 2 },
                    { 4, 17, "ihone 12", null, 2 },
                    { 5, 80, "noelle", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "OrderQuantity", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, 3, null },
                    { 1, 2, 2, null },
                    { 2, 2, 5, null },
                    { 3, 2, 2, null },
                    { 3, 5, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Article", "BlogId", "CreateDate", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "no article", 1, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1980), "seremonie 1", null },
                    { 2, "no article", 1, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1990), "seremonie 2", null },
                    { 3, "no article", 2, new DateTime(2022, 10, 24, 22, 55, 31, 300, DateTimeKind.Local).AddTicks(1990), "minasia", null }
                });

            migrationBuilder.InsertData(
                table: "productPropertyValues",
                columns: new[] { "ProductId", "ProductPropertyId", "UpdateDate", "Value" },
                values: new object[,]
                {
                    { 1, 1, null, "15" },
                    { 1, 2, null, "i7 10gen" },
                    { 1, 3, null, "intel" },
                    { 1, 4, null, "nvidia" },
                    { 1, 5, null, "rtx 2060" },
                    { 1, 6, null, "ssd m.2" },
                    { 1, 7, null, "1To" },
                    { 1, 9, null, "16Go" },
                    { 1, 12, null, "hp" },
                    { 2, 1, null, "16" },
                    { 2, 2, null, "amd ryzen 5" },
                    { 2, 3, null, "amd" },
                    { 2, 4, null, "amd" },
                    { 2, 5, null, "amd 6650" },
                    { 2, 6, null, "hdd" },
                    { 2, 7, null, "550go" },
                    { 2, 9, null, "16Go" },
                    { 2, 12, null, "asus" },
                    { 5, 10, null, "zack maid" },
                    { 5, 11, null, "action" }
                });

            migrationBuilder.InsertData(
                table: "shippingAdresses",
                columns: new[] { "Id", "City", "OrderId", "UpdateDate", "ZipCode" },
                values: new object[,]
                {
                    { 1, "casablanca", 1, null, 4000 },
                    { 2, "casablanca", 2, null, 6000 },
                    { 3, "rabat", 3, null, 2000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName",
                table: "Customers",
                column: "FirstName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId",
                table: "Post",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryProperty_ProductPropertyId",
                table: "ProductCategoryProperty",
                column: "ProductPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_productPropertyValues_ProductPropertyId",
                table: "productPropertyValues",
                column: "ProductPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_productCategoryId",
                table: "Products",
                column: "productCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_shippingAdresses_OrderId",
                table: "shippingAdresses",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "ProductCategoryProperty");

            migrationBuilder.DropTable(
                name: "productPropertyValues");

            migrationBuilder.DropTable(
                name: "shippingAdresses");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "productProperties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
