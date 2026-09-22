using System.ComponentModel.DataAnnotations;

namespace ESCUELA.Models
{
    public class Asignatura
    {
        [Key]
        public int Id_asignatura { get; set; }
        public string ClaveAsignatura { get; set; } = string.Empty;
        public string NombreAsignatura { get; set; } = string.Empty;
        public int Creditos { get; set; }
        public int Semestre { get; set; }
        public int Unidades { get; set; }
        public string Estatus { get; set; } = string.Empty;
        
    }
}
