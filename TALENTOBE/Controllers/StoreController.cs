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

    public class StoreController : ControllerBase
    {
        private readonly StoreInterface _storeInterface;
        private readonly JwtGenerateInterface _jwtGenerator;

        public StoreController(StoreInterface storeInterface,
                              JwtGenerateInterface jwtGenerator
                            )
        {
            _storeInterface = storeInterface;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("AddUpdateStore")]
        public async Task<Response<IEnumerable<StoreResponse>>> addStore(StoreRequest storeRequest)
        {
            Response<IEnumerable<StoreResponse>> result;
            result = await _storeInterface.AddUpdateStore(storeRequest);
            return result;
        }
        [HttpGet("GetStores")]
        public async Task<Response<IEnumerable<StoreResponse>>> getClients()
        {
            Response<IEnumerable<StoreResponse>> result;
            result = await _storeInterface.GetStores();
            return result;
        }
          [HttpDelete("DeleteStore")]
        public async Task<Response<IEnumerable<StoreResponse>>> getClients(int id_tienda)
        {
            Response<IEnumerable<StoreResponse>> result;
            result = await _storeInterface.DeleteStore(id_tienda);
            return result;
        }

    }

}

