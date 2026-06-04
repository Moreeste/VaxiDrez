using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTest
    {
        private GetCursoQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();
            cursoRecords.Add(fixture.Build<Curso>().With(x => x.CursoId, Guid.Empty).Create());

            var options = new DbContextOptionsBuilder<EducationDbContext>().UseInMemoryDatabase(databaseName: $"EducationDb-{Guid.NewGuid()}").Options;
            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();

            _handler = new GetCursoQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public void GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {

        }
    }
}
