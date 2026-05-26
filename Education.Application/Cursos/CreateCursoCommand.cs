using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;

namespace Education.Application.Cursos
{
    public class CreateCursoCommandRequest : IRequest
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
    }

    public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest>
    {
        public CreateCursoCommandRequestValidation()
        {
            RuleFor(x => x.Titulo);
            RuleFor(x => x.Descripcion);
        }
    }

    public class CreateCursoCommandHandler(EducationDbContext context) : IRequestHandler<CreateCursoCommandRequest>
    {
        public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
        {
            var curso = new Curso
            {
                CursoId = Guid.NewGuid(),
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                FechaCreacion = DateTime.UtcNow,
                FechaPublicacion = request.FechaPublicacion,
                Precio = request.Precio
            };

            context.Cursos.Add(curso);
            var valor = await context.SaveChangesAsync(cancellationToken);
            
            if (valor > 0)
            {
                return Unit.Value;
            }

            throw new InvalidOperationException("No se pudo crear el curso");
        }
    }
}
