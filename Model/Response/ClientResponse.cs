namespace BE_TALENTO.Model.Responses
{
    public class ClientResponse
    {
        public int id_cliente{get;set;}
        public string ?nombre { get; set; }
        public string ?apellidos { get; set; }
        public string ?direccion { get; set; }
    }
}