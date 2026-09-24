using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCUELA.Migrations
{
    /// <inheritdoc />
    public partial class AddEstudianteAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "Estudiantes");
        }
    }
}
