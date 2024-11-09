using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROG3050_Team_Project.Migrations
{
    /// <inheritdoc />
    public partial class checkoutOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Orders_OrderId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_OrderId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "GameOrder",
                columns: table => new
                {
                    GamesGameID = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameOrder", x => new { x.GamesGameID, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_GameOrder_Games_GamesGameID",
                        column: x => x.GamesGameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameOrder_OrdersOrderId",
                table: "GameOrder",
                column: "OrdersOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameOrder");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 3,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 4,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 5,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 6,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 7,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 8,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 9,
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 10,
                column: "OrderId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Games_OrderId",
                table: "Games",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Orders_OrderId",
                table: "Games",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
