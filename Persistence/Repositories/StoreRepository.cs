using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public class StoreRepository : StoreInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public StoreRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<StoreResponse>>> AddUpdateStore(StoreRequest storeRequest)
        {
                var storedProcedure = "AddUpdateStore";

            var dynamicParameters = new
            {
                id = storeRequest.id_tienda,
                sucursal = storeRequest.sucursal,
                direccion = storeRequest.direccion,

            };

            var resultado = ExecProc<StoreResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<StoreResponse>>> DeleteStore(int id_tienda)
        {
           var storedProcedure = "DeleteStore";

            var dynamicParameters = new
            {
                id = id_tienda,

            };

            var resultado = ExecProc<StoreResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<StoreResponse>>> GetStores()
        {
             var storedProcedure = "GetStores";

            var dynamicParameters = new
            {

            };

            var resultado = ExecProc<StoreResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
    }
}


