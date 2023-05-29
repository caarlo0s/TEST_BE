namespace BE_TALENTO.Persistence.DapperConnection
{
    public static class Response
    {
        public static Response<T> Fail<T> (int error, int status, string message, T data = default) => new Response<T>(error, "Transact-SQL", status, message, data);

        public static Response<T> Ok<T> (int error,  int status, string message, T data) => new Response<T>(error, "Transact-SQL", status, message, data);
    }
    
     public class Response<T>
    {
        public Response()
        {
        }
        public Response(int error, string type, int status, string msg, T data){            
            Error   = error;
            Type    = type;
            Status  = status;
            Message = msg;
            Data    = data;
        }

        public Response(int error){            
            Error   = error;
            Type    = "Transact-SQL";
            Status  = 200;
            Message = null;
        }

        public int Error { get; }
        public string Type{ get; }
        public int Status{get;}
        public string Message { get; }
        public T Data { get; set; }
    }

}