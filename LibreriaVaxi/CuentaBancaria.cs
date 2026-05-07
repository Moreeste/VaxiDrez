namespace LibreriaVaxi
{
    public class CuentaBancaria
    {
        public int Balance { get; set; }
        private readonly ILoggerGeneral _loggerGeneral;

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            Balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposito(int monto)
        {
            _loggerGeneral.Message($"Depositando la cantidad de: {monto}");
            Balance += monto;
            return true;
        }

        public bool Retiro(int monto)
        {
            if (Balance >= monto)
            {
                _loggerGeneral.LogDatabase($"Monto de retiro: {monto}");
                Balance -= monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(Balance);
            }

            return _loggerGeneral.LogBalanceDespuesRetiro(Balance-monto);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
