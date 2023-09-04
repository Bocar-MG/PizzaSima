using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaSima.Migrations
{
    /// <inheritdoc />
    public partial class PizzaConcluded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrders_PizzaSimas_PizzaId",
                table: "PizzaOrders");

            migrationBuilder.DropIndex(
                name: "IX_PizzaOrders_PizzaId",
                table: "PizzaOrders");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "PizzaOrders",
                newName: "NumeroPizza");

            migrationBuilder.AddColumn<string>(
                name: "NomPizza",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomPizza",
                table: "PizzaOrders");

            migrationBuilder.RenameColumn(
                name: "NumeroPizza",
                table: "PizzaOrders",
                newName: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_PizzaId",
                table: "PizzaOrders",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrders_PizzaSimas_PizzaId",
                table: "PizzaOrders",
                column: "PizzaId",
                principalTable: "PizzaSimas",
                principalColumn: "Id");
        }
    }
}
