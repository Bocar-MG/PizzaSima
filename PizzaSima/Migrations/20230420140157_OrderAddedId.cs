using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaSima.Migrations
{
    /// <inheritdoc />
    public partial class OrderAddedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: true),
                    AdresseLivraison = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_PizzaSimas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "PizzaSimas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaId",
                table: "Orders",
                column: "PizzaId");
        }
    }
}
