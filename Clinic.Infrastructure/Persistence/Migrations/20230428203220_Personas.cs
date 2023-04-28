using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Personas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    nmid = table.Column<int>(type: "int", nullable: false),
                    cddocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsnombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsapellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fenacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cdtipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cdgenero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feregistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    febaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cdusuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsdireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsphoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cdtelefonofijo = table.Column<string>(name: "cdtelefono_fijo", type: "nvarchar(max)", nullable: false),
                    cdtelefonomovil = table.Column<string>(name: "cdtelefono_movil", type: "nvarchar(max)", nullable: false),
                    dsemail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.nmid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
