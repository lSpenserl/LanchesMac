using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class CarrinhoCompraItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.RenameColumn(
                name: "LancheId",
                table: "CarrinhoCompraItens",
                newName: "LanchesLancheId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItens_LancheId",
                table: "CarrinhoCompraItens",
                newName: "IX_CarrinhoCompraItens_LanchesLancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LanchesLancheId",
                table: "CarrinhoCompraItens",
                column: "LanchesLancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LanchesLancheId",
                table: "CarrinhoCompraItens");

            migrationBuilder.RenameColumn(
                name: "LanchesLancheId",
                table: "CarrinhoCompraItens",
                newName: "LancheId");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoCompraItens_LanchesLancheId",
                table: "CarrinhoCompraItens",
                newName: "IX_CarrinhoCompraItens_LancheId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompraItens_Lanches_LancheId",
                table: "CarrinhoCompraItens",
                column: "LancheId",
                principalTable: "Lanches",
                principalColumn: "LancheId");
        }
    }
}
