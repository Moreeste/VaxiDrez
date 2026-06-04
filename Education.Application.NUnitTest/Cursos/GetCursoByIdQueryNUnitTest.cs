using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQueryNUnitTest
    {
        private GetCursoByIdQueryHandler _handler;
        private Guid _cursoId;

        [SetUp]
        public void Setup()
        {
            _cursoId = new Guid("8810f36a-9f27-4354-b871-f187a8d1ad81");
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();
            cursoRecords.Add(fixture.Build<Curso>().With(x => x.CursoId, _cursoId).Create());

            var options = new DbContextOptionsBuilder<EducationDbContext>().UseInMemoryDatabase(databaseName: $"EducationDb-{Guid.NewGuid()}").Options;
            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();

            _handler = new GetCursoByIdQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
        {
            var request = new GetCursoByIdQueryRequest 
            { 
                Id = _cursoId
            };
            var resultado = await _handler.Handle(request, CancellationToken.None);

            Assert.That(resultado, Is.Not.Null);
        }
    }
}
