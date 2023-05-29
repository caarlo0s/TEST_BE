using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public interface AuthInterface
    {
        public Task<Response<IEnumerable<AuthResponse>>> Login(AuthRequest authRequest);
    }
}