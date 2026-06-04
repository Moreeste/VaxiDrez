using AutoMapper;
using Education.Application.Dto;
using Education.Domain;

namespace Education.Application.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Curso, CursoDto>();
        }
    }
}
