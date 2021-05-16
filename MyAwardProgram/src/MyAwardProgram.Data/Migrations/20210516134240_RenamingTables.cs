using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAwardProgram.Data.Migrations
{
    public partial class RenamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Orders_OrderId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Products_ProductId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_TB_User_UserId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TB_User_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TB_UserAddress_AddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Partners_PartnerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partners",
                table: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movements",
                table: "Movements");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "TB_PartnerProduct");

            migrationBuilder.RenameTable(
                name: "Partners",
                newName: "TB_Partner");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "TB_Order");

            migrationBuilder.RenameTable(
                name: "Movements",
                newName: "TB_Movement");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PartnerId",
                table: "TB_PartnerProduct",
                newName: "IX_TB_PartnerProduct_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "TB_Order",
                newName: "IX_TB_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AddressId",
                table: "TB_Order",
                newName: "IX_TB_Order_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_UserId",
                table: "TB_Movement",
                newName: "IX_TB_Movement_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_ProductId",
                table: "TB_Movement",
                newName: "IX_TB_Movement_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_OrderId",
                table: "TB_Movement",
                newName: "IX_TB_Movement_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PartnerProduct",
                table: "TB_PartnerProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Partner",
                table: "TB_Partner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Order",
                table: "TB_Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_Movement",
                table: "TB_Movement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_TB_Order_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "TB_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_TB_PartnerProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "TB_PartnerProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Movement_TB_Order_OrderId",
                table: "TB_Movement",
                column: "OrderId",
                principalTable: "TB_Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Movement_TB_PartnerProduct_ProductId",
                table: "TB_Movement",
                column: "ProductId",
                principalTable: "TB_PartnerProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Order_TB_User_UserId",
                table: "TB_Order",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Order_TB_UserAddress_AddressId",
                table: "TB_Order",
                column: "AddressId",
                principalTable: "TB_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PartnerProduct_TB_Partner_PartnerId",
                table: "TB_PartnerProduct",
                column: "PartnerId",
                principalTable: "TB_Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_TB_Order_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_TB_PartnerProduct_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Movement_TB_Order_OrderId",
                table: "TB_Movement");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Movement_TB_PartnerProduct_ProductId",
                table: "TB_Movement");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Movement_TB_User_UserId",
                table: "TB_Movement");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Order_TB_User_UserId",
                table: "TB_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_Order_TB_UserAddress_AddressId",
                table: "TB_Order");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PartnerProduct_TB_Partner_PartnerId",
                table: "TB_PartnerProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PartnerProduct",
                table: "TB_PartnerProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Partner",
                table: "TB_Partner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Order",
                table: "TB_Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_Movement",
                table: "TB_Movement");

            migrationBuilder.RenameTable(
                name: "TB_PartnerProduct",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "TB_Partner",
                newName: "Partners");

            migrationBuilder.RenameTable(
                name: "TB_Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "TB_Movement",
                newName: "Movements");

            migrationBuilder.RenameIndex(
                name: "IX_TB_PartnerProduct_PartnerId",
                table: "Products",
                newName: "IX_Products_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Order_AddressId",
                table: "Orders",
                newName: "IX_Orders_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Movement_UserId",
                table: "Movements",
                newName: "IX_Movements_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Movement_ProductId",
                table: "Movements",
                newName: "IX_Movements_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Movement_OrderId",
                table: "Movements",
                newName: "IX_Movements_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partners",
                table: "Partners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movements",
                table: "Movements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Orders_OrderId",
                table: "Movements",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Products_ProductId",
                table: "Movements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_TB_User_UserId",
                table: "Movements",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TB_User_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "TB_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TB_UserAddress_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "TB_UserAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Partners_PartnerId",
                table: "Products",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
