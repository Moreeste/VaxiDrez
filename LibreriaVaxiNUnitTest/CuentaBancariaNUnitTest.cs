namespace LibreriaVaxi
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria _cuentaBancaria;

        [SetUp]
        public void Setup()
        {
            _cuentaBancaria = new CuentaBancaria(new LoggerGeneral());
        }
    }
}
