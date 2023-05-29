using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BE_TALENTO.Security.token{
    public class JwtGenerate : JwtGenerateInterface
    {
        private readonly IConfiguration _config;
    
        public JwtGenerate(IConfiguration config){
                _config = config;
        }

        public string CreateToken(int prmNumUserId, string prmVarUserEmail, string prmVarFullName)
        {
            var claims = new List<Claim>
            {
                new Claim("IdLogin", prmNumUserId.ToString()),
                new Claim("ClaLogin", prmVarUserEmail),
                new Claim("NomLogin", prmVarFullName)

            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("JwtConfig").GetValue<string>("Secret")));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            //Se agrega para que el vencimiento del toquen se ha a las 12:00:00 PM del siguiente dia 
            // var dateAndTime = DateTime.Now;
            var dateAndTime = DateTime.UtcNow;
            var date = dateAndTime.Date;

            var tokenDescription = new SecurityTokenDescriptor{
                Subject             = new ClaimsIdentity(claims),
                Expires             = date.AddDays(1),
                SigningCredentials  = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            
            return tokenHandler.WriteToken(token);
        }
    }
}


