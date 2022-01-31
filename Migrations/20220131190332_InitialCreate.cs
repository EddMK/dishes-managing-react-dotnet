using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dishesmanaging.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    IdProvider = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.IdProvider);
                });

            migrationBuilder.CreateTable(
                name: "Dishs",
                columns: table => new
                {
                    IdDish = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishs", x => x.IdDish);
                    table.ForeignKey(
                        name: "FK_Dishs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dishs_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "IdProvider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 1, "Sandwichs" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 2, "Pates" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 3, "Sushis" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 4, "Desserts" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 5, "Pizzas" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "Name" },
                values: new object[] { 6, "Plats chauds" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 1, "Tadal" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 2, "Miamland" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 3, "Vajra" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 4, "Serboc" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 5, "Delfood" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "IdProvider", "Name" },
                values: new object[] { 6, "Foodex" });

            migrationBuilder.InsertData(
                table: "Dishs",
                columns: new[] { "IdDish", "CategoryId", "Label", "Price", "ProviderId" },
                values: new object[] { 1, 1, "Sandwich Américain", 3.5, 1 });

            migrationBuilder.InsertData(
                table: "Dishs",
                columns: new[] { "IdDish", "CategoryId", "Label", "Price", "ProviderId" },
                values: new object[] { 2, 5, "Pizza Forèstiere", 5.0, 2 });

            migrationBuilder.InsertData(
                table: "Dishs",
                columns: new[] { "IdDish", "CategoryId", "Label", "Price", "ProviderId" },
                values: new object[] { 3, 4, "Tiramisu", 3.0, 5 });

            migrationBuilder.InsertData(
                table: "Dishs",
                columns: new[] { "IdDish", "CategoryId", "Label", "Price", "ProviderId" },
                values: new object[] { 4, 2, "Pattes Napolitaines", 4.0, 2 });

            migrationBuilder.InsertData(
                table: "Dishs",
                columns: new[] { "IdDish", "CategoryId", "Label", "Price", "ProviderId" },
                values: new object[] { 5, 1, "Sandwich Poulet Pané", 4.0, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdCategory",
                table: "Categories",
                column: "IdCategory",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishs_CategoryId",
                table: "Dishs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishs_IdDish",
                table: "Dishs",
                column: "IdDish",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishs_ProviderId",
                table: "Dishs",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_IdProvider",
                table: "Providers",
                column: "IdProvider",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
