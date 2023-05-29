using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public class ClientRepository : ClientInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public ClientRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<ClientResponse>>> AddUpdateClient(ClientRequest clientRequest)
        {
            var storedProcedure = "AddUpdateClient";

            var dynamicParameters = new
            {
                id = clientRequest.id_cliente,
                nombre = clientRequest.nombre,
                apellidos = clientRequest.apellidos,
                direccion = clientRequest.direccion
            };

            var resultado = ExecProc<ClientResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<ClientResponse>>> DeleteClient(int id_cliente)
        {
             var storedProcedure = "DeleteClient";

            var dynamicParameters = new
            {
                id = id_cliente,
                
            };

            var resultado = ExecProc<ClientResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        public Task<Response<IEnumerable<ClientResponse>>> GetClients()
        {
            var storedProcedure = "GetClients";

            var dynamicParameters = new
            {
                
            };

            var resultado = ExecProc<ClientResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
    }
}


