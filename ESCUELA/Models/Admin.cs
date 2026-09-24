using System.ComponentModel.DataAnnotations;

namespace ESCUELA.Models
{
    public class Admin
    {
        [Key]
        public int Id_admin { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public Boolean Estatus { get; set; }
    }
}
