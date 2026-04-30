namespace LibreriaVaxi
{
    public class Cliente
    {
        public string ClientNombre { get; set; }
        public int Descuento = 10;

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            Descuento = 30;
            ClientNombre = $"{nombre} {apellido}";
            return ClientNombre;
        }
    }
}
