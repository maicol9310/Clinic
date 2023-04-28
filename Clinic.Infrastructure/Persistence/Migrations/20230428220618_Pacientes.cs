using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Pacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    nmid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmidpersona = table.Column<int>(name: "nmid_persona", type: "int", nullable: false),
                    nmidmedicotra = table.Column<int>(name: "nmid_medicotra", type: "int", nullable: false),
                    dseps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dsarl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    feregistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    febaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cdusuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dscondicion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.nmid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
