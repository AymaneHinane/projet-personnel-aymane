using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommande_Commandes_CommandeId",
                table: "ProductCommande");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommande_Products_ProductId",
                table: "ProductCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCommande",
                table: "ProductCommande");

            migrationBuilder.RenameTable(
                name: "ProductCommande",
                newName: "ProductCommandes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCommande_CommandeId",
                table: "ProductCommandes",
                newName: "IX_ProductCommandes_CommandeId");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDepot",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Entreprise",
                table: "Magasins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValue: "not defined");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCommandes",
                table: "ProductCommandes",
                columns: new[] { "ProductId", "CommandeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommandes_Commandes_CommandeId",
                table: "ProductCommandes",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommandes_Products_ProductId",
                table: "ProductCommandes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommandes_Commandes_CommandeId",
                table: "ProductCommandes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCommandes_Products_ProductId",
                table: "ProductCommandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCommandes",
                table: "ProductCommandes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductCommandes",
                newName: "ProductCommande");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCommandes_CommandeId",
                table: "ProductCommande",
                newName: "IX_ProductCommande_CommandeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDepot",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Entreprise",
                table: "Magasins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "not defined",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCommande",
                table: "ProductCommande",
                columns: new[] { "ProductId", "CommandeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommande_Commandes_CommandeId",
                table: "ProductCommande",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCommande_Products_ProductId",
                table: "ProductCommande",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
