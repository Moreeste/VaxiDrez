using AutoMapper;
using Education.Application.Dto;
using Education.Domain;

namespace Education.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoDto>();
        }
    }
}
