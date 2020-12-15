using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSystem.Management.Migrations
{
    public partial class ExtendRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseProducts_Products_ProductId",
                table: "WarehouseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseProducts_Warehouses_WarehouseId",
                table: "WarehouseProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "WarehouseId",
                table: "WarehouseProducts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "WarehouseProducts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreateDate", "Name", "Origin", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"), "stn", null, "Stone", null, null },
                    { new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"), "wd", null, "Wood", null, null },
                    { new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"), "stl", null, "Steel", null, null },
                    { new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"), "gd", null, "Gold", null, null },
                    { new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"), "cl", null, "Coal", null, null }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Address", "Capacity", "CreateDate", "FunctioningCapacity", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24"), "Kyiv, Ukraine", 250f, null, 0f, "Warhouse 1", null },
                    { new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092"), "Lviv, Ukraine", 180f, null, 0f, "Warhouse 2", null },
                    { new Guid("6cc495ea-e737-4f69-b630-277c56f126fa"), "Kharkiv, Ukraine", 210f, null, 0f, "Warhouse 3", null }
                });

            migrationBuilder.InsertData(
                table: "WarehouseProducts",
                columns: new[] { "Id", "CreateDate", "ProductId", "UpdateDate", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("c76a8498-99a2-44b9-a5ac-99e4ea06d521"), null, new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("c0d88561-9ce9-4fc2-98ef-4fd1380e8a55"), null, new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("5e7a823b-d71f-476a-9537-2f4d4fb5b694"), null, new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("3028646d-66c7-4aed-bd4d-fe5166a4dcca"), null, new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("9551daac-a5f6-4df0-b0c0-5066ba94334a"), null, new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("41f7eb47-5fc5-49fb-a2fa-c1a31d4e849e"), null, new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("2b549877-704f-4ec0-9485-7a58f4dd233c"), null, new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("9bf45fee-f0e3-4e40-a732-75a9ffa5a770"), null, new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"), null, new Guid("6cc495ea-e737-4f69-b630-277c56f126fa") },
                    { new Guid("e0f3d7ac-f65c-4159-abe0-2c732b432b5a"), null, new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"), null, new Guid("6cc495ea-e737-4f69-b630-277c56f126fa") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseProducts_Products_ProductId",
                table: "WarehouseProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseProducts_Warehouses_WarehouseId",
                table: "WarehouseProducts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseProducts_Products_ProductId",
                table: "WarehouseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseProducts_Warehouses_WarehouseId",
                table: "WarehouseProducts");

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("2b549877-704f-4ec0-9485-7a58f4dd233c"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("3028646d-66c7-4aed-bd4d-fe5166a4dcca"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("41f7eb47-5fc5-49fb-a2fa-c1a31d4e849e"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("5e7a823b-d71f-476a-9537-2f4d4fb5b694"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("9551daac-a5f6-4df0-b0c0-5066ba94334a"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("9bf45fee-f0e3-4e40-a732-75a9ffa5a770"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("c0d88561-9ce9-4fc2-98ef-4fd1380e8a55"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("c76a8498-99a2-44b9-a5ac-99e4ea06d521"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("e0f3d7ac-f65c-4159-abe0-2c732b432b5a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: new Guid("6cc495ea-e737-4f69-b630-277c56f126fa"));

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WarehouseId",
                table: "WarehouseProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "WarehouseProducts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseProducts_Products_ProductId",
                table: "WarehouseProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseProducts_Warehouses_WarehouseId",
                table: "WarehouseProducts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
