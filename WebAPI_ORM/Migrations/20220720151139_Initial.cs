using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_ORM.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Uuid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CityName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Uuid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StreetName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    FloorsNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseNumber = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CityUuid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Uuid);
                    table.ForeignKey(
                        name: "FK_House_City_CityUuid",
                        column: x => x.CityUuid,
                        principalTable: "City",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    Uuid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlatNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseUuid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Uuid);
                    table.ForeignKey(
                        name: "FK_Flat_House_HouseUuid",
                        column: x => x.HouseUuid,
                        principalTable: "House",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    Uuid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    FlatUuid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.Uuid);
                    table.ForeignKey(
                        name: "FK_Citizen_Flat_FlatUuid",
                        column: x => x.FlatUuid,
                        principalTable: "Flat",
                        principalColumn: "Uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_FlatUuid",
                table: "Citizen",
                column: "FlatUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_HouseUuid",
                table: "Flat",
                column: "HouseUuid");

            migrationBuilder.CreateIndex(
                name: "IX_House_CityUuid",
                table: "House",
                column: "CityUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
