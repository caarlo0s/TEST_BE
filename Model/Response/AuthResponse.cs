namespace BE_TALENTO.Model.Responses
{
    public class AuthResponse
    {
        public int id_user { get; set; }    
        public string ?fullname { get; set; }
        public string ?email { get; set; }        
        public string ?token { get; set; } 
    }
}