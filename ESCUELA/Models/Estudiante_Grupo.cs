using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESCUELA.Models
{
    public class Estudiante_Grupo
    {
        [Key]
        public int Id_estudiante_grupo { get; set; }
        [ForeignKey("Estudiante")]
        public int Id_estudiante { get; set; }
        [ForeignKey("Grupo")]
        public int Id_grupo { get; set; }
    }
}
