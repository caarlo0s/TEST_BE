using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BE_TALENTO.Persistence.DapperConnection
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection _connection;
        
        private readonly string _conexionString;

        public FactoryConnection(IConfiguration configuration){
            _conexionString = configuration.GetConnectionString("ConnectionSqlServer");            
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open ){
                _connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {  
            
            if(_connection == null){
                _connection = new SqlConnection(_conexionString);
                // _connection = new OracleConnection(_conexionString);
            }
            if (_connection.State != ConnectionState.Open){
                _connection.Open();
            }
            return _connection;
        }
    }

}


