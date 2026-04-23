namespace LibreriaVaxi
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            int numero1 = 50;
            int numero2 = 69;

            // Act
            int resultado = op.SumarNumeros(numero1, numero2);

            // Assert
            Assert.That(resultado, Is.EqualTo(119));
        }

        [Test]
        public void EsValor_InputImpar_ReturnFalse()
        {
            // Arrange
            var op = new Operacion();
            int numero = 5;

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.That(esPar, Is.False);
        }

        [Test]
        public void EsValor_InputPar_ReturnTrue()
        {
            // Arrange
            var op = new Operacion();
            int numero = 4;

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.That(esPar, Is.True);
        }
    }
}
