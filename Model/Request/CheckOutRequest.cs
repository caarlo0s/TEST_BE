namespace BE_TALENTO.Model.Requests
{
    public class CheckOutRequest
    {
        public decimal total { get; set; }
       public string ?sucursal { get; set; }
       public List<ProductsCart>? products { get;set;}
    }
    public class ProductsCart
    {

        public int id_articulo {get;set;}       
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public decimal total { get; set; }
    }

}