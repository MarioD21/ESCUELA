using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESCUELA.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id_admin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id_admin);
                });

            // Cuenta de administrador por defecto: usuario "admin", contraseña "admin123".
            // Cámbiala en cuanto inicies sesión por primera vez.
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Correo", "Usuario", "Contrasena", "Estatus" },
                values: new object[] { "Administrador", "General", "", "admin@escuela.local", "admin", "admin123", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
