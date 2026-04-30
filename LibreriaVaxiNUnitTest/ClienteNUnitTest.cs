namespace LibreriaVaxi
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente _cliente;

        [SetUp]
        public void Setup()
        {
            _cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            //Arrange


            //Act
            string nombreCompleto = _cliente.CrearNombreCompleto("Esteban", "Rojas");

            //Assert
            Assert.That(nombreCompleto, Is.EqualTo("Esteban Rojas"));
            Assert.That(nombreCompleto, Does.Contain("Rojas"));
            Assert.That(nombreCompleto, Does.Contain("rojas").IgnoreCase);
            Assert.That(nombreCompleto, Does.StartWith("Esteban"));
            Assert.That(nombreCompleto, Does.EndWith("Rojas"));
        }

        [Test]
        public void ClientNombre_NoValues_ReturnNull()
        {
            Assert.That(_cliente.ClientNombre, Is.Null);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            Assert.That(_cliente.Descuento, Is.InRange(0, 100));
        }
    }
}
