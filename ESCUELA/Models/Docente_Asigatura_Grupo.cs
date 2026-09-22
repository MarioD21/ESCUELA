using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESCUELA.Models
{
    public class Docente_Asigatura_Grupo
    {
        [Key]
        public int Id_docente_asignatura { get; set; }
        [ForeignKey("Docente")]
        public int Id_docente { get; set; }
        [ForeignKey("Asignatura")]
        public int Id_asignatura { get; set; }
        [ForeignKey("Grupo")]
        public int Id_grupo { get; set; }
    }
}
