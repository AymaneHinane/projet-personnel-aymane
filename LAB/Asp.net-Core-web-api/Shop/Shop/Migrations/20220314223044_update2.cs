using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adresse_client_ClientModelID",
                table: "adresse");

            migrationBuilder.DropForeignKey(
                name: "FK_commande_client_ClientId",
                table: "commande");

            migrationBuilder.DropIndex(
                name: "IX_adresse_ClientModelID",
                table: "adresse");

            migrationBuilder.DropColumn(
                name: "ClientModelID",
                table: "adresse");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "commande",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AddressModelId",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Secondary_phone",
                table: "adresse",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_client_AddressModelId",
                table: "client",
                column: "AddressModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_client_adresse_AddressModelId",
                table: "client",
                column: "AddressModelId",
                principalTable: "adresse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_commande_client_ClientId",
                table: "commande",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_adresse_AddressModelId",
                table: "client");

            migrationBuilder.DropForeignKey(
                name: "FK_commande_client_ClientId",
                table: "commande");

            migrationBuilder.DropIndex(
                name: "IX_client_AddressModelId",
                table: "client");

            migrationBuilder.DropColumn(
                name: "AddressModelId",
                table: "client");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "commande",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Secondary_phone",
                table: "adresse",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientModelID",
                table: "adresse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_adresse_ClientModelID",
                table: "adresse",
                column: "ClientModelID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_adresse_client_ClientModelID",
                table: "adresse",
                column: "ClientModelID",
                principalTable: "client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_commande_client_ClientId",
                table: "commande",
                column: "ClientId",
                principalTable: "client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
