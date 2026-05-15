namespace LibreriaVaxi
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
        string MessageConReturnString(string message);
        bool MessageConOutParametroReturnBoolean(string str, out string outputStr);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }

            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola" + str;
            return true;
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {

        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public string MessageConReturnString(string message)
        {
            throw new NotImplementedException();
        }
    }
}
