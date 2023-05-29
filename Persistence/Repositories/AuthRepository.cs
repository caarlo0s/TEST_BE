using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public class AuthRepository : AuthInterface
    {
        private readonly IFactoryConnection _factoryConection;

        public AuthRepository(IFactoryConnection factoryConection)
        {
            _factoryConection = factoryConection;
        }

        public Task<Response<IEnumerable<AuthResponse>>> Login(AuthRequest authRequest)
        {
            var storedProcedure = "GetLogin";

			var dynamicParameters = new
			{
			    email		= authRequest.email,
                password	= authRequest.password,
			};
    
            var resultado = ExecProc<AuthResponse>.EjecutaSinTran(_factoryConection, storedProcedure, dynamicParameters);
            return resultado;
        }
    }
}


