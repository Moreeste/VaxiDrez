namespace LibreriaVaxi
{
    public class Cliente
    {
        public string ClientNombre { get; set; }
        public int Descuento = 10;

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre esta en blanco");
            }

            Descuento = 30;
            ClientNombre = $"{nombre} {apellido}";
            return ClientNombre;
        }
    }
}
