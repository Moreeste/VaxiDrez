namespace LibreriaVaxi
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            //Arrange
            Cliente cliente = new Cliente();

            //Act
            string nombreCompleto = cliente.CrearNombreCompleto("Esteban", "Rojas");

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
            var cliente = new Cliente();

            Assert.That(cliente.ClientNombre, Is.Null);
        }
    }
}
