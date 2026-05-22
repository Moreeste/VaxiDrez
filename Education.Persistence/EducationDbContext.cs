using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().Property(x => x.Precio).HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de C#",
                    Descripcion = "Aprende los fundamentos de C# y desarrollo de aplicaciones.",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddDays(30),
                    Precio = 56
                }
             );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de Java",
                    Descripcion = "Aprende los fundamentos de java y desarrollo de aplicaciones.",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddDays(30),
                    Precio = 57
                }
             );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de Python",
                    Descripcion = "Aprende los fundamentos de Python y desarrollo de aplicaciones.",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddDays(30),
                    Precio = 58
                }
             );
        }
    }
}
