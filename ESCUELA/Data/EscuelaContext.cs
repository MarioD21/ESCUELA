using ESCUELA.Models;
using Microsoft.EntityFrameworkCore;

namespace ESCUELA.Data
{
    public class EscuelaContext : DbContext
    {
        public EscuelaContext(DbContextOptions<EscuelaContext> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Estudiante_Grupo> Estudiante_Grupos { get; set; }
        public DbSet<Docente_Asigatura_Grupo> Docente_Asigatura_Grupos { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }


    }
}