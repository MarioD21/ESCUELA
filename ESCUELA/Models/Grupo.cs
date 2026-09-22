using System.ComponentModel.DataAnnotations;

namespace ESCUELA.Models
{
    public class Grupo
    {
        [Key]
        public int Id_grupo { get; set; }
        public string NombreGrupo { get; set; } = string.Empty;
        public string Semestre { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;

    }
}
