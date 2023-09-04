using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaSima.Migrations
{
    /// <inheritdoc />
    public partial class PizzaOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaOrders_PizzaSimas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "PizzaSimas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrders_PizzaId",
                table: "PizzaOrders",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrders");
        }
    }
}
