using System.ComponentModel.DataAnnotations;

namespace ESCUELA.Models
{
    public class Estudiante
    {
        [Key]
        public int Id_estudiante { get; set; }

        public string Matricula { get; set; }= string.Empty;
        public string Nombre { get; set; }= string.Empty;

        public string ApellidoPaterno { get; set; }= string.Empty;

        public string ApellidoMaterno { get; set; }= string.Empty;

        public string Correo { get; set; }= string.Empty;

        public Boolean estatus { get; set; }





    }
}
