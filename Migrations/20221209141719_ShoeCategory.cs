using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dan_Daniela_Proiect_Web.Migrations
{
    public partial class ShoeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeCategory_Shoe_ShoeID",
                        column: x => x.ShoeID,
                        principalTable: "Shoe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeCategory_CategoryID",
                table: "ShoeCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeCategory_ShoeID",
                table: "ShoeCategory",
                column: "ShoeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
