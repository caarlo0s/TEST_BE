namespace BE_TALENTO.Model.Requests
{
    public class ProductRequest
    {

        public int id_articulo {get;set;}
        public string ?codigo { get; set; }
        public string? descripcion { get; set; }
        public decimal ?precio { get; set; }
        public string? imagen { get; set; }
    }
}