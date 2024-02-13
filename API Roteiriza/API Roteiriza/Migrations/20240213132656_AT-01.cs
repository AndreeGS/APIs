using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Roteiriza.Migrations
{
    /// <inheritdoc />
    public partial class AT01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    CheckListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    CheckListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.CheckListId);
                });

            migrationBuilder.CreateTable(
                name: "Cost",
                columns: table => new
                {
                    CostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    CostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cost", x => x.CostId);
                });

            migrationBuilder.CreateTable(
                name: "CardTravel",
                columns: table => new
                {
                    TravelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TravelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelDescriptiion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelInitialDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelFinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelCostcostId = table.Column<int>(type: "int", nullable: true),
                    CheckListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTravel", x => x.TravelId);
                    table.ForeignKey(
                        name: "FK_CardTravel_CheckLists_checkListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "checkListId");
                    table.ForeignKey(
                        name: "FK_CardTravel_Cost_travelCostcostId",
                        column: x => x.TravelCostcostId,
                        principalTable: "Cost",
                        principalColumn: "costId");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardTraveltravelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Usuarios_CardTravel_cardTraveltravelId",
                        column: x => x.CardTraveltravelId,
                        principalTable: "CardTravel",
                        principalColumn: "travelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardTravel_checkListId",
                table: "CardTravel",
                column: "checkListId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTravel_travelCostcostId",
                table: "CardTravel",
                column: "travelCostcostId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_cardTraveltravelId",
                table: "Usuarios",
                column: "cardTraveltravelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CardTravel");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "Cost");
        }
    }
}
