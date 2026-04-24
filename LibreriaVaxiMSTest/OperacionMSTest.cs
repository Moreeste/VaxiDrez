using LibreriaVaxi;

namespace LibreriaVaxiMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            int numero1 = 50;
            int numero2 = 69;

            // Act
            int resultado = op.SumarNumeros(numero1, numero2);

            // Assert
            Assert.AreEqual(119, resultado);
        }

        [TestMethod]
        public void EsValor_InputImpar_ReturnFalse()
        {
            // Arrange
            var op = new Operacion();
            int numero = 5;

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.IsFalse(esPar);
        }

        [TestMethod]
        public void EsValor_InputPar_ReturnTrue()
        {
            // Arrange
            var op = new Operacion();
            int numero = 4;

            // Act
            bool esPar = op.EsValorPar(numero);

            // Assert
            Assert.IsTrue(esPar);
        }

        [TestMethod]
        public void SumarDecimales_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            var op = new Operacion();
            double numero1 = 2.2;
            double numero2 = 1.2;

            // Act
            double resultado = op.SumarDecimales(numero1, numero2);

            // Assert
            Assert.AreEqual(3.4, resultado, 0.1);
        }
    }
}
