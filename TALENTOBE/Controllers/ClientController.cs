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

    public class ClientController : ControllerBase
    {
        private readonly ClientInterface _clientInterface;
        private readonly JwtGenerateInterface _jwtGenerator;

        public ClientController(ClientInterface clientInterface,
                              JwtGenerateInterface jwtGenerator
                            )
        {
            _clientInterface = clientInterface;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("AddUpdateClient")]
        public async Task<Response<IEnumerable<ClientResponse>>> addClient(ClientRequest authRequest)
        {
            Response<IEnumerable<ClientResponse>> result;
            result = await _clientInterface.AddUpdateClient(authRequest);
            return result;
        }
        [HttpGet("GetClients")]
        public async Task<Response<IEnumerable<ClientResponse>>> getClients()
        {
            Response<IEnumerable<ClientResponse>> result;
            result = await _clientInterface.GetClients();
            return result;
        }
          [HttpDelete("DeleteClient")]
        public async Task<Response<IEnumerable<ClientResponse>>> getClients(int id_cliente)
        {
            Response<IEnumerable<ClientResponse>> result;
            result = await _clientInterface.DeleteClient(id_cliente);
            return result;
        }

    }

}

