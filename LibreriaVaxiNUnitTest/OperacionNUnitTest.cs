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
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool EsValor_InputImpar_ReturnFalse(int numero)
        {
            var op = new Operacion();

            return op.EsValorPar(numero);
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        public void EsValor_InputPar_ReturnTrue(int numero)
        {
            // Arrange
            var op = new Operacion();

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.That(esPar, Is.True);
        }
    }
}
