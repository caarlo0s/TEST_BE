namespace BE_TALENTO.Model.Responses
{
    public class ProductResponse
    {
      
        public int id_articulo {get;set;}
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string imagen { get; set; }
    }
}