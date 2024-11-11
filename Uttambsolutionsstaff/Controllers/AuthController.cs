using Microsoft.AspNetCore.Mvc;
using Uttambsolutionsstaffdbl;
using Uttambsolutionsstaffdbl.Entities;

namespace Uttambsolutionsstaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        [Route("Authenticate"), HttpPost]
        public async Task<ActionResult> AuthenticateAsync([FromBody] Uttambsolurionsstaffauth userdata)
        {
            var data = await bl.Validateuttambsolutionsstaffdata(userdata.Username, userdata.Password);
            return Ok();
        }
    }
}
