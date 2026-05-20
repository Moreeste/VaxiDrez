namespace LibreriaVaxi
{
    public class ClienteXUnitTest
    {
        private Cliente _cliente;

        public ClienteXUnitTest()
        {
            _cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            //Arrange


            //Act
            string nombreCompleto = _cliente.CrearNombreCompleto("Esteban", "Rojas");

            //Assert
            Assert.Equal("Esteban Rojas", nombreCompleto);
            Assert.Contains("Rojas", nombreCompleto);
            Assert.Contains("rojas", nombreCompleto, StringComparison.OrdinalIgnoreCase);
            Assert.StartsWith("Esteban", nombreCompleto);
            Assert.EndsWith("Rojas", nombreCompleto);
        }

        [Fact]
        public void ClientNombre_NoValues_ReturnNull()
        {
            Assert.Null(_cliente.ClientNombre);
        }

        [Fact]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            Assert.InRange(_cliente.Descuento, 0, 100);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            _cliente.CrearNombreCompleto("Esteban", "");
            Assert.NotNull(_cliente.ClientNombre);
            Assert.False(string.IsNullOrEmpty(_cliente.ClientNombre));
        }

        [Fact]
        public void ClientNombre_NombreEnBlanco_ThrowsException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Rojas"));

            Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);
            Assert.Throws<ArgumentException>(() => _cliente.CrearNombreCompleto("", "Rojas"));
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            _cliente.OrderTotal = 100;
            var resultado = _cliente.GetClienteDetalle();
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
        {
            _cliente.OrderTotal = 700;
            var resultado = _cliente.GetClienteDetalle();
            Assert.IsType<ClientePremium>(resultado);
        }
    }
}
