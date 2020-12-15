using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductSystem.Management.Migrations
{
    public partial class UpdateBatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Products_ProductId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Warehouses_WarehouseId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Batches_BatchId",
                table: "Transfers");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "BatchId",
                table: "Transfers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WarehouseId",
                table: "Batches",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Batches",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "WarehouseProducts",
                columns: new[] { "Id", "CreateDate", "ProductId", "UpdateDate", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("502f6c77-a0ce-4d3d-a995-d1b042208f93"), null, new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("ee113b4e-fd95-41f6-8e2c-ff7de0df8069"), null, new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("3231b6ec-53cb-4c30-8756-7636fde22859"), null, new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("99967649-0729-46a2-ad90-d733869b9762"), null, new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"), null, new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24") },
                    { new Guid("5536c82d-caa7-44e3-a2d9-423d676bbdb8"), null, new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("c0c63120-4357-461d-8139-df92fa81cc8b"), null, new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("b512951a-6533-4a7e-8abd-0a15189af3b1"), null, new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"), null, new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092") },
                    { new Guid("e0b8aaac-bdb6-46d1-a9bf-9ecfa82a4022"), null, new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"), null, new Guid("6cc495ea-e737-4f69-b630-277c56f126fa") },
                    { new Guid("b97b08a7-0d08-41a3-a19d-d8c5764b75e3"), null, new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"), null, new Guid("6cc495ea-e737-4f69-b630-277c56f126fa") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Products_ProductId",
                table: "Batches",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Warehouses_WarehouseId",
                table: "Batches",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Batches_BatchId",
                table: "Transfers",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Products_ProductId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Warehouses_WarehouseId",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Batches_BatchId",
                table: "Transfers");

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("3231b6ec-53cb-4c30-8756-7636fde22859"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("502f6c77-a0ce-4d3d-a995-d1b042208f93"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("5536c82d-caa7-44e3-a2d9-423d676bbdb8"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("99967649-0729-46a2-ad90-d733869b9762"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("b512951a-6533-4a7e-8abd-0a15189af3b1"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("b97b08a7-0d08-41a3-a19d-d8c5764b75e3"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("c0c63120-4357-461d-8139-df92fa81cc8b"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("e0b8aaac-bdb6-46d1-a9bf-9ecfa82a4022"));

            migrationBuilder.DeleteData(
                table: "WarehouseProducts",
                keyColumn: "Id",
                keyValue: new Guid("ee113b4e-fd95-41f6-8e2c-ff7de0df8069"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BatchId",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "WarehouseId",
                table: "Batches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Batches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

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
                name: "FK_Batches_Products_ProductId",
                table: "Batches",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Warehouses_WarehouseId",
                table: "Batches",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Batches_BatchId",
                table: "Transfers",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
