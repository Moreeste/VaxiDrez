using Moq;

namespace LibreriaVaxi
{
    public class CuentaBancariaXUnitTest
    {
        private CuentaBancaria _cuenta;
        
        [Fact]
        public void Deposito_Input100LoggerFake_ReturnsTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var result = cuentaBancaria.Deposito(100);

            Assert.True(result);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Fact]
        public void Deposito_Input100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<ILoggerGeneral>();
            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var result = cuentaBancaria.Deposito(100);

            Assert.True(result);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retito)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var result = cuentaBancaria.Retiro(retito);

            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retito)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MaxValue, -1, Moq.Range.Inclusive))).Returns(false);

            var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var result = cuentaBancaria.Retiro(retito);

            Assert.False(result);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";

            loggerGeneralMock.Setup(x => x.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var resultado = loggerGeneralMock.Object.MessageConReturnString("HOLA MUNDO");

            Assert.Equal(textoPrueba, resultado);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingOutput_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loggerGeneralMock.Setup(x => x.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParametroReturnBoolean("Vaxi", out parametroOut);

            Assert.True(resultado);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoReferencia_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            var cliente = new Cliente();
            var clienteNoUsado = new Cliente();

            loggerGeneralMock.Setup(x => x.MessageConObjetoReferenciaParametroReturnBoolean(ref cliente)).Returns(true);

            Assert.True(loggerGeneralMock.Object.MessageConObjetoReferenciaParametroReturnBoolean(ref cliente));
            Assert.False(loggerGeneralMock.Object.MessageConObjetoReferenciaParametroReturnBoolean(ref clienteNoUsado));
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();

            loggerGeneralMock.SetupProperty(x => x.TipoLogger, "warning");
            loggerGeneralMock.SetupProperty(x => x.PrioridadLogger, 1);
            

            Assert.Equal("warning", loggerGeneralMock.Object.TipoLogger);
            Assert.Equal(1, loggerGeneralMock.Object.PrioridadLogger);

            //callbacks
            string textoTemporal = "vaxi";
            loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
                .Returns(true).Callback<string>(parametro => textoTemporal += parametro);
            loggerGeneralMock.Object.LogDatabase("drez");

            Assert.Equal("vaxidrez", textoTemporal);
        }

        [Fact]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            var cuentaBancaria = new CuentaBancaria(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);

            Assert.Equal(100, cuentaBancaria.GetBalance());

            //Verifica cuenta veces el mock está llamando al método message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));
            loggerGeneralMock.Verify(x => x.Message("Es otro texto"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 1, Times.Once);
            loggerGeneralMock.VerifyGet(x => x.PrioridadLogger, Times.Once);
        }
    }
}
