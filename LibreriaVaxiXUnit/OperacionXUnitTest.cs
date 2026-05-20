namespace LibreriaVaxi
{
    public class OperacionXUnitTest
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            int numero1 = 50;
            int numero2 = 69;

            // Act
            int resultado = op.SumarNumeros(numero1, numero2);

            // Assert
            Assert.Equal(119, resultado);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void EsValor_InputImpar_ReturnFalse(int numeroImpar, bool expectedResult)
        {
            var op = new Operacion();

            var resultado = op.EsValorPar(numeroImpar);

            Assert.Equal(expectedResult, resultado);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        public void EsValor_InputPar_ReturnTrue(int numero)
        {
            // Arrange
            var op = new Operacion();

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.True(esPar);
        }

        [Theory]
        [InlineData(2.2, 1.2)] // 3.4
        [InlineData(2.23, 1.24)] // 3.47
        public void SumarDecimales_InputDosNumeros_GetValorCorrecto(double numero1, double numero2)
        {
            // Arrange
            var op = new Operacion();

            // Act
            double resultado = op.SumarDecimales(numero1, numero2);

            // Assert
            Assert.Equal(3.4, resultado, 0);
        }

        [Fact]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalo_ReturnsListaImpares()
        {
            //Arrange
            var op = new Operacion();
            var numerosImparesEsperados = new List<int> { 5, 7, 9 };

            // Act
            var resultado = op.GetListaNumerosImpares(5, 10);

            // Assert
            Assert.Equal(numerosImparesEsperados, resultado);
            Assert.Contains(5, resultado);
            Assert.NotEmpty(resultado);
            Assert.Equal(3, resultado.Count);
            Assert.DoesNotContain(100, resultado);
            Assert.Equal(resultado.OrderBy(x => x), resultado);
        }
    }
}
