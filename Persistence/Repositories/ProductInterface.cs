using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public interface ProductInterface
    {
        public Task<Response<IEnumerable<ProductResponse>>> AddUpdateProduct(ProductRequest ProductRequest);
         public Task<Response<IEnumerable<ProductResponse>>> GetProducts();
         public Task<Response<IEnumerable<ProductResponse>>> DeleteProduct(int id_articulo);
         public Task<Response<IEnumerable<StockStoreResponse>>> AddUpdProductStock(StockStoreRequest stockRequest);
         public Task<Response<IEnumerable<GetStockResponse>>> getStockXStore(string codigo, int id_articulo);
 public Task<Response<IEnumerable<ProductStoreResponse>>> getProdcutXStore(int id_tienda);
         
    }
}