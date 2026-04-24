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
        }
    }
}
