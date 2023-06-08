using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;

namespace BE_TALENTO.Persistence.Repositories
{
    public interface CheckOutInterface
    {
        public Task<Response<IEnumerable<CheckOutResponse>>> AddCheckOut(CheckOutRequest CheckOutRequest);

    }
}