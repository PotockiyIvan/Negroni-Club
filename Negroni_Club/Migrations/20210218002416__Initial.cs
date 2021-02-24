using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Negroni_Club.Migrations
{
    public partial class _Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "DishesCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IndexNumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesCategories", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    TitleImagePath = table.Column<string>(nullable: true),
                    DishesСategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_DishesCategories_DishesСategoryId",
                        column: x => x.DishesСategoryId,
                        principalTable: "DishesCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.InsertData(
                table: "DishesCategories",
                columns: new[] { "Id", "DateAdded", "IndexNumber", "Subtitle", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("efa7dae2-f142-43c1-a8da-ee4a1e7e04bf"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6975), 20, null, null, "Коктейли" },
                    { new Guid("70af1f54-e61e-47a8-bc96-80dc1c26b8d8"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6972), 19, null, null, "Вина" },
                    { new Guid("b29e55c8-ecfb-4399-9737-2eab0c2bdf27"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6969), 18, null, null, "Игристые Вина" },
                    { new Guid("766275ef-4952-46ec-b06b-63c3a7162641"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6967), 17, null, null, "Апперитивы и Биттеры" },
                    { new Guid("62a1f1ba-2da7-4c38-b15b-de06701c0de3"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6965), 16, null, null, "Водка" },
                    { new Guid("7b420447-6902-4dc9-8ff9-2652c7bf20f4"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6962), 15, null, null, "Текила" },
                    { new Guid("7787bc42-f3aa-4873-ad00-f36c71adb341"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6960), 14, null, null, "Бренди" },
                    { new Guid("bc751392-ae59-4914-a4aa-7f24753cb0a6"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6955), 12, null, null, "Ром" },
                    { new Guid("e2edbc7e-8764-484a-baf3-89a46f9519a4"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6953), 11, null, null, "Джин" },
                    { new Guid("60613bbe-9f22-4e84-83f3-931b461dff38"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6957), 13, null, null, "Коньяк" },
                    { new Guid("212282f7-4302-4668-bc27-b43fb4fe792c"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6948), 9, null, null, "Американский Виски" },
                    { new Guid("e045f9d3-fee2-42a5-8578-129603b15473"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6053), 1, null, null, "Пасты" },
                    { new Guid("5694c499-1687-48ce-a60a-1b04e44a8e53"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6950), 10, null, null, "Виски" },
                    { new Guid("bdde9343-5528-415e-9b41-11d333bcf5b2"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6932), 3, null, null, "Бургеры" },
                    { new Guid("4ea95bf7-cf8a-404d-91f0-939d61c861bd"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6935), 4, null, null, "Стейки" },
                    { new Guid("7f17720a-132b-4921-8e95-db3f40ea3c2d"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6907), 2, null, null, "Салаты" },
                    { new Guid("4a4a8e00-4337-45fa-aa88-dca265975308"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6941), 6, null, null, "Шотландский Виски" },
                    { new Guid("1dd9aba7-d5be-448a-a555-6ebe6137327a"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6943), 7, null, null, "Ирландский Виски" },
                    { new Guid("7c4d8b49-cc12-4b60-a464-3edce0045d25"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6946), 8, null, null, "Японский Виски" },
                    { new Guid("2f76c06a-a672-4ba3-a10d-96a04581f343"), new DateTime(2021, 2, 18, 0, 24, 16, 429, DateTimeKind.Utc).AddTicks(6938), 5, null, null, "Горячее" }
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishesСategoryId",
                table: "Dishes",
                column: "DishesСategoryId");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Dishes");


            migrationBuilder.DropTable(
                name: "DishesCategories");

        }
    }
}
