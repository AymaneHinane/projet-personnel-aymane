using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Api.Migrations
{
    /// <inheritdoc />
    public partial class postgresInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WarehouseType = table.Column<string>(type: "text", nullable: false),
                    WarehouseRegion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Excl_taxes = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Incl_taxes = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    InvoicePdf = table.Column<byte[]>(type: "bytea", nullable: true),
                    InvoiceCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceCategories_InvoiceCategoryId",
                        column: x => x.InvoiceCategoryId,
                        principalTable: "InvoiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockChangeHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyNameEng = table.Column<string>(type: "text", nullable: true),
                    PropertyNameFr = table.Column<string>(type: "text", nullable: true),
                    OldValue = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NewValue = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    ProductCategory = table.Column<int>(type: "integer", nullable: false),
                    warehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockChangeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockChangeHistories_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    productId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockProduced = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    RemainingStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    OrderStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DeliverStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ConsumeStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    LastYearRemainingStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DAPStock = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransferedStockEntryTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransferedStockExitTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Warehouses_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    DestinationType = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferedStockQuantity = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    DeliveredStockQuantity = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransferStatus = table.Column<string>(type: "text", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfers_Warehouses_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipients_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipients_Warehouses_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EditedField = table.Column<string>(type: "text", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OldValue = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    NewValue = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    TransferId = table.Column<Guid>(type: "uuid", nullable: true),
                    TranferNumero = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderName = table.Column<string>(type: "text", nullable: true),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: true),
                    RecipientName = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: true),
                    ProductCategory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferHistories_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferHistories_Warehouses_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferHistories_Warehouses_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferId = table.Column<Guid>(type: "uuid", nullable: false),
                    TruckNumber = table.Column<string>(type: "text", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExitStockWeight = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    EntryStockWeight = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ExitVoucher = table.Column<byte[]>(type: "bytea", nullable: true),
                    EntryVoucher = table.Column<byte[]>(type: "bytea", nullable: true),
                    TransferStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferOperation_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipientTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransferOperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveredStock = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TransferStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipientTransfers_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipientTransfers_TransferOperation_TransferOperationId",
                        column: x => x.TransferOperationId,
                        principalTable: "TransferOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "271b1113-e4a8-4031-b99f-f203932cf51a", null, "SUTA", "SUTA" },
                    { "466381e5-3ef0-45fd-b2f3-52a027e5d4d8", null, "SURAC", "SURAC" },
                    { "7f3950fa-9093-492b-9a9a-0f4b41138c34", null, "ADMIN", "ADMIN" },
                    { "8a8e723c-d8d1-46b5-a2e4-c17705b5dee3", null, "COSUMAR SIDI BENNOUR", "COSUMAR SIDI BENNOUR" },
                    { "999f3d6b-9626-401f-a863-b86d79f7cb3a", null, "SUNABEL", "SUNABEL" },
                    { "f753d221-c96e-486b-ac40-403dd11ea541", null, "COSUMAR ZAIO", "COSUMAR ZAIO" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceCategories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { new Guid("0a8bb548-eafb-463c-a464-2c1f50533236"), "Main d'oeuvre" },
                    { new Guid("15bd2baf-b829-4a55-afd4-7cfdf7671dbc"), "Transport de Matières premières" },
                    { new Guid("3263e398-73e6-4460-9c75-0ed7b923612a"), "Sacs" },
                    { new Guid("34d14645-8b66-440a-b4e9-c9e8191a8bc8"), "Transport de distribution" },
                    { new Guid("4424f14b-6415-46df-86ce-036d86e3a451"), "Location Chargeuse" },
                    { new Guid("553ce4ae-4dd7-49d3-953a-ac1a9fa9bbd6"), "Consommables" },
                    { new Guid("a51f6b67-1a85-4c0f-aa24-01cd2bc684fa"), "Manutention" },
                    { new Guid("ac1c2389-a285-46cb-adb8-229ffc11029e"), "Eléctricité" },
                    { new Guid("e3128d6c-7e72-4dce-b6a6-4a1f1029e049"), "Location Chariot" },
                    { new Guid("e7a8bca7-d4d8-46ff-be42-cc3d58bf0cf4"), "Gasoil" },
                    { new Guid("f86fc5ec-e49f-4d14-a5c5-5f3c67bafe8b"), "Analyse d'engrais" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "category" },
                values: new object[,]
                {
                    { new Guid("4436ef77-4ba3-4265-b265-968da0b04730"), "KCL", "rawMaterial" },
                    { new Guid("8580a5c2-e5aa-430e-9b67-598d4e988c2d"), "DAP", "rawMaterial" },
                    { new Guid("9f533133-2ad6-4b20-92f0-f66c105841fe"), "UREE", "rawMaterial" },
                    { new Guid("a9d2fe5e-0d38-493c-a700-ed63485686e0"), "ACIDE HUMIQUE", "rawMaterial" },
                    { new Guid("b7cf76e8-affa-45c6-a0f2-74add38778eb"), "TSP", "rawMaterial" },
                    { new Guid("bab91ca4-100c-4a9c-ba75-b447c0b721c3"), "AMMONITRATE", "rawMaterial" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Name", "WarehouseRegion", "WarehouseType" },
                values: new object[,]
                {
                    { new Guid("05c2b649-4b87-413e-a02a-6e82a12a1b34"), "218-241", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("05d1b779-e3b8-47cd-b993-8f1f6f05da7a"), "533", "SUTA", "distributionCenter" },
                    { new Guid("0f1f8d94-fd2e-4a11-97da-06317c69bf62"), "221", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("1199cf49-b675-4367-9b85-ed6ddeedbb48"), "211-222", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("12000c54-09d6-43f3-9505-5c2155099a39"), "336", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("1218f634-58ee-4625-a678-0215723779f3"), "234-242", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("148dbd99-602a-4803-8a0a-ee6c8fa3e6ca"), "COSUMAR SIDI BENNOUR", null, "site" },
                    { new Guid("14a4c70a-6a82-4d1e-902f-b2d9bd9f5373"), "360", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("18ada911-3a67-4666-a14d-27bcd96d1e40"), "1504", "SUTA", "distributionCenter" },
                    { new Guid("1b4fd25c-1252-441f-bb43-b0262392e2e0"), "246-247", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("1cf5a15d-5bb3-490c-a212-45ceeec22365"), "312", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("26b0d281-dd5c-47f9-ae05-2da0cd219a94"), "351", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("288e8aa3-2c91-4b19-9d8e-0959ab39e112"), "235", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("2b25c366-c63c-4fc7-a257-84d8f2771b0b"), "521", "SUTA", "distributionCenter" },
                    { new Guid("2f4173fa-b41f-4309-8a17-81285023ca41"), "310", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("30b351e9-4472-438c-aa17-36e6a239c9c8"), "404", "SUTA", "distributionCenter" },
                    { new Guid("310b0a03-431b-4bfd-a794-a36fe0cc2850"), "225", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("315f3187-ffbe-4bab-bdd8-38c9ea774adf"), "536", "SUTA", "distributionCenter" },
                    { new Guid("32ae3428-d477-46df-9ab6-c7bf8b2b5659"), "235", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("35007bcc-dbc9-40c7-aa61-155853631e4d"), "501/502/511", "SUTA", "distributionCenter" },
                    { new Guid("36521355-e9b7-44b3-9291-99ac13c72176"), "1104/6", "SUTA", "distributionCenter" },
                    { new Guid("39c12cc8-e7e9-4c55-9ef1-a8bdac6f9040"), "901", "SUNABEL_LOUKKOS", "distributionCenter" },
                    { new Guid("3edcf2ba-de09-4622-9459-ca43977cd4cd"), "231", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("3f14a919-d7fa-4cb2-95d2-dcfb14a13694"), "322", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("41562eaa-735d-4ce9-9b42-cdd6c44bc7f1"), "324", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("430e7f1d-600d-4843-82d0-837066dd677b"), "321", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("48513294-21c9-4bab-925d-1eb3a7c1a1de"), "341", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("49f628cd-1fef-4f92-a25c-f56ecc7ed1a0"), "PhytoBerkane", "ZAIO", "distributionCenter" },
                    { new Guid("4df39384-729c-4f58-b6e0-b736cf171900"), "244-245", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("4ecd556d-7245-478c-8cf3-3dc854541a37"), "233", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("50f266f8-d795-4760-9c0c-c05eb79ac8d0"), "1104/5-8", "SUTA", "distributionCenter" },
                    { new Guid("5162df2c-3ecc-4a1f-82be-11a15408230e"), "503", "SUTA", "distributionCenter" },
                    { new Guid("51b6d8f3-4c35-4564-aa4c-d7cea1b5758a"), "236-237", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("54249fa6-9bbf-47b9-9a74-f297d8849e53"), "221", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("54be1ecc-597f-4551-9fd6-7831b29790f7"), "530", "SUTA", "distributionCenter" },
                    { new Guid("55b085af-3dc2-4e54-b1e2-0920cd625057"), "243-943", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("5b32fa0c-e7d6-4dc9-8d2f-ddedd3c3ebdf"), "AGROSSAR", "ZAIO", "distributionCenter" },
                    { new Guid("5c68463e-0a95-4aee-85b3-baa8e989d7d5"), "244-245", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("60aaa4f3-a55b-4d77-b50a-2afc75f35cf9"), "506", "SUTA", "distributionCenter" },
                    { new Guid("677d7486-6459-4d75-b2b0-6e22d5f3a9b7"), "246-247", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("686a6256-1fdb-4350-a402-3882cd347a96"), "1104/9", "SUTA", "distributionCenter" },
                    { new Guid("6894b368-3f2a-441f-ba05-82a27e12655b"), "233", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("6b48d6d2-c40c-45da-92ce-e88b020206b9"), "340", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("6e1ca860-6cab-46cd-9e1d-0e29a6948505"), "909", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("6f5581cb-b7d8-499c-96ce-332f0f7a58b9"), "214-246-217", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("6fa3b325-8509-4a93-874f-89f2d97661a0"), "231", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("701145ec-a1b1-4d0c-8438-8467dff0987d"), "505/510/512", "SUTA", "distributionCenter" },
                    { new Guid("701d8c10-1705-44f8-b214-2be19bffbb2c"), "213", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("7210ab96-8812-49be-bc27-60e554b329c0"), "527", "SUTA", "distributionCenter" },
                    { new Guid("72f9a741-d736-4040-88c1-6b3333c9124c"), "361", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("7811ac4b-1262-4a52-82ac-fb7735714d97"), "363", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("791c5147-415c-4c60-b81f-6bf5e82cfde2"), "1107", "SUTA", "distributionCenter" },
                    { new Guid("7ab89f0a-16f8-4eef-9957-2bc63508c658"), "400", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("7bf334ec-9229-4ae5-ac76-faa5e661fabb"), "342", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("7da6e83e-06df-4156-a84c-295ad73b686d"), "338", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("7f39e309-ad64-4fbc-9b8c-b4fbbf960cd4"), "901-909", "SURAC_CANNE", "distributionCenter" },
                    { new Guid("80abbdd2-0f9e-48dc-8b6e-f29a3770d45b"), "1104/4-7", "SUTA", "distributionCenter" },
                    { new Guid("83efd78e-174f-4d57-9ed0-28549c502cc7"), "343", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("84e3e39d-71d6-40d3-9b42-3d48cf5843e7"), "901", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("84eb157b-383f-485c-a642-6251441e6d33"), "SUTA", null, "site" },
                    { new Guid("8bfd1680-4a5e-4cb0-8054-528f791e50a2"), "526", "SUTA", "distributionCenter" },
                    { new Guid("8c1a76c8-067c-40fc-bbf2-2ded5d95deb3"), "224-226", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("8d87e8d7-a7f6-4946-9344-3c9c09e0b02a"), "217", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("8ed5c72c-f600-4db3-9cd0-00f729a8601f"), "522", "SUTA", "distributionCenter" },
                    { new Guid("9195edf5-7605-422f-8bb0-9ab4b729294c"), "354", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("9487367e-9956-4923-8f69-5487753ad4be"), "909", "SUNABEL_LOUKKOS", "distributionCenter" },
                    { new Guid("955469f8-c4b0-4efc-af93-4f3fc999f04c"), "504", "SUTA", "distributionCenter" },
                    { new Guid("963a84c6-85dd-4f5d-bb5a-b1c2e7d92970"), "SUNABEL", null, "site" },
                    { new Guid("992c0dfa-cc81-4f82-93b9-e846c1b52c10"), "325", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("9a2d100e-aaf8-4643-8fc2-c845e57b051d"), "236-237", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("9aaeffba-e7f3-4480-be43-e06ed561aa60"), "212", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("9da3395d-e98b-4a4c-8541-24138f872c0c"), "906", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("a004cf49-4772-4c08-90b3-cf6915e18053"), "335", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("a948ea36-9fe5-43f2-bc7e-027f6c67f0cd"), "SURAC", null, "site" },
                    { new Guid("b51028cb-0ca2-4141-9618-b07145481abc"), "509", "SUTA", "distributionCenter" },
                    { new Guid("b54a1052-7140-4b36-a2e3-8788a97590ea"), "532", "SUTA", "distributionCenter" },
                    { new Guid("b626eba3-1ba2-430c-a794-12ab302ce222"), "906", "SURAC_CANNE", "distributionCenter" },
                    { new Guid("b6520c8f-246c-4034-b6ac-979a59ad534f"), "243-943", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("b7e6df3f-aab2-4b2b-b119-ce1bb7665511"), "524", "SUTA", "distributionCenter" },
                    { new Guid("b96d9aad-1169-4030-a919-d7abaea5357e"), "531", "SUTA", "distributionCenter" },
                    { new Guid("b97408c1-cb48-44f3-8506-94103ece669f"), "362", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("bb6de288-3620-4ffb-8b37-ad35f0d9d095"), "331", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("bc56e4bd-c0b1-4f6e-ab62-f8459dd4d09d"), "507", "SUTA", "distributionCenter" },
                    { new Guid("bde361c5-3ba7-4319-a766-0748dbef1232"), "525", "SUTA", "distributionCenter" },
                    { new Guid("beef3e5d-d8a1-427a-9cdc-ab9696abf449"), "234-242", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("bf41a037-d9fb-4ac7-ba88-e618747e7765"), "333", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("c0c4b904-e97b-483a-8b4c-ddef5ebd0486"), "903", "SURAC_CANNE", "distributionCenter" },
                    { new Guid("c2a195e7-7f53-4be5-a3e3-3e64c9735837"), "330", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("c2bd6e27-8994-4156-b470-750a4b6dd467"), "COSUMAR ZAIO", null, "site" },
                    { new Guid("c31d7f27-3806-4a1b-9892-4d31666b93f6"), "352", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("c561527f-437c-4f7c-a388-285d782e71ee"), "508", "SUTA", "distributionCenter" },
                    { new Guid("c78df6d0-2bad-44ec-9c4b-db13f9a0fe9d"), "225", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("c8f69301-e79a-4a0a-9ae2-233195f1239f"), "337", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("c966fabf-410b-4e8e-b36f-ba1c7f67723e"), "1104/1-2-3", "SUTA", "distributionCenter" },
                    { new Guid("cc730cda-69b5-42b6-8e6d-518c50668e66"), "Etablissement CHICKRI", "ZAIO", "distributionCenter" },
                    { new Guid("ccc33ad3-4e61-42c8-b4a4-bd9a27d46738"), "223", "SURAC_GHARB", "distributionCenter" },
                    { new Guid("cf051303-6ae5-48cc-bcf8-cdb2e82c6812"), "353", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("d617507d-f7f5-4f07-83c8-c4a51637595c"), "537", "SUTA", "distributionCenter" },
                    { new Guid("d985408b-f99c-4b3f-a833-b39a90ceff75"), "218-241", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("da1921c3-d6da-478f-b4c8-94c9c003e48b"), "332", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("da46877b-8f17-4cb5-b696-ab249f110b55"), "211-222", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("e47f1a3d-65bc-4c6c-889c-0f9ffc1d26cb"), "906", "SUNABEL_LOUKKOS", "distributionCenter" },
                    { new Guid("e7a807df-2627-41f9-a15b-8fc84a994526"), "320", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("ec417426-2c4b-43da-8227-7bbebe9c49b3"), "520", "SUTA", "distributionCenter" },
                    { new Guid("ed9c654f-4087-4611-add4-0c9aeb42c377"), "528", "SUTA", "distributionCenter" },
                    { new Guid("f10d7f01-0851-4c16-8af3-f1019b1286bf"), "535", "SUTA", "distributionCenter" },
                    { new Guid("f55e5b0d-83b8-4402-9433-2237ba3bba41"), "529", "SUTA", "distributionCenter" },
                    { new Guid("f64f1686-6393-4744-abf0-160ec12b51ce"), "224-226", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("f84c3923-7736-4a13-a81a-7f04d400bdce"), "223", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("fbae2eaa-fe0a-4404-8db9-71c3ed94ab71"), "2404", "SUTA", "distributionCenter" },
                    { new Guid("fd582356-a378-4724-9a2c-439f15775471"), "2202", "SUNABEL_GHARB", "distributionCenter" },
                    { new Guid("fe93782b-e08f-40b7-9eed-331e5e418f60"), "Bouyahyie FELLAH", "ZAIO", "distributionCenter" },
                    { new Guid("ff1fb08f-158d-4b1d-8346-a39e8841124b"), "311", "SIDI_BENNOUR", "distributionCenter" },
                    { new Guid("ff2204b9-3ea8-4161-975f-e8833465a710"), "534-538", "SUTA", "distributionCenter" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceCategoryId",
                table: "Invoices",
                column: "InvoiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_WarehouseId",
                table: "Invoices",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_RecipientId_TransferId",
                table: "Recipients",
                columns: new[] { "RecipientId", "TransferId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_TransferId",
                table: "Recipients",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientTransfers_RecipientId",
                table: "RecipientTransfers",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipientTransfers_TransferOperationId_RecipientId",
                table: "RecipientTransfers",
                columns: new[] { "TransferOperationId", "RecipientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockChangeHistories_warehouseId",
                table: "StockChangeHistories",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_productId_warehouseId",
                table: "Stocks",
                columns: new[] { "productId", "warehouseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_warehouseId",
                table: "Stocks",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_ProductId",
                table: "TransferHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_RecipientId",
                table: "TransferHistories",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_SenderId",
                table: "TransferHistories",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferHistories_TransferId",
                table: "TransferHistories",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOperation_TransferId",
                table: "TransferOperation",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ProductId",
                table: "Transfers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SenderId",
                table: "Transfers",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "RecipientTransfers");

            migrationBuilder.DropTable(
                name: "StockChangeHistories");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "TransferHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "InvoiceCategories");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "TransferOperation");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
