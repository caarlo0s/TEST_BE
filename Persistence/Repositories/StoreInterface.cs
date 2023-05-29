using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public interface StoreInterface
    {
        public Task<Response<IEnumerable<StoreResponse>>> AddUpdateStore(StoreRequest clientRequest);
         public Task<Response<IEnumerable<StoreResponse>>> GetStores();
         public Task<Response<IEnumerable<StoreResponse>>> DeleteStore(int id_tienda);
    }
}