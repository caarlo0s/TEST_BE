using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public interface ClientInterface
    {
        public Task<Response<IEnumerable<ClientResponse>>> AddUpdateClient(ClientRequest clientRequest);
         public Task<Response<IEnumerable<ClientResponse>>> GetClients();
         public Task<Response<IEnumerable<ClientResponse>>> DeleteClient(int id_cliente);
    }
}