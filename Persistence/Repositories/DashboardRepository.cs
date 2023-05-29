using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public class DashboardRepository : DashboardInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public DashboardRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<DashboardResponse>>> GetInformation()
        {
          var storedProcedure = "GetInfromation";

			var dynamicParameters = new
			{
			  
			};
    
            var resultado = ExecProc<DashboardResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }

        
    }
}


