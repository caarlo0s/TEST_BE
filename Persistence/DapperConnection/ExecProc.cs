using System.Data;
using Dapper;

namespace BE_TALENTO.Persistence.DapperConnection
{
    public static class ExecProc<T>
    {
        public async static Task<Response<IEnumerable<T>>> EjecutaConTran(IFactoryConnection factoryConection, string sNomSp, object parametros = null)
        {
            IEnumerable<T> vObjList = null;


            var storedProcedure = sNomSp;
            int nStatus;
           
            
            var connection = factoryConection.GetConnection();
            using(var dbTran = connection.BeginTransaction(System.Data.IsolationLevel.Snapshot))            
            {
                try {            
                                       
                    vObjList = await connection.QueryAsync<T>(storedProcedure, parametros, commandType: CommandType.StoredProcedure, transaction: dbTran);
                    
                    dbTran.Commit();                                      
                    
                }
                catch(Exception e) {
                    dbTran.Rollback();
                    nStatus = 500;
                    return await Task.FromResult(Response.Fail(5000, nStatus, e.Message, vObjList));
                }
                finally {
                    factoryConection.CloseConnection();
                }
            }
            
            if (vObjList.Count()==0)
            {
                nStatus = 204;
            }
            else{
                nStatus = 200;
            }           

            return await Task.FromResult( Response.Ok(0, nStatus, sNomSp,vObjList)); 
        }

        public async static Task<Response<IEnumerable<T>>> EjecutaSinTran(IFactoryConnection factoryConection, string sNomSp, object parametros = null/*, int nNumPagina = -1, int npCtdElementosPorPagina = -1, string spOrdenadoPor = null, bool bpOrdenDesc = false*/)
        {
            IEnumerable<T> vObjList = null;
            var storedProcedure = sNomSp;
            int nStatus;
              
            var connection = factoryConection.GetConnection();

            try {                                
                vObjList = await connection.QueryAsync<T>(storedProcedure, parametros, commandType: CommandType.StoredProcedure);             
            }
            catch(Exception e) {                
                nStatus = 500;
                return await Task.FromResult(Response.Fail(5000, nStatus, e.Message, vObjList));
            }
            finally {
                factoryConection.CloseConnection();
            }
       
            if (vObjList.Count()==0)
            {
                nStatus = 204;
            }
            else{
                nStatus = 200;
            }         
            return await Task.FromResult( Response.Ok(0, nStatus, sNomSp, vObjList)); 
        }
    }
}