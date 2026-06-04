using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class CreateCursoCommandNUnitTest
    {
        private CreateCursoCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EducationDbContext>().UseInMemoryDatabase(databaseName: $"EducationDb-{Guid.NewGuid()}").Options;
            var educationDbContextFake = new EducationDbContext(options);

            _handler = new CreateCursoCommandHandler(educationDbContextFake);
        }

        [Test]
        public async Task CreateCursoCommandHandler_InputCurso_ReturnsNumber()
        {
            var request = new CreateCursoCommandRequest
            {
                Titulo = "Curso de Prueba",
                Descripcion = "Descripción del curso de prueba",
                FechaPublicacion = DateTime.UtcNow,
                Precio = 99.99m
            };

            var resultado = await _handler.Handle(request, CancellationToken.None);

            Assert.That(resultado, Is.EqualTo(Unit.Value));
        }
    }
}
