using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext()
        {
            
        }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-AM7KUR1U;Initial Catalog=Education;User ID=sa;Password=123456;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().Property(x => x.Precio).HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = new Guid("A3D2B9E7-7C41-4D9B-8A55-2E91F6C4D702"),
                    Titulo = "Curso de C#",
                    Descripcion = "Aprende los fundamentos de C# y desarrollo de aplicaciones.",
                    FechaCreacion = new DateTime(2023, 1, 1),
                    FechaPublicacion = new DateTime(2023, 1, 1).AddDays(30),
                    Precio = 56
                }
             );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = new Guid("6F8C0F8A-4F8E-4F6A-9E4A-5D7A9C8B1F01"),
                    Titulo = "Curso de Java",
                    Descripcion = "Aprende los fundamentos de java y desarrollo de aplicaciones.",
                    FechaCreacion = new DateTime(2023, 1, 1),
                    FechaPublicacion = new DateTime(2023, 1, 1).AddDays(30),
                    Precio = 57
                }
             );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = new Guid("D9F4A1C3-5E28-4B7D-91F2-8C6E3A7B5903"),
                    Titulo = "Curso de Python",
                    Descripcion = "Aprende los fundamentos de Python y desarrollo de aplicaciones.",
                    FechaCreacion = new DateTime(2023, 1, 1),
                    FechaPublicacion = new DateTime(2023, 1, 1).AddDays(30),
                    Precio = 58
                }
             );
        }
    }
}
