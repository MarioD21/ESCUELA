using System.ComponentModel.DataAnnotations;

namespace ESCUELA.Models
{
    public class RegisterViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Selecciona tu rol")]
        [Display(Name = "Soy")]
        public string Rol { get; set; } = string.Empty;

        // Solo para docentes
        [Display(Name = "Número de empleado")]
        public int? Numero_Empleado { get; set; }

        // Solo para estudiantes
        [Display(Name = "Matrícula")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido materno es obligatorio")]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        [Display(Name = "Correo")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirma la contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarContrasena { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rol == "Docente" && Numero_Empleado == null)
            {
                yield return new ValidationResult(
                    "El número de empleado es obligatorio",
                    new[] { nameof(Numero_Empleado) });
            }

            if (Rol == "Estudiante" && string.IsNullOrWhiteSpace(Matricula))
            {
                yield return new ValidationResult(
                    "La matrícula es obligatoria",
                    new[] { nameof(Matricula) });
            }

            if (Rol != "Docente" && Rol != "Estudiante")
            {
                yield return new ValidationResult(
                    "Selecciona un rol válido",
                    new[] { nameof(Rol) });
            }
        }
    }
}
