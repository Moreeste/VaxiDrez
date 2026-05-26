using Education.Domain;

namespace Education.Application.Dto
{
    public class CursoDto
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Decimal Precio { get; set; }
    }
}
