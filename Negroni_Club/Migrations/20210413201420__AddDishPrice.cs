using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Negroni_Club.Migrations
{
    public partial class _AddDishPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "97031e4a-9ce0-4ec3-9d54-b9d51d0d2576");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ae174e0-5377-48f6-acba-e5b75c1d4ba5", "AQAAAAEAACcQAAAAEKrZT7YBMXO30WkMyDEEhdf7/9nbE336gpGWtzwoepjDN/J31oi5qhAqN3zGFtHXSg==" });

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1dd9aba7-d5be-448a-a555-6ebe6137327a"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("212282f7-4302-4668-bc27-b43fb4fe792c"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("2f76c06a-a672-4ba3-a10d-96a04581f343"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4a4a8e00-4337-45fa-aa88-dca265975308"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5694));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4ea95bf7-cf8a-404d-91f0-939d61c861bd"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5688));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("5694c499-1687-48ce-a60a-1b04e44a8e53"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("60613bbe-9f22-4e84-83f3-931b461dff38"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("62a1f1ba-2da7-4c38-b15b-de06701c0de3"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5718));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("70af1f54-e61e-47a8-bc96-80dc1c26b8d8"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("766275ef-4952-46ec-b06b-63c3a7162641"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7787bc42-f3aa-4873-ad00-f36c71adb341"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7b420447-6902-4dc9-8ff9-2652c7bf20f4"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5715));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c4d8b49-cc12-4b60-a464-3edce0045d25"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7f17720a-132b-4921-8e95-db3f40ea3c2d"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b29e55c8-ecfb-4399-9737-2eab0c2bdf27"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bc751392-ae59-4914-a4aa-7f24753cb0a6"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bdde9343-5528-415e-9b41-11d333bcf5b2"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e045f9d3-fee2-42a5-8578-129603b15473"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2edbc7e-8764-484a-baf3-89a46f9519a4"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("efa7dae2-f142-43c1-a8da-ee4a1e7e04bf"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("1813e8ab-e0b9-44c0-addd-babf0cf80abd"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 810, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("36b3ced4-93eb-477b-81ce-c9ebe0e6b1fe"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("8ad6e41f-e37e-428f-a713-3d77e3ddf862"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ab6a1906-5024-4cb2-9111-82b36171d994"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("eadc6d86-d236-4dea-8b61-fdec8b2fcdc0"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ec3fdb67-de7f-41f6-9504-90d2043a5dfc"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ff9730cb-964e-46e2-b070-fa0e33c4ac89"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("013bf5e9-0b38-4ec2-90ae-b7060c8cbbce"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("39b8284c-6b8e-4ab7-ade3-bd42ae778267"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("463385f4-3b78-43ec-9849-7363397df7a3"),
                column: "DateAdded",
                value: new DateTime(2021, 4, 13, 20, 14, 19, 811, DateTimeKind.Utc).AddTicks(4007));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "9efeaf20-ff0c-45db-bb0d-ec0188fe26cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "394b11a4-c732-4c02-b835-32c3cf195b61", "AQAAAAEAACcQAAAAEHu5mMMQ1/TQBy5D8REZfdwpSgdYOcNhcBZaPen9j4xUClqgRvS4HDESbIv/7uGldw==" });

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1dd9aba7-d5be-448a-a555-6ebe6137327a"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("212282f7-4302-4668-bc27-b43fb4fe792c"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("2f76c06a-a672-4ba3-a10d-96a04581f343"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4a4a8e00-4337-45fa-aa88-dca265975308"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4ea95bf7-cf8a-404d-91f0-939d61c861bd"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("5694c499-1687-48ce-a60a-1b04e44a8e53"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("60613bbe-9f22-4e84-83f3-931b461dff38"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("62a1f1ba-2da7-4c38-b15b-de06701c0de3"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("70af1f54-e61e-47a8-bc96-80dc1c26b8d8"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("766275ef-4952-46ec-b06b-63c3a7162641"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7787bc42-f3aa-4873-ad00-f36c71adb341"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7b420447-6902-4dc9-8ff9-2652c7bf20f4"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c4d8b49-cc12-4b60-a464-3edce0045d25"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7f17720a-132b-4921-8e95-db3f40ea3c2d"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b29e55c8-ecfb-4399-9737-2eab0c2bdf27"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bc751392-ae59-4914-a4aa-7f24753cb0a6"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bdde9343-5528-415e-9b41-11d333bcf5b2"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e045f9d3-fee2-42a5-8578-129603b15473"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2edbc7e-8764-484a-baf3-89a46f9519a4"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "DishesCategories",
                keyColumn: "Id",
                keyValue: new Guid("efa7dae2-f142-43c1-a8da-ee4a1e7e04bf"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 579, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("1813e8ab-e0b9-44c0-addd-babf0cf80abd"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("36b3ced4-93eb-477b-81ce-c9ebe0e6b1fe"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("8ad6e41f-e37e-428f-a713-3d77e3ddf862"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(6464));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ab6a1906-5024-4cb2-9111-82b36171d994"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("eadc6d86-d236-4dea-8b61-fdec8b2fcdc0"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ec3fdb67-de7f-41f6-9504-90d2043a5dfc"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ff9730cb-964e-46e2-b070-fa0e33c4ac89"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("013bf5e9-0b38-4ec2-90ae-b7060c8cbbce"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("39b8284c-6b8e-4ab7-ade3-bd42ae778267"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "TitleImages",
                keyColumn: "Id",
                keyValue: new Guid("463385f4-3b78-43ec-9849-7363397df7a3"),
                column: "DateAdded",
                value: new DateTime(2021, 2, 18, 21, 59, 9, 578, DateTimeKind.Utc).AddTicks(9507));
        }
    }
}
