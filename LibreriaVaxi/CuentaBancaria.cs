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
            _loggerGeneral.Message($"Es otro texto");
            _loggerGeneral.Message($"Tercer texto");
            _loggerGeneral.PrioridadLogger = 1;
            var prioridad = _loggerGeneral.PrioridadLogger;
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
