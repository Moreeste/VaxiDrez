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

        [Test]
        [TestCase(2.2, 1.2)] // 3.4
        [TestCase(2.23, 1.24)] // 3.47
        public void SumarDecimales_InputDosNumeros_GetValorCorrecto(double numero1, double numero2)
        {
            // Arrange
            var op = new Operacion();

            // Act
            double resultado = op.SumarDecimales(numero1, numero2);

            // Assert
            Assert.That(resultado, Is.EqualTo(3.4).Within(0.1));
        }

        [Test]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalo_ReturnsListaImpares()
        {
            //Arrange
            var op = new Operacion();
            var numerosImparesEsperados = new List<int> { 5, 7, 9 };

            // Act
            var resultado = op.GetListaNumerosImpares(5, 10);

            // Assert
            Assert.That(resultado, Is.EquivalentTo(numerosImparesEsperados));
        }
    }
}
