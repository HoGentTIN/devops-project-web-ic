using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtSquare.Server.Migrations
{
    public partial class UpdateBoughtBy2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_UserArts_BoughtById",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BoughtById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BoughtById",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "BoughtBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtBy",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "BoughtById",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_BoughtById",
                table: "Product",
                column: "BoughtById");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UserArts_BoughtById",
                table: "Product",
                column: "BoughtById",
                principalTable: "UserArts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
