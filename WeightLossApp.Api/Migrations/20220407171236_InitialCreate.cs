using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeightLossApp.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeEaten = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Servings = table.Column<double>(type: "float", nullable: false),
                    CaloriesPerServing = table.Column<int>(type: "int", nullable: false),
                    CarbsPerServing = table.Column<int>(type: "int", nullable: false),
                    ProteinPerServing = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Brand", "CaloriesPerServing", "CarbsPerServing", "CreatedAt", "DateTimeEaten", "Name", "ProteinPerServing", "Servings" },
                values: new object[] { 1, "Kellogs", 140, 34, new DateTime(2022, 4, 7, 13, 12, 36, 797, DateTimeKind.Local).AddTicks(7511), new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frosted Flakes", 2, 2.0 });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Brand", "CaloriesPerServing", "CarbsPerServing", "CreatedAt", "DateTimeEaten", "Name", "ProteinPerServing", "Servings" },
                values: new object[] { 2, "Monster Energy", 10, 3, new DateTime(2022, 4, 7, 13, 12, 36, 797, DateTimeKind.Local).AddTicks(7561), new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultra Paradise", 0, 1.0 });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Brand", "CaloriesPerServing", "CarbsPerServing", "CreatedAt", "DateTimeEaten", "Name", "ProteinPerServing", "Servings" },
                values: new object[] { 3, "JJ's Bakery", 390, 59, new DateTime(2022, 4, 7, 13, 12, 36, 797, DateTimeKind.Local).AddTicks(7569), new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightly Glazed Apple Pie", 3, 1.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
