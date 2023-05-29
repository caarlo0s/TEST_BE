using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BE_TALENTO.Model.Requests;
using BE_TALENTO.Model.Responses;
using BE_TALENTO.Persistence.DapperConnection;
using BE_TALENTO.Persistence.Repositories;
using BE_TALENTO.Security.token;

namespace BE_TALENTO.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthInterface _authInterface;
        private readonly JwtGenerateInterface _jwtGenerator;

        public AuthController(AuthInterface authInterface,
                              JwtGenerateInterface jwtGenerator
                            )
        {
            _authInterface = authInterface;
            _jwtGenerator = jwtGenerator;
        }
        
        [HttpPost("login")]
        public async Task<Response<IEnumerable<AuthResponse>>> Login(AuthRequest authRequest)
        {
            Response<IEnumerable<AuthResponse>> result;
            result = await _authInterface.Login(authRequest);
            if (result.Error == 0 && result.Data.ToList().Count!=0)
                result.Data.First().token = _jwtGenerator.CreateToken(result.Data.First().id_user, result.Data.First().email, result.Data.First().fullname);
            return result;
        }
    }

}

