using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{ 
    public class CheckOutRepository : CheckOutInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public CheckOutRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<CheckOutResponse>>> AddCheckOut(CheckOutRequest CheckOutRequest)
        { 
              var storedProcedure = "AddCheckOutHeader";

            var dynamicParameters = new
            {
                id = CheckOutRequest.sucursal,
                id_articulo = CheckOutRequest.total,              

            };

            var resultado = ExecProc<CheckOutResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
    }
}