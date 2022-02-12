using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class pruebaTec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteos",
                columns: table => new
                {
                    idConteo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sentido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hora = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteos", x => x.idConteo);
                });

            migrationBuilder.CreateTable(
                name: "Recaudos",
                columns: table => new
                {
                    idRecaudo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sentido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hora = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorTabulado = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recaudos", x => x.idRecaudo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conteos");

            migrationBuilder.DropTable(
                name: "Recaudos");
        }
    }
}
