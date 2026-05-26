using AutoMapper;
using Education.Application.Dto;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQueryRequest : IRequest<CursoDto>
    {
        public Guid Id { get; set; }
    }

    public class GetCursoByIdQueryHandler(EducationDbContext context, IMapper mapper) : IRequestHandler<GetCursoByIdQueryRequest, CursoDto>
    {
        public async Task<CursoDto> Handle(GetCursoByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var curso = await context.Cursos.FirstOrDefaultAsync(x => x.CursoId == request.Id);
            var cursoDto = mapper.Map<Curso, CursoDto>(curso);
            return cursoDto;
        }
    }
}
