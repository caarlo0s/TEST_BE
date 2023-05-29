using System.Data;

namespace BE_TALENTO.Persistence.DapperConnection
{
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetConnection();
            
    }
};