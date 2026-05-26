using AutoMapper;
using Education.Application.Dto;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoQueryRequest : IRequest<List<CursoDto>>
    {

    }

    public class GetCursoQueryHandler(EducationDbContext context, IMapper mapper) : IRequestHandler<GetCursoQueryRequest, List<CursoDto>>
    {
        public async Task<List<CursoDto>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
        {
            var cursos = await context.Cursos.ToListAsync();
            var cursosDto = mapper.Map<List<Curso>, List<CursoDto>>(cursos);
            return cursosDto;
        }
    }
}
