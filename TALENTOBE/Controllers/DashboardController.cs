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
    public class DashboardController : ControllerBase
    {
        private readonly DashboardInterface _dashboardInterface;
        private readonly JwtGenerateInterface _jwtGenerator;

        public DashboardController(DashboardInterface dashboardInterface,
                              JwtGenerateInterface jwtGenerator
                            )
        {
            _dashboardInterface = dashboardInterface;
            _jwtGenerator = jwtGenerator;
        }
        
        [HttpGet("getInformation")]
        public async Task<Response<IEnumerable<DashboardResponse>>> Login()
        {
            Response<IEnumerable<DashboardResponse>> result;
            result = await _dashboardInterface.GetInformation();          
            return result;
        }
    }

}

