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
    }
}
