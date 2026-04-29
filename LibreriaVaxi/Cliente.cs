namespace LibreriaVaxi
{
    public class Cliente
    {
        public string ClientNombre { get; set; }

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            ClientNombre = $"{nombre} {apellido}";
            return ClientNombre;
        }
    }
}
