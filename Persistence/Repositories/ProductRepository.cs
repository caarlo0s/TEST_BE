using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public class ProductRepository : ProductInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public ProductRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<StockStoreResponse>>> AddUpdProductStock(StockStoreRequest stockRequest)
        {
            var storedProcedure = "AddUpdProductStock";

            var dynamicParameters = new
            {
                id = stockRequest.id_stock_tienda,
                id_articulo = stockRequest.id_articulo_r,
                id_tienda = stockRequest.id_tienda_r,
                stock = stockRequest.stock,

            };

            var resultado = ExecProc<StockStoreResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<ProductResponse>>> AddUpdateProduct(ProductRequest productRequest)
        {
            var storedProcedure = "AddUpdateProduct";

            var dynamicParameters = new
            {
                id_articulo = productRequest.id_articulo,
                codigo = productRequest.codigo,
                descripcion = productRequest.descripcion,
                precio = productRequest.precio,
                imagen = productRequest.imagen
            };

            var resultado = ExecProc<ProductResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<ProductResponse>>> DeleteProduct(int id_articulo)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ProductResponse>>> GetProducts()
        {
            var storedProcedure = "GetProducts";

            var dynamicParameters = new { };

            var resultado = ExecProc<ProductResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<GetStockResponse>>> getStockXStore(string codigo, int id_articulo)
        {
            var storedProcedure = "GetStockXStore";

            var dynamicParameters = new
            {
                codigo = codigo,
                id_articulo = id_articulo
            };

            var resultado = ExecProc<GetStockResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
        public Task<Response<IEnumerable<ProductStoreResponse>>> getProdcutXStore(int id_tienda)
        {
            var storedProcedure = "GetProdcutXStrore";

            var dynamicParameters = new
            {

                id_tienda = id_tienda
            };

            var resultado = ExecProc<ProductStoreResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
    }
}
