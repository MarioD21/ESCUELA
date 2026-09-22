using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESCUELA.Models
{
    public class Calificaciones
    {
        [Key]
        public int Id_Calificacion { get; set; }
        [ForeignKey("Estudiante")]
        public int Id_Estudiante{ get; set; }
        [ForeignKey("Docente_Asigatura_Grupo")]
        public int Id_docente_asignatura { get; set; }
        public int Unidad { get; set; }
        public decimal Calificacion { get; set; }
        public int Oportunidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
