using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaSima.Migrations
{
    /// <inheritdoc />
    public partial class Beta2 : Migration
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

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "PizzaOrders");

            migrationBuilder.AddColumn<string>(
                name: "NomPizza",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPizza",
                table: "PizzaOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomPizza",
                table: "PizzaOrders");

            migrationBuilder.DropColumn(
                name: "NumeroPizza",
                table: "PizzaOrders");

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "PizzaOrders",
                type: "int",
                nullable: true);

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
