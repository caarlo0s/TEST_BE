namespace BE_TALENTO.Model.Requests
{
    public class StockStoreRequest
    {

     public int id_stock_tienda {get;set;}
        public int id_articulo_r {get;set;}
        public int id_tienda_r {get;set;}
        public decimal stock {get;set;}
        public DateTime date_create {get;set;}
        
    }
}