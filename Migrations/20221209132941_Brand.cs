using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dan_Daniela_Proiect_Web.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Shoe");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Shoe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_BrandID",
                table: "Shoe",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_Brand_BrandID",
                table: "Shoe",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_Brand_BrandID",
                table: "Shoe");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Shoe_BrandID",
                table: "Shoe");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Shoe");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Shoe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
