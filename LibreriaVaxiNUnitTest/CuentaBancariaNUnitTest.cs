namespace LibreriaVaxi
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria _cuentaBancaria;

        [SetUp]
        public void Setup()
        {
            _cuentaBancaria = new CuentaBancaria(new LoggerFake());
        }

        [Test]
        public void Deposito_Input100_ReturnsTrue()
        {
            var result = _cuentaBancaria.Deposito(100);

            Assert.That(result, Is.True);
            Assert.That(_cuentaBancaria.GetBalance(), Is.EqualTo(100));
        }
    }
}
