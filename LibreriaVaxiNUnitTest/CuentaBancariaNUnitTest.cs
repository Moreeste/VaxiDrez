using Moq;

namespace LibreriaVaxi
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria _cuenta;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Deposito_Input100LoggerFake_ReturnsTrue()
        {
            var cuentaBancaria = new CuentaBancaria(new LoggerFake());

            var result = cuentaBancaria.Deposito(100);

            Assert.That(result, Is.True);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        public void Deposito_Input100Mocking_ReturnsTrue()
        {
             var mocking = new Mock<ILoggerGeneral>();
            var cuentaBancaria = new CuentaBancaria(mocking.Object);

            var result = cuentaBancaria.Deposito(100);

            Assert.That(result, Is.True);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retito)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            loggerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);

            var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var result = cuentaBancaria.Retiro(retito);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retito)
        {
            var loggerMock = new Mock<ILoggerGeneral>();
            //loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MaxValue, -1, Moq.Range.Inclusive))).Returns(false);

            var cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(balance);

            var result = cuentaBancaria.Retiro(retito);

            Assert.That(result, Is.False);
        }
    }
}
