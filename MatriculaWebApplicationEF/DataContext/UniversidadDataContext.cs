using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.DataContext
{
    public class UniversidadDataContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-P1J30VH;DataBase=UniversidadDataBase;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudianteMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AsignaturaMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DocenteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
