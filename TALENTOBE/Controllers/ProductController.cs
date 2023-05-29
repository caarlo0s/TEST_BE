using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;
using BE_TALENTO.Persistence.Repositories;
using BE_TALENTO.Security.token;

namespace BE_TALENTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ProductInterface _productInterface;
        private readonly JwtGenerateInterface _jwtGenerator;

        public ProductController(ProductInterface productInterface,
                              JwtGenerateInterface jwtGenerator
                            )
        {
            _productInterface = productInterface;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("AddUpdateProduct")]
        public async Task<Response<IEnumerable<ProductResponse>>> addProduct(ProductRequest prodRequest)
        {
            Response<IEnumerable<ProductResponse>> result;
            result = await _productInterface.AddUpdateProduct(prodRequest);
            return result;
        }
          [HttpPost("addUpdProductStock")]
        public async Task<Response<IEnumerable<StockStoreResponse>>> addUpdProductStock(StockStoreRequest stockRequest)
        {
            Response<IEnumerable<StockStoreResponse>> result;
            result = await _productInterface.AddUpdProductStock(stockRequest);
            return result;
        }
        [HttpGet("GetProducts")]
        public async Task<Response<IEnumerable<ProductResponse>>> getProducts()
        {
            Response<IEnumerable<ProductResponse>> result;
            result = await _productInterface.GetProducts();
            return result;
        }

         [HttpGet("GetStockXStore")]
        public async Task<Response<IEnumerable<GetStockResponse>>> getStockXStore(string codigo, int id_articulo)
        {
            Response<IEnumerable<GetStockResponse>> result;
            result = await _productInterface.getStockXStore(codigo,id_articulo);
            return result;
        }
          [HttpDelete("DeleteProduct")]
        public async Task<Response<IEnumerable<ProductResponse>>> deleteProduct(int id_cliente)
        {
            Response<IEnumerable<ProductResponse>> result;
            result = await _productInterface.DeleteProduct(id_cliente);
            return result;
        }

    }

}

