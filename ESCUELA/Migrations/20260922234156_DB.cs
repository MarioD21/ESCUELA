using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCUELA.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAsignatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id_asignatura);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id_Calificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Estudiante = table.Column<int>(type: "int", nullable: false),
                    Id_docente_asignatura = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oportunidad = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id_Calificacion);
                });

            migrationBuilder.CreateTable(
                name: "Docente_Asigatura_Grupos",
                columns: table => new
                {
                    Id_docente_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_docente = table.Column<int>(type: "int", nullable: false),
                    Id_asignatura = table.Column<int>(type: "int", nullable: false),
                    Id_grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente_Asigatura_Grupos", x => x.Id_docente_asignatura);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante_Grupos",
                columns: table => new
                {
                    Id_estudiante_grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_estudiante = table.Column<int>(type: "int", nullable: false),
                    Id_grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante_Grupos", x => x.Id_estudiante_grupo);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id_grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGrupo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id_grupo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Docente_Asigatura_Grupos");

            migrationBuilder.DropTable(
                name: "Estudiante_Grupos");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
