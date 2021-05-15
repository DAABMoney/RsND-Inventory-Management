using Microsoft.EntityFrameworkCore.Migrations;

namespace RsND_Inventory_Management.Data.Migrations
{
    public partial class RemoveProductIDfromSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Products_ProductID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ProductID",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Oerders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Suppliers");

            migrationBuilder.RenameIndex(
                name: "IX_Oerders_CustomerID",
                table: "Orders",
                newName: "IX_Orders_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Oerders");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID",
                table: "Oerders",
                newName: "IX_Oerders_CustomerID");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Oerders",
                table: "Oerders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductID",
                table: "Suppliers",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oerders_Customers_CustomerID",
                table: "Oerders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Products_ProductID",
                table: "Suppliers",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
