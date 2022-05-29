using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostels.Data.Migrations
{
    public partial class Добавилсправочниккатегорий : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    ViewFromTheWindow = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfRooms = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "INTEGER", nullable: false),
                    HotelRoomTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сategories_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Сategories_HostelRoomTypes_HotelRoomTypeId",
                        column: x => x.HotelRoomTypeId,
                        principalTable: "HostelRoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сategories_BuildingId",
                table: "Сategories",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Сategories_HotelRoomTypeId",
                table: "Сategories",
                column: "HotelRoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сategories");
        }
    }
}
