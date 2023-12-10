using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Magasins_MagasinId",
                schema: "Entreprise",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "employeeName",
                schema: "Entreprise",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MagasinId",
                schema: "Entreprise",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Entreprise",
                table: "Employees",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                schema: "Entreprise",
                table: "Employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ProductCommande",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCommande", x => new { x.ProductId, x.CommandeId });
                    table.ForeignKey(
                        name: "FK_ProductCommande_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCommande_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FirstName_LastName",
                table: "Clients",
                columns: new[] { "FirstName", "LastName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Category_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommande_CommandeId",
                table: "ProductCommande",
                column: "CommandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Magasins_MagasinId",
                schema: "Entreprise",
                table: "Employees",
                column: "MagasinId",
                principalSchema: "Entreprise",
                principalTable: "Magasins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Magasins_MagasinId",
                schema: "Entreprise",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ProductCommande");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Clients_FirstName_LastName",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "Index_Category_Name",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Entreprise",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                schema: "Entreprise",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Entreprise",
                table: "Employees",
                newName: "employeeName");

            migrationBuilder.AlterColumn<int>(
                name: "MagasinId",
                schema: "Entreprise",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Magasins_MagasinId",
                schema: "Entreprise",
                table: "Employees",
                column: "MagasinId",
                principalSchema: "Entreprise",
                principalTable: "Magasins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
