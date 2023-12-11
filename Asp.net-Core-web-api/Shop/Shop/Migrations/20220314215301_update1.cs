using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduct_commande_CommandesCommandeId",
                table: "CommandeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduct_product_ProductsProductId",
                table: "CommandeProduct");

            migrationBuilder.DropTable(
                name: "ProductCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandeProduct",
                table: "CommandeProduct");

            migrationBuilder.DropIndex(
                name: "IX_CommandeProduct_ProductsProductId",
                table: "CommandeProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "CommandeProduct",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "CommandesCommandeId",
                table: "CommandeProduct",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CommandeProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CommandeId",
                table: "CommandeProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandeProduct",
                table: "CommandeProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeProduct_CommandeId",
                table: "CommandeProduct",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeProduct_ProductId",
                table: "CommandeProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduct_commande_CommandeId",
                table: "CommandeProduct",
                column: "CommandeId",
                principalTable: "commande",
                principalColumn: "CommandeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduct_product_ProductId",
                table: "CommandeProduct",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduct_commande_CommandeId",
                table: "CommandeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduct_product_ProductId",
                table: "CommandeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandeProduct",
                table: "CommandeProduct");

            migrationBuilder.DropIndex(
                name: "IX_CommandeProduct_CommandeId",
                table: "CommandeProduct");

            migrationBuilder.DropIndex(
                name: "IX_CommandeProduct_ProductId",
                table: "CommandeProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommandeProduct");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "CommandeProduct");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CommandeProduct",
                newName: "ProductsProductId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CommandeProduct",
                newName: "CommandesCommandeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandeProduct",
                table: "CommandeProduct",
                columns: new[] { "CommandesCommandeId", "ProductsProductId" });

            migrationBuilder.CreateTable(
                name: "ProductCommande",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProductCommande_commande_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "commande",
                        principalColumn: "CommandeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCommande_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandeProduct_ProductsProductId",
                table: "CommandeProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommande_CommandeId",
                table: "ProductCommande",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommande_ProductId",
                table: "ProductCommande",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduct_commande_CommandesCommandeId",
                table: "CommandeProduct",
                column: "CommandesCommandeId",
                principalTable: "commande",
                principalColumn: "CommandeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduct_product_ProductsProductId",
                table: "CommandeProduct",
                column: "ProductsProductId",
                principalTable: "product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
