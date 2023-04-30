using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MaestrasAndDataMaestra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterData",
                columns: table => new
                {
                    nmdato = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nmmaestro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cddato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsdato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cddato1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cddato2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cddato3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feregistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    febaja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterData", x => x.nmdato);
                });

            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    nmmaestro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cdmaestro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsmaestro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feregistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    febaja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.nmmaestro);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterData");

            migrationBuilder.DropTable(
                name: "Masters");
        }
    }
}
